using System;
using System.Collections.Generic;
using System.Linq;
using CRMSystem.Data.Repository;
using CRMSystem.Models;
using CRMSystem.Server.Controllers;
using CRMSystem.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CRMSystem.Tests
{
    [Trait("Category", "Customer")]
    public class CustomerControllerTest
    {
        [Fact]
        public void Get_ReturnsOK_IfThereAreCustomersInDatabase()
        {
            // Arrange
            var fakeData = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.All())
                .Returns(fakeData.FakeCustomers.AsQueryable());
            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ReturnsArgumentNullException_IfThereAreNoCustomersInDatabase()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var listCustomers = new List<Customer>();
            mockRepo.Setup(repo => repo.Customers.All())
                .Returns((IQueryable<Customer>)null);
            var sut = new CustomersController(mockRepo.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.Get());
        }

        [Fact]
        public void GetById_ReturnsNotFound_ForInvalidCustomerId()
        {
            // Arrange
            int testId = 5;
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.GetById(testId))
                .Returns((Customer)null);
            var sut = new CustomersController(mockRepo.Object);

            // Act 
            var result = sut.Get(testId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Get_ReturnsOk_ForValidCustomerId()
        {
            // Arrange
            int testId = 1;
            var fakeData = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.GetById(testId))
                .Returns((fakeData.FakeCustomers.First()));
            var sut = new CustomersController(mockRepo.Object);

            // Act 
            var result = sut.Get(testId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ReturnsBadRequest_GivenRequiredModel()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var sut = new CustomersController(mockRepo.Object);
            sut.ModelState.AddModelError("error", "some error");

            // Act
            var result = sut.Post(model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_VerifyThatModelStateIsValid()
        {
            // Arrange
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Customers.Add(It.IsAny<Customer>())).Verifiable();
            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Post(fakeRepo.CustomerDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_ReturnBadRequest_GivenRequiredModel()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var sut = new CustomersController(mockRepo.Object);
            sut.ModelState.AddModelError("error", "some error");

            // Act
            var result = sut.Update(id: 0, model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Update_VerifyThatModelStateIsValid()
        {
            // Arrange
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.All())
                .Returns(fakeRepo.FakeCustomers.Where(x => x.Id == 1).AsQueryable());
            mockRepo.Setup(repo => repo.Customers.Update(It.IsAny<Customer>())).Verifiable();

            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Update(1, fakeRepo.CustomerDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_ReturnBadRequest_ForInvalidCustomerId()
        {
            // Arrange
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.All())
                .Returns(fakeRepo.FakeCustomers.Where(x => x.Id == 100).AsQueryable());
            mockRepo.Setup(repo => repo.Customers.Update(It.IsAny<Customer>())).Verifiable();

            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Update(1, fakeRepo.CustomerDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Delete_ReturnOk_ForValidCustomerId()
        {
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.All())
                .Returns(fakeRepo.FakeCustomers.Where(x => x.Id == 1).AsQueryable());
            mockRepo.Setup(repo => repo.Customers.Delete(It.IsAny<Customer>())).Verifiable();
            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Delete(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Delete_ReturnBadRequest_ForInvalidCustomerId()
        {
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.All())
                .Returns(fakeRepo.FakeCustomers.Where(x => x.Id == 100).AsQueryable());
            mockRepo.Setup(repo => repo.Customers.Delete(It.IsAny<Customer>())).Verifiable();
            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Delete(100);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
