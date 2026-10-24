using Newtonsoft.Json;

namespace Valorant_Tracker.Objects.Store
{
    public class PlayerWallet
    {
        public Balances Balances { get; set; }
    }

    public class Balances
    {
        [JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
        public int VP { get; set; }

        [JsonProperty("e59aa87c-4cbf-517a-5983-6e81511be9b7")]
        public int RP { get; set; }

        [JsonProperty("f08d4ae3-939c-4576-ab26-09ce1f23bb37")]
        public int FreeAgentTokens { get; set; }
    }
}
