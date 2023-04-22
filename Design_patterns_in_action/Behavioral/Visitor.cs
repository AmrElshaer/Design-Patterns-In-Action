namespace Design_patterns_in_action.Behavioral
{
    // adding new function to object without modified it
    // instead of modified interface and all concerned 
    // we add new operation to follow Open-closed
    // used when the design stable and operation is change lot
    //the Visitor design pattern is also a behavior pattern that allows you to separate an algorithm from an object structure on which it operates. This pattern allows you to add new operations to an object structure without modifying its objects.
    public abstract class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int VacationDays { get; set; }
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit((dynamic)this);
        }

    }
    public class Developer : Employee
    {
        public Developer(string name, decimal salary) : base(name, salary)
        {
        }


    }
    public class Designer : Employee
    {
        public Designer(string name, decimal salary) : base(name, salary)
        {

        }
    }
    public class Organization
    {
        private IList<Employee> _employees = new List<Employee>();
        public IEnumerable<Employee> Employees { get => this._employees; }
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (var employee in _employees)
            {
                employee.Accept(visitor);
            }
        }
    }
    public interface IVisitor
    {
        void Visit(Developer developer);
        void Visit(Designer designer);
    }
    public class IncomeVisitor : IVisitor
    {
        public void Visit(Developer developer)
        {
            developer.Salary *= 1.10M;
        }
        public void Visit(Designer designer)
        {
            designer.Salary *= 1.15M;
        }
    }
    public class VacationVisitor : IVisitor
    {
        public void Visit(Developer developer)
        {
            developer.VacationDays += 3;
        }
        public void Visit(Designer designer)
        {
            designer.VacationDays += 5;
        }
    }
    public class Execute
    {
        public void Main()
        {
            Organization organization = new Organization();
            organization.Add(new Developer("Adam Smith", 10000));
            organization.Add(new Developer("John Doe", 12000));
            organization.Add(new Designer("Jane Doe", 15000));
            organization.Add(new Designer("Mary Smith", 17000));
            organization.Add(new Designer("John Smith", 16000));
            organization.Add(new Designer("Mary Doe", 18000));
            organization.Add(new Developer("Adam Doe", 11000));
            organization.Add(new Developer("John Smith", 13000));
            organization.Add(new Designer("Jane Smith", 14000));
            organization.Add(new Designer("Mary Doe", 19000));
            organization.Accept(new IncomeVisitor());
            foreach (var employee in organization.Employees)
            {
                Console.WriteLine("{0} {1:C} {2} days", employee.Name, employee.Salary, employee.VacationDays);
            }
        }
    }
  
}
