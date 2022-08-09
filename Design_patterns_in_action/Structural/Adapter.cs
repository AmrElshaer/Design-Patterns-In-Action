namespace Design_patterns_in_action.Structural
{
    interface ILion
    {
        void Roar();
    }

    class AfricanLion : ILion
    {
        public void Roar()
        {

        }
    }

    class AsiaLion : ILion
    {
        public void Roar()
        {

        }
    }
    class Hunter
    {
        public void Hunt(ILion lion)
        {

        }
    }
    class WildDog
    {
        public void bark()
        {
        }
    }
    // Adapter around wild dog to make it compatible with our game
    class WildDogAdapter : ILion
    {
        private WildDog mDog;
        public WildDogAdapter(WildDog dog)
        {
            this.mDog = dog;
        }
        public void Roar()
        {
            mDog.bark();
        }
    }
}
