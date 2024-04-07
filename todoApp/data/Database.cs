using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using todoApp.config;

namespace todoApp.data
{
    internal static class Database
    {
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

            server   = Encryption.Decode(ini.Read("server", "server"));
            database = Encryption.Decode(ini.Read("database", "server"));
            uid      = Encryption.Decode(ini.Read("uid", "server"));
            password = Encryption.Decode(ini.Read("pass", "server"));
            port     = Encryption.Decode(ini.Read("port", "server"));
            conStr   = $"SERVER={server};PORT={port};DATABASE={database};UID={uid};PASSWORD={password};";
            con      = new MySqlConnection(conStr);
        }

        public static void Connect()
        {
            Init();
            try
            { con.Open(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar se conectar ao banco de dados\r\nErro:\r\n{ex}",
                    "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Disconnect()
        {
            try
            { con.Close(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar fechar o banco de dados\r\nErro:\r\n{ex}",
                    "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
