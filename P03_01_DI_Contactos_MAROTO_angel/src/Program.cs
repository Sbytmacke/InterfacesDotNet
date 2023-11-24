using controllers;
using repositories;
using view;

class Program
{
    static void Main()
    {
        // Fachade
        var employeesRepository = new EmployeeRepositoryImpl();
        var departmentRepository = new DepartmentRepositoryImpl();

        var employeesController = new EmployeeControllerImpl(employeesRepository, departmentRepository);
        var departmentController = new DepartmentControllerImpl(employeesRepository, departmentRepository);

        var employeeView = new EmployeeView(employeesController);
        var departmentView = new DepartmentView(departmentController);

        StartSimulation(employeeView, departmentView);
    }

    private static void StartSimulation(EmployeeView employeeView, DepartmentView departmentView)
    {
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("======= CRUD Menu =======");
            Console.WriteLine("1. Employee Menu");
            Console.WriteLine("2. Department Menu");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            Console.WriteLine("\n");

            if (int.TryParse(Console.ReadLine(), out int menuChoice))
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

                switch (menuChoice)
                {
                    case 1:
                        employeeView.ShowEmployeeMenu();
                        break;
                    case 2:
                        departmentView.ShowDepartmentMenu();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

