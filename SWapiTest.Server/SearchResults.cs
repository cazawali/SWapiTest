namespace SWapiTest.Server
{
    public class SearchResults
    {

        public DateTime Date { get; set; }

        public required String[] Films { get; set; }


        public required String[] Vehicles { get; set; }

        public string Name { get; set; }
    }
}
