using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComparisonGenerator.Infrastructure.DataAccess;
using ComparisonGenerator.Infrastructure.Events;
using ComparisonGenerator.Logic.Events;
using ComparisonGenerator.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComparisonGenerator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComparisonController : ControllerBase
    {
        private readonly ILogger<ComparisonController> logger;
        private readonly IEventStore eventStore;
        private readonly IRepository<ComparisonReadModel> repository;
        private readonly IValidator<ComparisonCreateModel> createComparisonValidator;

        public ComparisonController(ILogger<ComparisonController> logger,
            IEventStore eventStore,
            IRepository<ComparisonReadModel> repository,
            IValidator<ComparisonCreateModel> createComparisonValidator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.createComparisonValidator = createComparisonValidator ?? throw new ArgumentNullException(nameof(createComparisonValidator));
        }

        [HttpGet]
        public async Task<IEnumerable<ComparisonReadModel>> Get() => await repository.Get();

        [HttpPut("add")]
        public async Task AddComparison(ComparisonCreateModel comparison)
        {

            await eventStore.HandleEvent(new ComparisonAdded(comparison.LeftHandSide, comparison.RightHandSide, comparison.Body, comparison.Author));
        }
    }
}