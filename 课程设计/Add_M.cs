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
    public partial class Add_M : DevExpress.XtraEditors.XtraForm
    {
        String type;
        public Add_M(String type)
        {
            InitializeComponent();
            this.type = type;
            if (type.Equals("学生"))
            {
            }
            else if (type.Equals("教师"))
            {
                id_label.Text = "教师号";
            }
            else if (type.Equals("教室"))
            {
                name_label.Text = "教室号";
                id_label.Text = "最大容量";
                sex_label.Visible = false;
                sex.Visible = false;
                age_label.Visible = false;
                age.Visible = false;
                major_label.Visible = false;
                major.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            if (type.Equals("学生"))
            {
                String Name = name.Text;
                String Sno = id.Text;
                String Sex = sex.Text;
                String Age = age.Text;
                String Major = major.Text;
                Boolean notNull1 = !Name.Equals("") && !Sno.Equals("") && !Sex.Equals("");
                Boolean notNull2 = !Age.Equals("") && !Major.Equals("");
                Boolean re = Regex.IsMatch(Sno, @"^\d{10}$");
                if (notNull1 && notNull2 && re)
                {
                    string sql = "select * from stu where Sno=@Sno";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Sno", Sno);
                    if (command.ExecuteScalar() == null)
                    {
                        sql = "insert into stu values(@Sno,@Sname,@Ssex,@Sage,@Smajor)";
                        command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("Sno", Sno);
                        command.Parameters.AddWithValue("Sname", Name);
                        command.Parameters.AddWithValue("Ssex", Sex);
                        command.Parameters.AddWithValue("Sage", Age);
                        command.Parameters.AddWithValue("Smajor", Major);
                        command.ExecuteNonQuery();
                        connection.Close();
                        this.DialogResult = DialogResult.OK;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("已有该学号！");
                    }
                }
                else
                {
                    MessageBox.Show("请输入正确信息！");
                }
            }
            else if (type.Equals("教师"))
            {
                String Name = name.Text;
                String Tno = id.Text;
                String Sex = sex.Text;
                String Age = age.Text;
                String Major = major.Text;
                Boolean notNull1 = !Name.Equals("") && !Tno.Equals("") && !Sex.Equals("");
                Boolean notNull2 = !Age.Equals("") && !Major.Equals("");
                Boolean re = Regex.IsMatch(Tno, @"^[A-Z]{2}\d{2}$");
                if (notNull1 && notNull2 && re)
                {
                    string sql = "select * from teacher where Tno=@Tno";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Tno", Tno);
                    if (command.ExecuteScalar() == null)
                    {
                        sql = "insert into teacher values(@Tno,@Tname,@Tsex,@Tage,@Tmajor)";
                        command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("Tno", Tno);
                        command.Parameters.AddWithValue("Tname", Name);
                        command.Parameters.AddWithValue("Tsex", Sex);
                        command.Parameters.AddWithValue("Tage", Age);
                        command.Parameters.AddWithValue("Tmajor", Major);
                        command.ExecuteNonQuery();
                        this.DialogResult = DialogResult.OK;
                        connection.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("已有该教师号！");
                    }
                }
                else
                {
                    MessageBox.Show("请输入正确信息！");
                }
            }
            else if (type.Equals("教室"))
            {
                String Rid = name.Text;
                String MaxSize = id.Text;
                int max = int.Parse(MaxSize);
                Boolean notNull = !Rid.Equals("") && !MaxSize.Equals("");
                Boolean re = Regex.IsMatch(Rid, @"^k[a-c][1-6]0[0-9]$") && (max >= 45 && max <= 120);
                if (notNull && re)
                {
                    string sql = "select * from classroom where Rid=@Rid";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Rid", Rid);
                    if (command.ExecuteScalar() == null)
                    {
                        sql = "insert into classroom values(@Rid,@MaxSize,@Isused)";
                        command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("Rid", Rid);
                        command.Parameters.AddWithValue("MaxSize", max);
                        command.Parameters.AddWithValue("Isused", 0);
                        command.ExecuteNonQuery();
                        this.DialogResult = DialogResult.OK;
                        connection.Close();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("已有该教室号！");
                    }
                }
                else
                {
                    MessageBox.Show("请输入正确信息！");
                }
            }
        }
    }
}