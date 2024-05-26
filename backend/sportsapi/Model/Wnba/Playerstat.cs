namespace sportsapi.Model.Wnba
{
    public partial class Statistics
    {
        public string[] labels { get; set; }
        public string[] names { get; set; }
        public string[] displayNames { get; set; }
        public Split[] splits { get; set; }
    }

    public partial class Split
    {
        public string displayName { get; set; }
        public string[] stats { get; set; }
    }

}
