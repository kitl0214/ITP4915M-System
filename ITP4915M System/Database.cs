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
            conn.Open();
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
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.ExecuteNonQuery();
        }

        /*─────────────────── 訂單相關 (維持原樣) ───────────────────*/
        public static int GetNextOrderId()
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(
                "SELECT IFNULL(MAX(CAST(oid AS UNSIGNED)),0)+1 FROM orders", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static void InsertOrder(OrderModel m)
        {
            const string sql = """
                INSERT INTO orders
                (oid,cid,product,unit,qty,order_type,extra_pkg,due_date,total)
                VALUES (@oid,
                        (SELECT cid FROM customers WHERE name=@cust LIMIT 1),
                        @prod,@unit,@qty,@otype,@pkg,@due,@total)
                """;
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@oid", m.Oid.ToString("000000"));
            cmd.Parameters.AddWithValue("@cust", m.Customer);
            cmd.Parameters.AddWithValue("@prod", m.Product);
            cmd.Parameters.AddWithValue("@unit", m.Unit);
            cmd.Parameters.AddWithValue("@qty", m.Qty);
            cmd.Parameters.AddWithValue("@otype", m.IsCustom ? "CUSTOM" : "GENERAL");
            cmd.Parameters.AddWithValue("@pkg", m.ExtraPack ? 1 : 0);
            cmd.Parameters.AddWithValue("@due", m.DueDate);
            cmd.Parameters.AddWithValue("@total", m.Total);
            cmd.ExecuteNonQuery();
        }
        public static DataTable GetAllOrders()
        {
            var dt = new DataTable();
            const string sql = "SELECT * FROM orders ORDER BY created_at DESC";
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }


        /* Update Order Status */
        public static void UpdateRAndDStatus(string specID, string status)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE r_and_d SET status = @status WHERE specID = @specID", conn);
                cmd.Parameters.AddWithValue("@specID", specID);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            }
        }

        /* R&D Form's On Going Projects Data Grid View */
        public static DataTable GetRDOrders()
        {
            var dt = new DataTable();
            const string sql = "SELECT * FROM r_and_d ORDER BY specID DESC";
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            using var adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }
    }
}
