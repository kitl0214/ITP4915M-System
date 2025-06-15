namespace ITP4915M_System
{
    public class InvoiceModel
    {
        public string InvoiceID { get; set; }
        public string OrderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
    }
}