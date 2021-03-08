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

namespace 课程设计
{
    public partial class ShowDetail : DevExpress.XtraEditors.XtraForm
    {
        String type;
        public ShowDetail(String type, String name, String id, String sex, String age, String major)
        {
            InitializeComponent();
            this.name.Text = name;
            this.id.Text = id;
            this.sex.Text = sex;
            this.age.Text = age;
            this.major.Text = major;
            String pwd;
            this.type = type;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            string sql = "select pwd from users where uid=@id";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("id", id);
            pwd = (String)command.ExecuteScalar();
            connection.Close();
            this.pwd.Text = pwd;
            if (type.Equals("教师"))
            {
                chart.Text = "教师号";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Major = this.major.Text;
            String Pwd = this.pwd.Text;
            String Id = this.id.Text;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "update users set pwd=@pwd where uid=@uid";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("pwd", Pwd);
            command.Parameters.AddWithValue("uid", Id);
            command.ExecuteNonQuery();
            command = null;
            if (type.Equals("学生"))
            {
                sql = "update stu set Smajor=@major where Sno=@Sno";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("major", Major);
                command.Parameters.AddWithValue("Sno", Id);
                command.ExecuteNonQuery();
                command = null;
            }
            else if (type.Equals("教师"))
            {
                sql = "update teacher set Tmajor=@major where Tno=@Tno";
                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("major", Major);
                command.Parameters.AddWithValue("Tno", Id);
                command.ExecuteNonQuery();
                command = null;
            }
            connection.Close();
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}