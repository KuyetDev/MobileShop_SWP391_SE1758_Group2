﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Entity.DTOs.PaymentDTO
{
    public class UpdatePaymentRequest
    {
        public int PaymentId { get; set; }

        public string PaymentName { get; set; } = null!;

        public bool? IsDeleted { get; set; }
    }
}
