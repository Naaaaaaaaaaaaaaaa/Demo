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
    public partial class DisplayAssistantDetails : Form
    {
        private Employee employee;
        public DisplayAssistantDetails(Employee employee)
        {
            this.employee = employee;

            InitializeComponent();
        }
        private void LoadForm(object sender, EventArgs e)
        {
            label3.Text = "Update " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            label4.Text = Database.business.BusinessName + "'s Business";

            label30.Text = this.employee.FullName;
            label31.Text = this.employee.ID;
            label32.Text = this.employee.DateOfBirth.ToString("dd/MM/yyyy");
            label33.Text = this.employee.PhoneNumber;
            label34.Text = this.employee.JointDate.ToString("dd/MM/yyyy");
            label35.Text = this.employee.CalculateAverageFeedbackRating().ToString("N2");
            if (this.employee is Driver) label36.Text = "Driver";
            if (this.employee is Assistant) label36.Text = "Assistant";

            foreach (var item in this.employee.FeedbackHistory)
            {
                richTextBox1.Text = richTextBox1.Text + "   Feedback:" + item.Content + "\n";
            }
        }
    }
}
