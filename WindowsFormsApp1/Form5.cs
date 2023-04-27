using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private int ind;
        private Form2 form2;
        public Form5(Form2 _form2)
        {
            InitializeComponent();
            form2 = _form2;
            listView1.FullRowSelect = true;
            listView2.FullRowSelect = true;
            Font font = new Font("Arial", 9, FontStyle.Regular);
            tabControl1.Font = font;
            ind = form2.IndId;
            ShowPrevRepairs();
            ShowExtraordinaryRepairs();

        }

        public void ShowPrevRepairs()
        {
            listView1.Items.Clear();
            using (Context conn = new Context())
            {
                //var prevRepairs=conn.PreventiveRepairs.Where(x=>x.Id==ind).ToList();
                var prevRepairs = conn.PreventiveRepairs.Include(x => x.Equipment).Where(x => x.fk_EquipmentId == ind);

                ListViewItem item = null;

                foreach (var pp in prevRepairs)
                {
                    item = new ListViewItem(new string[] {pp.Id.ToString(),pp.Equipment.Name.ToString(),pp.Data.ToString(),
                                                          ((double)pp.Price).ToString(), pp.Operation.ToString()});

                    listView1.Items.Add(item);

                }

            }

        }

        public void ShowExtraordinaryRepairs()
        {
            listView2.Items.Clear();
            using (Context conn = new Context())
            {
                var extraRepairs = conn.ExtraordinaryRepairs.Include(x => x.Equipment).Where(x => x.fk_EquipmentId == ind);
                ListViewItem item = null;

                foreach (var pp in extraRepairs)
                {
                    item = new ListViewItem(new string[] {pp.Id.ToString(),pp.Equipment.Name.ToString(),pp.Data.ToString(),
                                                          pp.Price.ToString(), pp.Operation.ToString()});

                    listView2.Items.Add(item);

                }
            }

        }
    }
}
