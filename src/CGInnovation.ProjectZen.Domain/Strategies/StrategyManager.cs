using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CGInnovation.ProjectZen.Strategies
{
    public class StrategyManager : DomainService
    {
        private readonly IStrategyRepository _strategyRepository;
        public StrategyManager(IStrategyRepository strategyRepository)
        {
            _strategyRepository = strategyRepository;
        }
        public async Task<Strategy> CreateAsync([NotNull] string name, string description)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingStrategy = await _strategyRepository.FindByNameAsync(name);
            if (existingStrategy != null)
            {
                throw new StrategyAlreadyExistsException(name);
            }
            var strategy = new Strategy(GuidGenerator.Create(), name, description);
            return strategy;
        }
        public async Task ChangeAsync(
           [NotNull] Strategy strategy,
           [NotNull] string newName,
           string newDescription)
        {
            Check.NotNull(strategy, nameof(strategy));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingStrategy = await _strategyRepository.FindByNameAsync(newName);
            if (existingStrategy != null && existingStrategy.Id != strategy.Id)
            {
                throw new StrategyAlreadyExistsException(newName);
            }
            strategy.ChangeName(newName);
            strategy.ChangeDescription(newDescription);
        }
    }
}
