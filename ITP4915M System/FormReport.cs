// -----------------------------------------------------------------------------
// FormReport.cs – monthly overview + safe CSV export (never throws on locked file)
// -----------------------------------------------------------------------------
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ITP4915MSystem;            //  Database.GetConnection()

namespace ITP4915M_System
{
    public partial class FormReport : Form
    {
        /* 若實際日期欄不是 due_date，請改為 order_date 或其他欄。                */
        private const string DATE_FIELD = "COALESCE(o.due_date, o.created_at)";

        public FormReport() => InitializeComponent();

        /* -------------------------------  LIFE-CYCLE  ------------------------------- */
        private void FormReport_Load(object? sender, EventArgs e)
        {
            dgvOrders.DataSource = LoadMonthlyOrders();     // 只顯示有訂單的月份
            dgvFollowups.DataSource = LoadMonthlyPending();    // 只顯示有 PENDING 的月份

            lblOrderCount.Text = $"Total orders: {GetScalar("SELECT COUNT(*) FROM orders")}";
            lblFUCount.Text = $"Pending follow-ups: {GetScalar("SELECT COUNT(*) FROM cs_followups WHERE status='PENDING'")}";

            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvFollowups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        /* -------------------------------  SQL UTIL  --------------------------------- */
        private static DataTable Query(string sql)
        {
            using var conn = Database.GetConnection();
            using var da = new MySqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        private static int GetScalar(string sql)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        /* -----------------------------  MONTHLY TABLES  ----------------------------- */
        private DataTable LoadMonthlyOrders()
        {
            string sql = $@"
              SELECT YEAR({DATE_FIELD}) AS `Year`,
                     UPPER(LEFT(MONTHNAME({DATE_FIELD}),3)) AS `Month`,
                     COUNT(*) AS `Orders`
              FROM orders o
              GROUP BY `Year`,`Month`
              ORDER BY `Year` DESC, MONTH({DATE_FIELD}) DESC";
            return Query(sql);
        }
        private DataTable LoadMonthlyPending()
        {
            string sql = $@"
              SELECT YEAR({DATE_FIELD}) AS `Year`,
                     UPPER(LEFT(MONTHNAME({DATE_FIELD}),3)) AS `Month`,
                     COUNT(*) AS `Pending`
              FROM orders o
              JOIN cs_followups f ON f.oid = o.oid AND f.status='PENDING'
              GROUP BY `Year`,`Month`
              ORDER BY `Year` DESC, MONTH({DATE_FIELD}) DESC";
            return Query(sql);
        }

        /* -------------------------  FULL DETAIL FOR EXPORT  ------------------------- */
        private static DataTable LoadAllOrders()
            => Query("SELECT * FROM orders ORDER BY created_at DESC");

        private static DataTable LoadFullPendingFollowups()
        {
            const string sql = @"
              SELECT
                  f.fid,
                  f.oid,
                  f.action,
                  f.comment,
                  f.status,
                  CASE WHEN f.action IN ('DISCOUNT','BOTH') THEN 'Y' ELSE '' END AS DiscountFlag,
                  CASE WHEN f.action IN ('REFUND','BOTH')   THEN 'Y' ELSE '' END AS RefundFlag,
                  f.created_at
              FROM cs_followups f
              JOIN orders o ON o.oid = f.oid
              WHERE f.status = 'PENDING'
              ORDER BY o.created_at DESC, f.fid";
            return Query(sql);
        }

        /* ------------------------------  CSV EXPORT  -------------------------------- */
        private void btnExportOrders_Click(object? s, EventArgs e)
            => ExportCsv(LoadAllOrders(), "orders_full");

        private void btnExportFU_Click(object? s, EventArgs e)
            => ExportCsv(LoadFullPendingFollowups(), "followups_pending");

        /// <summary>
        /// 寫入 CSV；若檔案被占用則提醒使用者並取消寫檔。
        /// </summary>
        private static void ExportCsv(DataTable tbl, string prefix)
        {
            if (tbl.Rows.Count == 0)
            {
                MessageBox.Show("No data to export."); return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"{prefix}_{DateTime.Now:yyyyMMdd}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            if (IsFileLocked(sfd.FileName))
            {
                MessageBox.Show("The file is open in another application.\n" +
                                "Please close it or choose a different name.",
                                "File in use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lines = new string[tbl.Rows.Count + 1];
            lines[0] = string.Join(",", tbl.Columns.Cast<DataColumn>()
                                                   .Select(c => Quote(c.ColumnName)));
            for (int i = 0; i < tbl.Rows.Count; i++)
                lines[i + 1] = string.Join(",",
                    tbl.Rows[i].ItemArray.Select(v => Quote(v?.ToString() ?? "")));

            try
            {
                File.WriteAllLines(sfd.FileName, lines, Encoding.UTF8);
                MessageBox.Show("Export completed!");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Export failed:\n{ex.Message}",
                                "I/O Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* ---------- 檢查檔案是否被鎖定 ---------- */
        private static bool IsFileLocked(string path)
        {
            if (!File.Exists(path)) return false;
            try
            {
                using FileStream fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
                return false;                        // 能夠獨佔
            }
            catch (IOException)
            {
                return true;                         // 被佔用
            }
        }

        /* 轉成 CSV-safe 字串 */
        private static string Quote(string s) => $"\"{s.Replace("\"", "\"\"")}\"";
    }
}
