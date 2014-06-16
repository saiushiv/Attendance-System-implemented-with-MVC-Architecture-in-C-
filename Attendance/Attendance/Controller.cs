using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Attendance
{
    public class Controller 
    {
        ClassRoster cr = new ClassRoster();

        public BindingSource dayHistory(int sclassid,string sdate)
        {

            cr.getrec(sclassid, sdate);

            if (datafound())
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cr.dbcmd;
                DataTable dbt = new DataTable();
                sda.Fill(dbt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dbt;
                sda.Update(dbt);
                return bs;
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = null;
                return bs;
            }
          
        }

        public bool datafound()
        {
            if (cr.gotit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
