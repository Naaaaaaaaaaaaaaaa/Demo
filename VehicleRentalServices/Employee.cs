using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalServices
{
    public class Employee : Person
    {
        protected DateTime joinDate;
        protected List<Contract> contractHistory;
        protected double monthlySalary;
        protected double averageRating;
        public double TotalContractValue => contractHistory.Sum(contract => contract.AfterSettlementValue);

        #region CONSTRUCTOR AND DESTRUCTOR
        public Employee()
        {
            this.joinDate = DateTime.Now;
            this.contractHistory = new List<Contract>();
            this.feedbackHistory = new List<Feedback>();
            this.monthlySalary = 0;
            this.averageRating = 0;
        }
        public Employee(string fullName, string id, DateTime dateOfBirth, string phoneNumber, DateTime joinDate)
        : base(fullName, id, dateOfBirth, phoneNumber)
        {
            this.joinDate = joinDate;
            this.contractHistory = new List<Contract>();
            this.feedbackHistory = new List<Feedback>();
            this.monthlySalary = 0;
            this.averageRating = 0;
        }
        ~Employee() {}
        #endregion

        #region PROPERTY
        public DateTime JointDate
        {
            get { return this.joinDate; }
        }
        public double MonthlySalary
        {
            get { return this.monthlySalary; }
        }
        public double AverageRating
        {
            get { return this.averageRating; }
        }
        public List<Contract> ContractHistory
        {
            get { return this.contractHistory; }
        }
        #endregion

        #region METHOD
        public void AddContract(Contract contract)
        {
            this.contractHistory.Add(contract);
        }
        public void CalculateSalary()
        {
            double baseSalary = CalculateBaseSalary();
            double percentageOnContract = CalculatePercentageOnContract();
            double totalContractValue = CalculateTotalContractValue();
            double percentageFeedbackBonus = CalculatePercentageFeedbackBonus();
            this.monthlySalary = 0;
            this.monthlySalary += baseSalary + percentageOnContract * totalContractValue;
            this.monthlySalary += percentageFeedbackBonus * this.monthlySalary;
        }
        public int CalculateYearsInBusiness()
        {
            return DateTime.Now.Year - joinDate.Year;
        }
        public virtual double CalculateBaseSalary()
        {
            return 0;
        }
        public virtual double CalculatePercentageOnContract()
        {
            return 0;
        }
        public double CalculateTotalContractValue()
        {
            double totalContractValue = 0;
            foreach (var item in contractHistory)
            {
                if (item.Paid == true)
                {
                    totalContractValue += item.PreSettlementValue;
                }
            }
            return totalContractValue;
        }
        public double CalculatePercentageFeedbackBonus()
        {
            int yearsInBusiness = CalculateYearsInBusiness();
            double averageFeedbackRating = CalculateAverageFeedbackRating();
            if (yearsInBusiness >= 1 && yearsInBusiness <= 2){
                if (averageFeedbackRating >= 1 && averageFeedbackRating < 2) return -0.1;
                if (averageFeedbackRating >= 2 && averageFeedbackRating < 3) return -0.05;
                if (averageFeedbackRating >= 3 && averageFeedbackRating < 4) return 0.0;
                if (averageFeedbackRating >= 4 && averageFeedbackRating < 5) return 0.05;
                if (averageFeedbackRating >= 5) return 0.1;
            }
            if (yearsInBusiness >= 3 && yearsInBusiness <= 5){
                if (averageFeedbackRating >= 1 && averageFeedbackRating < 2) return -0.15;
                if (averageFeedbackRating >= 2 && averageFeedbackRating < 3) return -0.1;
                if (averageFeedbackRating >= 3 && averageFeedbackRating < 4) return 0.0;
                if (averageFeedbackRating >= 4 && averageFeedbackRating < 5) return 0.1;
                if (averageFeedbackRating >= 5) return 0.15;
            }
            if (yearsInBusiness >= 5){
                if (averageFeedbackRating >= 1 && averageFeedbackRating < 2) return -0.1;
                if (averageFeedbackRating >= 2 && averageFeedbackRating < 3) return -0.05;
                if (averageFeedbackRating >= 3 && averageFeedbackRating < 4) return 0.0;
                if (averageFeedbackRating >= 4 && averageFeedbackRating < 5) return 0.15;
                if (averageFeedbackRating >= 5) return 0.2;
            }
            return 0;
        }
        public double CalculateAverageFeedbackRating()
        {
            if (feedbackHistory.Count == 0)
            {
                return 0;
            }
            double totalRating = 0;
            foreach (var item in feedbackHistory)
            {
                totalRating += (int)item.Rating;
            }
            this.averageRating = totalRating / feedbackHistory.Count;
            return averageRating;
        }
        #endregion

        public override void OutputInformation()
        {
            Console.WriteLine($"Full Name : {this.fullName}");
            Console.WriteLine($"ID : {this.id}");
            Console.WriteLine($"Date of Birth : {this.dateOfBirth}");
            Console.WriteLine($"Phone Number : {this.phoneNumber}");
            Console.WriteLine($"-------------------------------------------------------");
            Console.WriteLine($"Joining Date : {this.joinDate}");
            Console.WriteLine($"Monthly Salary : {this.monthlySalary}");
            Console.WriteLine($"Average Rating : {this.averageRating}");
        }
    }
}
