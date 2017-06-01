using Newtonsoft.Json;
using DataModel;

namespace TCPServiceLib
{
    public static class DataSerializer
    {
        public static Data Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<Data>(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public static string Serialize(Data data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
