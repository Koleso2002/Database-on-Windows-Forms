using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Controllers
{
    internal class AddPrevetiveRepairs
    {
        private static SqlConnection conn;
        private static string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";

        private ModelPreventivRepairs preventivRepairs;

        public AddPrevetiveRepairs(ModelPreventivRepairs _preventivRepairs)
        {
            preventivRepairs = _preventivRepairs;
        }
        public void Method()
        {
            using (conn = new SqlConnection(path))
            {
                //string command = @"select * from PreventiveRepairs;";
                //SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                //DataSet ds = new DataSet();
                //adapter.Fill(ds);
                //DataTable tb = ds.Tables[0];
                //DataRow newRow = tb.NewRow();

                //newRow[1] = equip.Where(x => x.Value == textBox1.Text).FirstOrDefault().Key;
                //newRow[2] = dateTimePicker1.Value;
                //newRow[3] = Double.Parse(textBox2.Text);
                //newRow[4] = textBox3.Text;

                //tb.Rows.Add(newRow);
                //SqlCommandBuilder sqlCommand = new SqlCommandBuilder(adapter);
                //adapter.Update(tb);
            }

        }
    }
}
