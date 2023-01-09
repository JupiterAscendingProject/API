using Jupiter_api.Controllers;
using Jupiter_api.Models;
using Jupiter_api.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jupiter_Test_unitTest
{
    public class ModuleControllerTest
    {
        private readonly ModuleController controller;
        private readonly CoreDbContext context;
        private readonly MemoryCache cache;
        public ModuleControllerTest()
        {
            DbContextOptions<CoreDbContext> options = new DbContextOptions<CoreDbContext>();
            context = new CoreDbContext(options);
            cache=new MemoryCache(new MemoryCacheOptions());    
            controller = new ModuleController(context, cache);
        }
        [Fact]
        public async Task GetAllModules_WhenCalled_ReturnsOkResult()
        {
            
            var okResult =await controller.GetAllModules();
            // Assert
            var items = Assert.IsType<List<ModuleDetail>>(okResult.Value);
            Assert.Equal(27, items.Count);
        }

       [Fact]
        public async Task GetModuleByID_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            
            var id = 1;
            // Act
            var okResult = await controller.GetModuleByID(id);
            // Assert
            Assert.IsType<ModuleDetail>(okResult.Value);
            Assert.Equal(id, (okResult.Value as ModuleDetail).ModuleNo);
        }

        [Fact]
        public async Task AddModule_ValidObjectPassed_ReturnCreatedResponse()
        {
            // Arrange
            var testItem = new ModuleDto()
            {

                ModuleName = ".net"

            };
            // Act
            
            var createdResponse = await controller.AddModule(testItem);

            // Assert
            var result=createdResponse.Result as OkObjectResult;

            Assert.NotNull(result);

            var responce=result.Value as ModuleDetail;
            Assert.NotNull(responce);

            Assert.Equal(responce.ModuleName, testItem.ModuleName);
           
        }

        [Fact]
        public async Task Remove_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var id = 0;
            // Act
            var noContentResponse =await controller.DeleteModule(id);
            // Assert
            Assert.IsType<OkObjectResult>(noContentResponse);
        }
    }
}
