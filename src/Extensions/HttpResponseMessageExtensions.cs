using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exercise.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeObject<T>(this Task<HttpResponseMessage> message)
        {
            return await DeserializeObject<T>(await message);
        }

        private static async Task<T> DeserializeObject<T>(this HttpResponseMessage message)
        {
            var jsonString = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}