using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Moq;
using Xunit;
using TechTitans.Repositories;

namespace TechTitansTesting.Repositories
{
    public class RepositoryTests
    {
        private Mock<IDatabaseOperations> _mockDatabaseOperations;
        private Repository<TestEntity> _repository;

        public RepositoryTests()
        {

        }

        [Fact]
        public void Add_WhenEntityIsAdded_ShouldReturnTrue()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockDatabaseOperations.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null))
                           .Returns(1);

            var result = _repository.Add(entity);

            Assert.True(result);
        }

        [Fact]
        public void Delete_WhenEntityIsDeleted_ShouldReturnTrue()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockDatabaseOperations.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null))
                           .Returns(1);

            var result = _repository.Delete(entity);

            Assert.True(result);
        }

        [Fact]
        public void GetAll_ShouldReturnEntities_WhenEntitiesExist()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entities = new List<TestEntity> { new TestEntity { Id = 1, Name = "Test1" }, new TestEntity { Id = 2, Name = "Test2" } };
            _mockDatabaseOperations.Setup(c => c.Query<TestEntity>(It.IsAny<string>(), null, null, true, null, null))
                           .Returns(entities);

            var result = _repository.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetById_WhenEntityExists_ShouldReturnEntity()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockDatabaseOperations.Setup(c => c.Query<TestEntity>(It.IsAny<string>(), null, null, true, null, null))
                           .Returns(new List<TestEntity> { entity });

            var result = _repository.GetById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }
    }

    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
