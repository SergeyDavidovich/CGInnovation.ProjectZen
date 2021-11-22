using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace CGInnovation.ProjectZen.Projects
{
    public class ProjectAppService_Tests : ProjectZenApplicationTestBase
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectAppService_Tests()
        {
            _projectAppService = GetRequiredService<IProjectAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Projects_Without_Any_Filter()
        {
            var result = await _projectAppService.GetListAsync(new GetProjectListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(author => author.Name == "George Orwell");
            result.Items.ShouldContain(author => author.Name == "Douglas Adams");
        }
    }
}
