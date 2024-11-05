using System.ComponentModel.DataAnnotations;

namespace SWapiTest.Server
{
    public class SearchResultFilm
    {
        [Key()]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public String Film { get; set; }

        public string Name { get; set; }
    }
}
