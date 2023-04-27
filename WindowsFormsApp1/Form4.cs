using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private static SqlConnection conn;
        private static string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";
        //Form3 form3;
        private int _indexId;
        public int indexId
        {
            get => _indexId;
            set
            {
                _indexId = value;
            }
        }

        public Form4()
        {
            InitializeComponent();
            //form3 = _form3;
            Fill();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           DataGridViewRow row = dataGridView1.CurrentRow;
            if (row.Cells[0].Value.ToString() != String.Empty)
            {
                indexId = (int)row.Cells[0].Value;
            }
            this.Close();
        }


        private void Fill()
        {
            using (conn = new SqlConnection(path))
            {
                string command = @"Select Equipment.Id,Equipment.Name as 'Оборудование',Equipment.SerialNumber as 'Заводской номер' 
                                    from Equipment;";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tb = ds.Tables[0];
                dataGridView1.DataSource = tb;
            }
        }
    }
}
