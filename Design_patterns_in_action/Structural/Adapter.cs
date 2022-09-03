namespace Design_patterns_in_action.Structural
{
    // adapter vs decorator
    // state vs strategy
    // observable vs Mediator
    //
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
    // when you have source code that you can't modified so you can't change it and you want to consume his code
    class WildDog
    {
        public void bark()
        {
        }
    }
    // Adapter around wild dog to make it compatible with our game
    class WildDogAdapter : WildDog, ILion
    {

        public void Roar()
        {
            bark();
        }
    }
}
