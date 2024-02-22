using MobileShop.Entity.DTOs.ProductDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MobileShop.Nghia.Test
{
    public class ProductTest
    {
        private ProductService _productService { get; set; } = null;
        private FstoreContext _context;

        [SetUp]
        public void Setup()
        {
            var context = new FstoreContext();
            _context = context;
            _productService = new ProductService(context);

        }

        [Test]
        public void GetAllProduct_test()
        {
            var result = false;
            var products = _productService.GetAllProduct();
            if (products.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void AddProduct_test()
        {
            var result = false;
            var createProduct = new CreateProductRequest
            {
                ProductName = "Test",
                Price = 1000,
                Quantity = 300,
                Description = "Test",
                CategoryId = 1,
                ImageId = 1,
                CreateDate = DateTime.Now,
                CreateBy = 4,
                IsDeleted = true
            };
                var response = _productService.AddProduct(createProduct);
                if (response.IsSuccess is true) result = true;
              Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void UpdateProduct_test()
        {
            {
                var result = false;
                var productEntry = new UpdateProductRequest
                {
                    ProductName = "Test",
                    Price = 1000,
                    Quantity = 300,
                    Description = "Test",
                    CategoryId = 1,
                    ImageId = 1,
                    CreateDate = DateTime.Now,
                    CreateBy = 4,
                    IsDeleted = true
                };
                var response = _productService.UpdateProduct(productEntry);
                if (response.IsSuccess is true) result = true;
                Assert.That(result, Is.EqualTo(true));
            }
        }

        [Test]
          public void DeleteProduct_test()
          {
            var result = false;
            var response = _productService.UpdateDeleteStatusProduct(1);
            if (response = true) result = true;
            Assert.That(result, Is.EqualTo(true));

          }
    }
 }

