using System.ComponentModel.DataAnnotations;

namespace SWapiTest.Server
{
    public class SearchResultVehicle
    {
        [Key()]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public String Vehicle { get; set; }

        public string Name { get; set; }
    }
}
