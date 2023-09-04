/* it was funny*/

       string employeetext = "employees.txt";
        List<Employee> employees = new List<Employee>();
        LoadEmployeesFromFile(employees);

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("1. Create a new employee");
            Console.WriteLine("2. View all employees");
            Console.WriteLine("3. Search for an employee");
            Console.WriteLine("4. Delete an employee by their Employee ID");
            Console.WriteLine("5. Exit");
            Console.Write("*************************************\n");
            Console.WriteLine("Enter Your Choice :  ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewEmployee(employees);
                        break;
                    case 2:
                        ViewAllEmployees(employees);
                        break;
                    case 3:
                        search(employees);
                        break;
                    
                    case 4:
                        DeleteEmployeeByID(employees);
                        break;
                    case 5:
                        SaveEmployeesToFile(employees);
                        exit = true;
                        Console.WriteLine("GoodBye!!");
                        break;
                    default:
                        Console.WriteLine("incorrect choice, Please select a valid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Choice. Please enter a valid choice.");
            }

            Console.WriteLine();
        }
    

     void LoadEmployeesFromFile(List<Employee> employees)
    {
        if (File.Exists(employeetext))
        {
            using (StreamReader reader = new StreamReader(employeetext))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] employeeData = line.Split(';');

                    if (employeeData.Length == 4 && int.TryParse(employeeData[0], out int employeeID) && DateTime.TryParse(employeeData[3], out DateTime startDate)) {
                       
                        employees.Add(new Employee(employeeData[1], employeeData[2], startDate){
                            EmployeeID = employeeID
                        });
                    }
                }
            }
        }
    }
     void SaveEmployeesToFile(List<Employee> employees)
    {
        using (StreamWriter writer = new StreamWriter(employeetext))
        {
            foreach (Employee employee in employees)
            {
                writer.WriteLine($"{employee.EmployeeID}|{employee.Name}|{employee.Title}|{employee.StartDate.ToShortDateString()}");
            }
        }
    }

   void CreateNewEmployee(List<Employee> employees)
    {
        Console.Write("Enter the employee's name: ");
        string name = Console.ReadLine()??"";

        Console.Write("Enter the employee's title: ");
        string title = Console.ReadLine()??"";

        DateTime startDate;
        do
        {
            Console.Write("Enter the employee's start date (yyyy-MM-dd): ");
           
        } while (!DateTime.TryParse(Console.ReadLine(), out startDate));

        Employee newEmployee = new Employee(name, title, startDate);
        employees.Add(newEmployee);
         foreach (Employee employee in employees)
            {
                Console.WriteLine("\n" + newEmployee);
            }
            
        Console.WriteLine("New employee Added and successfuly.");
    }

    void ViewAllEmployees(List<Employee> employees)
    {
        if (employees.Count > 0)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("All Employees :");
            Console.WriteLine("****************");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }
    void search(List<Employee> employees){
        Console.WriteLine("******************");
        Console.WriteLine(" 1. Search By Id");
        Console.WriteLine(" 2. Search By Name");
        Console.WriteLine("******************\n");

    if (int.TryParse(Console.ReadLine(), out int choicesearch))
            {
                switch (choicesearch)
                {
                    case 1:
                    SearchEmployeeByID(employees);
                    break;
                    case 2:
                    SearchEmployeeByName(employees);
                    break;
                    default :
                    Console.WriteLine("Inavalid Choice! Try Again!");
                    break;

    }
            }
    }
     

   void SearchEmployeeByID(List<Employee> employees)
    {
        Console.Write("Enter an employee ID to search for: ");
        if (int.TryParse(Console.ReadLine(), out int searchID))
        {
            Employee employee = employees.FirstOrDefault(e => e.EmployeeID == searchID);
            if (employee != null)
            {
                Console.WriteLine("Employee found successfully:");
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid employee ID.");
        }
    }

    void SearchEmployeeByName(List<Employee> employees)
    {
        Console.Write("Enter the name to search for: ");
        string searchName = Console.ReadLine()??"";

        List<Employee> findEmployees = employees
            .Where(e => e.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        if (findEmployees.Count > 0)
        {
            Console.WriteLine("Found Employees:");
            foreach (Employee employee in findEmployees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }

    void DeleteEmployeeByID(List<Employee> employees)
    {
        Console.Write("Enter the employee ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int deleteID))
        {
            Employee employeeToDelete = employees.FirstOrDefault(e => e.EmployeeID == deleteID);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
                Console.WriteLine("Employee has been Deleted.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid employee ID.");
        }
    }
