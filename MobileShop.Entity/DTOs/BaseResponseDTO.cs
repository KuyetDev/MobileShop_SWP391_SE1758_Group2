using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Entity.DTOs
{
    public class BaseResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
