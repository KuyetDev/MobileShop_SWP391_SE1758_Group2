using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Entity.DTOs.ImageDTO
{
    public class UpdateImageRequest
    {
        public int ImageId { get; set; }

        public string? ImageLink { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
