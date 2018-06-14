using System;

namespace SportsBall
{
    public class GameResult
    {
        public HomeOrAway HomeOrAway { get; set; }

        public DateTime GameDate { get; set; }

        public string TeamName { get; set; }

        public int Goals { get; set; }
        public int GoalAttempts { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsOffGoal { get; set; }

        public double PossessionPercent { get; set; }

        public double ConversionRate => (double)Goals / (double)GoalAttempts;
    }

    public enum HomeOrAway
    {
        Home,
        Away
    }
}