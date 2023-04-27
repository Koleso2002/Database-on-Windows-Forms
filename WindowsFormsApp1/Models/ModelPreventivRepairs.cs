using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class ModelPreventivRepairs
    {
        public int Id { get; set; }
        public string NameEquipment { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }
        public string operation { get; set; }

    }
}
