namespace ITP4915M_System
{
    public class FormProdModel
    {
        public int Oid { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Unit { get; set; } = "pcs";
        public int Qty { get; set; }
        public bool IsCustom { get; set; }
        public bool ExtraPack { get; set; }
        public DateTime DueDate { get; set; }
        public int Total { get; set; }
    }
}


