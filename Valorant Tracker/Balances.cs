using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    public class Balances
    {
        public int ValorantPoints { get; set; }
        public int RadianitePoints { get; set; }
        public int FreeAgents { get; set; }
        public int StatusCode;

        public static async Task<Balances> GetBalanceAsync(Auth au)
        {
            var client = new RestClient($"https://pd.{au.RegionShard}.a.pvp.net/store/v1/wallet/{au.Subject}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
            request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

            var response = await client.ExecuteAsync(request);
            var ret = new Balances { StatusCode = (int)response.StatusCode };

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                var obj = JObject.Parse(response.Content);
                ret.ValorantPoints = obj["Balances"]?.Value<int>("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741") ?? 0;
                ret.RadianitePoints = obj["Balances"]?.Value<int>("e59aa87c-4cbf-517a-5983-6e81511be9b7") ?? 0;
                ret.FreeAgents = obj["Balances"]?.Value<int>("f08d4ae3-939c-4576-ab26-09ce1f23bb37") ?? 0;
            }
            return ret;
        }
    }
}