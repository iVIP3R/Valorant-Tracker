using System.Collections.Generic;

namespace Valorant_Tracker.Objects.Player
{
    public class MatchHistory
    {
        public string Subject { get; set; }
        public int BeginIndex { get; set; }
        public int EndIndex { get; set; }
        public int Total { get; set; }
        public List<Match> History { get; set; }

        public class Match
        {
            public string MatchID { get; set; }
            public object GameStartTime { get; set; }
            public string QueueID { get; set; }
        }
    }
}
