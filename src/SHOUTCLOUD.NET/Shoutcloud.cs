using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SHOUTCLOUD
{
    public static class SHOUTCLOUD
    {
        private static readonly string SERVICE_URL = "HTTP://API.SHOUTCLOUD.IO/V1/SHOUT";

        public static async Task<string> UPCASE(string input, CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = new HttpClient();

            var payload = new { INPUT = input };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(SERVICE_URL, content, cancellationToken);
            response.EnsureSuccessStatusCode(); // THROW IF ERROR

            var result = JsonConvert.DeserializeObject<IDictionary<string, object>>(await response.Content.ReadAsStringAsync());
            return result["OUTPUT"].ToString();
        }
    }
}
