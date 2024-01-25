using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalServices
{
    public partial class DisplayBusinessInfo : Form
    {
        public DisplayBusinessInfo()
        {
            InitializeComponent();
            LoadForm();
        }
        private void LoadForm()
        {
            Database.business.ClearEmployeeList();
            Database.business.ClearContractList();
            Database.business.ClearRenterList();
            var list = new List<Employee>();
            list.AddRange(Database.drivers);
            list.AddRange(Database.assistants);
            Database.business.AddRangeEmployee(list);
            Database.business.AddRangeContract(Database.contracts);
            Database.business.AddRangeRenter(Database.renter);

            Database.business.CalculateMonthlyRevenue();
            label30.Text = Database.business.MonthlyRevenue.ToString() + " VND";
            Database.business.CalculateMonthlySalaryExpense();
            label31.Text = Database.business.MonthlySalaryExpense.ToString() + " VND";

            label3.Text = "Total monthly salary expense is calculated up to date " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }
        private void ClickRentalPolicy(object sender, EventArgs e)
        {
            DisplayRentalPolicy displayRentalPolicy = new DisplayRentalPolicy(Database.cars);
            displayRentalPolicy.Show();
            this.Close();
        }
        private void ClickSalaryPolicy(object sender, EventArgs e)
        {
            var list = new List<Employee>();
            list.AddRange(Database.drivers);
            list.AddRange(Database.assistants);
            DisplaySalaryPolicy displaySalaryPolicy = new DisplaySalaryPolicy(list);
            displaySalaryPolicy.Show();
            this.Close();
        }
        private void ClickRenters(object sender, EventArgs e)
        {
            DisplayOwnerAllRenters displayOwnerAllRenters = new DisplayOwnerAllRenters();
            displayOwnerAllRenters.Show();
            this.Close();
        }
        private void ClickContracts(object sender, EventArgs e)
        {
            DisplayOwnerAllContracts displayOwnerAllContracts = new DisplayOwnerAllContracts();
            displayOwnerAllContracts.Show();
            this.Close();
        }
        private void ClickCars(object sender, EventArgs e)
        {
            DisplayOwnerAllCars displayOwnerAllCars = new DisplayOwnerAllCars();
            displayOwnerAllCars.Show();
            this.Close();
        }
        private void ClickEmployees(object sender, EventArgs e)
        {
            DisplayOwnerAllEmployees displayOwnerAllEmployees = new DisplayOwnerAllEmployees();
            displayOwnerAllEmployees.Show();
            this.Close();
        }
    }
}
