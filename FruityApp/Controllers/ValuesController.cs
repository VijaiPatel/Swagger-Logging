using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
//using FruityAppy.Controllers;

namespace FruityApp.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        List<string> fruitList = new List<string>
        {

        };

        public ValuesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<string> Get()
        {
            //List<string> fruitList = new List<string>();
            string filepath = @"C:\Users\Vj\source\repos\FruityApp\FruityApp\FruitFile.txt";
            string text = System.IO.File.ReadAllText(filepath);
            foreach(string line in text.Split(","))
            {
                fruitList.Add(line);
            }
            _logger.LogError("Get performed sucessfully!!");
            return fruitList;

        }
        [HttpPost]
        public string? PostValue([FromBody] string? value)
        {
            //List<string> fruitList = new List<string>();
            if (value != null && value != "")
            {
                string filepath = @"C:\Users\Vj\source\repos\FruityApp\FruityApp\FruitFile.txt";
                string text = System.IO.File.ReadAllText(filepath);
                string totalText = (string)text + "," + value;
                System.IO.File.WriteAllText(filepath, totalText);
                foreach (string line in totalText.Split(","))
                {
                    fruitList.Add(line);
                }
            }
            if (value != null && value != "")
            {
                _logger.LogInformation($" Added sucessfully : value : { value}");
                return "Added sucessfully.";
            }
            else
            {
                _logger.LogError("Bad data action unsecessfull");
                return "NOT ADDED, check data in right format.";
            }
        }
    }
}
