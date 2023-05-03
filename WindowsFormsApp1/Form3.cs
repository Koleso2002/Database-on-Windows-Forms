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
        ushort flagSender;
        private ModelPreventivRepairs preventivRepairs;
        private ModelExtraOrdinaryRepairs extraOrdinaryRepairs;
        //private ModelOverRepair overRepair;
        private MainRepository repository;

        Dictionary<int, string> equip = new Dictionary<int, string>();
        int idEquipment;
        Form4 form4;
        public Form3(ushort _flagSender)
        {
            InitializeComponent();
            flagSender = _flagSender;
            preventivRepairs = new ModelPreventivRepairs();
            extraOrdinaryRepairs = new ModelExtraOrdinaryRepairs();
            //overRepair = new ModelOverRepair();
            repository = new MainRepository();
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
            //preventivRepairs.NameEquipment = equip.Where(x => x.Value == textBox1.Text && x.Key== idEquipment).FirstOrDefault().Key.ToString();
            preventivRepairs.IdEquipment=idEquipment;
            preventivRepairs.date = dateTimePicker1.Value;
            if (textBox3.Text != string.Empty)
            {
                preventivRepairs.operation = textBox3.Text;
                flag = true;
            }
            return flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (AddRepairs())
            {
                if (flagSender == 3)
                {
                    repository.AddPreventiveRepairs(preventivRepairs);
                }
                if (flagSender == 4)
                {
                    repository.AddExtraRepairs(extraOrdinaryRepairs);
                }
                    this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            form4.ShowDialog();
            idEquipment = form4.indexId;
            if (idEquipment != 0)
            {
                DataTable tb = repository.ShowEquipmentMainWindow();
                equip.Clear();
                foreach (DataRow row in tb.Select())
                {
                    equip.Add(Convert.ToInt32(row[0]), Convert.ToString(row[1]));
                }
                textBox1.Text = equip[idEquipment];
            }
        }
    }
}
