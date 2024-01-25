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
    public partial class DisplayRenterDetails : Form
    {
        private Renter renter;
        public DisplayRenterDetails(Renter renter)
        {
            this.renter = renter;

            InitializeComponent();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            label3.Text = "Update " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            label4.Text = Database.business.BusinessName + "'s Business";

            label30.Text = this.renter.FullName;
            label31.Text = this.renter.ID;
            label32.Text = this.renter.DateOfBirth.ToString("dd/MM/yyyy");
            label33.Text = this.renter.PhoneNumber;
            label34.Text = this.renter.JointDate.ToString("dd/MM/yyyy");
            label35.Text = this.renter.ContractHistory.Count.ToString();
            label36.Text = this.renter.TotalContractValue.ToString() + " VND";

            foreach (var item in this.renter.FeedbackHistory)
            {
                richTextBox1.Text = richTextBox1.Text + "   Feedback:" + item.Content + "\n";
            }
        }
    }
}
