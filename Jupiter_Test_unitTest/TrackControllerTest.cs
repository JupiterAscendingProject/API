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
    public class TrackControllerTest
    {
        private readonly CoreDbContext context;
        private readonly TrackController controller;
        private readonly MemoryCache cache;
        public TrackControllerTest()
        {
            DbContextOptions<CoreDbContext> options = new DbContextOptions<CoreDbContext>();
            context = new CoreDbContext(options);
            cache = new MemoryCache(new MemoryCacheOptions());
            controller = new TrackController(context, cache);
        }
        [Fact]
        public async Task GetAllTracks_WhenCalled_ReturnsOkResult()
        {

            var okResult = await controller.GetAllTracks();
            // Assert
            var items = Assert.IsType<List<TrackDetail>>(okResult.Value).ToList();


            Assert.Equal(6, items.Count);
        }

       [Fact]
        public async Task GetModulesOfTrack_ExistingTracknoPassed_ReturnsRightItem()
        {
            var id = 1;
            // Act
            var okResult = await controller.GetModulesOfTrack(id);
            // Assert
            Assert.IsType<TrackModuleDto>(okResult);
            Assert.Equal(id, (okResult as TrackModuleDto).TrackNo);
        }

        [Fact]
        public async Task AddTrack_ValidObjectPassed_ReturnCreatedResponse()
        {
            // Arrange
            var testItem = new TrackDto()
            {

                TrackName = ".net"

            };
            // Act

            var createdResponse = await controller.AddTrack(testItem);

            // Assert
            var result = createdResponse.Result as OkObjectResult;
            Assert.NotNull(result);

            var responce = result.Value as TrackDetail;
            Assert.NotNull(responce);

            Assert.Equal(responce.TrackName, testItem.TrackName);

        }

        [Fact]
        public async Task DeleteTrack_ReturnsNoContentResult()
        {
            // Arrange
            var id = 0;
            // Act
            var noContentResponse = await controller.DeleteTrack(id);
            // Assert
            Assert.IsType<OkObjectResult>(noContentResponse);
        }
    }
}
