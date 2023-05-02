using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ModelView
{
    internal class EquipmentOnMainWindow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string typeEquipment { get; set; }
        public string serialNumber { get; set; }
        public DateTime productionDate { get; set; }
        public DateTime dateOfCommission { get; set; }
        public double purchasePrice { get; set; }
        public double residualPrice { get; set; }
        public int percentOfWear { get; set; }
        public string workNotWork { get; set; }
        public string requiredRepairs { get; set; }
    }
}
