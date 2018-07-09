using System;
using System.Collections.Generic;
using CRMSystem.Client.DTOModels;
using CRMSystem.DTOModels.Models;
using CRMSystem.Models;

namespace CRMSystem.Tests.Mocks
{
    public class FakeData
    {
        public FakeData()
        {
            this.CreateFakeCustomers();
            this.CreateFakeProducts();
        }

        public ICollection<Customer> FakeCustomers { get; set; }

        public ICollection<Product> FakeProducts { get; set; }

        public CustomerDTO CustomerDTO
        {
            get
            {
                return new CustomerDTO
                {
                    Address = "Some address",
                    Company = "Some company",
                    Email = "asia@gmail.com",
                    FirstName = "Asya",
                    LastName = "Becheva",
                    Phone = "0888998899",
                    Status = Status.active,
                    Username = "asyaB",
                };
            }
        }
        public ICollection<Product> FakeProduts2
        {
            get
            {
                return new List<Product>
                {
                    new Product { Id = 1, Info = "DISPLAY: Super AMOLED ", Name = "Samsung Galaxy S8", Price = 1500 },
                    new Product { Id = 2, Info = "5.8 inches, 84.8 cm2", Name = "HUAWEI", Price = 2200 }
                };
            }
        }

        public List<CustomerProduct> FakeCustomerProducts
        {
            get
            {
                return new List<CustomerProduct>
                {
                    new CustomerProduct
                    {
                        CustomerId = 1,
                        ProductId = 1,
                        Product = new Product { Id = 1, Info = "DISPLAY: Super AMOLED ", Name = "Samsung Galaxy S8", Price = 1500 },
                        Customer = new Customer { Id = 1, FirstName = "Petar", LastName = "Petrov", Address = "ul. Iskar", Email = "petarpetrov@gmail.com", Company = "another company", Phone = "0888778877", Status = Status.active, AddedOn = DateTime.Now, Username = "petarP" }
                    }
                };
            }
        }

        public ProductDTO ProductDTO
        {
            get
            {
                return new ProductDTO
                {
                    Name = "LG",
                    Info = "6.8 inches, 88.8 cm2",
                    Price = 3000
                };
            }
        }

        private void CreateFakeCustomers()
        {
            this.FakeCustomers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Asya",
                    LastName = "Becheva",
                    Address = "ul. Marica",
                    Email = "asiabecheva@gmail.com",
                    Company = "mycompany",
                    Phone = "0884545454",
                    Status = Status.active,
                    AddedOn = DateTime.Now,
                    Username = "asyaB",
                    SalledProducts = this.FakeCustomerProducts },
                new Customer { Id = 3, FirstName = "Petar", LastName = "Petrov", Address = "ul. Iskar", Email = "petarpetrov@gmail.com", Company = "another company", Phone = "0888778877", Status = Status.active, AddedOn = DateTime.Now, Username = "petarP" },
                new Customer { Id = 4, FirstName = "Georgi", LastName = "Georgiev", Address = "ul. Amazonka", Email = "goshogeorgiev@gmail.com", Company = "goshos company", Phone = "0887878787", Status = Status.inactive, AddedOn = DateTime.Now, Username = "goshoG" },
            };
        }

        private void CreateFakeProducts()
        {
            this.FakeProducts = new List<Product>
            {
                new Product { Id = 1, Info = "DISPLAY: Super AMOLED ", Name = "Samsung Galaxy S8", Price = 1500 },
                new Product { Id = 2, Info = "5.8 inches, 84.8 cm2", Name = "HUAWEI", Price = 2200 }
            };
        }
    }
}
