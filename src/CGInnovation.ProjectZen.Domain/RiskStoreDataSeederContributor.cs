using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CGInnovation.ProjectZen.Risks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen
{
    public class RiskStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Risk, Guid> _riskRepository;

        public RiskStoreDataSeederContributor(IRepository<Risk, Guid> bookRepository)
        {
            _riskRepository = bookRepository;
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
        }
    }
}


