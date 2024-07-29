using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Results.AddressResults
{
    // Bu class Address clasımızdaki proportiesleri tutacakc ve onları listelememizi sağlayacak
    public class GetAddressQueryResult
    {
        public int AddressID { get; set; }
        public string UserID { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
    }
}
