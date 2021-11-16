using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOgil
{
    public interface ICrud<T> 
    {
        T Save(T entity);
        IList<T> GetAll();
        T GetById(int id);
        void Delete(int id);

    }
}
