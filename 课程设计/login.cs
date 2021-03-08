using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 课程设计
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = username.Text;
            String pwd = password.Text;
            String type = usertype.Text;
            int sqltype = 0;
            String uid = "1";
            if (type.Equals("学生")) sqltype = 1;
            else if (type.Equals("教师")) sqltype = 2;
            else if (type.Equals("管理员")) sqltype = 3;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            string sql = "select uid from users where uid=@name and pwd=@pwd and type=@type";
            MySqlConnection connection = new MySqlConnection(connString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("pwd", pwd);
                command.Parameters.AddWithValue("type", sqltype);
                uid = (string)command.ExecuteScalar();
                //MessageBox.Show(type);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            if (name.Equals(uid))
            {
                user.name = name;
                user.type = type;
                if (sqltype == 1)
                {
                    student stu = new student(this, user.name);
                    stu.Show();
                    this.Hide();
                    MessageBox.Show("欢迎登陆：" + type + name);
                }
                else if (sqltype == 2)
                {
                    teacher tech = new teacher(this, user.name);
                    tech.Show();
                    this.Hide();
                    MessageBox.Show("欢迎登陆：" + type + name);
                }
                else if (sqltype == 3)
                {
                    manager mana = new manager(this);
                    mana.Show();
                    this.Hide();
                    MessageBox.Show("欢迎登陆：" + type + name);
                }
            }
            else
            {
                MessageBox.Show("请输入正确信息");
            }
        }

        private void usertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public static class user
    {
        public static String name;
        public static String type;
    }
}
