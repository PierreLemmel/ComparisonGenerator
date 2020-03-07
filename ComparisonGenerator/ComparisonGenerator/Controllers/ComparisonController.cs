using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComparisonGenerator.DataAccess;
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
        private readonly IRepository<ComparisonModel> repository;

        public ComparisonController(ILogger<ComparisonController> logger, IRepository<ComparisonModel> repository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IEnumerable<ComparisonModel>> Get() => await repository.Get();

        [HttpPut("add")]
        public async Task AddComparison(ComparisonModel comparison) => await repository.Add(comparison);
    }
}