namespace HerbariumLearnApp
{
    public class Plant
    {
        public string Id { get; set; }
        public string GerName { get; set; }
        public string LatName { get; set; }
        public string GerFamily { get; set; }
        public string LatFamily { get; set; }
        public DateOnly DiscoveryDate { get; set; }
        public string Location { get; set; }

        public Plant()
        {
        }

        public Plant(
            string id,
            string gerName,
            string latName,
            string gerFamily,
            string latFamily,
            DateOnly discoveryDate,
            string location)
        {
            Id = id;
            GerName = gerName;
            LatName = latName;
            GerFamily = gerFamily;
            LatFamily = latFamily;
            DiscoveryDate = discoveryDate;
            Location = location;
        }
    }
}