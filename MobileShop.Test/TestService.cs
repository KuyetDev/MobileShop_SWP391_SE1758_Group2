using Microsoft.EntityFrameworkCore;
using MobileShop.Entity.DTOs.CategoryDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;

namespace MobileShop.Test
{
    public class TestService
    {
        private AccountService _accountService { get; set; } = null!;
        private CategoryService _categoryService { get; set; } = null!;
        private ProductService _productService { get; set; } = null!;
        private FstoreContext _context;
        private EncryptionService _encryptionService;
        [SetUp]
        public void Setup()
        {
            var context = new FstoreContext();
            var encryptionService = new EncryptionService();
            _context = context;
            _encryptionService = encryptionService;
            _accountService = new AccountService(_context, _encryptionService);
            _categoryService = new CategoryService(_context);
            _productService = new ProductService(_context);
        }

        [Test]
        public void GetAllAccount_Test()
        {
            var result = false;
            var accounts = _accountService.GetAllAccount();
            if (accounts.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetAllCategory_Test()
        {
            var result = false;
            var categories = _categoryService.GetAllCategory();
            if (categories.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void AddCategory_Test()
        {
            var result = false;
            var categoryEntry = new CreateCategoryRequest
            {
                CategoryName = "Test",
                IsDeleted = false
            };
            var response = _categoryService.AddCategory(categoryEntry);
            if (response.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetProductByKeyword_Test()
        {
            var result = false;
            var keyword = "Xiaomi";
            var products = _productService.GetProductsByKeyword(keyword);
            if (products.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}