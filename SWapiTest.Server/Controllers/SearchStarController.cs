using Microsoft.AspNetCore.Mvc;
using StarWarsApiCSharp;
using SWapiTest.Server.Data;

namespace SWapiTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchStarController : ControllerBase
    {

        private readonly SearchStarDbContext dbContext;
        //private readonly ILogger<SearchStarController> _logger;

        public SearchStarController(SearchStarDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        [HttpGet(Name = "GetSearchStar")]
        public IEnumerable<SearchResults> Get(string? searchname)
        {
            IRepository<Film> filmsRepo = new Repository<Film>();
            IRepository<Vehicle> vehiclesRepo = new Repository<Vehicle>();
            string searchedString;

            //Get the Person movies looking by the name

            IRepository<Person> PersonRepo = new Repository<Person>();
            if (searchname == null || searchname.Length == 0)
                searchedString = "Luke Skywalker";
            else
                searchedString = searchname;
            List<Person> Persons = (List<Person>)PersonRepo.GetEntities();
            List<Person> SearchedPersons = (from item in Persons
                                            where item.Name.Equals(searchedString)
                                            select item).ToList();




            /* Get the movies and vehicles of the selected persons */
            List<String> FoundFilms = new List<String>();
            List<String> FoundVehicles = new List<String>();


            foreach (Person SelectedPerson in SearchedPersons)
            {


                /*Create SearchResult */
                foreach (string film in SelectedPerson.Films)
                {
                    //
                    var filmSplited = film.Split('/');
                    var filmid = filmSplited[filmSplited.Count() - 2];
                    int filmDI = int.Parse(filmid);
                    var Searchedfilm = filmsRepo.GetById(filmDI).Title;
                    FoundFilms.Add(Searchedfilm);
                    //Add films and save them
                    SearchResultFilm resultatfilm = new SearchResultFilm();
                    resultatfilm.Id = new Guid();
                    resultatfilm.Date = DateTime.Now;
                    resultatfilm.Film = Searchedfilm;
                    resultatfilm.Name = searchedString;
                    dbContext.SearchResultFilms.Add(resultatfilm);
                    
                }
                dbContext.SaveChanges();

                foreach (string vehicle in SelectedPerson.Vehicles)
                {
                    //
                    var vehicleSplited = vehicle.Split('/');
                    var vehicleid = vehicleSplited[vehicleSplited.Count() - 2];
                    int vehicleDI = int.Parse(vehicleid);
                    var Searchedvehicle = vehiclesRepo.GetById(vehicleDI).Name;
                    FoundVehicles.Add(Searchedvehicle);
                    //Add films and save them
                    SearchResultVehicle resultatVehicle = new SearchResultVehicle();
                    resultatVehicle.Id = new Guid();
                    resultatVehicle.Date = DateTime.Now;
                    resultatVehicle.Vehicle = Searchedvehicle;
                    resultatVehicle.Name = searchedString;
                    dbContext.SearchResultVehicles.Add(resultatVehicle);
                    dbContext.SaveChanges();
                }
            }

            /* Save The Search Results */
            SearchResults result = new SearchResults
            {
                Date = DateTime.Now,
                Name = searchedString,
                Films = FoundFilms.ToArray(),
                Vehicles = FoundVehicles.ToArray()
            };
            /*dbContext.SearchResultats.Add(result);
            dbContext.SaveChanges();*/


            return Enumerable.Range(1, 1).Select(index => result)
                .ToArray();

            

              
        }
    }
}
