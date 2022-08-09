namespace Design_patterns_in_action.Structural
{
    // the decorator pattern is a design pattern that allows behavior to be added to an individual object
    //either statically or dynamically, without affecting the behavior of other objects from the same class. The decorator pattern is often useful for adhering to the Single Responsibility Principle, as it allows functionality to be divided between classes with unique areas of concern.
    interface ICoffee
    {
        int GetCost();
        string GetDescription();
    }

    class SimpleCoffee : ICoffee
    {
        public int GetCost()
        {
            return 5;
        }

        public string GetDescription()
        {
            return "Simple Coffee";
        }
    }
    class MilkCoffee : ICoffee
    {
        private readonly ICoffee mCoffee;

        public MilkCoffee(ICoffee coffee)
        {
            mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
        }
        public int GetCost()
        {
            return mCoffee.GetCost() + 1;
        }

        public string GetDescription()
        {
            return String.Concat(mCoffee.GetDescription(), ", milk");
        }
    }

    class WhipCoffee : ICoffee
    {
        private readonly ICoffee mCoffee;

        public WhipCoffee(ICoffee coffee)
        {
            mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
        }
        public int GetCost()
        {
            return mCoffee.GetCost() + 1;
        }

        public string GetDescription()
        {
            return String.Concat(mCoffee.GetDescription(), ", whip");
        }
    }

    class VanillaCoffee : ICoffee
    {
        private readonly ICoffee mCoffee;

        public VanillaCoffee(ICoffee coffee)
        {
            mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
        }
        public int GetCost()
        {
            return mCoffee.GetCost() + 1;
        }

        public string GetDescription()
        {
            return String.Concat(mCoffee.GetDescription(), ", vanilla");
        }
    }
}
