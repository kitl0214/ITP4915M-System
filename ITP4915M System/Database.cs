using System;
using System.Collections.Generic;
using System.Data;
using ITP4915M_System;
using MySql.Data.MySqlClient;

namespace ITP4915MSystem
{
    public static class Database
    {
        // ※ root 無密碼請留空
        private const string ConnStr =
            "server=localhost;user id=root;password=;database=company_accounts;port=3306;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(ConnStr);

            return conn;
        }

        /*─────────────────── 登入驗證 ───────────────────*/
        public static bool ValidateUser(string dept, string user, string pwd, out string message)
        {
            const string sql = """
                SELECT COUNT(*) FROM accounts
                WHERE department=@dept AND username=@user AND password=@pwd
                """;

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pwd", pwd);

            bool ok = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            message = ok ? "Login success" : "Invalid credentials";
            return ok;
        }

        /*─────────────────── 帳號維護 ───────────────────*/
        public static IEnumerable<string> GetDepartments()
        {
            const string sql = "SELECT DISTINCT department FROM accounts ORDER BY department";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read()) yield return rdr.GetString(0);
        }

        /// <summary>傳回所有帳號，或指定部門</summary>
        public static DataTable GetAccounts(string deptFilter)
        {
            var dt = new DataTable();
            string sql = deptFilter == "All"
                ? "SELECT username, password, department FROM accounts"
                : "SELECT username, password, department FROM accounts WHERE department=@dept";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            if (deptFilter != "All") cmd.Parameters.AddWithValue("@dept", deptFilter);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }

        public static void AddAccount(string user, string pwd, string dept)
        {
            const string sql = """
                INSERT INTO accounts (username,password,department)
                VALUES (@u,@p,@d)
                """;
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", pwd);
            cmd.Parameters.AddWithValue("@d", dept);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateAccount(string user, string newPwd, string dept)
        {
            const string sql = """
                UPDATE accounts SET password=@p
                WHERE username=@u AND department=@d
                """;
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", newPwd);
            cmd.Parameters.AddWithValue("@d", dept);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteAccount(string user)
        {
            const string sql = "DELETE FROM accounts WHERE username=@u";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.ExecuteNonQuery();
        }

        /*─────────────────── 訂單相關 (維持原樣) ───────────────────*/
        public static int GetNextOrderId()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                "SELECT IFNULL(MAX(CAST(oid AS UNSIGNED)),0)+1 FROM orders", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void InsertOrder(OrderModel m)
        {
            const string sql = """
        INSERT INTO orders
              (oid, customer_name, product, unit, qty,
               order_type, extra_pkg, due_date, total)
        VALUES (@oid, @cust,        @prod,  @unit, @qty,
                @otype, @pkg,       @due,   @total);
        """;

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@oid", m.Oid.ToString("000000"));
            cmd.Parameters.AddWithValue("@cust", m.Customer);                 // ← 直接存名稱
            cmd.Parameters.AddWithValue("@prod", m.Product);
            cmd.Parameters.AddWithValue("@unit", m.Unit);
            cmd.Parameters.AddWithValue("@qty", m.Qty);
            cmd.Parameters.AddWithValue("@otype", m.IsCustom ? "CUSTOM" : "GENERAL");
            cmd.Parameters.AddWithValue("@pkg", (m.ExtraPack ? 1 : 0));
            cmd.Parameters.AddWithValue("@due", m.DueDate);
            cmd.Parameters.AddWithValue("@total", m.Total);

            cmd.ExecuteNonQuery();
        }

        public static DataTable GetAllOrders()
        {
            var dt = new DataTable();
            const string sql = "SELECT * FROM orders ORDER BY created_at DESC";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
        public static void DeleteOrder(int oid)
        {
            const string sql = "DELETE FROM orders WHERE oid=@oid";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@oid", oid);
            cmd.ExecuteNonQuery();
        }
        public static OrderModel GetOrder(int oid)
        {
            const string sql = @"
        SELECT
            oid,
            customer_name,   -- ← 改用此欄位
            product,
            unit,
            qty,
            order_type,
            extra_pkg,
            due_date,
            total
        FROM orders
        WHERE oid = @oid
        LIMIT 1";

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@oid", oid.ToString("000000"));

            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) throw new InvalidOperationException("Order not found.");

            return new OrderModel
            {
                Oid = oid,
                Customer = rdr["customer_name"].ToString(),   // ← 改這裡
                Product = rdr["product"].ToString(),
                Unit = Convert.ToInt32(rdr["unit"]),
                Qty = Convert.ToInt32(rdr["qty"]),
                IsCustom = rdr["order_type"].ToString() == "CUSTOM",
                ExtraPack = Convert.ToInt32(rdr["extra_pkg"]) == 1,
                DueDate = Convert.ToDateTime(rdr["due_date"]),
                Total = Convert.ToInt32(rdr["total"])
            };
        }

        public static void UpdateOrder(OrderModel m)
        {
            const string sql = @"
        UPDATE orders SET
            customer_name = @cust,     -- ← 改用名稱欄位
            product       = @prod,
            unit          = @unit,
            qty           = @qty,
            order_type    = @otype,
            extra_pkg     = @pkg,
            due_date      = @due,
            total         = @total
        WHERE oid = @oid";

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@oid", m.Oid.ToString("000000"));
            cmd.Parameters.AddWithValue("@cust", m.Customer);                 // 名稱
            cmd.Parameters.AddWithValue("@prod", m.Product);
            cmd.Parameters.AddWithValue("@unit", m.Unit);
            cmd.Parameters.AddWithValue("@qty", m.Qty);
            cmd.Parameters.AddWithValue("@otype", m.IsCustom ? "CUSTOM" : "GENERAL");
            cmd.Parameters.AddWithValue("@pkg", (m.ExtraPack ? 1 : 0));
            cmd.Parameters.AddWithValue("@due", m.DueDate);
            cmd.Parameters.AddWithValue("@total", m.Total);

            cmd.ExecuteNonQuery();
        }


        /*───────────────────── 客戶服務專用 ─────────────────────*/
        public static DataTable GetAllFollowups()
        {
            const string sql = """
        SELECT f.fid, f.oid, o.product, o.created_at, o.due_date, o.qty,
               f.action, f.comment, f.status, f.created_at AS followup_time
        FROM cs_followups f
        JOIN orders o ON o.oid = f.oid
        ORDER BY f.created_at DESC;
    """;

            using var conn = GetConnection();
            using var da = new MySqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void AddFollowup(string oid, string action, string comment)
        {
            const string sql = """
        INSERT INTO cs_followups (oid, action, comment)
        VALUES (@oid, @action, @comment);
    """;

            using var conn = GetConnection();
            conn.Open();                                         // ★ 補這行
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@oid", oid);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.ExecuteNonQuery();
        }

        public static void SetFollowupCompleted(int fid)
        {
            const string sql = """
        UPDATE cs_followups
        SET status = 'COMPLETED', completed_at = NOW()
        WHERE fid = @fid;
    """;

            using var conn = GetConnection();
            conn.Open();                                         // ★ 補這行
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fid", fid);
            cmd.ExecuteNonQuery();
        }
        public static void UpdateFollowup(int fid, string action, string comment)
        {
            const string sql = @"
        UPDATE cs_followups
        SET action = @act,
            comment = @cm
        WHERE fid = @fid";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@act", action);
            cmd.Parameters.AddWithValue("@cm", comment);
            cmd.Parameters.AddWithValue("@fid", fid);
            cmd.ExecuteNonQuery();
        }
        public static void SetFollowupStatus(int fid, string status)
        {
            const string sql = "UPDATE cs_followups SET status=@s WHERE fid=@id";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", fid);
            cmd.ExecuteNonQuery();
        }
        public static DataTable GetFollowupsByOrder(string oid)
        {
            const string sqlFull = """
        SELECT oid,
               fid,
               action,
               comment,
               status,
               discount_amount,
               refund_amount,
               created_at,
               followup_time
        FROM followups
        WHERE oid = @oid
        ORDER BY created_at
        """;

            const string sqlLite = """
        SELECT oid,
               fid,
               action,
               comment,
               status,
               created_at,
               followup_time
        FROM followups
        WHERE oid = @oid
        ORDER BY created_at
        """;

            using var conn = GetConnection();
            conn.Open();

            var dt = new DataTable();

            using var cmd = new MySqlCommand(sqlFull, conn);
            cmd.Parameters.AddWithValue("@oid", oid);

            try
            {
                // 先嘗試撈完整版
                using var da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (MySqlException ex) when (ex.Message.Contains("discount_amount")
                                         || ex.Message.Contains("refund_amount"))
            {
                // 降級改用精簡版 SQL
                cmd.CommandText = sqlLite;
                dt.Clear();                            // 清空舊結構
                using var daLite = new MySqlDataAdapter(cmd);
                daLite.Fill(dt);

                // 手動補上兩欄，保持欄位一致
                if (!dt.Columns.Contains("discount_amount"))
                    dt.Columns.Add("discount_amount", typeof(string));

                if (!dt.Columns.Contains("refund_amount"))
                    dt.Columns.Add("refund_amount", typeof(string));
            }

            return dt;
        }



        /*ｖ───────────────────── R&D Department ─────────────────────ｖ*/

        /* Update Order Status */
        public static void UpdateRAndDStatus(string specID, string status)
        {
            using (var conn = GetConnection())
            {
                var cmd = new MySqlCommand("UPDATE r_and_d SET status = @status WHERE specID = @specID", conn);
                cmd.Parameters.AddWithValue("@specID", specID);
                cmd.Parameters.AddWithValue("@status", status);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /* R&D Form's On Going Projects Data Grid View */
        public static DataTable GetRDOrders()
        {
            var dt = new DataTable();
            const string sql = @"
        SELECT r_and_d.*,
               orders.customer_name
        FROM r_and_d
        JOIN orders ON r_and_d.orderID = orders.oid
        ORDER BY r_and_d.specID DESC";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }

        /*︿───────────────────── R&D Department ─────────────────────︿*/

        /*ｖ───────────────────── Finance Department ─────────────────────ｖ*/
        // Invoice 相關操作

        // Invoice 相關操作

        public static DataTable GetAllInvoices()
        {
            var dt = new DataTable();

            const string sql = @"
SELECT
    i.invoiceID,
    i.orderID,
    o.customer_name     AS user_name,   -- 改用 orders 裡的名稱
    o.order_type,
    i.amount,
    i.issueDate,
    i.status
FROM invoice i
INNER JOIN orders o ON i.orderID = o.oid
ORDER BY i.invoiceID DESC";

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }


        public static void InsertInvoice(InvoiceModel model)
        {
            const string sql = @"INSERT INTO Invoice (invoiceID, orderID, amount, issueDate, status)
                         VALUES (@invoiceID, @orderID, @amount, @issueDate, @status)";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@invoiceID", model.InvoiceID);
            cmd.Parameters.AddWithValue("@orderID", model.OrderID);
            cmd.Parameters.AddWithValue("@amount", model.Amount);
            cmd.Parameters.AddWithValue("@issueDate", model.IssueDate);
            cmd.Parameters.AddWithValue("@status", model.Status);
            cmd.ExecuteNonQuery();
        }

        public static void UpdateInvoiceStatus(string invoiceID, string status)
        {
            const string sql = "UPDATE Invoice SET status = @status WHERE invoiceID = @invoiceID";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@invoiceID", invoiceID);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteInvoice(string invoiceID)
        {
            const string sql = "DELETE FROM Invoice WHERE invoiceID = @invoiceID";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@invoiceID", invoiceID);
            cmd.ExecuteNonQuery();
        }

        public static DataTable GetInvoiceSelectableOrders()
        {
            var dt = new DataTable();
            const string sql = @"
        SELECT o.oid, o.product, o.total, o.due_date, o.order_type
        FROM orders o
        LEFT JOIN Invoice i ON o.oid = i.orderID
        WHERE i.orderID IS NULL
        ORDER BY o.created_at DESC
    ";
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }


        public static string GetNextInvoiceID()
        {
            using var conn = GetConnection();
            conn.Open();
            string sql = "SELECT IFNULL(MAX(CAST(SUBSTRING(invoiceID,2) AS UNSIGNED)), 0)+1 FROM Invoice";
            using var cmd = new MySqlCommand(sql, conn);
            int next = Convert.ToInt32(cmd.ExecuteScalar());
            return "I" + next.ToString("D5");
        }
        /*︿───────────────────── Finance Department ─────────────────────︿*/
        public static InvoiceDetailModel GetInvoiceDetail(string invoiceID)
        {
            const string sql = @"
SELECT
    i.invoiceID,
    i.orderID,
    o.customer_name     AS user_name,
    o.order_type,
    i.amount,
    i.issueDate,
    i.status
FROM invoice i
INNER JOIN orders o ON i.orderID = o.oid
WHERE i.invoiceID = @invoiceID
LIMIT 1";

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@invoiceID", invoiceID);
            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new InvoiceDetailModel
                {
                    InvoiceID = rdr["invoiceID"].ToString(),
                    OrderID = rdr["orderID"].ToString(),
                    UserName = rdr["user_name"].ToString(),
                    OrderType = rdr["order_type"].ToString(),
                    Amount = rdr["amount"] is DBNull ? 0 : Convert.ToDecimal(rdr["amount"]),
                    IssueDate = rdr["issueDate"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(rdr["issueDate"]),
                    Status = rdr["status"].ToString()
                };
            }
            return null;
        }
    }
}
