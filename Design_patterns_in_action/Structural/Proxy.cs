namespace Design_patterns_in_action.Structural
{
    // Using the proxy pattern, a class represents the functionality of another class.
    interface IDoorProxy
    {
        void Open();
        void Close();
    }

    class LabDoor : IDoorProxy
    {
        public void Close()
        {
            Console.WriteLine("Closing lab door");
        }

        public void Open()
        {
            Console.WriteLine("Opening lab door");
        }
    }
    class SecuredDoor : IDoorProxy
    {
        private IDoorProxy mDoor;

        public SecuredDoor(IDoorProxy door)
        {
            mDoor = door ?? throw new ArgumentNullException("door", "door can not be null");
        }

        public void Open(string password)
        {
            if (Authenticate(password))
            {
                mDoor.Open();
            }
            else
            {
                Console.WriteLine("Big no! It ain't possible.");
            }
        }

        private bool Authenticate(string password)
        {
            return password == "$ecr@t";
        }


        public void Open()
        {
            mDoor.Open();
        }

        public void Close()
        {
            mDoor.Close();
        }
    }
}
