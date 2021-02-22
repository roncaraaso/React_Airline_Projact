using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class SetRedis
    {
        
        public static int airlineNum = 4;
        public static bool setToRedis( string host , string key , string value)
        {
            bool success = false;
            using (RedisClient client = new RedisClient(host))
            {
                
                if(client.Get<string>(key) == null){
                    success = client.Set(key, value);
                }
            }
            return success;
        }

        public static string  Get(string host ,string key)
        {
            using(RedisClient client = new RedisClient(host))
            {
                return client.Get<string>(key);
               // return client.GetAll<string>();
            }
        }
        public static void Remove(string host, string key)
        {
            using (RedisClient client = new RedisClient(host))
            {
               client.Del(key);
               
            }
        }
    }
}