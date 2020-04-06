using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentsDataSet.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.studentsDataSet.Students);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentsDataSet.Journal". При необходимости она может быть перемещена или удалена.
            this.journalTableAdapter.Fill(this.studentsDataSet.Journal);
            

        }

        private void JournalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.journalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentsDataSet);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for(int i=0;i<studentsDataGridView.RowCount-1;i++)
            {
                this.journalTableAdapter.Insert(new Guid(studentsDataGridView.Rows[i].Cells[0].Value.ToString()), dataTimePicker.Value, Convert.ToBoolean(studentsDataGridView.Rows[i].Cells[3].Value));
            }
            this.tableAdapterManager.UpdateAll(this.studentsDataSet);
        }
    }
}
