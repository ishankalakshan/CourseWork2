namespace DesktopManager.Forms
{
    partial class Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BookingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDTA = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookingId,
            this.CustomerName,
            this.NIC,
            this.Telephone,
            this.Seat,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(644, 202);
            this.dataGridView1.TabIndex = 0;
            // 
            // BookingId
            // 
            this.BookingId.DataPropertyName = "BookingId";
            this.BookingId.HeaderText = "Id";
            this.BookingId.Name = "BookingId";
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "customername";
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // NIC
            // 
            this.NIC.DataPropertyName = "customernic";
            this.NIC.HeaderText = "NIC";
            this.NIC.Name = "NIC";
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "customertel";
            this.Telephone.HeaderText = "Mobile";
            this.Telephone.Name = "Telephone";
            // 
            // Seat
            // 
            this.Seat.DataPropertyName = "seatid";
            this.Seat.HeaderText = "Seat No";
            this.Seat.Name = "Seat";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "StatusName";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // UpdateDTA
            // 
            this.UpdateDTA.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateDTA_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(673, 484);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.ComponentModel.BackgroundWorker UpdateDTA;
    }
}