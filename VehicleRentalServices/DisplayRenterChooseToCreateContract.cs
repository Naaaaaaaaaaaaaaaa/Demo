using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalServices
{
    public partial class DisplayRenterChooseToCreateContract : Form
    {
        private int cntkilometers = 0;
        private int cntprepayments = 0;
        private Contract contract = new Contract();
        private Renter renter;
        private DateTime startDate;
        private DateTime endDate;
        private Car car;
        public DisplayRenterChooseToCreateContract(Renter renter, DateTime startDate, DateTime endDate, Car car)
        {
            this.renter = renter;
            this.startDate = startDate;
            this.endDate = endDate;
            this.car = car;

            InitializeComponent();
            LoadForm();
        }
        private bool CheckToRegister()
        {
            return (CheckDriver() || CheckAssistant())
                && CheckRenter() && CheckLabelCar() && CheckStartDate() && CheckEndDate() && CheckKilometers() && CheckPrepayment();
        }
        private bool CheckToUpdateContract()
        {
            return CheckLabelCar() && CheckStartDate() && CheckEndDate() && CheckKilometers();
        }
        private void UpdateContract()
        {
            if (CheckToUpdateContract())
            {
                if (CheckDriver() && CheckAssistant())
                {
                    contract = new Contract(Database.business, (Renter)comboBox1.SelectedItem, (Driver)comboBox2.SelectedItem,
                        (Assistant)comboBox4.SelectedItem, (Car)comboBox3.SelectedItem, dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox1.Text));
                }
                if (!CheckDriver() && CheckAssistant())
                {
                    contract = new Contract(Database.business, (Renter)comboBox1.SelectedItem, new Driver(),
                        (Assistant)comboBox4.SelectedItem, (Car)comboBox3.SelectedItem, dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox1.Text));
                }
                if (CheckDriver() && !CheckAssistant())
                {
                    contract = new Contract(Database.business, (Renter)comboBox1.SelectedItem, (Driver)comboBox2.SelectedItem,
                        new Assistant(), (Car)comboBox3.SelectedItem, dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBox1.Text));
                }

                label23.Text = (contract.PercentagePrepayment * 100).ToString() + "%";
                label28.Text = (contract.PercentageDiscounted * 100).ToString() + "%";
                label21.Text = contract.PreSettlementValue.ToString();
            }
            else
            {
                label23.Text = "";
                label28.Text = "";
                label21.Text = "$$$";
            }
        }
        private void ClickRegister(object sender, EventArgs e)
        {
            if (CheckToRegister())
            {
                contract.AddPrepayment(Convert.ToDouble(textBox2.Text));
                Database.contracts.Add(contract);

                label7.Text = "You have successfully created";
                label8.Text = contract.ID;
                label8.ForeColor = Color.IndianRed;
                notifyIcon1.ShowBalloonTip(2000, "Created " + label8.Text + " successfully", "Welcome to VRS, let's start your first experiences", ToolTipIcon.None);

                this.Close();
            }
            else
            {
                MessageBox.Show("You have not entered enough information or the information is not available", "Warning",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }
        private void ClickReset(object sender, EventArgs e)
        {
            ClickForm(sender, e);

            cntkilometers = 0;
            cntprepayments = 0;
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Refresh();
            comboBox2.Refresh();
            comboBox3.Refresh();
            dateTimePicker1.Refresh();
            dateTimePicker2.Refresh();
            label8.Text = "IDContract";
            label8.ForeColor = SystemColors.ButtonShadow;
        }
        private bool CheckRenter()
        {
            if (comboBox1.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckDriver()
        {
            if (comboBox2.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckLabelCar()
        {
            if (comboBox3.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckStartDate()
        {
            TimeSpan timeSpan = dateTimePicker1.Value - DateTime.Now;
            return timeSpan.Days >= 0;
        }
        private bool CheckEndDate()
        {
            TimeSpan timeSpan = dateTimePicker2.Value - dateTimePicker1.Value;
            return timeSpan.Days >= 0 && timeSpan.Days < 3;
        }
        private bool CheckKilometers()
        {
            return !string.IsNullOrEmpty(textBox1.Text) && textBox1.Text.All(char.IsDigit) && textBox1.Text.Length < 5;
        }
        private bool CheckAssistant()
        {
            if (comboBox4.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckPrepayment()
        {
            return !string.IsNullOrEmpty(textBox2.Text) && textBox2.Text.All(char.IsDigit)
                && Convert.ToDouble(textBox2.Text) >= contract.PercentagePrepayment * contract.PreSettlementValue
                && Convert.ToDouble(textBox2.Text) <= contract.PreSettlementValue;
        }
        private void TextChangedKilometers(object sender, EventArgs e)
        {
            if (cntkilometers != 0 && !CheckKilometers())
            {
                label11.ForeColor = Color.LightCoral;
                label11.Text = "Kilometers not available";
            }
            else
            {
                label11.Text = "";
            }
            cntkilometers++;
            UpdateContract();
        }
        private void TextChangedPrepayments(object sender, EventArgs e)
        {
            if (cntprepayments != 0 && !CheckPrepayment())
            {
                label25.ForeColor = Color.LightCoral;
                label25.Text = "Prepaid amount not available";
            }
            else
            {
                label25.Text = "";
            }
            cntprepayments++;
            UpdateContract();
        }
        private void LeaveKilometers(object sender, EventArgs e)
        {
            if (!CheckKilometers())
            {
                label11.ForeColor = Color.LightCoral;
                label11.Text = "Kilometers not available";
            }
            else
            {
                label11.Text = "";
            }
            UpdateContract();
        }
        private void LeavePrepayments(object sender, EventArgs e)
        {
            if (!CheckPrepayment())
            {
                label25.ForeColor = Color.LightCoral;
                label25.Text = "Prepaid amount not available";
            }
            else
            {
                label25.Text = "";
            }
            UpdateContract();
        }
        private void MouseClickKilometers(object sender, MouseEventArgs e)
        {
            if (!CheckKilometers())
            {
                label11.ForeColor = Color.LightCoral;
                label11.Text = "Kilometers not available";
            }
            else
            {
                label11.Text = "";
            }
        }
        private void MouseClickPrepayments(object sender, MouseEventArgs e)
        {
            if (!CheckPrepayment())
            {
                label25.ForeColor = Color.LightCoral;
                label25.Text = "Prepaid amount not available";
            }
            else
            {
                label25.Text = "";
            }
        }
        private List<Driver> GetListDriver()
        {
            if (CheckStartDate() && CheckEndDate())
            {
                var resultDrivers = new List<Driver>();
                foreach (var driver in Database.drivers)
                {
                    bool check = true;
                    foreach (var contract in Database.contracts)
                    {
                        TimeSpan timeSpan1 = contract.StartDate - dateTimePicker2.Value;
                        TimeSpan timeSpan2 = dateTimePicker1.Value - contract.EndDate;
                        bool option1 = contract.GetDriver != driver;
                        bool option2 = contract.GetDriver == driver && contract.Paid == true;
                        bool option3 = contract.GetDriver == driver && contract.Paid == false && (timeSpan1.Days > 0 || timeSpan2.Days > 0);
                        check = check && (option1 || option2 || option3);
                    }
                    if (check)
                    {
                        resultDrivers.Add(driver);
                    }
                }
                return resultDrivers;
            }
            return new List<Driver>();
        }
        private List<Assistant> GetListAssistant()
        {
            if (CheckStartDate() && CheckEndDate())
            {
                var resultAssistants = new List<Assistant>();
                foreach (var assistant in Database.assistants)
                {
                    bool check = true;
                    foreach (var contract in Database.contracts)
                    {
                        TimeSpan timeSpan1 = contract.StartDate - dateTimePicker2.Value;
                        TimeSpan timeSpan2 = dateTimePicker1.Value - contract.EndDate;
                        bool option1 = contract.GetAssistant != assistant;
                        bool option2 = contract.GetAssistant == assistant && contract.Paid == true;
                        bool option3 = contract.GetAssistant == assistant && contract.Paid == false && (timeSpan1.Days > 0 || timeSpan2.Days > 0);
                        check = check && (option1 || option2 || option3);
                    }
                    if (check)
                    {
                        resultAssistants.Add(assistant);
                    }
                }
                return resultAssistants;
            }
            return new List<Assistant>();
        }
        private void LoadForm()
        {
            if (Database.business.BusinessName == "") label14.Text = "Business";
            else label14.Text = Database.business.BusinessName + "'s Business";

            comboBox1.DataSource = null;
            comboBox1.DataSource = new List<Renter> { this.renter };
            comboBox1.DisplayMember = "FullName";

            comboBox2.DataSource = null;
            comboBox2.DataSource = GetListDriver();
            comboBox2.DisplayMember = "FullName";

            comboBox3.DataSource = null;
            comboBox3.DataSource = new List<Car> { this.car };
            comboBox3.DisplayMember = "LicensePlates";

            comboBox4.DataSource = null;
            comboBox4.DataSource = GetListAssistant();
            comboBox4.DisplayMember = "FullName";

            dateTimePicker1.Value = this.startDate;
            dateTimePicker2.Value = this.endDate;

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = true;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }
        private void ClickForm(object sender, EventArgs e)
        {
            comboBox2.DataSource = null;
            comboBox2.DataSource = GetListDriver();
            comboBox2.DisplayMember = "FullName";

            comboBox4.DataSource = null;
            comboBox4.DataSource = GetListAssistant();
            comboBox4.DisplayMember = "FullName";

            UpdateContract();
        }
        private void ClickRentalPolicy(object sender, EventArgs e)
        {
            DisplayRentalPolicy displayRenterRentalPolicy = new DisplayRentalPolicy(new List<Car> { this.car });
            displayRenterRentalPolicy.Show();
        }
        private void CMSDriverClick(object sender, EventArgs e)
        {
            if (CheckDriver())
            {
                DisplayDriverDetails displayDriverDetails = new DisplayDriverDetails((Driver)comboBox2.SelectedItem);
                displayDriverDetails.Show();
            }
        }
        private void CMSAssistantClick(object sender, EventArgs e)
        {
            if (CheckAssistant())
            {
                DisplayAssistantDetails displayAssistantDetails = new DisplayAssistantDetails((Assistant)comboBox4.SelectedItem);
                displayAssistantDetails.Show();
            }
        }
    }
}
