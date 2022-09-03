namespace Design_patterns_in_action.Behavioral
{
    // when the status  of object is change another object need to notify
    // push style of communication
    // pull style of communication
    public interface Observable
    {
        // pull style communication coupling
        // push style void Update(DataSource data)
        void Update();
    }

    public class Subject
    {
        private IList<Observable> _Observable = new List<Observable>();

        public void Add(Observable observable)
        {
            _Observable.Add(observable);
        }

        public void Remove(Observable observable)
        {
            _Observable.Remove(observable);
        }

        public void Notify()
        {
            foreach (var observable in _Observable)
            {
                observable.Update();
            }
        }
    }
    public class DataSource : Subject
    {
        private int a;
        private int b;

        public int GetA()
        {
            return this.a;
        }
        public void SetA(int value)
        {
            this.a = value;
            base.Notify();
        }
        public void SetB(int value)
        {
            this.b = value;
            base.Notify();
        }
        public int GetB()
        {
            return this.b;
        }


    }

    public class SpreadSheet : Observable
    {
        private int total;
        private readonly DataSource data;
        public SpreadSheet(DataSource data)
        {
            this.data = data;
        }
        public int Get()
        {
            return this.total;
        }

        public void Update()
        {
            this.total = data.GetA() + data.GetB();
        }
    }
    public class Chart : Observable
    {
        private readonly DataSource data;

        public Chart(DataSource data)
        {
            this.data = data;
        }

        public void Update()
        {
            Console.WriteLine($"Draw A=> {data.GetA()}");
            Console.WriteLine($"Draw B=> {data.GetB()}");
        }
    }


}
