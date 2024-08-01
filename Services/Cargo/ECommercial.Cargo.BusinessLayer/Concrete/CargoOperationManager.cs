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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;
        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void Tdelete(int id)
        {
            _cargoOperationDal.delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void Tinsert(CargoOperation entity)
        {
            _cargoOperationDal.insert(entity);
        }

        public void Tupdate(CargoOperation entity)
        {
            _cargoOperationDal.update(entity);
        }
    }
}
