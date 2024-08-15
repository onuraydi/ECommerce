using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.CalatogDtos.ProductDetailDtos
{
    public class GetByIdProductDetailDto
    {
        public string ProductID { get; set; }
        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInformation { get; set; }
    }
}
