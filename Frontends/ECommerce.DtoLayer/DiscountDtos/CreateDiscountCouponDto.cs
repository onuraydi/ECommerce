using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.DiscountDtos
{
    public class CreateDiscountCouponDto
    {
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CouponValidDate { get; set; }
    }
}
