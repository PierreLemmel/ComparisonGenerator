using System;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.Events
{
    public interface IEventStore
    {
        void RegisterHandler<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
        Task HandleEvent<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}