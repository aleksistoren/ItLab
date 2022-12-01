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
    public partial class DataBaseMainForm : Form
    {
        public DataBaseMainForm()
        {
            InitializeComponent();
        }

        private void CreateDataBaseButton_Click(object sender, EventArgs e)
        {
            // open form for create DB
            var dataBaseCreateForm = new DataBaseCreateForm();
            DialogResult result = dataBaseCreateForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Program.databaseManager.CreateDatabase(dataBaseCreateForm.DataBaseName);
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void ShowDataBaseButton_Click(object sender, EventArgs e)
        {
            var databaseListViewForm = new DataBaseListViewForm();
            databaseListViewForm.ShowDialog();
        }

        private void RestoreDataBaseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Program.databaseManager.DumpsDirectory;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Program.databaseManager.RestoreDatabase(openFileDialog.OpenFile());
                    }
                    catch (ArgumentException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }
    }
}
