namespace Design_patterns_in_action.Behavioral
{
    public class WebServer
    {
        private Handler handler;

        public WebServer(Handler handler)
        {
            this.handler = handler;
        }

        public void Handler(HttpRequest request)
        {
            handler.Handle(request);
        }
    }
    public class HttpRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class Authenticator : Handler
    {
        public Authenticator(Handler nextHandler) : base(nextHandler)
        {
        }

        protected override bool DoHandler(HttpRequest request)
        {
            var isValid = (request.UserName == "admin" && request.Password == "admin");
            Console.WriteLine("Authenticated");
            return !isValid;
        }
    }
    public class Compressor : Handler
    {
        public Compressor(Handler nextHandler) : base(nextHandler)
        {
        }

        protected override bool DoHandler(HttpRequest request)
        {

            Console.WriteLine("Compress");
            return false;
        }
    }
    public class Logger : Handler
    {
        public Logger(Handler nextHandler) : base(nextHandler)
        {
        }

        protected override bool DoHandler(HttpRequest request)
        {

            Console.WriteLine("Log");
            return false;
        }
    }
    public abstract class Handler
    {
        private readonly Handler next;

        protected Handler(Handler nextHandler)
        {
            this.next = nextHandler;
        }
        // template pattern
        public void Handle(HttpRequest request)
        {
            if (DoHandler(request))
            {
                return;
            }
            next?.Handle(request);

        }
        protected abstract bool DoHandler(HttpRequest request);
    }
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
