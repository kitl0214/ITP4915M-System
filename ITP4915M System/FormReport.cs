// FormReport.cs – Monthly order summary + CSV export
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ITP4915MSystem;          // provides Database.GetConnection()

namespace ITP4915M_System
{
    public partial class FormReport : Form
    {
        public FormReport() => InitializeComponent();

        /* ---------- life-cycle ---------- */
        private void FormReport_Load(object sender, EventArgs e)
        {
            var tbl = LoadMonthlySummary();
            dgvOrders.DataSource = tbl;
            lblOrderCount.Text = $"Total months: {tbl.Rows.Count}";
        }

        /* ---------- data ---------- */
        private DataTable LoadMonthlySummary()
        {
            const string sql = @"
                SELECT
                    YEAR(due_date)  AS `Year`,
                    MONTH(due_date) AS `Month`,
                    COUNT(*)        AS `TotalOrders`
                FROM orders
                GROUP BY `Year`, `Month`
                ORDER BY `Year` DESC, `Month` DESC";
            using var conn = Database.GetConnection();
            using var da = new MySqlDataAdapter(sql, conn);
            var tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }

        /* ---------- export ---------- */
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource is not DataTable tbl || tbl.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = $"orders_monthly_{DateTime.Now:yyyyMMdd}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            var lines = new string[tbl.Rows.Count + 1];
            // header
            lines[0] = string.Join(",", tbl.Columns.Cast<DataColumn>()
                                                  .Select(c => Quote(c.ColumnName)));
            // data
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                lines[i + 1] = string.Join(",", tbl.Rows[i].ItemArray
                                         .Select(v => Quote(v?.ToString() ?? "")));
            }
            File.WriteAllLines(sfd.FileName, lines, Encoding.UTF8);
            MessageBox.Show("Export completed!");
        }

        private static string Quote(string s) => $"\"{s.Replace("\"", "\"\"")}\"";

      
    }
}
