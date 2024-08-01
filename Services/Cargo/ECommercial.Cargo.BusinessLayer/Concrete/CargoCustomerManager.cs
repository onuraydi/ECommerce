using ECommercial.Cargo.BusinessLayer.Abstract;
using ECommercial.Cargo.DataAccessLayer.Abstract;
using ECommercial.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;
        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public void Tdelete(int id)
        {
            _cargoCustomerDal.delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomerDal.GetById(id);
        }

        public void Tinsert(CargoCustomer entity)
        {
            _cargoCustomerDal.insert(entity);
        }

        public void Tupdate(CargoCustomer entity)
        {
            _cargoCustomerDal.update(entity);
        }
    }
}
