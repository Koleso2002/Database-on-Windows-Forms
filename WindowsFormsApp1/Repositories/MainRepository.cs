using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.ModelView;

namespace WindowsFormsApp1.Controllers
{
    internal class MainRepository
    {
        private static SqlConnection conn;
        private static string path = @"Data Source=KONSTANTIN\SQLEXPRESS;
                            Initial Catalog=Equipment;
                            Integrated Security=SSPI;";

        private ModelPreventivRepairs preventivRepairs;
        private ModelExtraOrdinaryRepairs extraOrdinaryRepairs;

        //private ModelEquipment modelEquipment;
        //private EquipmentOnMainWindow equipmentOnMainWindow;
        //private PrevRepairsOnMainWindow prevRepairsOnMainWindow;
        DataTable tb;

        public void AddPreventiveRepairs(ModelPreventivRepairs _preventivRepairs)
        {
            preventivRepairs = _preventivRepairs;
            using (conn = new SqlConnection(path))
            {
                string command = @"select * from PreventiveRepairs;";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tb = ds.Tables[0];
                DataRow newRow = tb.NewRow();

                newRow[1] = preventivRepairs.IdEquipment;
                newRow[2] = preventivRepairs.date;
                newRow[3] = preventivRepairs.price;
                newRow[4] = preventivRepairs.operation;

                tb.Rows.Add(newRow);
                SqlCommandBuilder sqlCommand = new SqlCommandBuilder(adapter);
                adapter.Update(tb);
            }
        }

        public void AddExtraRepairs(ModelExtraOrdinaryRepairs _extraOrdinaryRepairs)
        {
            extraOrdinaryRepairs = _extraOrdinaryRepairs;
            using (conn = new SqlConnection(path))
            {
                string command = @"select * from ExtraordinaryRepairs;";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tb = ds.Tables[0];
                DataRow newRow = tb.NewRow();

                newRow[1] = extraOrdinaryRepairs.IdEquipment;
                newRow[2] = extraOrdinaryRepairs.date;
                newRow[3] = extraOrdinaryRepairs.price;
                newRow[4] = extraOrdinaryRepairs.operation;

                tb.Rows.Add(newRow);
                SqlCommandBuilder sqlCommand = new SqlCommandBuilder(adapter);
                adapter.Update(tb);
            }
        }

        public DataTable ShowEquipmentMainWindow()
        {
            using (conn = new SqlConnection(path))
            {
                string command = @"select Equipment.Id, Equipment.Name as 'Оборудование', TypeEquipment.Type as 'Тип оборудования',
                                        Equipment.SerialNumber as 'Заводской номер', Equipment.ProductionDate as 'Дата выпуска',
                                        Equipment.DateOfCommission as 'Дата ввода в эксплуатацию', Equipment.PurchasePrice as 'Стоимость покупки',
                                        Equipment.ResidualPrice as 'Остаточная стоимость',Equipment.PercentageOfWear as 'Процент износа',
                                        Equipment.fk_Work_NotWork as 'Работает/не работает'
                                        from Equipment join TypeEquipment on Equipment.fk_TypeEquipment=TypeEquipment.Id;";

                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tb = ds.Tables[0];
            }
            return tb;
        }

        public DataTable ShowPrevRepairsOnMainWindow()
        {
            using (conn = new SqlConnection(path))
            {
                string command1 = @"select PreventiveRepairs.Id, Equipment.Name, PreventiveRepairs.Data,
                                    PreventiveRepairs.Price, PreventiveRepairs.Operation
                                    from PreventiveRepairs join Equipment on PreventiveRepairs.fk_EquipmentId=Equipment.Id;";


                SqlDataAdapter adapter = new SqlDataAdapter(command1, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tb = ds.Tables[0];
            }
            return tb;
        }

        public DataTable ShowExtraRepairsOnMainWindow()
        {
            using (conn = new SqlConnection(path))
            {
                string command1 = @"select ExtraordinaryRepairs.Id, Equipment.Name, ExtraordinaryRepairs.Data,
                                    ExtraordinaryRepairs.Price, ExtraordinaryRepairs.Operation
                                    from ExtraordinaryRepairs join Equipment on ExtraordinaryRepairs.fk_EquipmentId=Equipment.Id;";


                SqlDataAdapter adapter = new SqlDataAdapter(command1, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tb = ds.Tables[0];
            }
            return tb;
        }

        public DataTable ShowEquipmentAddRepairs()
        {
            using (conn = new SqlConnection(path))
            {
                string command = @"Select Equipment.Id,Equipment.Name as 'Оборудование',Equipment.SerialNumber as 'Заводской номер' 
                                    from Equipment;";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                tb = ds.Tables[0];
            }
            return tb;
        }

    }
}
