using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{
    public class ClassRoster
    {
        public bool gotit;
        public MySqlConnection dbconn;
        public MySqlCommand dbcmd;
        public MySqlDataReader dtread;
        
        public void getrec(int sclassid , string sdate) 
        {
            int count = 0;

            TechnicalServices ts = new TechnicalServices();
            dbconn = ts.get_db_connection();
            
            string qry = "SELECT tbl.Name,tbl.Absent FROM (SELECT c.Cls_Num, a.Date, c.Name, IF( a.Student_Nm IS NULL , '', 'X' ) AS Absent FROM class_roster c LEFT JOIN `attendance_rec` a ON a.Cls_Num = c.Cls_Num AND a.Student_Nm = c.Name AND a.Date = '" + sdate + "' WHERE EXISTS ( SELECT * FROM `attendance_rec` a WHERE a.Cls_Num = '" + sclassid + "' AND a.Date = '" + sdate + "') ORDER BY c.Name ASC)tbl WHERE tbl.Cls_Num = '" + sclassid + "' ORDER BY tbl.Name ASC";

            System.Diagnostics.Debug.WriteLine(qry);

            dbcmd = ts.execute_query(qry, dbconn);
            dtread = ts.execute_reader(dbcmd);

            while (dtread.Read())
            {
                count = count + 1;
                gotit = true;
            }

            if (count == 0)
            {

                gotit = false;
            }

            ts.close_db_connection();
        }
    }
}
