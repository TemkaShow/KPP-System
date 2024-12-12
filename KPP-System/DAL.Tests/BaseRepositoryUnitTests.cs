using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.IO;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTestsBaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputPassInstance_CalledAddMethodOfDBSetWithPassInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<KPPContext>()
                .Options;
            var mockContext = new Mock<KPPContext>(opt);
            var mockDbSet = new Mock<DbSet<Pass>>();
            mockContext
                .Setup(context =>
                    context.Set<Pass>(
                        ))
                    .Returns(mockDbSet.Object);
            var repository = new TestPassRepository(mockContext.Object);
            Pass expectedStreet = new Mock<Pass>().Object;

            //Act
            repository.Create(expectedStreet);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedStreet
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<KPPContext>()
                .Options;
            var mockContext = new Mock<KPPContext>(opt);
            var mockDbSet = new Mock<DbSet<Pass>>();
                mockContext
                    .Setup(context =>
                        context.Set<Pass>(
                    ))
                .Returns(mockDbSet.Object);
            Pass expectedPass = new Pass() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedPass.Id))
                .Returns(expectedPass);
            var repository = new TestPassRepository(mockContext.Object);

            //Act
            var actualPass = repository.Get(expectedPass.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedPass.Id
                    ), Times.Once());
            Assert.Equal(expectedPass, actualPass);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<KPPContext>()
                .Options;
            var mockContext = new Mock<KPPContext>(opt);
            var mockDbSet = new Mock<DbSet<Pass>>();
            mockContext
                .Setup(context =>
                    context.Set<Pass>(
                ))
            .Returns(mockDbSet.Object);
            var repository = new TestPassRepository(mockContext.Object);
            Pass expectedPass = new Pass() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedPass.Id))
                .Returns(expectedPass);

            //Act
            repository.Delete(expectedPass.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedPass.Id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedPass
                    ), Times.Once());
        }

    }
}