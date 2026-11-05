public abstract class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal BaseSalary { get; protected set; }

    protected Employee(string name, decimal salary)
    {
        Name = name;
        BaseSalary = salary;
    }

    public abstract decimal CalculateSalary();
}

public class Manager : Employee
{
    public decimal Bonus { get; set; }

    public Manager(string name, decimal salary, decimal bonus)
        : base(name, salary)
    {
        Bonus = bonus;
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + Bonus;
    }
}

public class Developer : Employee
{
    public int ProjectsCompleted { get; set; }

    public Developer(string name, decimal salary)
        : base(name, salary) { }

    public override decimal CalculateSalary()
    {
        return BaseSalary + (ProjectsCompleted * 100);
    }
}

public class PayrollService
{
    public void ProcessPayroll(IEnumerable<Employee> employees)
    {
        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"{employee.Name}: €{employee.CalculateSalary():F2}"
            );
        }
    }
}