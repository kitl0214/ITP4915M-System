// -----------------------------------------------------------------------------
// FormUserStubs.cs – 只替「尚未改造」的表單補兩參數建構子
//   ⚠️ 已改造完成的表單 (如 FormSales) 請刪除對應 Stub，避免衝突
// -----------------------------------------------------------------------------
namespace ITP4915M_System
{
    // ── 尚未改造 ─────────────────────────────
    public partial class FormRD
    { public FormRD(string user, string dept) : this() { } }

    public partial class FormProd
    { public FormProd(string user, string dept) : this() { } }

    public partial class FormFinance
    { public FormFinance(string user, string dept) : this() { } }

    public partial class FormLogistics
    { public FormLogistics(string user, string dept) : this() { } }

    // ── (FormSales 已改造，Stub 已移除) ───────
}
