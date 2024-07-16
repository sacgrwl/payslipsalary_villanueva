namespace PaySlipCalculator
{
    class Program
    {
        static Dictionary<string, string> accounts = new Dictionary<string, string>();
        static Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
        static int employeeNumber = 1000;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = ReadPassword(false);

            if (accounts.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Please try again.");
                return;
            }

            accounts.Add(username, password);
            employees.Add(username, new Employee(employeeNumber++.ToString()));
            Console.WriteLine("Account created successfully.");
        }

        static void Login()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = ReadPassword(false);

            if (!accounts.ContainsKey(username) || accounts[username] != password)
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                return;
            }

            Employee employee = employees[username];
            PaySlip paySlip = new PaySlip(employee);
            paySlip.GeneratePaySlip();
        }

        static string ReadPassword(bool hide)
        {
            string password = "";
            ConsoleKeyInfo info;

            do
            {
                info = Console.ReadKey(true);

                if (info.Key != ConsoleKey.Enter)
                {
                    if (info.Key == ConsoleKey.Backspace)
                    {
                        if (password.Length > 0)
                        {
                            Console.Write("\b \b"); 
                            password = password.Substring(0, password.Length - 1);
                        }
                    }
                    else
                    {
                        Console.Write(hide ? "*" : info.KeyChar.ToString());
                        password += info.KeyChar;
                    }
                }
            }
            while (info.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }

    class Employee
    {
        public string EmployeeNumber { get; set; }

        public Employee(string employeeNumber)
        {
            EmployeeNumber = employeeNumber;
        }
    }
}
