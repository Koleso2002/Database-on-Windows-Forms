using System;


namespace WindowsFormsApp1.Models
{
    internal class ModelEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string typeEquipment { get; set; }
        public string serialNumber { get; set; }
        public DateTime productionDate { get; set; }
        public DateTime dateOfCommission { get; set; }
        public double purchasePrice { get; set; }
        public double residualPrice { get; set; }
        public int percentOfWear { get;set; }
        public string workNotWork { get; set; }
        public string requiredRepairs { get; set; }
        public DateTime preventiveRepairs { get; set; }
        public DateTime extraordinaryRepairs { get; set; }
    }
}
