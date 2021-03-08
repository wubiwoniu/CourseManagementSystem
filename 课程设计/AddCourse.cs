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
    public partial class AddCourse : DevExpress.XtraEditors.XtraForm
    {
        String uid;
        public AddCourse(String id)
        {
            InitializeComponent();
            uid = id;
            this.where.Items.Clear();
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "select Rid FROM classroom where Isused=0";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                this.where.Items.Add(dr[0].ToString());
            }
            dr.Close();
            connection.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Cname = name.Text;
            String Cid = id.Text;
            String Credit = credit.Text;
            String Rid = where.Text;
            Boolean notNull = !Cname.Equals("") && !Cid.Equals("") && !Credit.Equals("") && !Rid.Equals("");
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "select Cid FROM course where Cid=@Cid";//课程号是否被占用
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("Cid", Cid);
            if (command.ExecuteScalar() == null)
            {
                Boolean re = Regex.IsMatch(Cid, @"^\d{5}$");
                if (re && notNull)
                {
                    sql = "insert into course values(@id,@Cname,@Tno,@Credit,@Rid,0)";
                    command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("id", Cid);
                    command.Parameters.AddWithValue("Cname", Cname);
                    command.Parameters.AddWithValue("Tno", uid);
                    command.Parameters.AddWithValue("Credit", Credit);
                    command.Parameters.AddWithValue("Rid", Rid);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("请输入正确信息！");
                }
            }
            else
            {
                MessageBox.Show("请输入正确信息！");
            }
        }

        private void where_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}