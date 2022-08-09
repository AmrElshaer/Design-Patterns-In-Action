namespace Design_patterns_in_action.Structural
{
    // Facade pattern provides a simplified interface to a complex subsystem.
    //How do you turn on the computer? "Hit the power button" you say!
    //That is what you believe because you are using a simple interface that computer provides on the outside, internally it has to do a lot of stuff to make it happen.
    //This simple interface to the complex subsystem is a facade.
    class Computer
    {
        public void GetElectricShock()
        {
            Console.Write("Ouch!");
        }

        public void MakeSound()
        {
            Console.Write("Beep beep!");
        }

        public void ShowLoadingScreen()
        {
            Console.Write("Loading..");
        }

        public void Bam()
        {
            Console.Write("Ready to be used!");
        }

        public void CloseEverything()
        {
            Console.Write("Bup bup bup buzzzz!");
        }

        public void Sooth()
        {
            Console.Write("Zzzzz");
        }

        public void PullCurrent()
        {
            Console.Write("Haaah!");
        }
    }
    class ComputerFacade
    {
        private readonly Computer mComputer;

        public ComputerFacade(Computer computer)
        {
            this.mComputer = computer ?? throw new ArgumentNullException("computer", "computer cannot be null");
        }

        public void TurnOn()
        {
            mComputer.GetElectricShock();
            mComputer.MakeSound();
            mComputer.ShowLoadingScreen();
            mComputer.Bam();
        }

        public void TurnOff()
        {
            mComputer.CloseEverything();
            mComputer.PullCurrent();
            mComputer.Sooth();
        }
    }
}
