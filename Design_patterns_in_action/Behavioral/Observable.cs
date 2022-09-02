namespace Design_patterns_in_action.Behavioral
{
    // when the status  of object is change another object need to notify
    public interface Observable
    {
        void Update(DataSource dataSource);
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

        public void Notify(DataSource dataSource)
        {
            foreach (var observable in _Observable)
            {
                observable.Update(dataSource);
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
            base.Notify(this);
        }
        public void SetB(int value)
        {
            this.b = value;
            base.Notify(this);
        }
        public int GetB()
        {
            return this.b;
        }


    }

    public class SpreadSheet : Observable
    {
        private int total;
        public int Get()
        {
            return this.total;
        }

        public void Update(DataSource data)
        {
            this.total = data.GetA() + data.GetB();
        }
    }
    public class Chart : Observable
    {
        public void Update(DataSource data)
        {
            Console.WriteLine($"Draw A=> {data.GetA()}");
            Console.WriteLine($"Draw B=> {data.GetB()}");
        }
    }


}
