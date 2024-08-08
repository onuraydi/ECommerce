using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.CalatogDtos.OfferDiscountDtos
{
    public class UpdateOfferDiscountDto
    {
        public string OfferDiscounId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ButtonText { get; set; }
        public string ImageUrl { get; set; }
    }
}
