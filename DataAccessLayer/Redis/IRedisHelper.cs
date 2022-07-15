using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Redis
{
    public interface IRedisHelper
    {
        Task<bool> SetKeyAsync(string Key, int Value);
        Task<int> GetKeyAsync(string Key);

    }
}
