using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace 课程设计
{
    public partial class giveGrade : DevExpress.XtraEditors.XtraForm
    {
        String Cid;
        String Sno;
        public giveGrade(String cid, String sno)
        {
            InitializeComponent();
            Cid = cid;
            Sno = sno;
            stuno.Text = Sno;
            cno.Text = Cid;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            String sql = "select Cname from course where Cid=@Cid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("Cid", Cid);
            cname.Text = (String)command.ExecuteScalar();

            sql = "select Sname from stu where Sno=@Sno";
            command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("Sno", Sno);
            stuname.Text = (String)command.ExecuteScalar();

            sql = "select grade from gradelist where Sno=@Sno and Cid=@Cid";
            command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("Sno", Sno);
            command.Parameters.AddWithValue("Cid", Cid);
            grade.Text = command.ExecuteScalar() == null ? "" : command.ExecuteScalar().ToString();
            connection.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Grade = grade.Text;
            Boolean notNull = !Grade.Equals("");
            Boolean re;
            if (notNull)
            {
                re = int.Parse(Grade) >= 0 && int.Parse(Grade) <= 100;
            }
            else
            {
                re = false;
            }
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            if (re && notNull)
            {
                String sql = "update gradelist set grade=@Grade where Sno=@Sno and Cid=@Cid";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("Grade", Grade);
                command.Parameters.AddWithValue("Sno", Sno);
                command.Parameters.AddWithValue("Cid", Cid);
                command.ExecuteNonQuery();
                connection.Close();
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("输入信息有误！");
            }
        }
    }
}