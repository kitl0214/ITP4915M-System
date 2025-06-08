namespace ITP4915M_System      // ⚠ 與其他檔保持一致
{
    public class OrderModel
    {
        public int Oid { get; set; }      // 6-digit Order ID
        public string Customer { get; set; } = "";
        public string Product { get; set; } = "";
        public int Unit { get; set; }      // 單價 (int)
        public int Qty { get; set; }      // 數量 (int)
        public bool IsCustom { get; set; }      // Custom / General
        public bool ExtraPack { get; set; }      // +$1 包裝
        public DateTime DueDate { get; set; }
        public int Total { get; set; }      // 計算後總價
    }
}
