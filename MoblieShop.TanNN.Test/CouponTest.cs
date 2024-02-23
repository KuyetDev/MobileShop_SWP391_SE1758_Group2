using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShop.Entity.DTOs.AccountDTO;
using MobileShop.Entity.DTOs.CouponDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;

namespace MoblieShop.TanNN.Test
{
    
    public class CouponTest
    {
        private CouponService _couponService { get; set; } = null;
        private FstoreContext _context;

        [SetUp]
        public void Setup()
        {
            var context = new FstoreContext();
            _context = context;
            _couponService = new CouponService(context);

        }

        [Test]
        public void GetALLCoupon_Test()
        {
            var result = false;
            var coupon = _couponService.GetALLCoupon();
            if (coupon.Count > 0) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CreateCoupon_Test()
        {
            var result = false;
            var couponEntry = new CreateCouponRequest
            {
                Code = "VIP",
                DiscountPercent = 5,
                IsDeleted = true
            };


            var couponRespone = _couponService.AddCoupon(couponEntry);
            if (couponRespone.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void UpdateCoupon_Test()
        {
            var result = false;
            var couponEntry = new UpdateCouponRequest
            {
                CouponId = 5,
                Code = "VIP1",
                DiscountPercent = 20,
                IsDeleted = false

            };


            var coupon = _couponService.UpdateCoupon(couponEntry);
            if (coupon.IsSuccess is true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void GetCouponById_Test()
        {
            var result = false;
            var coupon = _couponService.GetCouponById(5);
            if (coupon != null) result = true;
            Assert.That(result, Is.EqualTo(true));

        }
        [Test]
        public void GetCouponByCode_Test()
        {
            var result = false;
            var coupon = _couponService.GetCouponByCode("VIP1");
            if (coupon != null) result = true;
            Assert.That(result, Is.EqualTo(true));

        }
        [Test]
        public void DeleteCoupon_Test()
        {
            var result = false;
            var coupon = _couponService.UpdateDeleteStatusCoupon(6);
            if (coupon = true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void CheckExpiryCoupon_Test()
        {
            var result = false;
            var expirationDate = _couponService.CheckExpiryCoupon(5);
            if (expirationDate == true) result = true;
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
