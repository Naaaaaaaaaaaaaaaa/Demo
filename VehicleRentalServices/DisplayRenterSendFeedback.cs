using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VehicleRentalServices
{
    public partial class DisplayRenterSendFeedback : Form
    {
        private bool isPicture1Visible = true;
        private bool isPicture2Visible = true;
        private bool isPicture3Visible = true;
        private bool isPicture4Visible = true;
        private bool isPicture5Visible = true;
        public DisplayRenterSendFeedback()
        {
            InitializeComponent();
            LoadForm();
        }
        private void LoadForm()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = Database.renter;
            comboBox1.DisplayMember = "FullName";

            comboBox2.DataSource = null;
            List<Person> persons = new List<Person>();
            persons.Add(Database.owner);
            persons.AddRange(Database.drivers);
            persons.AddRange(Database.assistants);
            comboBox2.DataSource = persons;
            comboBox2.DisplayMember = "FullName";
        }
        private bool CheckToSend()
        {
            return CheckFrom() && CheckTo() && CheckCategory() && CheckRate();
        }
        private void ClickSend(object sender, EventArgs e)
        {
            if (!CheckRate())
            {
                label9.Text = "Please select your rating";
                return;
            }
            else
            {
                label9.Text = "";
            }
            if (CheckToSend())
            {
                notifyIcon1.ShowBalloonTip(2000, "Feedback sent successfully", "Feedback has been sent to " + ((Person)comboBox2.SelectedItem).FullName, ToolTipIcon.None);

                Feedback feedback = new Feedback((Renter)comboBox1.SelectedItem, (Person)comboBox2.SelectedItem, (ECategory)comboBox3.SelectedItem, GetERate(), richTextBox1.Text, DateTime.Now);
                Database.feedbacks.Add(feedback);

                label6.Text = "";
                label8.Text = "";
                label17.Text = "";

                richTextBox1.Text = "";
                isPicture1Visible = false;
                isPicture2Visible = false;
                isPicture3Visible = false;
                isPicture4Visible = false;
                isPicture5Visible = false;
                ClickPictureBox1(sender, e); ClickPictureBox2(sender, e); ClickPictureBox3(sender, e); ClickPictureBox4(sender, e); ClickPictureBox5(sender, e);
            }
            else
            {
                MessageBox.Show("You have not entered enough information or the information is not available", "Warning",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }
        private ERate GetERate()
        {
            List<bool> boolList = new List<bool> { isPicture1Visible, isPicture2Visible, isPicture3Visible, isPicture4Visible, isPicture5Visible };
            int countTrue = boolList.Count(b => b == false);
            switch (countTrue)
            {
                case 1: return ERate.One;
                case 2: return ERate.Two;
                case 3: return ERate.Three;
                case 4: return ERate.Four;
                case 5: return ERate.Five;
            }
            return ERate.One;
        }
        private bool CheckFrom()
        {
            if (comboBox1.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckTo()
        {
            if (comboBox2.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckCategory()
        {
            if (comboBox3.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckRate()
        {
            return !(isPicture1Visible && isPicture2Visible && isPicture3Visible && isPicture4Visible && isPicture5Visible);
        }
        private void ClickPictureBox1(object sender, EventArgs e)
        {
            isPicture1Visible = !isPicture1Visible;
            isPicture2Visible = true;
            isPicture3Visible = true;
            isPicture4Visible = true;
            isPicture5Visible = true;
            ScanPictureBoxRate();
        }
        private void ClickPictureBox2(object sender, EventArgs e)
        {
            isPicture1Visible = false;
            isPicture2Visible = !isPicture2Visible;
            isPicture3Visible = true;
            isPicture4Visible = true;
            isPicture5Visible = true;
            ScanPictureBoxRate();
        }
        private void ClickPictureBox3(object sender, EventArgs e)
        {
            isPicture1Visible = false;
            isPicture2Visible = false;
            isPicture3Visible = !isPicture3Visible;
            isPicture4Visible = true;
            isPicture5Visible = true;
            ScanPictureBoxRate();
        }
        private void ClickPictureBox4(object sender, EventArgs e)
        {
            isPicture1Visible = false;
            isPicture2Visible = false;
            isPicture3Visible = false;
            isPicture4Visible = !isPicture4Visible;
            isPicture5Visible = true;
            ScanPictureBoxRate();
        }
        private void ClickPictureBox5(object sender, EventArgs e)
        {
            isPicture1Visible = false;
            isPicture2Visible = false;
            isPicture3Visible = false;
            isPicture4Visible = false;
            isPicture5Visible = !isPicture5Visible;
            ScanPictureBoxRate();
        }
        private void ScanPictureBoxRate()
        {
            if (isPicture1Visible) pictureBox1.Image = Properties.Resources.imageStar; else pictureBox1.Image = Properties.Resources.imageStarLight;
            if (isPicture2Visible) pictureBox2.Image = Properties.Resources.imageStar; else pictureBox2.Image = Properties.Resources.imageStarLight;
            if (isPicture3Visible) pictureBox3.Image = Properties.Resources.imageStar; else pictureBox3.Image = Properties.Resources.imageStarLight;
            if (isPicture4Visible) pictureBox4.Image = Properties.Resources.imageStar; else pictureBox4.Image = Properties.Resources.imageStarLight;
            if (isPicture5Visible) pictureBox5.Image = Properties.Resources.imageStar; else pictureBox5.Image = Properties.Resources.imageStarLight;
        }
        private void ForFrom(object sender, EventArgs e)
        {
            if (!CheckFrom())
            {
                label17.ForeColor = Color.IndianRed;
                label17.Text = "Please select the sender";
            }
            else
            {
                label17.Text = "";
            }
        }
        private void ForTo(object sender, EventArgs e)
        {
            if (!CheckTo())
            {
                label6.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point);
                label6.ForeColor = Color.IndianRed;
                label6.Text = "Please select the receiver";
            }
            else
            {
                label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                label6.ForeColor = Color.LimeGreen;
                string position = "";
                Person person = (Person)comboBox2.SelectedItem;
                if (person is Owner) position = "Owner";
                if (person is Driver) position = "Driver";
                if (person is Assistant) position = "Assistant";
                label6.Text = position;
            }
        }
        private void ForCategory(object sender, EventArgs e)
        {
            if (!CheckCategory())
            {
                label8.ForeColor = Color.IndianRed;
                label8.Text = "Please select category";
            }
            else
            {
                label8.Text = "";
            }
        }
        private void MouseClickForFrom(object sender, MouseEventArgs e)
        {
            if (!CheckFrom())
            {
                label17.ForeColor = Color.IndianRed;
                label17.Text = "Please select the sender";
            }
            else
            {
                label17.Text = "";
            }
        }
        private void MouseClickForTo(object sender, MouseEventArgs e)
        {
            if (!CheckTo())
            {
                label6.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point);
                label6.ForeColor = Color.IndianRed;
                label6.Text = "Please select the receiver";
            }
            else
            {
                label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                label6.ForeColor = Color.LimeGreen;
                string position = "";
                Person person = (Person)comboBox2.SelectedItem;
                if (person is Owner) position = "Owner";
                if (person is Driver) position = "Driver";
                if (person is Assistant) position = "Assistant";
                label6.Text = position;
            }
        }
        private void MouseClickForCategory(object sender, MouseEventArgs e)
        {
            if (!CheckCategory())
            {
                label8.ForeColor = Color.IndianRed;
                label8.Text = "Please select category";
            }
            else
            {
                label8.Text = "";
            }
        }
        private void ClickForm(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
