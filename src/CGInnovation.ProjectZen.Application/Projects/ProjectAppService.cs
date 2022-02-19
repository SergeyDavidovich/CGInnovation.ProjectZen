using CGInnovation.ProjectZen.Permissions;
using CGInnovation.ProjectZen.Strategies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen.Projects
{
    [Authorize(ProjectZenPermissions.Projects.Default)]
    public class ProjectAppService : ProjectZenAppService, IProjectAppService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectManager _projectManager;
        private readonly IStrategyRepository _strategyRepository;
        public ProjectAppService(
            IProjectRepository projectRepository,
            IStrategyRepository strategyRepository,
            ProjectManager projectManager)
        {
            _projectRepository = projectRepository;
            _strategyRepository = strategyRepository;
            _projectManager = projectManager;
        }
        public async Task<ProjectDto> GetAsync(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);
            var result = ObjectMapper.Map<Project, ProjectDto>(project);
            return result;
        }
        public async Task<PagedResultDto<ProjectDto>> GetListAsync(GetProjectListDto input)
        {
            // get the IQueryable from the repository
            //var strategyQueryable = await _strategyRepository.GetQueryableAsync(); // one
            //var projectQueryable = await _projectRepository.GetQueryableAsync(); // many

            //var projectsDto = from strategy in strategyQueryable
            //                    join project in projectQueryable on strategy.Id equals project.Id
            //                    select new ProjectDto()
            //                    {
            //                        Id = project.Id,
            //                        Name = project.Name,
            //                        Description = project.Description,
            //                        StrategyName = strategy.Name
            //                    };

            ////Execute the query and get a list
            //var queryResult = await AsyncExecuter.ToListAsync(projectsDto);

            // get the IEnumerable from the repository
            var strategies = await _strategyRepository.GetListAsync();

            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Project.Name);
            }
            var projects = await _projectRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var projectsDto = from strategy in strategies
                              join project in projects on strategy.Id equals project.StrategyId
                              select new ProjectDto()
                              {
                                  Id = project.Id,
                                  Name = project.Name,
                                  Description = project.Description,
                                  StrategyName = strategy.Name,
                                  StrategyId = strategy.Id
                              };

            var totalCount = input.Filter == null
                ? await _projectRepository.CountAsync()
                : await _projectRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            var result = new PagedResultDto<ProjectDto>(
                totalCount, projectsDto.ToList());
            //    ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects)
            //);
            return result;
        }
        public async Task<ListResultDto<StrategyLookupDto>> GetStrategyLookupAsync()
        {
            var strategies = await _strategyRepository.GetListAsync();

            var nameList = new ListResultDto<StrategyLookupDto>(
                ObjectMapper.Map<List<Strategy>, List<StrategyLookupDto>>(strategies));

            return nameList;
        }

        [Authorize(ProjectZenPermissions.Projects.Create)]
        public async Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
            var project = 
                await _projectManager.CreateAsync(
                    input.Name, input.Description, input.StrategyId);

            await _projectRepository.InsertAsync(project);

            return ObjectMapper.Map<Project, ProjectDto>(project);
        }

        [Authorize(ProjectZenPermissions.Projects.Edit)]
        public async Task UpdateAsync(Guid id, UpdateProjectDto input)
        {
            var project = await _projectRepository.GetAsync(id);

            if (project.Name != input.Name)
            {
                await _projectManager.ChangeAsync(project, input.Name, input.Description, input.StrategyId);
            }
            project.StrategyId=input.StrategyId;
            project.Description = input.Description;

            await _projectRepository.UpdateAsync(project);
        }

        [Authorize(ProjectZenPermissions.Projects.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _projectRepository.DeleteAsync(id);
        }

    }
}
