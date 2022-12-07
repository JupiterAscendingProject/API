using Jupiter_api.Controllers;
using Jupiter_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jupiter_Test_unitTest
{
    public class TrainerControllerTest
    {
        private readonly TrainerController controller;
        private readonly CoreDbContext context;
        public TrainerControllerTest()
        {
            DbContextOptions<CoreDbContext> options = new DbContextOptions<CoreDbContext>();
            context = new CoreDbContext(options);
            controller = new TrainerController(context);
        }
        [Fact]
        public async Task GetAllModules_WhenCalled_ReturnsOkResult()
        {

            var okResult = await controller.GetAllTrainerDetails();
            // Assert
            var items = Assert.IsType<List<TrainerDetail>>(okResult.Value);
            Assert.Equal(13, items.Count);
        }

        [Fact]
        public async Task GetModuleByID_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange

            var id = 2810;
            // Act
            var okResult = await controller.GetTrainerDetailById(id);
            // Assert
            Assert.IsType<TrainerDetail>(okResult.Value);
            Assert.Equal(id, (okResult.Value as TrainerDetail).EmpId);
        }

      /* [Fact]
        public async Task Post_ValidObjectPassed_ReturnCreatedResponse()
        {
            // Arrange
            var testItem = new TrainerDetail()
            {

                TrainerName = "Vinod"

            };
            // Act

            var createdResponse = await controller.Post(testItem);

            // Assert
            var result = createdResponse.Result as OkObjectResult;

            Assert.NotNull(result);

            var responce = result.Value as TrainerDetail;
            Assert.NotNull(responce);

            Assert.Equal(responce.TrainerName, testItem.TrainerName);

        }*/

        [Fact]
        public async Task GetTrainersOfModule_WhenCalled_ReturnsOkResult()
        {
            int ModuleNo = 6;
            var okResult = await controller.GetTrainersOfModule(ModuleNo);
            // Assert
            var items = Assert.IsType<List<TrainerDetail>>(okResult);
            Assert.Equal(2, items.Count);
        }

        
        [Fact]
        public async Task GetTrainerNames_WhenCalled_ReturnsOkResult()
        {
            
            var okResult = await controller.GetTrainerNames();
            // Assert
            var items = Assert.IsType<List<string>>(okResult.Value);
            Assert.Equal(13, items.Count);
        }


        [Fact]
        public async Task GetTrainerModule_WhenCalled_ReturnTrue()
        {
            int Id = 2810;
            var okResult =await controller.GetTrainerModule(Id);
            var items = Assert.IsType<List<TrainerModule>>(okResult);
            Assert.Equal(2, items.Count);
        }
    }
}
