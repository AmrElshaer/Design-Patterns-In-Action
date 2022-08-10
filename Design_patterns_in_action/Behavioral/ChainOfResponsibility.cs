namespace Design_patterns_in_action.Behavioral
{
    // It helps building a chain of objects. Request enters from one end and keeps going from object to object till it finds the suitable handler.
    public class ChainOfResponsibility
    {
        abstract class Account
        {
            private Account mSuccessor;
            protected decimal mBalance;

            public void SetNext(Account account)
            {
                mSuccessor = account;
            }

            public void Pay(decimal amountTopay)
            {
                if (CanPay(amountTopay))
                {
                    Console.WriteLine($"Paid {amountTopay:c} using {this.GetType().Name}.");
                }
                else if (this.mSuccessor != null)
                {
                    Console.WriteLine($"Cannot pay using {this.GetType().Name}. Proceeding..");
                    mSuccessor.Pay(amountTopay);
                }
                else
                {
                    throw new Exception("None of the accounts have enough balance");
                }
            }
            private bool CanPay(decimal amount)
            {
                return mBalance >= amount;
            }
        }

        class Bank : Account
        {
            public Bank(decimal balance)
            {
                this.mBalance = balance;
            }
        }

        class Paypal : Account
        {
            public Paypal(decimal balance)
            {
                this.mBalance = balance;
            }
        }

        class Bitcoin : Account
        {
            public Bitcoin(decimal balance)
            {
                this.mBalance = balance;
            }
        }
    }
}
