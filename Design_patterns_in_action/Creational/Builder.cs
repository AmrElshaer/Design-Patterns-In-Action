using System.Text;

namespace Design_patterns_in_action.Creational
{
    //avoiding constructor pollution.
    // Burger(int size, bool cheese, bool pepperoni, bool lettuce, bool tomato)
    class Burger
    {
        private int mSize;
        private bool mCheese;
        private bool mPepperoni;
        private bool mLettuce;
        private bool mTomato;

        public Burger(BurgerBuilder builder)
        {
            this.mSize = builder.Size;
            this.mCheese = builder.Cheese;
            this.mPepperoni = builder.Pepperoni;
            this.mLettuce = builder.Lettuce;
            this.mTomato = builder.Tomato;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.Append($"This is {this.mSize} inch Burger. ");
            return sb.ToString();
        }
    }
    class BurgerBuilder
    {
        public int Size;
        public bool Cheese;
        public bool Pepperoni;
        public bool Lettuce;
        public bool Tomato;

        public BurgerBuilder(int size)
        {
            this.Size = size;
        }

        public BurgerBuilder AddCheese()
        {
            this.Cheese = true;
            return this;
        }

        public BurgerBuilder AddPepperoni()
        {
            this.Pepperoni = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            this.Lettuce = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            this.Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(this);
        }
    }
}
