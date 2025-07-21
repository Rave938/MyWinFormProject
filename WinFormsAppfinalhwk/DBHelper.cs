using System;
using MySqlConnector;
using System.Data;

namespace StudyPlanner
{
    public class DBHelper
    {
        private static string dbName = "StudyPlanner";
        private static string serverConnectionString = "server=localhost;user=root;password=42120506Lcm$;port=3306;charset=utf8;";
        private static string dbConnectionString = $"server=localhost;database={dbName};user=root;password=42120506Lcm$;port=3306;charset=utf8;";

        public static MySqlConnection GetConnection()
        {
            EnsureDatabaseAndTable();
            return new MySqlConnection(dbConnectionString);
        }

        private static void EnsureDatabaseAndTable()
        {
            using (var conn = new MySqlConnection(serverConnectionString))
            {
                conn.Open();
                string sql = $"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{dbName}'";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        string createDbSql = $"CREATE DATABASE {dbName} CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci";
                        using (var createCmd = new MySqlCommand(createDbSql, conn))
                        {
                            createCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            // 检查并创建 Users 表
            using (var conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();
                string checkTableSql = $"SHOW TABLES LIKE 'Users'";
                using (var cmd = new MySqlCommand(checkTableSql, conn))
                {
                    var tableResult = cmd.ExecuteScalar();
                    if (tableResult == null)
                    {
                        string createTableSql = @"
                            CREATE TABLE Users (
                                UserId VARCHAR(50) PRIMARY KEY,
                                Email VARCHAR(100) NOT NULL,
                                Password VARCHAR(100) NOT NULL,
                                Gender VARCHAR(10) NOT NULL DEFAULT '隐藏',
                                Origin VARCHAR(50) NOT NULL DEFAULT '隐藏'
                            )";
                        using (var createTableCmd = new MySqlCommand(createTableSql, conn))
                        {
                            createTableCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // 补全 Gender 字段
                        string checkGenderSql = "SHOW COLUMNS FROM Users LIKE 'Gender'";
                        using (var checkCmd = new MySqlCommand(checkGenderSql, conn))
                        {
                            var result = checkCmd.ExecuteScalar();
                            if (result == null)
                            {
                                string addGenderSql = "ALTER TABLE Users ADD COLUMN Gender VARCHAR(10) NOT NULL DEFAULT '隐藏'";
                                using (var addCmd = new MySqlCommand(addGenderSql, conn))
                                {
                                    addCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        // 补全 Origin 字段
                        string checkOriginSql = "SHOW COLUMNS FROM Users LIKE 'Origin'";
                        using (var checkCmd = new MySqlCommand(checkOriginSql, conn))
                        {
                            var result = checkCmd.ExecuteScalar();
                            if (result == null)
                            {
                                string addOriginSql = "ALTER TABLE Users ADD COLUMN Origin VARCHAR(50) NOT NULL DEFAULT '隐藏'";
                                using (var addCmd = new MySqlCommand(addOriginSql, conn))
                                {
                                    addCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            // 检查并创建 Exams 表
            using (var conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();
                string checkExamsTableSql = $"SHOW TABLES LIKE 'Exams'";
                using (var cmd = new MySqlCommand(checkExamsTableSql, conn))
                {
                    var tableResult = cmd.ExecuteScalar();
                    if (tableResult == null)
                    {
                        string createTableSql = @"
                            CREATE TABLE Exams (
                                ExamId INT AUTO_INCREMENT PRIMARY KEY,
                                UserId VARCHAR(50) NOT NULL,
                                Subject VARCHAR(100) NOT NULL,
                                ExamDate DATETIME NOT NULL,
                                Importance VARCHAR(10) NOT NULL DEFAULT '中',
                                KeyTopics VARCHAR(255) DEFAULT '',
                                FOREIGN KEY (UserId) REFERENCES Users(UserId)
                            )";
                        using (var createTableCmd = new MySqlCommand(createTableSql, conn))
                        {
                            createTableCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // 补全 Subject 字段
                        string checkSubjectSql = "SHOW COLUMNS FROM Exams LIKE 'Subject'";
                        using (var checkCmd = new MySqlCommand(checkSubjectSql, conn))
                        {
                            var result = checkCmd.ExecuteScalar();
                            if (result == null)
                            {
                                string addSubjectSql = "ALTER TABLE Exams ADD COLUMN Subject VARCHAR(100) NOT NULL DEFAULT ''";
                                using (var addCmd = new MySqlCommand(addSubjectSql, conn))
                                {
                                    addCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        // 可按需补全其它字段
                    }
                }
            }
        }

        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// 执行查询SQL语句，返回MySqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>MySqlDataReader对象</returns>
        public static MySqlDataReader ExecuteReader(string sql, params MySqlParameter[] parameters)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(parameters);
                // 使用CommandBehavior.CloseConnection确保关闭reader时同时关闭连接
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        
        /// <summary>
        /// 执行查询，返回单个值
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果的第一行第一列</returns>
        public static object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar() ?? ""; // 修复可能返回null引用
                }
            }
        }
    }
}
