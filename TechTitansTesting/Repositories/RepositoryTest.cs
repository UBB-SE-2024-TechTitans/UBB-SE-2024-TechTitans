using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Moq;
using Xunit;
using TechTitans.Repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Xunit.Sdk;

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
        public void Add_WhenDatabaseOperationsThrowsException_ShouldReturnFalse()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockDatabaseOperations.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null))
                           .Throws(new Exception("Test exception"));

            var result = _repository.Add(entity);

            Assert.False(result);
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
        public void Delete_WhenDatabaseOperationsThrowsException_ShouldReturnFalse()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "Test" };
            _mockDatabaseOperations.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null))
                           .Throws(new Exception("Test exception"));

            var result = _repository.Delete(entity);

            Assert.False(result);
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
        public void GetAll_ShouldReturnEmptyList_WhenEntitiesDoNotExist()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            _mockDatabaseOperations.Setup(c => c.Query<TestEntity>(It.IsAny<string>(), null, null, true, null, null))
                           .Returns(new List<TestEntity>());

            var result = _repository.GetAll();

            Assert.Empty(result);
        }

        [Fact]
        public void GetAll_WhenDatabaseOperationsThrowsException_ShouldReturnNull()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            _mockDatabaseOperations.Setup(c => c.Query<TestEntity>(It.IsAny<string>(), null, null, true, null, null))
                           .Throws(new Exception("Test exception"));

            var result = _repository.GetAll();

            Assert.Null(result); 
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

        [Fact]
        public void GetById_WhenEntityDoesNotExist_ShouldReturnNull()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            _mockDatabaseOperations.Setup(c => c.Query<TestEntity>(It.IsAny<string>(), null, null, true, null, null))
                           .Returns(new List<TestEntity>());

            var result = _repository.GetById(1);

            Assert.Null(result);
        }

        [Fact]
        public void Update_WhenEntityIsUpdated_ShouldReturnTrue()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "UpdatedTest" };

            _mockDatabaseOperations.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null))
                                   .Returns(1);

            
            var result = _repository.Update(entity);

            
            Assert.True(result);
            _mockDatabaseOperations.Verify(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null), Times.Once);
        }

        [Fact]
        public void Update_WhenDatabaseOperationsThrowsException_ShouldReturnFalse()
        {
            _mockDatabaseOperations = new Mock<IDatabaseOperations>();
            _repository = new Repository<TestEntity>(_mockDatabaseOperations.Object);
            var entity = new TestEntity { Id = 1, Name = "UpdatedTest" };
            var expectedExceptionMessage = "Test exception";

            _mockDatabaseOperations.Setup(c => c.Execute(It.IsAny<string>(), It.IsAny<TestEntity>(), null, null, null))
                                   .Throws(new Exception("Test exception"));


            bool result = _repository.Update(entity);
            

            Assert.False(result);
          }


        [Fact]
        public void GetKeyColumnName_WhenColumnAttributeIsSpecified_ShouldReturnColumnName()
        {

            string expectedColumnName = "Id"; 


            string actualColumnName = Repository<TestEntity>.GetKeyColumnName(); 

            
            Assert.Equal(expectedColumnName, actualColumnName);
        }

        [Fact]
        public void GetKeyColumnName_WhenColumnAttributeIsNotSpecified_ShouldReturnProprietyName()
        {
            string expectedColumnName = "Id";

            string actualColumnName = Repository<TestEntityWithoutColumnAttribute>.GetKeyColumnName();

            Assert.Equal(expectedColumnName, actualColumnName);
        }

        [Fact]
        public void GetKeyColumnName_WhenThereIsNoKey_ShouldReturnNull()
        {
            string actualColumnName = Repository<TestEntityWithoutKey>.GetKeyColumnName();

            Assert.Null(actualColumnName);
        }

    }

    public class TestEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }

    public class TestEntityWithoutColumnAttribute
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class TestEntityWithoutKey
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
