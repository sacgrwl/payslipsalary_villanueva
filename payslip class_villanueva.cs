namespace PaySlipCalculator
{
    class PaySlip
    {
        private Employee employee;
        private decimal basicSalary = 20000;
        private int workingDays = 15;
        private decimal absentDeduction = 1333;
        private decimal taxRate = 0.10m;

        public PaySlip(Employee employee)
        {
            this.employee = employee;
        }

        public void GeneratePaySlip()
        {
            int absents = GetAbsents();
            decimal totalSalary = CalculateTotalSalary(absents);

            
            Console.WriteLine("Pay Slip");
            Console.WriteLine("=========");
            Console.WriteLine($"Employee Number: {employee.EmployeeNumber}");
            Console.WriteLine($"Basic Salary: {basicSalary:C}");
            Console.WriteLine($"Working Days: {workingDays}");
            Console.WriteLine($"Absents: {absents}");
            Console.WriteLine($"Absent Deduction: {absentDeduction:C}");
            Console.WriteLine($"Tax Rate: {taxRate:P}");
            Console.WriteLine($"Total Salary: {totalSalary:C}");
            Console.WriteLine("=========");

            ProcessPayment();
        }

        private decimal CalculateTotalSalary(int absents)
        {
            decimal totalSalary = basicSalary;
            totalSalary -= (absentDeduction * absents);
            totalSalary -= (totalSalary * taxRate);
            return totalSalary;
        }

        private void ProcessPayment()
        {
            Console.WriteLine("Choose a payment method:");
            Console.WriteLine("1. GCASH");
            Console.WriteLine("2. Bank Transfer");
            Console.Write("Enter your choice: ");
            int paymentMethod = Convert.ToInt32(Console.ReadLine());

            string accountNumber;
            string bankName = null;

            switch (paymentMethod)
            {
                case 1:
                    accountNumber = GetGCashNumber();
                    break;
                case 2:
                    bankName = GetBankName();
                    accountNumber = GetBankAccountNumber(bankName);
                    break;
                default:
                    Console.WriteLine("Invalid payment method.");
                    return;
            }

            Console.WriteLine($"Salary transferred to {(paymentMethod == 1 ? "GCASH" : bankName)} account {accountNumber} successfully.");
        }

        private int GetAbsents()
        {
            Console.Write("Enter number of absents: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        private string GetGCashNumber()
        {
            string accountNumber;
            while (true)
            {
                Console.Write("Enter GCASH number (at least 11 digits): ");
                accountNumber = Console.ReadLine();
                if (accountNumber.Length >= 11)
                {
                    return accountNumber;
                }
                else
                {
                    Console.WriteLine("GCASH number must be at least 11 digits. Please try again.");
                }
            }
        }

        private string GetBankName()
        {
            Console.WriteLine("Choose a bank:");
            Console.WriteLine("1. BDO");
            Console.WriteLine("2. BPI");
            Console.WriteLine("3. METROBANK");
            Console.WriteLine("4. PNB");
            Console.WriteLine("5. SECURITY BANK");
            Console.WriteLine("6. UNIONBANK");
            Console.WriteLine("7. LANDBANK");
            Console.Write("Enter your choice: ");
            int bankChoice = Convert.ToInt32(Console.ReadLine());

            return bankChoice switch
            {
                1 => "BDO",
                2 => "BPI",
                3 => "METROBANK",
                4 => "PNB",
                5 => "SECURITY BANK",
                6 => "UNIONBANK",
                7 => "LANDBANK",
                _ => null
            };
        }

        private string GetBankAccountNumber(string bankName)
        {
            string accountNumber;
            while (true)
            {
                Console.Write($"Enter your {bankName} account number (at least 12 digits): ");
                accountNumber = Console.ReadLine();
                if (accountNumber.Length >= 12)
                {
                    return accountNumber;
                }
                else
                {
                    Console.WriteLine($"Account number must be at least 12 digits. Please try again.");
                }
            }
        }
    }
}
