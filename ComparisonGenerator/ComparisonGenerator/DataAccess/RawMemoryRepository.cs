using ComparisonGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonGenerator.DataAccess
{
    public class RawComparisonRepository : IRepository<ComparisonModel>
    {
        private readonly ICollection<ComparisonModel> rawMemoryRepo = new List<ComparisonModel>()
        {
            new ComparisonModel
            { 
                LeftHandSide = "Les enfants",
                RightHandSide = "les prises électriques",
                Body = "faut pas mettre les doigts dedans",
                Author = "Pierre Lemmel"
            },
            new ComparisonModel
            {
                LeftHandSide = "Les bites",
                RightHandSide = "le fromage",
                Body = "des fois ça pue",
                Author = "Pierre Lemmel"
            }
        };

        public async Task Add(ComparisonModel comp)
        {
            rawMemoryRepo.Add(comp);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<ComparisonModel>> Get() => await Task.FromResult(rawMemoryRepo);
    }
}
