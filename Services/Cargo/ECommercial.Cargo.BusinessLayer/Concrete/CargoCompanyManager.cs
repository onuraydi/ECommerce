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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public void Tdelete(int id)
        {
            _cargoCompanyDal.delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }

        public void Tinsert(CargoCompany entity)
        {
            _cargoCompanyDal.insert(entity);
        }

        public void Tupdate(CargoCompany entity)
        {
            _cargoCompanyDal.update(entity);
        }
    }
}
