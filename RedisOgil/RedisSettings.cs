using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOgil
{
 
    public class EntitySetting
    {
        public string Name { get; set; }
        public long Expiry { get; set; }

    }
    public class RedisSettings
    {
        public List<EntitySetting> EntitySettings { get; set; }
        public string Endpoint { get; set; }
    }
}
