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
    public partial class DisplayOwner : Form
    {
        public DisplayOwner()
        {
            InitializeComponent();
        }
        private void ClickRegister(object sender, EventArgs e)
        {
            DisplayOwnerRegister displayOwnerRegister = new DisplayOwnerRegister();
            displayOwnerRegister.Show();
            this.Close();
        }
        private void ClickAllContract(object sender, EventArgs e)
        {
            DisplayOwnerAllContracts displayOwnerAllContract = new DisplayOwnerAllContracts();
            displayOwnerAllContract.Show();
            this.Close();
        }
        private void ClickAllFeedback(object sender, EventArgs e)
        {
            DisplayOwnerAllFeedback displayOwnerAllFeedback = new DisplayOwnerAllFeedback();
            displayOwnerAllFeedback.Show();
            this.Close();
        }
        private void ClickAllEmployee(object sender, EventArgs e)
        {
            DisplayOwnerAllEmployees displayOwnerAllEmployee = new DisplayOwnerAllEmployees();
            displayOwnerAllEmployee.Show();
            this.Close();
        }
        private void ClickAllRenter(object sender, EventArgs e)
        {
            DisplayOwnerAllRenters displayOwnerAllRenter = new DisplayOwnerAllRenters();
            displayOwnerAllRenter.Show();
            this.Close();
        }
        private void ClickAllCars(object sender, EventArgs e)
        {
            DisplayOwnerAllCars displayOwnerAllCars = new DisplayOwnerAllCars();
            displayOwnerAllCars.Show();
            this.Close();
        }
    }
}
