using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns_in_action.Behavioral
{
    internal class MacroCommand
    {
        public void Run()
        {
            var accountId = 1;
            var account = new Account(accountId);
            var depositeCommand = new DepositeCommond(account, 200);
            var drawCommand = new DrawCommond(account, 50);
            var deposite = new DepositeCommond(account, 300);
            var invoker = new CommanInvoker(new List<IAccountCommand>
               { depositeCommand, drawCommand , deposite });
            MacroStorage macroStorage = MacroStorage.Instance;
            macroStorage.CreateMacro(invoker.GetCommands(), accountId);
            var macros = macroStorage.GetMacros();
            foreach (var macro in macros)
            {
                Console.WriteLine($"Macro Id {macro.Id} Created At {macro.CreatedAt}");
            }
            invoker.ExecuteCommands();
            Replay(accountId);
            void Replay(int accountId)
            {
                var macro = macroStorage.GetAccountMacro(accountId);
                var account = new Account(accountId);
                var commands = macro.Commands.ToList();
                var invoker = new CommanInvoker();
                foreach (var item in commands)
                {
                    item.SetAccount(account);
                    invoker.AddCommands(item);
                }
                invoker.ExecuteCommands();

            }

        }

        class Account
        {

            public Account(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
            public decimal Amount { get; set; }
            public void Deposite(decimal amount)
            {
                if (amount <= 0) return;
                this.Amount += amount;
                Console.WriteLine($"The account {this.Id} Deposite {amount} and the current {this.Amount}");
            }
            public void Draw(decimal amount)
            {
                if (amount > this.Amount) return;
                this.Amount -= amount;
                Console.WriteLine($"The account {this.Id} Draw {amount} and the current {this.Amount}");

            }
        }
        abstract class IAccountCommand
        {
            protected Account account;

            protected IAccountCommand(Account account)
            {
                this.account = account;
            }
            public void SetAccount(Account account)
            {
                this.account = account;
            }
            public abstract void Execute();
        }
        class DepositeCommond : IAccountCommand
        {

            private decimal amount;
            public DepositeCommond(Account account, decimal amount) : base(account)
            {
                this.amount = amount;
            }
            public override void Execute()
            {
                account.Deposite(amount);
            }
        }
        class DrawCommond : IAccountCommand
        {

            private decimal amount;

            public DrawCommond(Account account, decimal amount)
                : base(account)
            {
                this.amount = amount;
            }

            public override void Execute()
            {
                this.account.Draw(amount);
            }
        }

        class CommanInvoker
        {
            List<IAccountCommand> commands = new();
            public CommanInvoker(List<IAccountCommand> commands)
            {
                this.commands = commands;
            }
            public CommanInvoker()
            {

            }
            public void AddCommands(IAccountCommand accountCommand)
            {
                this.commands.Add(accountCommand);
            }
            public void ExecuteCommands()
            {
                foreach (IAccountCommand command in commands)
                {
                    command.Execute();
                }
                ClearCommands();
            }
            public IEnumerable<IAccountCommand> GetCommands()
            {
                return this.commands.ToList();
            }
            private void ClearCommands()
            {
                commands.Clear();
            }
        }
        class Macro
        {
            public Macro(int id, IEnumerable<IAccountCommand> commands, int accountId)
            {
                this.Id = id;
                this.Commands = commands;
                AccountId = accountId;

            }
            public int Id { get; set; }
            public int AccountId { get; set; }
            public IEnumerable<IAccountCommand> Commands { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
        class MacroStorage
        {
            private MacroStorage()
            {

            }
            private static MacroStorage _instance;
            public static MacroStorage Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new MacroStorage();
                    }
                    return _instance;
                }
            }
            private List<Macro> macros = new();
            public void CreateMacro(IEnumerable<IAccountCommand> commands, int accountId)
            {
                var macro = new Macro(macros.Count + 1, commands, accountId);
                macros.Add(macro);
            }
            public IEnumerable<Macro> GetMacros()
            {

                return macros.AsReadOnly();

            }
            public Macro GetAccountMacro(int accountId)
            {
                return macros.FirstOrDefault(m => m.AccountId == accountId);
            }

        }
    }
}
