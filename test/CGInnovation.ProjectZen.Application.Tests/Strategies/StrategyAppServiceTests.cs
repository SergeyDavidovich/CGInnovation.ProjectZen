using CGInnovation.ProjectZen.Strategies;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace CGInnovation.ProjectZen.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
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

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(u => u.Name == "Strategy 1");
        }
    }
}
