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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";
        SqlConnection conn;
        Form3 form3;

        public Form1()
        {
            InitializeComponent();
            Enter enter = new Enter(this);
            enter.ShowDialog();
            label1.Text=string.Empty;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
            if (Roles.Role == RoleType.USER)
            {
                button2.Visible=false;
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
                ShowAllEquipment();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            listView1.Items.Clear();
            ShowAllEquipment();
            ShowAllPreventiveRepairs();
            label1.Text = "Двойным щелчком по строке вы можете посмотреть паспорт оборудования";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 passport = new Form2();
            passport.ShowDialog();
            ShowAllEquipment();
        }

        DataTable dataTable = new DataTable();

        private void ShowAllEquipment()
        {
            using (conn = new SqlConnection(path))
            {
                string command = @"select Equipment.Id, Equipment.Name as 'Оборудование', TypeEquipment.Type as 'Тип оборудования',
                                        Equipment.SerialNumber as 'Заводской номер', Equipment.ProductionDate as 'Дата выпуска',
                                        Equipment.DateOfCommission as 'Дата ввода в эксплуатацию', Equipment.PurchasePrice as 'Стоимость покупки',
                                        Equipment.ResidualPrice as 'Остаточная стоимость',Equipment.PercentageOfWear as 'Процент износа',
                                        Equipment.fk_Work_NotWork as 'Работает/не работает'
                                        from Equipment join TypeEquipment on Equipment.fk_TypeEquipment=TypeEquipment.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataTable = ds.Tables[0];
                dataGridView1.DataSource = dataTable;
            }
        }

        private void ShowAllPreventiveRepairs()
        {
            using (conn = new SqlConnection(path))
            {
                string command1 = @"select PreventiveRepairs.Id, Equipment.Name, PreventiveRepairs.Data,
                                    PreventiveRepairs.Price, PreventiveRepairs.Operation
                                    from PreventiveRepairs join Equipment on PreventiveRepairs.fk_EquipmentId=Equipment.Id;";


                SqlDataAdapter adapter = new SqlDataAdapter(command1, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.ShowDialog();
            Thread.Sleep(1000);
            listView1.Items.Clear();
            ShowAllPreventiveRepairs();

        }
    }
}
