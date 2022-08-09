namespace Design_patterns_in_action.Structural
{
    //Composite pattern lets clients treat the individual objects in a uniform manner.
    //The composite pattern describes that a group of objects is to be treated in the same way as a single instance of an object
    interface IEmployee
    {
        float GetSalary();
        string GetRole();
        string GetName();
    }


    class Developer : IEmployee
    {
        private string mName;
        private float mSalary;

        public Developer(string name, float salary)
        {
            this.mName = name;
            this.mSalary = salary;
        }

        public float GetSalary()
        {
            return this.mSalary;
        }

        public string GetRole()
        {
            return "Developer";
        }

        public string GetName()
        {
            return this.mName;
        }
    }

    class Designer : IEmployee
    {
        private string mName;
        private float mSalary;

        public Designer(string name, float salary)
        {
            this.mName = name;
            this.mSalary = salary;
        }

        public float GetSalary()
        {
            return this.mSalary;
        }

        public string GetRole()
        {
            return "Designer";
        }

        public string GetName()
        {
            return this.mName;
        }
    }
    class Organization
    {
        protected List<IEmployee> employees;

        public Organization()
        {
            employees = new List<IEmployee>();
        }

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public float GetNetSalaries()
        {
            float netSalary = 0;

            foreach (var e in employees)
            {
                netSalary += e.GetSalary();
            }
            return netSalary;
        }
    }
}
