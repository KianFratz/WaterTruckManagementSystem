namespace WaterTruckManagementSystem
{
    partial class CustomerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnBuyOrder = new System.Windows.Forms.Button();
            this.btnYourOrder = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(957, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 649);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDashboard);
            this.panel3.Controls.Add(this.btnHistory);
            this.panel3.Controls.Add(this.btnBuyOrder);
            this.panel3.Controls.Add(this.btnYourOrder);
            this.panel3.Location = new System.Drawing.Point(0, 155);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 173);
            this.panel3.TabIndex = 4;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(194, 38);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistory.Location = new System.Drawing.Point(3, 132);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(194, 38);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnBuyOrder
            // 
            this.btnBuyOrder.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBuyOrder.FlatAppearance.BorderSize = 0;
            this.btnBuyOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyOrder.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBuyOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnBuyOrder.Image")));
            this.btnBuyOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuyOrder.Location = new System.Drawing.Point(3, 44);
            this.btnBuyOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuyOrder.Name = "btnBuyOrder";
            this.btnBuyOrder.Size = new System.Drawing.Size(194, 38);
            this.btnBuyOrder.TabIndex = 1;
            this.btnBuyOrder.Text = "Make an Order";
            this.btnBuyOrder.UseVisualStyleBackColor = false;
            this.btnBuyOrder.Click += new System.EventHandler(this.btnBuyOrder_Click);
            // 
            // btnYourOrder
            // 
            this.btnYourOrder.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnYourOrder.FlatAppearance.BorderSize = 0;
            this.btnYourOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYourOrder.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYourOrder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnYourOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnYourOrder.Image")));
            this.btnYourOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYourOrder.Location = new System.Drawing.Point(3, 88);
            this.btnYourOrder.Name = "btnYourOrder";
            this.btnYourOrder.Size = new System.Drawing.Size(194, 38);
            this.btnYourOrder.TabIndex = 2;
            this.btnYourOrder.Text = "Your Orders";
            this.btnYourOrder.UseVisualStyleBackColor = false;
            this.btnYourOrder.Click += new System.EventHandler(this.btnYourOrder_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.Window;
            this.lblCustomerName.Location = new System.Drawing.Point(64, 101);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(78, 21);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Customer";
            this.lblCustomerName.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.SystemColors.Window;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 649);
            this.panel2.TabIndex = 2;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 649);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnBuyOrder;
        private System.Windows.Forms.Button btnYourOrder;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}