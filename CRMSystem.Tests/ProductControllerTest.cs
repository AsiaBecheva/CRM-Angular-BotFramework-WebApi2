using System;
using System.Linq;
using CRMSystem.Client.Controllers;
using CRMSystem.Data.Repository;
using CRMSystem.Models;
using CRMSystem.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CRMSystem.Tests
{
    [Trait("Category", "Product")]
    public class ProductControllerTest
    {
        [Fact]
        public void Get_ReturnsOK_IfThereAreProductsInTheDatabase()
        {
            // Arrange
            var fakeData = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Products.All())
                .Returns(fakeData.FakeProducts.AsQueryable());
            var sut = new ProductsController(mockRepo.Object);

            // Act
            var result = sut.Get();

            // Assert
            Assert.IsNotType<OkResult>(result);
        }

        [Fact]
        public void Get_ReturnArgumentNullException_IfThereAreNoProductsInTheDatabase()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Products.All())
                .Returns((IQueryable<Product>)null);
            var sut = new ProductsController(mockRepo.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => sut.Get());
        }

        [Fact]
        public void GetById_ReturnsNotFound_ForInvalidCustomerId()
        {
            // Arrange
            var id = 100;
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Products.GetById(id))
                .Returns((Product)null);
            var sut = new ProductsController(mockRepo.Object);

            // Act
            var result = sut.Get(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        //[Fact]
        //public void GetById_ReturnsOK_ForValidCustomerId()
        //{
        //    // Arrange
        //    var id = 1;
        //    var fakeData = new FakeData();
        //    var mockRepo = new Mock<IUnitOfWork>();

        //    mockRepo.Setup(repo => repo.Customers.All())
        //        .Returns(fakeData.FakeCustomers.AsQueryable());

        //    mockRepo.Setup(repo => repo.Products.All())
        //        .Returns(fakeData.FakeProducts.AsQueryable());

        //    var sut = new ProductsController(mockRepo.Object);

        //    var pesho = mockRepo.Object.Customers.All();
        //    var gosho = pesho.SelectMany(x => x.SalledProducts.Where(y => y.CustomerId == id));
        //    var stamat = gosho.Include(x => x.ProductId);


        //    // Act
        //    var result = sut.Get(id);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        [Fact]
        public void Post_ReturnsBadRequest_GivenRequiredModel()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var sut = new ProductsController(mockRepo.Object);
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
            mockRepo.Setup(x => x.Products.Add(It.IsAny<Product>())).Verifiable();
            var sut = new ProductsController(mockRepo.Object);

            // Act
            var result = sut.Post(fakeRepo.ProductDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Update_ReturnBadRequest_GivenRequiredModel()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var sut = new ProductsController(mockRepo.Object);
            sut.ModelState.AddModelError("error", "some error");

            // Act
            var result = sut.Update(id: 0, model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        //[Fact]
        //public void Update_VerifyThatModelStateIsValid()
        //{
        //    // Arrange
        //    var fakeRepo = new FakeData();
        //    var mockRepo = new Mock<IUnitOfWork>();
        //    mockRepo.Setup(repo => repo.Customers.All())
        //        .Returns(fakeRepo.FakeCustomers.Where(x => x.Id == 1).AsQueryable());
        //    mockRepo.Setup(repo => repo.Customers.Update(It.IsAny<Customer>())).Verifiable();

        //    var sut = new ProductsController(mockRepo.Object);

        //    // Act
        //    var result = sut.Update(1, fakeRepo.ProductDTO);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        [Fact]
        public void Delete_ReturnOk_ForValidProductId()
        {
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Products.All())
                .Returns(fakeRepo.FakeProducts.Where(x => x.Id == 1).AsQueryable());
            mockRepo.Setup(repo => repo.Products.Delete(It.IsAny<Product>())).Verifiable();
            var sut = new ProductsController(mockRepo.Object);

            // Act
            var result = sut.Delete(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Delete_ReturnBadRequest_ForInvalidProductId()
        {
            var id = 100;
            var fakeRepo = new FakeData();
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Products.All())
                .Returns(fakeRepo.FakeProducts.Where(x => x.Id == id).AsQueryable());
            mockRepo.Setup(repo => repo.Products.Delete(It.IsAny<Product>())).Verifiable();
            var sut = new ProductsController(mockRepo.Object);

            // Act
            var result = sut.Delete(id);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
