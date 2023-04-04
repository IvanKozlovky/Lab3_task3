using System;

class Employee
{
    public string Surname { get; set; }
    public double Salary { get; set; }
    public int StartYear { get; set; }

    public Employee()
    {
        Surname = "NoName";
        Salary = 0.0;
        StartYear = DateTime.Now.Year;
    }

    public Employee(string surname, double salary, int startYear)
    {
        Surname = surname;
        Salary = salary;
        StartYear = startYear;
    }

    public int CalculateWorkExperience()
    {
        return DateTime.Now.Year - StartYear;
    }

    public int DaysSinceStartYear()
    {
        DateTime startDate = new DateTime(StartYear, 1, 1);
        return (DateTime.Now - startDate).Days;
    }

    public override string ToString()
    {
        return $"Surname: {Surname}, Salary: {Salary}, Start Year: {StartYear}";
    }
}

class CompanyEmployee : Employee
{
    public int BirthYear { get; set; }

    public CompanyEmployee() : base()
    {
        BirthYear = DateTime.Now.Year;
    }

    public CompanyEmployee(string surname, double salary, int startYear, int birthYear) : base(surname, salary, startYear)
    {
        BirthYear = birthYear;
    }

    public int YearsTo60OrAfter60()
    {
        int age = DateTime.Now.Year - BirthYear;
        if (age < 60)
        {
            return 60 - age;
        }
        else
        {
            return age - 60;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", Birth Year: {BirthYear}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee("Ivanov", 35000, 2010);
        Console.WriteLine(employee.ToString());
        Console.WriteLine("Work experience: " + employee.CalculateWorkExperience());
        Console.WriteLine("Days since start year: " + employee.DaysSinceStartYear());

        CompanyEmployee companyEmployee = new CompanyEmployee("Petrov", 40000, 2005, 1970);
        Console.WriteLine(companyEmployee.ToString());
        Console.WriteLine("Work experience: " + companyEmployee.CalculateWorkExperience());
        Console.WriteLine("Days since start year: " + companyEmployee.DaysSinceStartYear());
        Console.WriteLine("Years to 60 or after 60: " + companyEmployee.YearsTo60OrAfter60());
    }
}