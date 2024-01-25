﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleRentalServices
{
    public partial class DisplayAdminContractPayments : Form
    {
        private Contract contract = new Contract();
        public DisplayAdminContractPayments()
        {
            InitializeComponent();
            LoadListView();
            LoadChecklistCarDamage();
            LoadEnabledForm();
        }
        private void LoadListView()
        {
            listView1.Items.Clear();
            foreach (var contract in Database.contracts)
            {
                ListViewItem item = new ListViewItem();
                item.Text = contract.ID;
                item.ImageIndex = 0;
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.StartDate.ToString("dd/MM/yyyy") });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.EndDate.ToString("dd/MM/yyyy") });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.GetRenter.FullName });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.PreSettlementValue.ToString() + "đ" });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.PrePayment.ToString() + "đ" });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.Paid ? "Paid" : "Effected" });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.GetCar.GetEVehicles.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.GetCar.LicensePlates.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.GetDriver.FullName });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.GetAssistant.FullName });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = contract.GetCar.GetECarClassification.ToString() });

                listView1.Items.Add(item);
            }
        }
        private void LoadChecklistCarDamage()
        {
            foreach (var enumValue in Enum.GetValues(typeof(EDamage)))
            {
                checkedListBox1.Items.Add(enumValue);
            }
        }
        private void LoadEnabledForm()
        {
            dateTimePicker1.Value = DateTime.Now;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            label3.Text = "";
            label4.Text = "";
            label8.Text = "";
            label23.Text = "";
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Text = "After-SettlementValue";
            comboBox1.DataSource = new List<EPayments> { EPayments.COD, EPayments.Visa, EPayments.ATM };

            listView1.Enabled = true;
            dateTimePicker1.Enabled = false;
            button1.Enabled = true;
            checkedListBox1.Enabled = false;
            button2.Enabled = false;
            comboBox1.Enabled = false;
            button3.Enabled = false;
        }
        private void LoadLateCost()
        {
            TimeSpan timeSpan = dateTimePicker1.Value - contract.EndDate;
            label3.Text = (timeSpan.Days * Convert.ToInt64(2000000)).ToString();
        }
        private void LoadPrepayment()
        {
            label23.Text = contract.PrePayment.ToString();
        }
        private void LoadRemainingCosts()
        {
            if (!CheckPaymentDate() || !CheckListCarDamage()) return;
            TimeSpan timeSpan = dateTimePicker1.Value - contract.EndDate;
            double value = contract.PreSettlementValue + (timeSpan.Days * Convert.ToInt64(2000000)) + (checkedListBox1.CheckedItems.Count * Convert.ToInt64(1000000)) - contract.PrePayment;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.IndianRed;
            button2.Text = value.ToString() + "VND";
        }
        private Contract GetContract(string input)
        {
            return Database.contracts.Where(contract => contract.ID == input).ToList()[0];
        }
        private bool CheckListContract()
        {
            return listView1.SelectedItems.Count > 0;
        }
        private bool CheckListCarDamage()
        {
            return true;
        }
        private bool CheckPaymentDate()
        {
            TimeSpan timeSpan1 = dateTimePicker1.Value - DateTime.Now;
            TimeSpan timeSpan2 = DateTime.Now - contract.EndDate;
            return timeSpan1.Days >= 0 && timeSpan2.Days >= 0;
        }
        private bool CheckPayments()
        {
            if (comboBox1.SelectedIndex != -1) return true;
            else return false;
        }
        private bool CheckToPayment()
        {
            return CheckPaymentDate() && CheckListCarDamage() && CheckPayments();
        }
        private void ClickToContractPayment(object sender, EventArgs e)
        {
            if (CheckToPayment())
            {
                DialogResult choose = MessageBox.Show("Confirm contract payment " + contract.ID, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (choose == DialogResult.Yes)
                {
                    TimeSpan timeSpan = dateTimePicker1.Value - contract.EndDate;
                    double money = contract.PreSettlementValue + (timeSpan.Days * Convert.ToInt64(2000000)) + (checkedListBox1.CheckedItems.Count * Convert.ToInt64(1000000)) - contract.PrePayment;
                    contract.ContractPayments(dateTimePicker1.Value, (EPayments)comboBox1.SelectedItem, money);
                    ClickReset(sender, e);
                    notifyIcon1.ShowBalloonTip(2000, contract.ID + " contract payment successfully", "Welcome to VRS, let's start your first experiences", ToolTipIcon.None);
                }
            }
            else
            {
                MessageBox.Show("You have not entered enough information or the information is not available", "Warning",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }
        private void ClickChoose(object sender, EventArgs e)
        {
            if (CheckListContract())
            {
                contract = GetContract(listView1.SelectedItems[0].Text);
                if (contract.HasTakenEffect == true && contract.Paid == true)
                {
                    MessageBox.Show("You have paid for contract " + contract.ID, "Warning",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    this.contract = new Contract();
                    return;
                }
                TimeSpan timeSpan = DateTime.Now - contract.EndDate;
                if (!(timeSpan.Days >= 0))
                {
                    MessageBox.Show("Contract " + contract.ID + " is not yet due for payment", "Warning",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    this.contract = new Contract();
                    return;
                }
                if (contract.HasTakenEffect == true && contract.Paid == false)
                {
                    listView1.Enabled = false;
                    dateTimePicker1.Enabled = true;
                    button1.Enabled = false;
                    checkedListBox1.Enabled = true;
                    button2.Enabled = true;
                    comboBox1.Enabled = true;
                    button3.Enabled = true;

                    if (CheckPaymentDate())
                    {
                        label8.Text = "";
                        LoadLateCost();
                    }

                    LoadPrepayment();
                    LoadRemainingCosts();
                }
            }
        }
        private void ClickReset(object sender, EventArgs e)
        {
            LoadListView();
            LoadEnabledForm();
        }
        private void ValueChangedPaymentDate(object sender, EventArgs e)
        {
            if (!CheckPaymentDate())
            {
                label8.ForeColor = Color.LightCoral;
                label8.Text = "Payment date not available";
                label3.Text = "";
            }
            else
            {
                label8.Text = "";
                LoadLateCost();
                LoadRemainingCosts();
            }
        }
        private void MouseClickPaymentDate(object sender, MouseEventArgs e)
        {
            if (!CheckPaymentDate())
            {
                label8.ForeColor = Color.LightCoral;
                label8.Text = "Please enter payment date";
                label3.Text = "";
            }
            else
            {
                label8.Text = "";
                LoadLateCost();
                LoadRemainingCosts();
            }
        }
        private void SelectedValueChangedCarDamage(object sender, EventArgs e)
        {
            if (!CheckListCarDamage())
            {
                label4.ForeColor = Color.LightCoral;
                label4.Text = "Car damage not available";
            }
            else
            {
                label4.Text = (checkedListBox1.CheckedItems.Count * Convert.ToInt64(1000000)).ToString();
                LoadRemainingCosts();
            }
        }
        private void ItemCheckCarDamage(object sender, ItemCheckEventArgs e)
        {
            if (!CheckListCarDamage())
            {
                label4.ForeColor = Color.LightCoral;
                label4.Text = "Car damage not available";
            }
            else
            {
                label4.Text = (checkedListBox1.CheckedItems.Count * Convert.ToInt64(1000000)).ToString();
                LoadRemainingCosts();
            }
        }
        private void LeavePaymentDate(object sender, EventArgs e)
        {
            if (!CheckPaymentDate())
            {
                label8.ForeColor = Color.LightCoral;
                label8.Text = "Payment date not available";
                label3.Text = "";
            }
            else
            {
                label8.Text = "";
                LoadLateCost();
                LoadRemainingCosts();
            }
        }
        private void LeaveCarDamage(object sender, EventArgs e)
        {
            if (!CheckListCarDamage())
            {
                label4.ForeColor = Color.LightCoral;
                label4.Text = "Car damage not available";
            }
            else
            {
                label4.Text = (checkedListBox1.CheckedItems.Count * Convert.ToInt64(1000000)).ToString();
                LoadRemainingCosts();
            }
        }
        private void ClickForm(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            LoadListView();
        }
        private void ClickContextMS(object sender, EventArgs e)
        {
            if (CheckListContract())
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                var result = Database.contracts.Where(item => item.ID == selectedItem.Text).ToList();
                DisplayContractDetails displayContractDetails = new DisplayContractDetails(result[0]);
                displayContractDetails.Show();
            }
        }
    }
}