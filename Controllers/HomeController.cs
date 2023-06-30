using Microsoft.AspNetCore.Mvc;
using StayCation.Models;
using System.Diagnostics;

namespace StayCation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var AllProperties = ReadPropertiesFromFile("Database.txt");
            var mostPicks = AllProperties.Where(property=> property.group=="Most Picks").ToList();
            ViewData["Most"]= mostPicks;
            var beautyBackyards = AllProperties.Where(property => property.group == "Houses with beautiful Backyards").ToList();
            ViewData["beauty"]= beautyBackyards;
            var livingRoom= AllProperties.Where(property => property.group == "Hotels with large living rooms").ToList();
            ViewData["LargeRoom"]= livingRoom;
            var kitchenSet = AllProperties.Where(property => property.group == "Apartments with kitchen set").ToList();
            ViewData["kitchen"] = kitchenSet;

            return View();
        }
            











        public static List<Property> ReadPropertiesFromFile(string filePath)
        {
            List<Property> properties = new List<Property>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split('|');

                        if (fields.Length >= 6)
                        {
                            string location = fields[1].Trim();
                            string propName = fields[2].Trim();
                            string price = fields[3].Trim();
                            string pic = fields[4].Trim();
                            string group = fields[5].Trim();
                            string popularity = fields[6].Trim();
                            

                            Property property = new Property(location, propName, price, pic, group, popularity);
                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}