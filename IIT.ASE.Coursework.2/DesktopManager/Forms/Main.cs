﻿using DesktopManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopManager.Forms
{
    public partial class Main : Form
    {
        private BookingService _bookingService;
        public Main()
        {
            InitializeComponent();
            _bookingService = new BookingService();
            LoadData();
        }

        public void LoadData()
        {
            var data = _bookingService.LoadBookings();

            dataGridView1.AutoGenerateColumns = false;
            
            //dataGridView1.DataMember = 
            //dataGridView1.Columns[1].Name = "Category";
            //dataGridView1.Columns[2].Name = "Main Ingredients";
            //dataGridView1.Columns[3].Name = "Rating";

            dataGridView1.DataSource = data;
        }
        public enum BookingStatusEnum
        {
            Accepted = 1,
            Pending = 2,
            Rejected = 3,
            Cancelled = 4
        }
    }
}
