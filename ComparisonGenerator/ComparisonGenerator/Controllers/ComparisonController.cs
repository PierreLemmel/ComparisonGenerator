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
        private readonly IRepository<ComparisonReadModel> repository;
        private readonly IComparandSource comparandSource;

        public ComparisonController(ILogger<ComparisonController> logger, IRepository<ComparisonReadModel> repository, IComparandSource comparandSource)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.comparandSource = comparandSource ?? throw new ArgumentNullException(nameof(comparandSource));
        }

        [HttpGet]
        public async Task<IEnumerable<ComparisonReadModel>> Get() => await repository.Get();

        [HttpGet("GetComparand")]
        public async Task<string> GetComparand() => await comparandSource.GetComparand();

        [HttpPut("add")]
        public async Task AddComparison(ComparisonCreateModel comparison) => await repository.Add(new ComparisonReadModel
        {
            Id = Guid.NewGuid(),
            Content = $"{comparison.LeftHandSide} c'est comme {comparison.RightHandSide} : {comparison.Body}",
            Author = comparison.Author
        });
    }
}