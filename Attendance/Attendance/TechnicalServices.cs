using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Attendance
{
    class TechnicalServices
    {
        private MySqlConnection mysqlconn;
        private MySqlCommand mysqlcmd;
        private MySqlDataReader mysqldr;

        public MySqlConnection get_db_connection()
        {
            string connstring = "datasource=localhost;port=3306;username=root;password=sai123;database=attendance";
            mysqlconn = new MySqlConnection(connstring);
            mysqlconn.Open();
            return mysqlconn;
        }

        public void close_db_connection()
        {
            mysqlconn.Close();
        }

        public MySqlCommand execute_query(String qry, MySqlConnection mysqlconn)
        {
            mysqlcmd = new MySqlCommand(qry, mysqlconn);
            return mysqlcmd;
        }

        public MySqlDataReader execute_reader(MySqlCommand mysqlcmd)
        {
            mysqldr = mysqlcmd.ExecuteReader();
            return mysqldr;
        }
    }
}
