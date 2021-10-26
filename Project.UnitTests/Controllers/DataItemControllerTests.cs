using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project.Controllers;
using Project.Models;
using Project.Repositories;
using Xunit;

namespace Project.UnitTests.Controllers
{
    public class DataItemControllerTests
    {
        private readonly Mock<IDataItemRepository> _mockDataItemRepository;
        private readonly DataItemController _controller;

        public DataItemControllerTests()
        {
            _mockDataItemRepository = new Mock<IDataItemRepository>();
            _controller = new DataItemController(_mockDataItemRepository.Object);
        }

        [Fact]
        public async Task Get_DataListHasItems_ReturnsCorrectData()
        {
            // Arrange
            var dataItems = new List<DataItem>() {
                new DataItem() { Id = 1, Value = "Fizz" },
                new DataItem() { Id = 2, Value = "Buzz" },
                new DataItem() { Id = 3, Value = "FizzBuzz" }
            };
            _mockDataItemRepository.Setup(r => r.GetAllDataItems()).ReturnsAsync(dataItems);

            // Act
            var actionResult = await _controller.Get();

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(dataItems, okObjectResult.Value);
        }

        [Fact]
        public async Task Get_DataListHasNoItems_ReturnsCorrectData()
        {
            // Arrange
            var dataItems = new List<DataItem>();
            _mockDataItemRepository.Setup(r => r.GetAllDataItems()).ReturnsAsync(dataItems);

            // Act
            var actionResult = await _controller.Get();

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(dataItems, okObjectResult.Value);
        }


        [Fact]
        public async Task Get_DataListIsNull_DoesNotFail()
        {
            // Arrange
            IEnumerable<DataItem> dataItems = null;
            _mockDataItemRepository.Setup(r => r.GetAllDataItems()).ReturnsAsync(dataItems);

            // Act
            var actionResult = await _controller.Get();

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(dataItems, okObjectResult.Value);
        }
    }
}
