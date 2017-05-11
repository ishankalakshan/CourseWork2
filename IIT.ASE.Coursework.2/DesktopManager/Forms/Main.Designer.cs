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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BookingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDTA = new System.ComponentModel.BackgroundWorker();
            this.cbRequestStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSeatView = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(19, 91);
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
            // cbRequestStatus
            // 
            this.cbRequestStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRequestStatus.FormattingEnabled = true;
            this.cbRequestStatus.Location = new System.Drawing.Point(126, 41);
            this.cbRequestStatus.Name = "cbRequestStatus";
            this.cbRequestStatus.Size = new System.Drawing.Size(190, 21);
            this.cbRequestStatus.TabIndex = 0;
            this.cbRequestStatus.SelectedIndexChanged += new System.EventHandler(this.cbRequestStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select status";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(465, 322);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(96, 32);
            this.btnApprove.TabIndex = 3;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Visible = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(465, 437);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(198, 32);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(465, 532);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(198, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSeatView
            // 
            this.btnSeatView.Location = new System.Drawing.Point(465, 399);
            this.btnSeatView.Name = "btnSeatView";
            this.btnSeatView.Size = new System.Drawing.Size(198, 32);
            this.btnSeatView.TabIndex = 3;
            this.btnSeatView.Text = "View Seats";
            this.btnSeatView.UseVisualStyleBackColor = true;
            this.btnSeatView.Click += new System.EventHandler(this.btnSeatView_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(21, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Label = "#PERCENT{P0}";
            series1.Legend = "Legend1";
            series1.Name = "PieChart";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(374, 224);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            title1.DockedToChartArea = "ChartArea1";
            title1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.IsDockedInsideChartArea = false;
            title1.Name = "SeatsTitle";
            title1.Text = "Seat Availability";
            this.chart1.Titles.Add(title1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Location = new System.Drawing.Point(29, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 242);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(567, 322);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(96, 32);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 586);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSeatView);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRequestStatus);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ComboBox cbRequestStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSeatView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReject;
    }
}