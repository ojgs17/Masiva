using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisOgil
{
    class RedisService<T> : IRedisService<T> where T : IRedisEntity
    {
        public interface IEntity
        {
            int Id { get; set; }
        }
        IDatabase _redis;
        private const string _one_suffix = "id_";
        private const string _list_suffix = "list";
        string _key;
        string _one_key;
        string _list_key;
        RedisSettings _settings;
        EntitySetting _entitySettings;
        IConnectionMultiplexer _connection;
        public RedisService(IConnectionMultiplexer connection, IOptions<RedisSettings> redisSettings)
        {
            _connection = connection;
            _key = typeof(T).Name;
            _list_key = $"{_key}_{_list_suffix}";
            _one_key = $"{_key}_{_one_suffix}";
            _settings = redisSettings.Value;
            _entitySettings = _settings.EntitySettings.Where(e => e.Name.Equals(_key)).FirstOrDefault();
            _redis = _connection.GetDatabase();
        }
        public async Task<IList<T>> GetList()
        {
            var data = await _redis.StringGetAsync(_list_key);
            if (!data.HasValue) return default(IList<T>);
            var redisData = Encoding.UTF8.GetString(data);
            var entity = JsonConvert.DeserializeObject<IList<T>>(redisData);
            return entity;
        }
        public async Task<T> GetOne(int id)
        {
            var data = await _redis.StringGetAsync($"{_one_key}{id}");
            if (!data.HasValue) return default(T);
            var redisData = Encoding.UTF8.GetString(data);
            var entity = JsonConvert.DeserializeObject<T>(redisData);
            return entity;
        }
        public async void SetList(IList<T> entity)
        {
            var data = JsonConvert.SerializeObject(entity);
            var redisData = Encoding.UTF8.GetBytes(data);
            await _redis.StringSetAsync(_list_key, redisData);
        }
        public async void SetOne(T entity)
        {
            var data = JsonConvert.SerializeObject(entity);
            var redisData = Encoding.UTF8.GetBytes(data);
            await _redis.StringSetAsync($"{_one_key}{entity.Id}", redisData);            
        }
        public bool IsCacheableEntity()
        {
            return _entitySettings != null;
        }
    }
}
