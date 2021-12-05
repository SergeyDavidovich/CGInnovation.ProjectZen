using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.Risks;
using CGInnovation.ProjectZen.Strategies;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen
{
    public class ProjectZenDataSeederContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Risk, Guid> _riskRepository;
        
        private readonly IRepository<Project,Guid> _projectRepository;
        private readonly ProjectManager _projectManager;

        private readonly IRepository<Strategy, Guid> _strategyRepository;
        private readonly StrategyManager _strategyManager;

        public ProjectZenDataSeederContributor(
            IRepository<Risk, Guid> riskRepository,
            IRepository<Project,Guid> projectRepository,
            ProjectManager projectManager,
            StrategyManager strategyManager,
            IRepository<Strategy, Guid> strategyRepository)
            
        {
            _riskRepository = riskRepository;
            
            _projectRepository = projectRepository;
            _projectManager = projectManager;

            _strategyRepository = strategyRepository;
            _strategyManager = strategyManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _riskRepository.GetCountAsync() <= 0)
            {
                await _riskRepository.InsertAsync(
                    new Risk
                    {
                        Name = "Risk of Nuclear War",
                        Mitigation = Mitigation.Full,
                        Occures = true,
                        OccuredDate = new DateTime(1949, 6, 8),
                        Impact = Impact.Level1,
                        Likelihood= Likelihood.Level1
                    },
                    autoSave: true
                );

                await _riskRepository.InsertAsync(
                    new Risk
                    {
                        Name = "Risk of pregnancy",
                        Mitigation = Mitigation.None,
                        Occures = true,
                        OccuredDate = new DateTime(1949, 6, 8),
                        Impact = Impact.Level2,
                        Likelihood = Likelihood.Level2

                    },
                    autoSave: true
                );
                await _riskRepository.InsertAsync(
                       new Risk
                       {
                           Name = "Risk of Covid 19",
                           Mitigation = Mitigation.Partial,
                           Occures = true,
                           OccuredDate = new DateTime(1949, 6, 8),
                           Impact = Impact.Level3,
                           Likelihood = Likelihood.Level3

                       },
                       autoSave: true
                   );
            }
            //todo: uncomment!!! 

            if (await _projectRepository.GetCountAsync() <= 0)
            {
                await _projectRepository.InsertAsync(
                    await _projectManager.CreateAsync("Project 1", "Description 1"));

                await _projectRepository.InsertAsync(
                    await _projectManager.CreateAsync("Project 2", "Description 2"));
            }

            if (await _strategyRepository.GetCountAsync() <= 0)
            {
                await _strategyRepository.InsertAsync(
                    await _strategyManager.CreateAsync("Strategy 1", "Description 1"));

                await _strategyRepository.InsertAsync(
                    await _strategyManager.CreateAsync("Strategy 2", "Description 2"));
            }
        }
    }
}


