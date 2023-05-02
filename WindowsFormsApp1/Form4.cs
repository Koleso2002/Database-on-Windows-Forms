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
using WindowsFormsApp1.Controllers;
using WindowsFormsApp1.ModelView;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private MainRepository repository;
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
            repository = new MainRepository();
            dataGridView1.DataSource = repository.ShowEquipmentAddRepairs();
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

    }
}
