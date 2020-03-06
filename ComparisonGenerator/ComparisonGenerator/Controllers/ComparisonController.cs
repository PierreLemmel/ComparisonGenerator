using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComparisonGenerator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComparisonGenerator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComparisonController : ControllerBase
    {
        private readonly ILogger<ComparisonController> logger;

        public ComparisonController(ILogger<ComparisonController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<ComparisonModel> Get()
        {
            yield return new ComparisonModel("Les enfants", "les prises électriques", "faut pas mettre les doigts dedans");
            yield return new ComparisonModel("Les bites", "le fromage", "des fois ça pue");
        }
    }
}