using System;

namespace SportsBall
{
    public class GameResult
    {
        public HomeOrAway HomeOrAway { get; set; }

        public DateTime GameDate { get; set; }

        public string TeamName { get; set; }
    }

    public enum HomeOrAway
    {
        Home,
        Away
    }
}