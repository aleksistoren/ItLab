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
    public partial class ProjectionTablesResultForm : Form
    {
        public ProjectionTablesResultForm(Table table1, List<String> indexs)
        {
            List<int> indx = new List<int>();
            foreach(var index in indexs){ 
                if (int.TryParse(index, out int n))
                {
                    indx.Add(n);
                }
                else
                {
                    throw new InvalidOperationException($"Index must be int, {index} is not int");
                }
            }
            InitializeComponent();
            foreach (var i in indx)
            {
                var columnDefinition = table1.ColumnDefinitions[i - 1];
                var col = new DataGridViewTextBoxColumn();
                col.Name = columnDefinition.Name;
                col.HeaderText = columnDefinition.Name;
                ResultDataGridView.Columns.Add(col);
            }

            List<List<object>> data = Table.ProjectionTables(table1, indx);
            foreach (var dataRow in data)
            {
                int n = ResultDataGridView.Rows.Add();
                var row = ResultDataGridView.Rows[n];
                for (int i = 0; i < dataRow.Count; i++)
                {
                    if (dataRow[i] is null)
                    {
                        row.Cells[i].Value = "";
                    }
                    else
                    {
                        row.Cells[i].Value = dataRow[i].ToString();
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
