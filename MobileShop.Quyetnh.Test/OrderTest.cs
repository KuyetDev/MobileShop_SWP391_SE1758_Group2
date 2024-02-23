using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShop.Entity.DTOs.OrderDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;
namespace MobileShop.Quyetnh.Test
{
    public class OrderTest
    {
        private OrderService _orderService { get; set; } = null!;
        private OrderDetailService _orderDetailService { get; set; } = null!;
        private FstoreContext _context;
        [SetUp]
        public void Setup()
        {
            var context = new FstoreContext();
            _context = context;
            _orderService = new OrderService(context);
            _orderDetailService = new OrderDetailService(context, _orderService);
        }

        [Test]
        public void GetAllOrder_Test()
        {
            var result = false;
            var orders = _orderService.GetAllOrders();
            if (orders.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CreateOrder_Test()
        {
            var result = false;
            var orderEntry = new CreateOrderRequest
            {
                CustomerId = 1003,
                Address = "HN",
                CouponId = 5,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                PaymentId = 1,
                RequiredDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                Status = 1
            };
            var orderResponse = _orderService.AddOrder(orderEntry);
            if (orderResponse.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void UpdateOrder_Test()
        {
            var result = false;
            var orderEntry = new UpdateOrderRequest
            {
                OrderId = 2,
                CustomerId = 1003,
                Address = "HN",
                CouponId = 5,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                PaymentId = 1,
                RequiredDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                Status = 1
            };
            var orderResponse = _orderService.UpdateOrder(orderEntry);
            if (orderResponse.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DeleteOrder_Test()
        {
            var result = false;
            var orderId = 1;
            var response = _orderService.UpdateDeleteStatusOrder(orderId);
            if (response is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
