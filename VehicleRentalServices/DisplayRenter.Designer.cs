namespace VehicleRentalServices
{
    partial class DisplayRenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayRenter));
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(24, 21);
            label1.Name = "label1";
            label1.Size = new Size(136, 39);
            label1.TabIndex = 1;
            label1.Text = "Renter";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = SystemColors.Control;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(29, 105);
            button1.Name = "button1";
            button1.Size = new Size(162, 76);
            button1.TabIndex = 4;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ClickRegister;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(29, 62);
            label2.Name = "label2";
            label2.Size = new Size(421, 21);
            label2.TabIndex = 5;
            label2.Text = "We are happy that you have chosen us among many project teams";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(480, 105);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(269, 269);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackColor = SystemColors.Control;
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(259, 203);
            button2.Name = "button2";
            button2.Size = new Size(162, 76);
            button2.TabIndex = 7;
            button2.Text = "Contract History";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ClickContractHistory;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.BackColor = SystemColors.Control;
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(259, 304);
            button3.Name = "button3";
            button3.Size = new Size(162, 76);
            button3.TabIndex = 8;
            button3.Text = "Feedback History";
            button3.UseVisualStyleBackColor = false;
            button3.Click += ClickFeedbackHistory;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.BackColor = SystemColors.Control;
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(29, 304);
            button4.Name = "button4";
            button4.Size = new Size(162, 76);
            button4.TabIndex = 10;
            button4.Text = "Send Feedback";
            button4.UseVisualStyleBackColor = false;
            button4.Click += ClickSendFeedback;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.BackColor = SystemColors.Control;
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(29, 203);
            button5.Name = "button5";
            button5.Size = new Size(162, 76);
            button5.TabIndex = 11;
            button5.Text = "Rental Policy";
            button5.UseVisualStyleBackColor = false;
            button5.Click += ClickRentalPolicy;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top;
            button6.BackColor = SystemColors.Control;
            button6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(259, 105);
            button6.Name = "button6";
            button6.Size = new Size(162, 76);
            button6.TabIndex = 12;
            button6.Text = "Rent Car";
            button6.UseVisualStyleBackColor = false;
            button6.Click += ClickFindCar;
            // 
            // DisplayRenter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DisplayRenter";
            Text = "Display Renter";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}