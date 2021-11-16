using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedisOgil
{
    public interface IRedisService<T> where T : IRedisEntity
    {
        bool IsCacheableEntity();
        Task<T> GetOne(int id);
        void SetOne(T entity);
        Task<IList<T>> GetList();
        void SetList(IList<T> entity);

    }
}
