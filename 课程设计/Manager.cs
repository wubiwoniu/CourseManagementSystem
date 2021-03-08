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
    public partial class manager : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        login _login;
        public manager(login Login)
        {
            InitializeComponent();
            _login = Login;
            ManagridControl.DataSource = null;
            ManagridControl.MainView = StuView;
            ManagridControl.DataSource = stuBindingSource;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“学生选课管理系统DataSet1.teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter1.Fill(this.学生选课管理系统DataSet1.teacher);
            // TODO: 这行代码将数据加载到表“学生选课管理系统DataSet1.stu”中。您可以根据需要移动或删除它。
            this.stuTableAdapter1.Fill(this.学生选课管理系统DataSet1.stu);
            // TODO: 这行代码将数据加载到表“学生选课管理系统DataSet1.classroom”中。您可以根据需要移动或删除它。
            this.classroomTableAdapter1.Fill(this.学生选课管理系统DataSet1.classroom);


        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ManagridControl.DataSource = null;
            ManagridControl.MainView = StuView;
            ManagridControl.DataSource = stuBindingSource;
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            ManagridControl.DataSource = null;
            ManagridControl.MainView = TeachView;
            ManagridControl.DataSource = teacherBindingSource;
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            ManagridControl.DataSource = null;
            ManagridControl.MainView = RoomView;
            ManagridControl.DataSource = classroomBindingSource;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Sno = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Sno").ToString();
            string Sname = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Sname").ToString();
            string Ssex = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Ssex").ToString();
            string Sage = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Sage").ToString();
            string Smajor = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Smajor").ToString();
            ShowDetail chart = new ShowDetail("学生", Sname, Sno, Ssex, Sage, Smajor);
            if (chart.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("修改成功");
                this.学生选课管理系统DataSet1.AcceptChanges();
                this.stuTableAdapter1.Fill(this.学生选课管理系统DataSet1.stu);
                StuView.RefreshData();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Tno = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tno").ToString();
            string Tname = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tname").ToString();
            string Tsex = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tsex").ToString();
            string Tage = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tage").ToString();
            string Tmajor = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tmajor").ToString();
            ShowDetail chart = new ShowDetail("教师", Tname, Tno, Tsex, Tage, Tmajor);
            if (chart.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("修改成功");
                this.学生选课管理系统DataSet1.AcceptChanges();
                this.teacherTableAdapter1.Fill(this.学生选课管理系统DataSet1.teacher);
                TeachView.RefreshData();
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Add_M add = new Add_M("学生");
            if (add.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("添加成功！");
                this.学生选课管理系统DataSet1.AcceptChanges();
                this.stuTableAdapter1.Fill(this.学生选课管理系统DataSet1.stu);
                StuView.RefreshData();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Add_M add = new Add_M("教师");
            if (add.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("添加成功！");
                this.学生选课管理系统DataSet1.AcceptChanges();
                this.teacherTableAdapter1.Fill(this.学生选课管理系统DataSet1.teacher);
                StuView.RefreshData();
            }
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            Add_M add = new Add_M("教室");
            if (add.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("添加成功！");
                this.学生选课管理系统DataSet1.AcceptChanges();
                this.classroomTableAdapter1.Fill(this.学生选课管理系统DataSet1.classroom);
                StuView.RefreshData();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Boolean flag = false;
            List<int> selectedRows;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            selectedRows = StuView.GetSelectedRows().Where((t) => t >= 0).ToList();
            foreach (int i in selectedRows)
            {
                String sql = "select Sno from gradelist where Sno=@Sno";
                String Sno = this.StuView.GetRowCellValue(i, "Sno").ToString();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("Sno", Sno);
                if (command.ExecuteScalar() == null)
                {
                    sql = "DELETE FROM stu where Sno=@Sno";
                    command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Sno", Sno);
                    command.ExecuteNonQuery();
                    command = null;
                    StuView.GetDataRow(i).Delete();
                }
                else
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("部分学生无法删除");
            }
            else
            {
                MessageBox.Show("删除成功");
            }
            connection.Close();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Boolean flag = false;
            List<int> selectedRows;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            selectedRows = TeachView.GetSelectedRows().Where((t) => t >= 0).ToList();
            foreach (int i in selectedRows)
            {
                String sql = "select Tno from course where Tno=@Tno";
                String Tno = this.TeachView.GetRowCellValue(i, "Tno").ToString();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("Tno", Tno);
                if (command.ExecuteScalar() == null)
                {
                    sql = "DELETE FROM teacher where Tno=@Tno";
                    command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Tno", Tno);
                    command.ExecuteNonQuery();
                    command = null;
                    TeachView.GetDataRow(i).Delete();
                }
                else
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("部分教师无法删除");
            }
            else
            {
                MessageBox.Show("删除成功");
            }
            connection.Close();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            Boolean flag = false;
            List<int> selectedRows;
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            selectedRows = RoomView.GetSelectedRows().Where((t) => t >= 0).ToList();
            foreach (int i in selectedRows)
            {
                String Isused = this.RoomView.GetRowCellValue(i, "Isused").ToString();
                if (Isused.Equals("0"))
                {
                    string sql = "DELETE FROM classroom where Rid=@Rid";
                    String Rid = this.RoomView.GetRowCellValue(i, "Rid").ToString();
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Rid", Rid);
                    command.ExecuteNonQuery();
                    command = null;
                    RoomView.GetDataRow(i).Delete();
                }
                else
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("部分教室使用中");
            }
            else
            {
                MessageBox.Show("删除成功");
            }
            connection.Close();
        }

        private void StuView_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = StuView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hInfo.InRow)
                {
                    string Sno = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Sno").ToString();
                    string Sname = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Sname").ToString();
                    string Ssex = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Ssex").ToString();
                    string Sage = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Sage").ToString();
                    string Smajor = StuView.GetRowCellValue(StuView.FocusedRowHandle, "Smajor").ToString();
                    ShowDetail chart = new ShowDetail("学生", Sname, Sno, Ssex, Sage, Smajor);
                    if (chart.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("修改成功");
                        this.学生选课管理系统DataSet1.AcceptChanges();
                        this.stuTableAdapter1.Fill(this.学生选课管理系统DataSet1.stu);
                        StuView.RefreshData();
                    }
                }
            }
        }

        private void TeachView_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = TeachView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {

                if (hInfo.InRow)
                {
                    string Tno = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tno").ToString();
                    string Tname = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tname").ToString();
                    string Tsex = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tsex").ToString();
                    string Tage = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tage").ToString();
                    string Tmajor = TeachView.GetRowCellValue(TeachView.FocusedRowHandle, "Tmajor").ToString();
                    ShowDetail chart = new ShowDetail("教师", Tname, Tno, Tsex, Tage, Tmajor);
                    if (chart.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("修改成功");
                        this.学生选课管理系统DataSet1.AcceptChanges();
                        this.teacherTableAdapter1.Fill(this.学生选课管理系统DataSet1.teacher);
                        TeachView.RefreshData();
                    }
                }
            }
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
            _login.Show();
        }

        private void ManagridControl_Click(object sender, EventArgs e)
        {

        }
    }
}