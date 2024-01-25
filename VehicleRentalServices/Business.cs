using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalServices
{
    public class Business
    {
        private string businessName;
        private double monthlyRevenue;
        private double monthlySalaryExpense;
        private Owner owner;
        private List<Employee> employees;
        private List<Contract> contracts;
        private List<Renter> renters;

        #region CONSTRUCTOR AND DESTRUCTOR
        public Business()
        {
            this.businessName = "";
            this.owner = new Owner();
            this.monthlyRevenue = 0;
            this.monthlySalaryExpense = 0;
            this.employees = new List<Employee>();
            this.contracts = new List<Contract>();
            this.renters = new List<Renter>();
        }
        public Business(string businessName, Owner owner)
        {
            this.businessName = businessName;
            this.owner = owner;
            this.monthlyRevenue = 0;
            this.monthlySalaryExpense = 0;
            this.employees = new List<Employee>();
            this.contracts = new List<Contract>();
            this.renters = new List<Renter>();
        }
        ~Business() { }
        #endregion

        #region PROPERTY
        public string BusinessName
        {
            get { return this.businessName; }
        }
        public double MonthlyRevenue
        {
            get { return this.monthlyRevenue; }
        }
        public double MonthlySalaryExpense
        {
            get { return this.monthlySalaryExpense; }
        }
        #endregion

        #region METHOD
        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee);
        }
        public void AddContract(Contract contract)
        {
            this.contracts.Add(contract);
        }
        public void AddRenter(Renter renter)
        {
            this.renters.Add(renter);
        }
        public void AddRangeEmployee(List<Employee> employee)
        {
            this.employees.AddRange(employee);
        }
        public void AddRangeContract(List<Contract> contract)
        {
            this.contracts.AddRange(contract);
        }
        public void AddRangeRenter(List<Renter> renter)
        {
            this.renters.AddRange(renter);
        }
        public void ClearEmployeeList()
        {
            this.employees.Clear();
        }
        public void ClearContractList()
        {
            this.contracts.Clear();
        }
        public void ClearRenterList()
        {
            this.renters.Clear();
        }
        public void CalculateMonthlyRevenue()
        {
            this.monthlyRevenue = 0;
            foreach (var item in contracts)
            {
                if (item.StartDate.Year == DateTime.Now.Year && item.StartDate.Month == DateTime.Now.Month)
                {
                    if (item.Paid)
                    {
                        this.monthlyRevenue += item.AfterSettlementValue;
                    }
                }
            }
        }
        public void CalculateMonthlySalaryExpense()
        {
            this.monthlySalaryExpense = 0;
            foreach (var item in employees)
            {
                item.CalculateSalary();
                this.monthlySalaryExpense += item.MonthlySalary;
            }
        }
        #endregion

        public void OutputInformation()
        {
            Console.WriteLine($"Business's Name : {this.businessName}");
            Console.WriteLine($"Business Owners : {this.owner.FullName}");
            Console.WriteLine($"Monthly Revenue : {this.monthlyRevenue}");
            Console.WriteLine($"Monthly Salary Expense: {this.monthlySalaryExpense}");
        }
    }
}
