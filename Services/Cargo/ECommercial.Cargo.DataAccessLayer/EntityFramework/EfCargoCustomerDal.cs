using ECommercial.Cargo.DataAccessLayer.Abstract;
using ECommercial.Cargo.DataAccessLayer.Repositories;
using ECommercial.Cargo.DtoLayer.Concrete;
using ECommercial.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
