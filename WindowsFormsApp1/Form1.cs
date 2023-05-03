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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Form3 form3;
        MainRepository repository;
        public Form1()
        {
            InitializeComponent();
            Enter enter = new Enter(this);
            enter.ShowDialog();
            label1.Text = string.Empty;
            repository = new MainRepository();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            button4.Click += button3_Click;
            if (Roles.Role == RoleType.USER)
            {
                button2.Visible = false;
                tabPage2.Parent = null;
                tabPage5.Parent = null;
            }
        }

        private void DataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row.Cells[0].Value.ToString() != String.Empty)
            {
                int ind = (int)row.Cells[0].Value;
                Form2 form2 = new Form2();
                form2.ShowPassport(ind);
                form2.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Roles.Role == RoleType.ADMIN)
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                ShowAllPreventiveRepairs();
                ShowAllExtraRepairs();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = repository.ShowEquipmentMainWindow();
            label1.Text = "Двойным щелчком по строке вы можете посмотреть паспорт оборудования";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 passport = new Form2();
            passport.ShowDialog();
            dataGridView1.DataSource = repository.ShowEquipmentMainWindow();
        }

        private void ShowAllPreventiveRepairs()
        {
            DataTable dt = repository.ShowPrevRepairsOnMainWindow();
            ListViewItem item = null;
            foreach (DataRow row in dt.Select())
            {
                List<string> lv = new List<string>();
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    lv.Add(Convert.ToString(cell));
                }
                item = new ListViewItem(lv.ToArray());
                listView1.Items.Add(item);
            }
        }

        private void ShowAllExtraRepairs()
        {
            DataTable dt = repository.ShowExtraRepairsOnMainWindow();
            ListViewItem item = null;
            foreach (DataRow row in dt.Select())
            {
                List<string> lv = new List<string>();
                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    lv.Add(Convert.ToString(cell));
                }
                item = new ListViewItem(lv.ToArray());
                listView2.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ushort flagSender = 3;
            if (sender == button3)
                flagSender = 3;
            if (sender == button4)
                flagSender = 4;
            form3 = new Form3(flagSender);
            form3.ShowDialog();
            Thread.Sleep(1000);
            if (flagSender == 3)
            {
                listView1.Items.Clear();
                ShowAllPreventiveRepairs();
            }
            if (flagSender == 4)
            {
                listView2.Items.Clear();
                ShowAllExtraRepairs();
            }
        }
    }
}
