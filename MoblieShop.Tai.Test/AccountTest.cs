using MobileShop.Entity.DTOs.AccountDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoblieShop.Tai.Test
{
    public class AccountTest
    {
        private AccountService _accountService { get; set; } = null;
        private EncryptionService _encryptionService { get; set; } = null;
        private FstoreContext _context;
        [SetUp]
        public void Setup()
        {
            var context = new FstoreContext();
            _context = context;
            _encryptionService = new EncryptionService();
            _accountService = new AccountService(context, _encryptionService);

        }

        [Test]
        public void GetAllAccount_Test()
        {
            var result = false;
            var account = _accountService.GetAllAccount();
            if(account.Count > 0) result = true;

            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void CreateAccount_Test()
        {
            var result = false;
            var accountEnty = new CreateAccountRequest
            {
                FullName = "Test",
                Mail = "Test@gmail.com",
                Address = "Test",
                Dob = DateTime.Now,
                Gender = false,
                Phone = "Test",
                Password = "Test",
                Active = true,
                RoleId = 2,
                IsDeleted = true
            };
            var response = _accountService.AddAccount(accountEnty);
            if (response.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void UpdateAccount_Test()
        {
            var result = false;
            var accountEnty = new UpdateAccountRequest
            {
                FullName = "Test",
                Mail = "Test@gmail.com",
                Address = "Test",
                Dob = DateTime.Now,
                Gender = false,
                Phone = "Test",
                Password = "Test",
                Active = true,
                RoleId = 2,
                IsDeleted = true
            };
            var response = _accountService.UpdateAccount(accountEnty);
            if(response.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void DeleteAccount_Test()
        {
            var result = false;
            var response = _accountService.UpdateDeleteStatusAccount(1);
            if(response = true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetAccountsByKeyword_Test()
        {
            var result = false;
            var account = _accountService.GetAccountsByKeyword("Test");
            if(account != null) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetAccountById_Test()
        {
            var result = false;
            var account = _accountService.GetAccountById(4);
            if (account != null) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetAccountByEmailAndPassword_Test()
        {
            var result = false;
            var account = _accountService.GetAccountByEmailAndPassword("Test@gmail.com","Test");
            if (account != null) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        
        [Test]
        public void GetAccountByEmail_Test()
        {
            var result = false;
            var account = _accountService.GetAccountByEmail("Test@gmail.com");
            if (account != null) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetAccountsByRoleId_Test()
        {
            var result = false;
            var account = _accountService.GetAccountsByRoleId(2);
            if (account != null) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
