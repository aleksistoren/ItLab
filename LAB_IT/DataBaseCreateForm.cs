﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_IT
{
    public partial class DataBaseCreateForm : Form
    {
        public string DataBaseName
        {
            get
            {
                return DataBaseNameTextBox.Text;
            }
        }

        public DataBaseCreateForm()
        {
            InitializeComponent();
        }

        private void DataBaseCreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
