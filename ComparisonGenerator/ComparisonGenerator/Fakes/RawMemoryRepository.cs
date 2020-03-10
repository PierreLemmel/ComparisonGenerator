using ComparisonGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.DataAccess
{
    public class RawComparisonRepository : IRepository<ComparisonReadModel>
    {
        private readonly ICollection<ComparisonReadModel> rawMemoryRepo = new List<ComparisonReadModel>()
        {
            new ComparisonReadModel
            {
                Id = Guid.NewGuid(),
                Content = "Les enfants c'est comme les prises électriques : faut pas mettre les doigts dedans",
                Author = "Pierre Lemmel"
            },
            new ComparisonReadModel
            {
                Id = Guid.NewGuid(),
                Content = "Les bites, c'est comme le fromage : des fois ça pue",
                Author = "Pierre Lemmel"
            }
        };

        public async Task Add(ComparisonReadModel comp)
        {
            rawMemoryRepo.Add(comp);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<ComparisonReadModel>> Get() => await Task.FromResult(rawMemoryRepo);
    }
}
