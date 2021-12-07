using CGInnovation.ProjectZen.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
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

        public ProjectAppService(IProjectRepository projectRepository,
            ProjectManager projectManager)
        {
            _projectRepository = projectRepository;
            _projectManager = projectManager;
        }
        public async Task<ProjectDto> GetAsync(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);
            return ObjectMapper.Map<Project, ProjectDto>(project);
        }
        public async Task<PagedResultDto<ProjectDto>> GetListAsync(GetProjectListDto input)
        {
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

            var totalCount = input.Filter == null
                ? await _projectRepository.CountAsync()
                : await _projectRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<ProjectDto>(
                totalCount,
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects)
            );
        }

        [Authorize(ProjectZenPermissions.Projects.Create)]
        public async Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
            var project = await _projectManager.CreateAsync(input.Name, input.Description);

            await _projectRepository.InsertAsync(project);

            return ObjectMapper.Map<Project, ProjectDto>(project);
        }

        [Authorize(ProjectZenPermissions.Projects.Edit)]
        public async Task UpdateAsync(Guid id, UpdateProjectDto input)
        {
            var project = await _projectRepository.GetAsync(id);

            if (project.Name != input.Name)
            {
                await _projectManager.ChangeAsync(project, input.Name, input.Description);
            }
            project.Description=input.Description;

            await _projectRepository.UpdateAsync(project);
        }

        [Authorize(ProjectZenPermissions.Projects.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _projectRepository.DeleteAsync(id);
        }

    }
}
