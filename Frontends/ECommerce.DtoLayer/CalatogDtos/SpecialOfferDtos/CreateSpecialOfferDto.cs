using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.CalatogDtos.SpecialOfferDtos
{
    public class CreateSpecialOfferDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageURL { get; set; }
        public string ButtonText { get; set; }
    }
}
