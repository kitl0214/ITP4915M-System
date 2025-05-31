using MySql.Data.MySqlClient;
using System.Data;

namespace ITP4915MSystem
{
    public static class Database
    {
        // ※ 若 root 無密碼，password= 留空或移除皆可
        private const string ConnStr =
            "server=localhost;user id=root;password=;database=company_accounts;port=3306;";

        /// <summary>Return an opened MySqlConnection.</summary>
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(ConnStr);
            conn.Open();
            return conn;
        }

        /// <summary>Check if (dept, user, pwd) exists.  Return true / false & message.</summary>
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

            var count = (long)cmd.ExecuteScalar();
            message = count == 1 ? "Login success" : "Invalid credentials";
            return count == 1;
        }

        /// <summary>Return every account, or only one department when deptFilter ≠ "All".</summary>
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

        /// <summary>Insert a new (dept, user, pwd) row.</summary>
        public static void AddAccount(string dept, string user, string pwd)
        {
            const string sql = """
                INSERT INTO accounts (username, password, department)
                VALUES (@user, @pwd, @dept)
                """;

            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Delete a row by username.</summary>
        public static void DeleteAccount(string user)
        {
            const string sql = "DELETE FROM accounts WHERE username=@user";

            using var conn = GetConnection();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.ExecuteNonQuery();
        }
    }
}
