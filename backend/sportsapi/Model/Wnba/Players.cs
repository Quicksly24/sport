namespace sportsapi.Model.Wnba
{
    public class Players
    {
        
        public string id { get; set; }

        public string displayName { get; set; }

        public string dateOfBirth { get; set; }

        public string jersey { get; set; }

        public Img headshot { get; set; }
       
    }

    public class Img
    {
        public string href { get; set; }

        public string alt { get; set; }
    }
}
