using Jupiter.Controllers;
using Jupiter_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jupiter_Test_unitTest
{
    public class SkillsFilterControllerTest
    {
        private readonly CoreDbContext context;
        private readonly SkillsFilterController controller;
        public SkillsFilterControllerTest()
        {
            DbContextOptions<CoreDbContext> options = new DbContextOptions<CoreDbContext>();
            context = new CoreDbContext(options);
            controller = new SkillsFilterController(context);
        }
        [Fact]
        public async Task GetAllModules_WhenCalled_ReturnsOkResult()
        {

            var okResult = await controller.GetSkills();
            // Assert
            var items = Assert.IsType<List<string>>(okResult.Value);

            
            Assert.Equal(6, items.Count);
        }
    }
}
