class Employee
{
    public string Name { get; set; }
    public int EmployeeID { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }

    public Employee(string name, string title, DateTime startDate)
    {
        Name = name;
        EmployeeID = GenerateEmployeeID();
        Title = title;
        StartDate = startDate;
    }

    private int GenerateEmployeeID()
    {
        Random random = new Random();
        return random.Next(1000, 10000); 
    }

    public override string ToString()
    {
        return $"Employee ID: {EmployeeID}, Name: {Name}, Title: {Title}, Start Date: {StartDate.ToShortDateString()}";
    }
}
