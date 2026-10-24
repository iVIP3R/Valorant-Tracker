namespace Valorant_Tracker.Objects.Authentication
{
    public class UserData
    {
        public string country { get; set; }
        public string sub { get; set; }
        public bool email_verified { get; set; }
        public object player_plocale { get; set; }
        public long country_at { get; set; }
        public Pw pw { get; set; }
        public bool phone_number_verified { get; set; }
        public bool account_verified { get; set; }
        public object ppid { get; set; }
        public string player_locale { get; set; }
        public Acct acct { get; set; }
        public int age { get; set; }
        public string jti { get; set; }
        public Affinity affinity { get; set; }

        public class Pw
        {
            public long cng_at { get; set; }
            public bool reset { get; set; }
            public bool must_reset { get; set; }
        }

        public class Acct
        {
            public int type { get; set; }
            public string state { get; set; }
            public bool adm { get; set; }
            public string game_name { get; set; }
            public string tag_line { get; set; }
            public long created_at { get; set; }
        }

        public class Affinity
        {
            public object pp { get; set; }
        }
    }
}
