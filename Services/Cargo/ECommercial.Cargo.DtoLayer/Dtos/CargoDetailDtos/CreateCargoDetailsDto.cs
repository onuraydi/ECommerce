using ECommercial.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class CreateCargoDetailsDto
    {
        public string SenderCustomer { get; set; }
        public string RecieverCustomer { get; set; }
        public string Barcode { get; set; }
        public int CargoCompanyID { get; set; }
    }
}
