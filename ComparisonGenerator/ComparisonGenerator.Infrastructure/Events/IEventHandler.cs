using System;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.Events
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        Task HandleEvent(TEvent evt);
    }
}