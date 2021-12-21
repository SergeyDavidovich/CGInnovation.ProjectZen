using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using JetBrains.Annotations;
using Volo.Abp;
using System;

namespace CGInnovation.ProjectZen.Projects
{
    public class ProjectManager : DomainService
    {
        private IProjectRepository _projectRepository;
        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> CreateAsync(
            [NotNull] string name,
            string description,
            [NotNull] Guid strategyId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingProject = await _projectRepository.FindByNameAsync(name);
            if (existingProject != null)
            {
                throw new ProjectAlreadyExistsException(name);
            }

            var result = new Project(
                GuidGenerator.Create(), 
                name, 
                description, 
                strategyId);

            return result;
        }

        public async Task ChangeAsync(
            [NotNull] Project project, 
            [NotNull] string newName, 
            string newDescription,
            [NotNull]Guid newStrategyId)
        {
            Check.NotNull(project, nameof(project));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingProject = await _projectRepository.FindByNameAsync(newName);

            if (existingProject != null && existingProject.Id != project.Id)
            {
                throw new ProjectAlreadyExistsException(newName);
            }
            project.ChangeName(newName);
            project.ChangeDescription(newDescription);
            project.StrategyId = newStrategyId;
        }
    }
}


