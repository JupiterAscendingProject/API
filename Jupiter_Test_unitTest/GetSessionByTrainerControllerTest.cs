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
    public class GetSessionByTrainerControllerTest
    {
        private readonly GetSessionByTrainerController controller;
        private readonly CoreDbContext context;
        public GetSessionByTrainerControllerTest()
        {
            DbContextOptions<CoreDbContext> options = new DbContextOptions<CoreDbContext>();
            context = new CoreDbContext(options);
            controller = new GetSessionByTrainerController(context);
        }

        [Fact]
        public async Task PostMainTable_ValidObjectAndIdPassed_ReturnCreatedResponse()
        {
            // Arrange


            var testItem = new MainTable()
            {

                SessionLocation = "string",
                Module = 5,
                SessionId = 4,
                TrainerId = 1,
                TrainingMode = "string",
                Track = 1,
                SessionDate = DateTime.Now,
            };
            // Act

            var createdResponse = await controller.PostMainTable(testItem);

            // Assert
            var result = createdResponse.Result as CreatedAtActionResult;

            Assert.NotNull(result);

            var responce = result.Value as MainTable;
            Assert.NotNull(responce);

            Assert.Equal(responce.SessionLocation, testItem.SessionLocation);


        }


        [Fact]
        public async Task PutMainTable_ValidObjectAndIdPassed_ReturnCreatedResponse()
        {
            // Arrange
            int id = 4;

            var testItem = new MainTable()
            {

                SessionLocation = "Bengaluru",
                Module = 5,
                SessionId = 4,
                TrainerId = 2,
                TrainingMode = "string",
                Track = 1,
                SessionDate = DateTime.Now,


            };
            // Act

            var createdResponse = await controller.PutMainTable(id, testItem);

            // Assert
            var result = createdResponse as OkObjectResult;
            Assert.NotNull(result);

            var responce = result.Value as MainTable;
            Assert.NotNull(responce);

            Assert.Equal(responce.SessionLocation, testItem.SessionLocation);
            Assert.Equal(responce.SessionId, testItem.SessionId);

        }

        [Fact]
        public async Task GetMainTables_WhenCalled_ReturnsOkResult()
        {

            var okResult = await controller.GetMainTables();
            // Assert
            var items = Assert.IsType<List<MainTable>>(okResult.Value);
            Assert.Equal(6, items.Count);
        }

        [Fact]
        public async Task GetMainTable_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange

            var id = 1;
            // Act
            var okResult = await controller.GetMainTable(id);
            // Assert
            Assert.IsType<MainTable>(okResult.Value);
            Assert.Equal(id, (okResult.Value as MainTable).SessionId);
        }


        [Fact]
        public async Task GettMainTableByTrainerid_ExistingTraineridPassed_ReturnsRightItem()
        {
            // Arrange

            var trainerid = 3;
            // Act
            var okResult = await controller.GettMainTableByTrainerid(trainerid);
            // Assert
            var items = Assert.IsType<List<MainTable>>(okResult);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public async Task GetMainnTableByModule_ExistingModulePassed_ReturnsRightItem()
        {
            // Arrange

            var skillid = 5;
            // Act
            var okResult = await controller.GetMainnTableByModule(skillid);
            // Assert
            var items = Assert.IsType<List<MainTable>>(okResult);
            Assert.Equal(4, items.Count);
        }

        
        [Fact]
        public async Task GetMainTTableByTrackid_ExistingModulePassed_ReturnsRightItem()
        {
            // Arrange

            var trackid = 3;
            // Act
            var okResult = await controller.GetMainTTableByTrackid(trackid);
            // Assert
            var items = Assert.IsType<List<MainTable>>(okResult);
            Assert.Equal(2, items.Count);
        }

        

          

        

        [Fact]
        public async Task DeleteMainTable_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var id = 4;
            // Act
            
            var noContentResponse =await controller.DeleteMainTable(id);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);

        }
    }
}
