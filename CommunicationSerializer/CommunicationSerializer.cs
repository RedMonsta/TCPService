using Newtonsoft.Json;
using CommandsLib;

namespace CommunicationSerializer
{
    public class CommunicationSerializer
    {
        public ICustomCommand Deserialize(string str)
        {
            return JsonConvert.DeserializeObject<ICustomCommand>(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public string Serialize(Response response)
        {
            return JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
