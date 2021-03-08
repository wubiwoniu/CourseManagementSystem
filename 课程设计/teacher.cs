using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;

namespace 课程设计
{
    public partial class teacher : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        String uid;
        login _login;
        public teacher(login Login, String id)
        {
            InitializeComponent();
            uid = id;
            _login = Login;
            this.selectCourseTTableAdapter.Fill(this.学生选课管理系统DataSet.SelectCourseT, uid);
            TeachControl.DataSource = null;
            TeachControl.MainView = CourseView;
            TeachControl.DataSource = selectCourseTBindingSource;
            CourseView.RefreshData();
        }

        private void teacher_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“学生选课管理系统DataSet.selectcourse”中。您可以根据需要移动或删除它。


        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Boolean flag = true;
            List<int> selectedRows;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            selectedRows = CourseView.GetSelectedRows().Where((t) => t >= 0).ToList();
            foreach (int i in selectedRows)
            {
                String Cid = this.CourseView.GetRowCellValue(i, "Cid").ToString();
                string sql = "select Cid FROM gradelist where Cid=@Cid";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("Cid", Cid);
                if (command.ExecuteScalar() == null)
                {
                    sql = "DELETE FROM course where Tno=@Tno and Cid=@Cid";
                    command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Tno", uid);
                    command.Parameters.AddWithValue("Cid", Cid);
                    command.ExecuteNonQuery();
                    command = null;
                    CourseView.GetDataRow(i).Delete();
                }
                else
                {
                    flag = false;
                }
            }
            if (flag)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("部分课程开设中，无法删除");
            }
            connection.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            TeachControl.DataSource = null;
            TeachControl.MainView = CourseView;
            TeachControl.DataSource = selectCourseTBindingSource;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddCourse add = new AddCourse(uid);
            if (add.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("修改成功");
                this.学生选课管理系统DataSet.AcceptChanges();
                this.selectCourseTTableAdapter.Fill(this.学生选课管理系统DataSet.SelectCourseT, uid);
                CourseView.RefreshData();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.myStuTableAdapter.Fill(this.学生选课管理系统DataSet.MyStu, uid);
            TeachControl.DataSource = null;
            TeachControl.MainView = MyStuView;
            TeachControl.DataSource = myStuBindingSource;
            MyStuView.RefreshData();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<int> selectedRows;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            selectedRows = MyStuView.GetSelectedRows().Where((t) => t >= 0).ToList();
            foreach (int i in selectedRows)
            {
                String Cid = this.MyStuView.GetRowCellValue(i, "Cid").ToString();
                String Sno = this.MyStuView.GetRowCellValue(i, "Sno").ToString();
                string sql = "delete from gradelist where Cid=@Cid and Sno=@Sno";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("Cid", Cid);
                command.Parameters.AddWithValue("Sno", Sno);
                command.ExecuteNonQuery();
                command = null;
                MyStuView.GetDataRow(i).Delete();
            }
            MessageBox.Show("删除成功！");
            connection.Close();
        }


        private void MyStuView_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = MyStuView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hInfo.InRow)
                {

                    string Cid = MyStuView.GetRowCellValue(MyStuView.FocusedRowHandle, "Cid").ToString();
                    string Sno = MyStuView.GetRowCellValue(MyStuView.FocusedRowHandle, "Sno").ToString();
                    giveGrade gg = new giveGrade(Cid, Sno);
                    if (gg.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("打分成功！");
                        this.学生选课管理系统DataSet.AcceptChanges();
                        this.myStuTableAdapter.Fill(this.学生选课管理系统DataSet.MyStu, uid);
                        MyStuView.RefreshData();
                    }
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Cid = MyStuView.GetRowCellValue(MyStuView.FocusedRowHandle, "Cid").ToString();
            string Sno = MyStuView.GetRowCellValue(MyStuView.FocusedRowHandle, "Sno").ToString();
            giveGrade gg = new giveGrade(Cid, Sno);
            if (gg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("打分成功！");
                this.学生选课管理系统DataSet.AcceptChanges();
                this.myStuTableAdapter.Fill(this.学生选课管理系统DataSet.MyStu, uid);
                MyStuView.RefreshData();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
            _login.Show();
        }
    }
}