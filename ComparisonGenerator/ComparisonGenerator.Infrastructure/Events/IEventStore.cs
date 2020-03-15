using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.Events
{
    public interface IEventStore
    {
        Task HandleEvent<TEvent>(TEvent evt);
    }
}