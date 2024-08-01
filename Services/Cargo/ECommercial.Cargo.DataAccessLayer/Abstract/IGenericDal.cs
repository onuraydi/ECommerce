using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void insert(T entity);
        void update(T entity);
        void delete(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
