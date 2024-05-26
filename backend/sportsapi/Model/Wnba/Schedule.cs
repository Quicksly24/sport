namespace sportsapi.Model.Wnba
{

    public class evt
    {
        public string id { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public SeasonType seasonType { get; set; }
        public bool timeValid { get; set; }

        public Competition[] competitions { get; set; }

    }

    public class SeasonType
    {

        public string name { get; set; }

    }

    public class Competition
    {
        public competitor[] competitors { get; set; }

    }

    public class competitor
    {

        public Team team { get; set; }

        public Score score { get; set; }

    }

    public class Team
    {
        public Logo[] logos { get; set; }
    }

    public class Score
    {
        public string displayValue { get; set; }

    }
}
