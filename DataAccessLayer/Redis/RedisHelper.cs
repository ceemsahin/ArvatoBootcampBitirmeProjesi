using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Redis
{
    public class RedisHelper : IRedisHelper
    {
        public async Task<int> GetKeyAsync(string Key)
        {
            var database = await GetRedisDatabase();


            var value = await database.StringGetAsync(Key);


            return await Task.FromResult((int)value);
        }

        public async Task<bool> SetKeyAsync(string Key, int Value)
        {
            var database = await GetRedisDatabase();

            return await database.StringSetAsync(Key, Value);
        }

        private async Task<IDatabase> GetRedisDatabase()
        {
            var config = new ConfigurationOptions
            {
                EndPoints = { "localhost" },
                Ssl = false,
                AbortOnConnectFail = false,
            };

            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(config);

            return redis.GetDatabase(0);
        }
    }
}