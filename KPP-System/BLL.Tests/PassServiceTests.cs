using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System.IO;
using User = CCL.Security.Identity.User;

namespace BLL.Tests
{
    public class PassServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new PassService(nullUnitOfWork)
            );
        }

        [Fact]
        public void GetPasses_PassFromDAL_CorrectMappingToPassDTO()
        {
            // Arrange
            User user = new Employee(1, "str", "str", "str", "str", "str", DateTime.Today, 1);
            SecurityContext.SetUser(user);
            var passService = GetPassService();

            // Act
            var actualPassDto = passService.GetPasses(0).First();

            // Assert
            Assert.True(
                actualPassDto.Id == 1
                && actualPassDto.IssueDate == DateTime.Today
                && actualPassDto.ExpiretionDate == DateTime.Today
                && actualPassDto.Status == DAL.Enums.PassStatus.Active
                && actualPassDto.UserId == 1
            );
        }
        IPassService GetPassService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedPass = new Pass()
            {
                Id = 1,
                IssueDate = DateTime.Today,
                ExpiretionDate = DateTime.Today,
                Status = DAL.Enums.PassStatus.Active,
                UserId = 1
            };
            var mockDbSet = new Mock<IPassRepository>();
            mockDbSet
                .Setup(z =>
                    z.Find(
                    It.IsAny<Func<Pass, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                .Returns(
                    new List<Pass>() { expectedPass }
                );
            mockContext
                .Setup(context =>
                    context.Passes)
                    .Returns(mockDbSet.Object);

            IPassService passService = new PassService(mockContext.Object);
            return passService;
        }
    }
}