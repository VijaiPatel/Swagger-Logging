using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace FruityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        List<string> fruitList = new List<string>
        {
            "Apple: 24",
            "Banana: 15",
            "Grapes: 10"
            };
        public ValuesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public List<string> Get()
        {
            return fruitList;

        }
    }
}
