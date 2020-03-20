using ComparisonGenerator.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.Events
{
    public class EventStore : IEventStore
    {
        private readonly IDictionary<Type, ICollection<Func<IEvent, Task>>> handlers = new Dictionary<Type, ICollection<Func<IEvent, Task>>>();
        private readonly IRepository<Event> evtRepository;

        public EventStore(IRepository<Event> repository)
        {
            evtRepository = repository;
        }

        public void RegisterHandler<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            Type evtType = typeof(TEvent);

            ICollection<Func<IEvent, Task>> typedHandlers;
            if (handlers.ContainsKey(evtType))
            {
                typedHandlers = handlers[evtType];
            }
            else
            {
                typedHandlers = new List<Func<IEvent, Task>>();
                handlers[evtType] = typedHandlers;
            }

            typedHandlers.Add(f => handler.HandleEvent((TEvent)f));
        }

        public async Task HandleEvent<TEvent>(TEvent evt) where TEvent : IEvent
        {
            await StoreEvent(evt);

            Type evtType = typeof(TEvent);
            if (handlers.TryGetValue(evtType, out ICollection<Func<IEvent, Task>> evtTypeHandlers))
            {
                foreach(Func<IEvent, Task> handler in evtTypeHandlers)
                {
                    await handler(evt);
                }
            }
        }

        private async Task StoreEvent<TEvent>(TEvent evt) where TEvent : IEvent
        {
            Event data = new Event()
            {
                Type = typeof(TEvent).Name,
                JsonContent = JsonSerializer.Serialize(evt),
            };

            await evtRepository.Add(data);
        }
    }
}
