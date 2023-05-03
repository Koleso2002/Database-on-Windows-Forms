using System;

namespace WindowsFormsApp1.Models
{
    internal class ModelPreventivRepairs
    {
        public int Id { get; set; }
        public int IdEquipment { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }
        public string operation { get; set; }

    }
}
