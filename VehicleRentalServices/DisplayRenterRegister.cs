﻿using System;
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
    public partial class DisplayRenterRegister : Form
    {
        private int cntfullname = 0;
        private int cntcitizencode = 0;
        private int cntbirthday = 0;
        private int cntphonenumber = 0;
        public DisplayRenterRegister()
        {
            InitializeComponent();
        }
        private void ClickRegister(object sender, EventArgs e)
        {
            if (CheckFullName(textBox1.Text) && CheckCitizenCode(textBox2.Text) && CheckBirthday(dateTimePicker1.Value) && CheckPhoneNumber(textBox3.Text))
            {
                label7.Text = "You have successfully registered";
                label8.Text = "Hello";
                label9.Text = textBox1.Text;
                notifyIcon1.ShowBalloonTip(2000, "Registered successfully", "Welcome " + textBox1.Text + " to VRS, let's start your first experiences", ToolTipIcon.None);

                Renter renter = new Renter(textBox1.Text, textBox2.Text, dateTimePicker1.Value, textBox3.Text, DateTime.Now);
                Database.renter.Add(renter);

                Button button = new Button();
                button.Text = textBox1.Text;
                button.AutoSize = true;

                ClickReset(sender, e);
            }
            else
            {
                MessageBox.Show("You have not entered enough information or the information is not available", "Warning",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }
        private void ClickReset(object sender, EventArgs e)
        {
            cntfullname = 0;
            cntcitizencode = 0;
            cntbirthday = 0;
            cntphonenumber = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Refresh();
        }
        private bool CheckFullName(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        private bool CheckCitizenCode(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
        private bool CheckBirthday(DateTime input)
        {
            TimeSpan timeSpan = DateTime.Now - input;
            return (timeSpan.Days > 18 * 365) && !(dateTimePicker1.Value.Year == DateTime.Now.Year && dateTimePicker1.Value.Month == DateTime.Now.Month && dateTimePicker1.Value.Day == DateTime.Now.Day);
        }
        private bool CheckPhoneNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
        }
        private void TextChangedFullName(object sender, EventArgs e)
        {
            string input = Convert.ToString(textBox1.Text);
            if (cntfullname != 0 && !CheckFullName(input))
            {
                label10.ForeColor = Color.LightCoral;
                label10.Text = "The name includes only alphabetic characters";
            }
            else
            {
                label10.Text = "";
            }
            cntfullname++;
        }
        private void TextChangedCitizenCode(object sender, EventArgs e)
        {
            string input = Convert.ToString(textBox2.Text);
            if (cntcitizencode != 0 && !CheckCitizenCode(input))
            {
                label11.ForeColor = Color.LightCoral;
                label11.Text = "Enter your citizen code";
            }
            else
            {
                label11.Text = "";
            }
            cntcitizencode++;
        }
        private void TextChangedBirthday(object sender, EventArgs e)
        {
            if (!CheckBirthday(dateTimePicker1.Value))
            {
                label12.ForeColor = Color.LightCoral;
                label12.Text = "You must be 18 years old";
            }
            else
            {
                label12.Text = "";
            }
            cntbirthday++;
        }
        private void TextChangedPhoneNumber(object sender, EventArgs e)
        {
            string input = Convert.ToString(textBox3.Text);
            if (cntphonenumber != 0 && !CheckPhoneNumber(input))
            {
                label13.ForeColor = Color.LightCoral;
                label13.Text = "The phone number must includes numbers";
            }
            else
            {
                label13.Text = "";
            }
            cntphonenumber++;
        }
        private void LeaveFullName(object sender, EventArgs e)
        {
            string input = Convert.ToString(textBox1.Text);
            if (!CheckFullName(input))
            {
                label10.ForeColor = Color.LightCoral;
                label10.Text = "The name includes only alphabetic characters";
            }
            else
            {
                label10.Text = "";
            }
        }
        private void LeaveCitizenCode(object sender, EventArgs e)
        {
            string input = Convert.ToString(textBox2.Text);
            if (!CheckCitizenCode(input))
            {
                label11.ForeColor = Color.LightCoral;
                label11.Text = "Enter your citizen code";
            }
            else
            {
                label11.Text = "";
            }
        }
        private void LeaveBirthday(object sender, EventArgs e)
        {
            if (!CheckBirthday(dateTimePicker1.Value))
            {
                label12.ForeColor = Color.LightCoral;
                label12.Text = "You must be 18 years old";
            }
            else
            {
                label12.Text = "";
            }
        }
        private void LeavePhoneNumber(object sender, EventArgs e)
        {
            string input = Convert.ToString(textBox3.Text);
            if (!CheckPhoneNumber(input))
            {
                label13.ForeColor = Color.LightCoral;
                label13.Text = "The phone number must includes numbers";
            }
            else
            {
                label13.Text = "";
            }
        }

    }
}
