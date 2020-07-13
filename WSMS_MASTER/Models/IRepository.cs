using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSMS_MASTER.Models
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        bool Add(T entity);
        T GetById(int id);
        bool Update(T entity);
        bool Delete(int id);
        List<T> Search(params object[] args);

    }
}
