using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LYQ.TokenDemo.Models.Token
{
    public class JsonHelper<T> where T : class
    {
        public static T JsonDeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string JsonSerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}