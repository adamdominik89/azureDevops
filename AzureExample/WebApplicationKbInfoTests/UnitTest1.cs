using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using WebApplicationKbInfo.Controllers;
using WebApplicationKbInfo.Models;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        private Mock<ILogger<HomeController>> _mockLogger;

        public UnitTest1()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
        }

        [Fact]
        public void GivenHomeController_WhenCallIndex_ThenViewNotNull()
        {
            // Arrange
            var homeController = new HomeController(_mockLogger.Object);

            // Act
            var view = homeController.Index();

            // Assert
            Assert.NotNull(view);
        }

        [Fact]
        public void GivenHomeController_WhenCallPrivacy_ThenViewNotNull()
        {
            // Arrange 
            var homeController = new HomeController(_mockLogger.Object);

            // Act
            var view = homeController.Privacy();

            // Assert
            Assert.NotNull(view);
        }

        [Fact]
        public void GivenHomeController_WhenCallError_ThenReturnsViewWithErrorViewModel()
        {
            // Arrange
            var homeController = new HomeController(_mockLogger.Object)
            {
                ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
            };

            // Act
            var view = homeController.Error() as ViewResult;

            // Assert

            Assert.IsType<ErrorViewModel>(view.Model);
        }
    }
}
