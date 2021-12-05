using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using JetBrains.Annotations;
using Volo.Abp;

namespace CGInnovation.ProjectZen.Projects
{
    public class ProjectManager : DomainService
    {
        private IProjectRepository _projectRepository;
        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> CreateAsync([NotNull] string name, string description)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingProject = await _projectRepository.FindByNameAsync(name);
            if (existingProject != null)
            {
                throw new ProjectAlreadyExistsException(name);
            }

            return new Project(
                GuidGenerator.Create(),
                name, description);
        }

        public async Task ChangeAsync(
            [NotNull] Project project,
            [NotNull] string newName,
            string newDescription)
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
        }
    }
}


