using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using todoApp.config;
using System.Data;

namespace todoApp.data
{
    static class Database
    {
        private static readonly string messageErrorTitle = "Erro de conexão com o banco de dados";

        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        private static string port;
        private static string conStr;
        private static MySqlConnection con;
        private static MySqlCommand cmd;
        private static void Init()
        {
            IniFile ini = new IniFile(Function.GetExeLocation() + @"\config\data.ini");
            string section = "server";

            server = Encryption.Decode(ini.Read("server", section));
            database = Encryption.Decode(ini.Read("database", section));
            uid = Encryption.Decode(ini.Read("uid", section));
            password = Encryption.Decode(ini.Read("password", section));
            port = Encryption.Decode(ini.Read("port", section));

            conStr = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={password};";
            con = new MySqlConnection(conStr);
        }

        public static void Connect()
        {
            Init();
            try
            { con.Open(); }
            catch (Exception ex)
            {
                string messageError = $"Erro ao conectar com o banco de dados: {ex.Source} -> {ex.Message}";

                MessageBox.Show(messageError, messageErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Disconnect()
        {
            try
            { con.Close(); }
            catch (Exception ex)
            {
                string messageError = $"Erro ao fechar a conexão com o banco de dados:  {ex.Source}  -> {ex.Message}";

                MessageBox.Show(messageError, messageErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static DataTable ExecuteSQL(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new MySqlCommand(sql, con);
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
}
