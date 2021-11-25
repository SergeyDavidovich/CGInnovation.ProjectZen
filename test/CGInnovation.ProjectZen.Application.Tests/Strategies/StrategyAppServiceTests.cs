using CGInnovation.ProjectZen.Strategies;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace CGInnovation.ProjectZen.Samples
{
    public class StrategyAppServiceTests : ProjectZenApplicationTestBase
    {
        private readonly IStrategyAppService _strategyAppService;

        public StrategyAppServiceTests()
        {
            _strategyAppService = GetRequiredService<IStrategyAppService>();
        }

        [Fact]
        public async Task Initial_Data_Should_Contain_Admin_User()
        {
            //Act
            var result = await _strategyAppService.GetListAsync(new GetStrategyListDto());
            
            var strategy = new CreateStrategyDto();

            strategy.Name = "New Strategy";
            _strategyAppService.CreateAsync(strategy).Wait();


            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(u => u.Name == "Strategy 1");
        }
    }
}
