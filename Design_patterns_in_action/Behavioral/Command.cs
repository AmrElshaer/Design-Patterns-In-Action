using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns_in_action.Behavioral
{
    public class EventSourcingImplementation
    {
        public abstract class IEvent{
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
        public class EventStore
        {
            private readonly List<IEvent> events = new List<IEvent>();

            public void AppendEvent(IEvent @event)
            {
                events.Add(@event);
            }

            public IEnumerable<IEvent> GetEvents()
            {
                return events;
            }
        }
        public class OrderCreatedEvent : IEvent
        {
            private readonly int orderId;
            private readonly string customerName;
            private readonly decimal totalAmount;

            public OrderCreatedEvent(int orderId, string customerName, decimal totalAmount)
            {
                this.orderId = orderId;
                this.customerName = customerName;
                this.totalAmount = totalAmount;
            }

            public void Execute(EventStore eventStore)
            {
                var orderCreatedEvent = new OrderCreatedEvent(orderId, customerName, totalAmount);
                eventStore.AppendEvent(orderCreatedEvent);
            }
        }
        public interface ICommand
        {
            void Execute(EventStore eventStore);
        }
        public class CreateOrderCommand : ICommand
        {
            private readonly int orderId;
            private readonly string customerName;
            private readonly decimal totalAmount;

            public CreateOrderCommand(int orderId, string customerName, decimal totalAmount)
            {
                this.orderId = orderId;
                this.customerName = customerName;
                this.totalAmount = totalAmount;
            }

            public void Execute(EventStore eventStore)
            {
                var orderCreatedEvent = new OrderCreatedEvent(orderId, customerName, totalAmount);
                eventStore.AppendEvent(orderCreatedEvent);
            }
        }
        public class CommandProcessor
        {
            private readonly IEnumerable<ICommand> commands;

            public CommandProcessor(IEnumerable<ICommand> commands)
            {
                this.commands = commands;
            }

            public void Execute(EventStore eventStore)
            {
                foreach (var command in commands)
                {
                    command.Execute(eventStore);
                }
            }
        }
    }
    public class CommandTest
    {
        public static void Run()
        {
            var entity = new Entity();
            var commandQueue = new CommandQueue();
            commandQueue.EnqueueCommand(new CreateEntity(entity));
            commandQueue.EnqueueCommand(new UpdateCommand(entity, "New Name"));
            commandQueue.ExecuteCommands();
        }
    }
    //Undo-Redo functionality,Batch processing, logging, queuing, scheduling, and transactions.
    // convert from request to object from .AddOrder to new AddOrderCommand
    // The Command interface declares a method for executing a command.
    interface ICommand
    {
        void Execute();
    }
    public class CreateEntity : ICommand
    {
        private readonly Entity en;

        public CreateEntity(Entity en)
        {
            this.en = en;
        }
        public void Execute()
        {
            en.Create();
        }
    }
    public class UpdateCommand : ICommand
    {
        private readonly Entity en;
        private readonly string newName;

        public UpdateCommand(Entity en, string newName)
        {
            this.en = en;
            this.newName = newName;
        }
        public void Execute()
        {
            en.UpdateName(newName);
        }
    }
    class CommandQueue
    {
        private Queue<ICommand> commands = new Queue<ICommand>();

        public void EnqueueCommand(ICommand command)
        {
            commands.Enqueue(command);
        }

        public void ExecuteCommands()
        {
            while (commands.Count > 0)
            {
                var command = commands.Dequeue();
                command.Execute();
            }
        }
    }

    public class Entity
    {
        public string Name { get; private set; }

        public void Create()
        {
            Console.WriteLine("Entity created.");
        }

        public void UpdateName(string newName)
        {
            Console.WriteLine($"Entity name updated to {newName}.");
            Name = newName;
        }
    }


}
