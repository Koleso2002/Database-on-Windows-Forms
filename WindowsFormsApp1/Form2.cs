using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        List<TypeEquipment> typeEquipment;
        Form5 form5;
        Equipment equipment = null;
        private int _indId;
        public int IndId
        {
            get => _indId;
            set { _indId = value; }
        }

        public Form2()
        {
            InitializeComponent();
            RequireRepairs.Enabled = false;
            PreventiveRepairs.Enabled = false;
            ExtraordinaryRepairs.Enabled = false;
            WorkNotWork.CheckedChanged += WorkNotWork_CheckedChanged;
            PreventiveRepairs.DoubleClick += PreventiveRepairs_DoubleClick;
            ExtraordinaryRepairs.DoubleClick+= PreventiveRepairs_DoubleClick;
            AllTypesEquipment();
        }


        private void AllTypesEquipment()
        {
            using (Context conn = new Context())
            {
                typeEquipment = conn.TypeEquipment.ToList();
            }
            Type.Items.Clear();
            Type.Items.AddRange(typeEquipment.Select(x => x.Type).ToArray());
        }

        private void WorkNotWork_CheckedChanged(object sender, EventArgs e)
        {
            if (WorkNotWork.Checked) RequireRepairs.Enabled = true;
            else RequireRepairs.Enabled = false;
        }

        private void AddEquipment(Equipment _equipment)
        {
            using (Context conn = new Context())
            {
                if (equipment == null)
                {
                    equipment = new Equipment();
                }
                else { equipment = _equipment; }
                TypeEquipment typeEquipment = new TypeEquipment();
                equipment.Name = Name.Text;
                equipment.fk_TypeEquipment = Type.SelectedIndex + 1;
                equipment.SerialNumber = SerialNumber.Text;
                equipment.ProductionDate = ProductionDate.Value;
                equipment.DateOfCommission = DateOfCommission.Value;
                equipment.PurchasePrice = Decimal.Parse(PurshasePrise.Text);
                equipment.ResidualPrice = Decimal.Parse(ResidualPrice.Text);
                equipment.PercentageOfWear = short.Parse(PercentageOfWear.Text);

                if (WorkNotWork.Checked)
                {
                    equipment.fk_Work_NotWork = "Не работает";
                    equipment.RequiredRepairs = RequireRepairs.Text;
                }
                else
                {
                    equipment.fk_Work_NotWork = "Работает";
                    equipment.RequiredRepairs = RequireRepairs.Text = "Не требуется";
                }
                conn.Equipment.AddOrUpdate(equipment);
                conn.SaveChanges();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {

            if (Name.Text == String.Empty || Type.Text == String.Empty || SerialNumber.Text == String.Empty ||
               PurshasePrise.Text == String.Empty || ResidualPrice.Text == String.Empty || PercentageOfWear.Text == String.Empty)
                MessageBox.Show("Заполните поля!");
            else
            {
                AddEquipment(equipment);
                this.Close();
            }
        }

        public void ShowPassport(int index)
        {
            label12.Text = "Двойным щелчком по полю дат вы сможете вывести всю информацию по ремонтам";
            using (Context conn = new Context())
            {
                equipment = conn.Equipment.Where(x => x.Id == index).FirstOrDefault();
                var prevRepairs = conn.PreventiveRepairs.Where(x => x.fk_EquipmentId == equipment.Id).
                    OrderByDescending(y => y.Data).FirstOrDefault();
                var extraRepairs = conn.ExtraordinaryRepairs.Where(x => x.fk_EquipmentId == equipment.Id).
                    OrderByDescending(y => y.Data).FirstOrDefault();
                int i = (int)equipment.fk_TypeEquipment;
                TypeEquipment typeEquipment = conn.TypeEquipment.Where(x => x.Id == i).FirstOrDefault();

                if (equipment != null)
                {
                    Name.Text = equipment.Name;
                    Type.Text = typeEquipment.Type;
                    SerialNumber.Text = equipment.SerialNumber;
                    ProductionDate.Text = equipment.ProductionDate.ToString();
                    DateOfCommission.Text = equipment.DateOfCommission.ToString();
                    PurshasePrise.Text = equipment.PurchasePrice.ToString();
                    ResidualPrice.Text = equipment.ResidualPrice.ToString();
                    PercentageOfWear.Text = equipment.PercentageOfWear.ToString();
                    RequireRepairs.Text = equipment.RequiredRepairs;
                    PreventiveRepairs.Enabled = true;
                    if (prevRepairs != null)
                        PreventiveRepairs.Text = prevRepairs.Data.ToShortDateString();
                    else
                        PreventiveRepairs.Text = equipment.PreventiveMaintenance.GetValueOrDefault().ToShortDateString();
                    ExtraordinaryRepairs.Enabled = true;
                    if (extraRepairs != null)
                        ExtraordinaryRepairs.Text = extraRepairs.Data.ToShortDateString();
                    else
                        ExtraordinaryRepairs.Text = equipment.ExtraordinaryRepairs.GetValueOrDefault().ToShortDateString();
                    if (equipment.fk_Work_NotWork == "Не работает")
                        WorkNotWork.Text = "Не работает";
                    else WorkNotWork.Text = "Работает";
                }

                if (Roles.Role == RoleType.USER)
                {
                    Add.Enabled = false;
                    Add.Visible = false;
                    Name.ReadOnly = true;
                    Type.DroppedDown = false;
                    SerialNumber.ReadOnly = true;
                    ProductionDate.Enabled = false;
                    DateOfCommission.Enabled = false;
                    PurshasePrise.ReadOnly = true;
                    ResidualPrice.ReadOnly = true;
                    PercentageOfWear.ReadOnly = true;
                    RequireRepairs.ReadOnly = true;
                    PreventiveRepairs.ReadOnly = true;
                    ExtraordinaryRepairs.ReadOnly = true;
                    WorkNotWork.Enabled = false;
                }
                if (Roles.Role == RoleType.ADMIN)
                {
                    Add.Text = "Сохранить изменения";
                }

            }

        }

        private void PreventiveRepairs_DoubleClick(object sender, EventArgs e)
        {
            IndId = equipment.Id;
            form5 = new Form5(this);
            form5.Show();
        }

     
    }
}
