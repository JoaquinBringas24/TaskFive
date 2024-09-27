using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TaskFive.Models;

namespace TaskFive.Controllers
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
            List<Record> values = new List<Record>();
            for (int i = 0; i < 20; i++)
            {
                Record record = new Record();
                record.RandomIdentifier = Guid.NewGuid().ToString();
                record.Name = "Name" + i;
                record.Adress = "Adress" + i;
                record.Phone = "+1 " + i;
                values.Add(record);
            }
            return View(values);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ApiCall(string region, int error, int seed)
        {
            var random = new Random(seed);

            int intValue; 
            string adress;
            string name;

            switch(region) {
                case "america":
                    intValue = 1;
                    adress = "USA";
                    name = "John";
                    break;

                case "mexico":
                    intValue = 52;
                    adress = "Mexico";
                    name = "Juan";
                    break;
                
                case "canada":
                    intValue = 1;
                    adress = "Canada";
                    name = "Jean";
                    break;

                default:
                    intValue = 53;
                    adress = "Argentina";
                    name = "Joaquin";
                    break;
            }

            List<Record> values = new List<Record>();
            for (int i = 0; i < 10; i++)
            {
                Record record = new Record();
                record.RandomIdentifier = Guid.NewGuid().ToString();
                record.Name = name;
                record.Adress = adress;
                record.Phone = $"+{intValue} {random.Next(100000000, 999999999)}";
                values.Add(record);
            }

            return Json(values);
        }
    }
}
