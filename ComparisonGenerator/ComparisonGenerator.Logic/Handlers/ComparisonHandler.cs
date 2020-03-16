using System;
using System.Threading.Tasks;
using ComparisonGenerator.Infrastructure.DataAccess;
using ComparisonGenerator.Infrastructure.Events;
using ComparisonGenerator.Logic.Events;
using ComparisonGenerator.Models;

namespace ComparisonGenerator.Logic.Handlers
{
    public class ComparisonHandler : IEventHandler<ComparisonAdded>
    {
        private readonly IRepository<ComparisonReadModel> repository;

        public ComparisonHandler(IRepository<ComparisonReadModel> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task HandleEvent(ComparisonAdded comparison)
        {
            ComparisonReadModel readModel = new ComparisonReadModel
            {
                Content = $"{comparison.LeftPart} c'est comme {comparison.RightPart} : {comparison.Body}",
                Author = comparison.Author
            };

            await repository.Add(readModel);
        }
    }
}
