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
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private ModelPreventivRepairs preventivRepairs;
        private AddPrevetiveRepairs addPrevetiveRepairs;

        private static SqlConnection conn;
        private static string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";

        Dictionary<int, string> equip = new Dictionary<int, string>();
        Form4 form4;

        public Form3()
        {
            InitializeComponent();
            preventivRepairs = new ModelPreventivRepairs();
            textBox2.LostFocus += TextBox2_LostFocus;
        }

        private void TextBox2_LostFocus(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox2.Text, out var pr))
            {
                preventivRepairs.price = pr;
            }
            else
            {
                MessageBox.Show("В поле \"Сумма\" неверный формат данных. Попробуйте ввести копейки через запятую!");
                textBox2.Focus();
            }
        }

        private bool AddRepairs()
        {
            bool flag = false;
            preventivRepairs.NameEquipment = textBox1.Text;
            preventivRepairs.date = dateTimePicker1.Value;
            if (textBox3.Text != string.Empty)
            {
                preventivRepairs.operation = textBox3.Text;
                flag = true;
            }
            return flag;
        }


        //  string eqp;
        //DateTime date;
        //double price;
        //string operations;

        //bool flag = true;
        //while (flag)
        //{
        //    try
        //    {
        //        eqp = equip.Where(x => x.Value == textBox1.Text).FirstOrDefault().Key.ToString();
        //        date = dateTimePicker1.Value;
        //        price = Double.Parse(textBox2.Text);
        //        operations = textBox3.Text;
        //        flag = false;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("В поле \"Сумма\" неверный формат. Попробуйте ввести копейки через запятую!");
        //    }

        //    using (conn = new SqlConnection(path))
        //    {
        //        string command = @"select * from PreventiveRepairs;";
        //        SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds);
        //        DataTable tb = ds.Tables[0];
        //        DataRow newRow = tb.NewRow();

        //        newRow[1] = equip.Where(x => x.Value == textBox1.Text).FirstOrDefault().Key;
        //        newRow[2] = dateTimePicker1.Value;
        //        newRow[3] = Double.Parse(textBox2.Text);
        //        newRow[4] = textBox3.Text;

        //    tb.Rows.Add(newRow);
        //    SqlCommandBuilder sqlCommand = new SqlCommandBuilder(adapter);
        //    adapter.Update(tb);
        //    }
        //}


        private void button1_Click(object sender, EventArgs e)
        {

            if (AddRepairs())
            {
                addPrevetiveRepairs = new AddPrevetiveRepairs(preventivRepairs);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.ShowDialog();

            int key = form4.indexId;
            if (key != 0)
            {
                using (conn = new SqlConnection(path))
                {
                    string command = @"Select * from Equipment;";
                    SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                    SqlCommandBuilder sqlCommand = new SqlCommandBuilder(adapter);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable tb = ds.Tables[0];

                    equip.Clear();
                    foreach (DataRow row in tb.Select())
                    {
                        equip.Add(Convert.ToInt32(row[0]), Convert.ToString(row[1]));
                    }
                }
                textBox1.Text = equip[key];
            }
        }
    }
}
