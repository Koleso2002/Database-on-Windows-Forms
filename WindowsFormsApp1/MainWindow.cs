using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class MainWindow
    {
        private static SqlConnection conn;
        private static string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";


        public static DataSet Show(SqlConnection _conn)
        {
            conn = _conn;
            using (conn = new SqlConnection(path))
            {
                conn.Open();
                string commandShow = @"select Equipment.Id, Equipment.Name as 'Оборудование', TypeEquipment.Type as 'Тип оборудования',
                                        Equipment.SerialNumber as 'Заводской номер', Equipment.ProductionDate as 'Дата выпуска',
                                        Equipment.DateOfCommission as 'Дата ввода в эксплуатацию', Equipment.PurchasePrice as 'Стоимость покупки',
                                        Equipment.ResidualPrice as 'Остаточная стоимость',Equipment.PercentageOfWear as 'Процент износа',
                                        Equipment.fk_Work_NotWork as 'Работает/не работает'
                                        from Equipment join TypeEquipment on Equipment.fk_TypeEquipment=TypeEquipment.Id";

                SqlDataAdapter adapter = new SqlDataAdapter(commandShow, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

                //DataTable table = new DataTable();



                //SqlCommand command = new SqlCommand(commandShow, conn);
                //command.ExecuteNonQuery();
                //SqlDataReader sql = command.ExecuteReader();

                //table.Load(sql);

                //dataGridView1.DataSource = table;
                //dataGridView1.ReadOnly = true;
            }
        }
    }
}
