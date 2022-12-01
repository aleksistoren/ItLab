using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB_IT_SERVER_;

namespace LAB_IT_CLIENT
{
    public partial class ProjectionTablesForm : Form
    {
        private Database ContextDb;
        private Table table1;

        public ProjectionTablesForm(Database db)
        {
            InitializeComponent();

            ContextDb = db;

            Table1ComboBox.DataSource = new BindingSource(this.ContextDb.Tables, null);
            Table1ComboBox.DisplayMember = "Name";
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            table1 = (Table)Table1ComboBox.SelectedItem;
            var indexs = IndexOfProjectionTextBox.Text.Split(' ').ToList(); 

            var form = new ProjectionTablesResultForm(table1, indexs);
            form.ShowDialog();
        }

        private void Table2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
