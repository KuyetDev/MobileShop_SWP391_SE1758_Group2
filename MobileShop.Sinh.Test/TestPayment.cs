using MobileShop.Entity.DTOs.PaymentDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Sinh.Test
{
    public class TestPayment
    {
        private PaymentService _paymentService { get; set; } = null;
        private FstoreContext _context;
        [SetUp]
        public void Setup()
        {
            var context = new FstoreContext();
            _context = context;
            _paymentService = new PaymentService(context);
        }

        [Test]
        public void GetAllPayment_Test()
        {
            var result = false;
            var payments = _paymentService.GetAllPayment();
            if (payments.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CreatePayment_Test()
        {
            var result = false; 
            var createPayment = new CreatePaymentRequest
            {
                PaymentName = "Zalo pay",
                IsDeleted = true
            };
            var response = _paymentService.AddPayment(createPayment);
            if (response.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));

        }


        [Test]
        public void GetPaymentByID_Test()
        {
            var result = false;
            var payment = _paymentService.GetPaymentById(1);
            if (payment != null) result = true;
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public void UpdatePayment_Test()
        {
            var result = false;
            var updatePayment = new UpdatePaymentRequest
            {
                PaymentId = 2,
                PaymentName = "Banking",
                IsDeleted = false
            };
            var response = _paymentService.UpdatePayment(updatePayment);
            if (response.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public void UpdateDeleteStatusPayment_Test()
        {
            var result = false;
            var response = _paymentService.UpdateDeleteStatusPayment(2);
            if (response = true) result = true;
            Assert.That(result, Is.EqualTo(true));

        }
    }
}
