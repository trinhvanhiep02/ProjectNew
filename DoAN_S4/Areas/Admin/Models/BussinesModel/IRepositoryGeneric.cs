using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAN_S4.Areas.Admin.Models.BussinesModel
{
    public interface IRepositoryGeneric <T, K>
    {
        List<T> getAll();
        T GetByID(K key);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(K key);
    }
}
