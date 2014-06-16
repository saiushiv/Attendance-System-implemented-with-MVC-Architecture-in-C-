using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Attendance
{
    public partial class AttendanceSystem : Form
    {
        public static int class_id;
        public static string class_date;

        public AttendanceSystem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.ToString().Length == 0)
            {
                MessageBox.Show("Please Enter Valid Class Number.");
            }
            else
            {
                class_id = Int32.Parse(maskedTextBox1.Text.ToString());
                class_date = dateTimePicker1.Value.ToString("dd-MM-yyyy");

                Controller c = new Controller();
                c.dayHistory(class_id, class_date);
                if (c.datafound())
                {
                    dataGridView1.DataSource = c.dayHistory(class_id, class_date);
                }
                else
                {
                    dataGridView1.DataSource = "";
                    MessageBox.Show("No Records Found.");
                }
            }
         
        }


       
    }
}
