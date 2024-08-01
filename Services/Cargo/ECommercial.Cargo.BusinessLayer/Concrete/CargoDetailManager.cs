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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void Tdelete(int id)
        {
            _cargoDetailDal.delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetailDal.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetailDal.GetById(id);
        }

        public void Tinsert(CargoDetail entity)
        {
            _cargoDetailDal.insert(entity);
        }

        public void Tupdate(CargoDetail entity)
        {
            _cargoDetailDal.update(entity);
        }
    }
}
