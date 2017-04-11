namespace TabApplication.Forms
{
    partial class SeatView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatView));
            this.gbSeatPlan = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.seatId_107 = new System.Windows.Forms.Button();
            this.seatId_108 = new System.Windows.Forms.Button();
            this.seatId_104 = new System.Windows.Forms.Button();
            this.seatId_106 = new System.Windows.Forms.Button();
            this.seatId_103 = new System.Windows.Forms.Button();
            this.seatId_109 = new System.Windows.Forms.Button();
            this.seatId_105 = new System.Windows.Forms.Button();
            this.seatId_110 = new System.Windows.Forms.Button();
            this.seatId_102 = new System.Windows.Forms.Button();
            this.seatId_111 = new System.Windows.Forms.Button();
            this.seatId_101 = new System.Windows.Forms.Button();
            this.seatId_100 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.UpdateSeatWorker = new System.ComponentModel.BackgroundWorker();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbSeatPlan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSeatPlan
            // 
            this.gbSeatPlan.BackColor = System.Drawing.Color.White;
            this.gbSeatPlan.Controls.Add(this.panel1);
            this.gbSeatPlan.Controls.Add(this.label1);
            this.gbSeatPlan.Controls.Add(this.seatId_107);
            this.gbSeatPlan.Controls.Add(this.seatId_108);
            this.gbSeatPlan.Controls.Add(this.seatId_104);
            this.gbSeatPlan.Controls.Add(this.seatId_106);
            this.gbSeatPlan.Controls.Add(this.seatId_103);
            this.gbSeatPlan.Controls.Add(this.seatId_109);
            this.gbSeatPlan.Controls.Add(this.seatId_105);
            this.gbSeatPlan.Controls.Add(this.seatId_110);
            this.gbSeatPlan.Controls.Add(this.seatId_102);
            this.gbSeatPlan.Controls.Add(this.seatId_111);
            this.gbSeatPlan.Controls.Add(this.seatId_101);
            this.gbSeatPlan.Controls.Add(this.seatId_100);
            this.gbSeatPlan.Location = new System.Drawing.Point(45, 118);
            this.gbSeatPlan.Name = "gbSeatPlan";
            this.gbSeatPlan.Size = new System.Drawing.Size(497, 497);
            this.gbSeatPlan.TabIndex = 0;
            this.gbSeatPlan.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 28);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Reserved";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(250, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 10);
            this.label6.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Pending";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(332, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 10);
            this.label4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(428, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Available";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(414, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 10);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(103, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stage";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seatId_107
            // 
            this.seatId_107.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_107.Location = new System.Drawing.Point(355, 172);
            this.seatId_107.Name = "seatId_107";
            this.seatId_107.Size = new System.Drawing.Size(63, 30);
            this.seatId_107.TabIndex = 0;
            this.seatId_107.Text = "107";
            this.seatId_107.UseVisualStyleBackColor = true;
            this.seatId_107.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_108
            // 
            this.seatId_108.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_108.Location = new System.Drawing.Point(286, 172);
            this.seatId_108.Name = "seatId_108";
            this.seatId_108.Size = new System.Drawing.Size(63, 30);
            this.seatId_108.TabIndex = 0;
            this.seatId_108.Text = "108";
            this.seatId_108.UseVisualStyleBackColor = true;
            this.seatId_108.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_104
            // 
            this.seatId_104.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_104.Location = new System.Drawing.Point(355, 117);
            this.seatId_104.Name = "seatId_104";
            this.seatId_104.Size = new System.Drawing.Size(63, 30);
            this.seatId_104.TabIndex = 0;
            this.seatId_104.Text = "104";
            this.seatId_104.UseVisualStyleBackColor = true;
            this.seatId_104.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_106
            // 
            this.seatId_106.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_106.Location = new System.Drawing.Point(424, 172);
            this.seatId_106.Name = "seatId_106";
            this.seatId_106.Size = new System.Drawing.Size(63, 30);
            this.seatId_106.TabIndex = 0;
            this.seatId_106.Text = "106";
            this.seatId_106.UseVisualStyleBackColor = true;
            this.seatId_106.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_103
            // 
            this.seatId_103.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_103.Location = new System.Drawing.Point(286, 117);
            this.seatId_103.Name = "seatId_103";
            this.seatId_103.Size = new System.Drawing.Size(63, 30);
            this.seatId_103.TabIndex = 0;
            this.seatId_103.Text = "103";
            this.seatId_103.UseVisualStyleBackColor = true;
            this.seatId_103.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_109
            // 
            this.seatId_109.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_109.Location = new System.Drawing.Point(145, 172);
            this.seatId_109.Name = "seatId_109";
            this.seatId_109.Size = new System.Drawing.Size(63, 30);
            this.seatId_109.TabIndex = 0;
            this.seatId_109.Text = "109";
            this.seatId_109.UseVisualStyleBackColor = true;
            this.seatId_109.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_105
            // 
            this.seatId_105.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_105.Location = new System.Drawing.Point(424, 117);
            this.seatId_105.Name = "seatId_105";
            this.seatId_105.Size = new System.Drawing.Size(63, 30);
            this.seatId_105.TabIndex = 0;
            this.seatId_105.Text = "105";
            this.seatId_105.UseVisualStyleBackColor = true;
            this.seatId_105.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_110
            // 
            this.seatId_110.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_110.Location = new System.Drawing.Point(76, 172);
            this.seatId_110.Name = "seatId_110";
            this.seatId_110.Size = new System.Drawing.Size(63, 30);
            this.seatId_110.TabIndex = 0;
            this.seatId_110.Text = "110";
            this.seatId_110.UseVisualStyleBackColor = true;
            this.seatId_110.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_102
            // 
            this.seatId_102.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_102.Location = new System.Drawing.Point(145, 117);
            this.seatId_102.Name = "seatId_102";
            this.seatId_102.Size = new System.Drawing.Size(63, 30);
            this.seatId_102.TabIndex = 0;
            this.seatId_102.Text = "102";
            this.seatId_102.UseVisualStyleBackColor = true;
            this.seatId_102.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_111
            // 
            this.seatId_111.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_111.Location = new System.Drawing.Point(7, 172);
            this.seatId_111.Name = "seatId_111";
            this.seatId_111.Size = new System.Drawing.Size(63, 30);
            this.seatId_111.TabIndex = 0;
            this.seatId_111.Text = "111";
            this.seatId_111.UseVisualStyleBackColor = true;
            this.seatId_111.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_101
            // 
            this.seatId_101.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_101.Location = new System.Drawing.Point(76, 117);
            this.seatId_101.Name = "seatId_101";
            this.seatId_101.Size = new System.Drawing.Size(63, 30);
            this.seatId_101.TabIndex = 0;
            this.seatId_101.Text = "101";
            this.seatId_101.UseVisualStyleBackColor = true;
            this.seatId_101.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // seatId_100
            // 
            this.seatId_100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seatId_100.Location = new System.Drawing.Point(7, 117);
            this.seatId_100.Name = "seatId_100";
            this.seatId_100.Size = new System.Drawing.Size(63, 30);
            this.seatId_100.TabIndex = 0;
            this.seatId_100.Text = "100";
            this.seatId_100.UseVisualStyleBackColor = true;
            this.seatId_100.Click += new System.EventHandler(this.OnSeatClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UploadBooking_Worker);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(101, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(384, 45);
            this.label8.TabIndex = 1;
            this.label8.Text = "IIT STAGE CRAFT 2017";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(42, 626);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh Seats";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // UpdateSeatWorker
            // 
            this.UpdateSeatWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateSeatWorker_DoWork);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(469, 626);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SeatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gbSeatPlan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 700);
            this.Name = "SeatView";
            this.Text = "Seat Plan";
            this.gbSeatPlan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSeatPlan;
        private System.Windows.Forms.Button seatId_104;
        private System.Windows.Forms.Button seatId_103;
        private System.Windows.Forms.Button seatId_105;
        private System.Windows.Forms.Button seatId_102;
        private System.Windows.Forms.Button seatId_101;
        private System.Windows.Forms.Button seatId_100;
        private System.Windows.Forms.Button seatId_107;
        private System.Windows.Forms.Button seatId_108;
        private System.Windows.Forms.Button seatId_106;
        private System.Windows.Forms.Button seatId_109;
        private System.Windows.Forms.Button seatId_110;
        private System.Windows.Forms.Button seatId_111;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRefresh;
        private System.ComponentModel.BackgroundWorker UpdateSeatWorker;
        private System.Windows.Forms.Button btnExit;
    }
}