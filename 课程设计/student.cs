using DevExpress.XtraBars;
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
    public partial class student : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        String uid;
        login _login;
        private class mygrade
        {
            public double credit;
            public double grade;
        }
        private static List<mygrade> MyGrade = new List<mygrade>();

        public student(login Login, String id)
        {
            InitializeComponent();
            uid = id;
            _login = Login;

            this.selectgradeTableAdapter.Fill(this.学生选课管理系统DataSet1.Selectgrade, uid);
            StuControl.DataSource = null;
            StuControl.MainView = LearnedView;
            StuControl.DataSource = selectgradeBindingSource;
            LearnedView.RefreshData();
            for (int i = 0; i < LearnedView.RowCount; i++)
            {
                object credit = LearnedView.GetDataRow(i)["Credit"];
                double Credit = Convert.ToDouble(credit);
                object grade = LearnedView.GetDataRow(i)["grade"];
                double Grade = Convert.ToDouble(grade);
                mygrade temp = new mygrade();
                temp.grade = Grade;
                temp.credit = Credit;
                MyGrade.Add(temp);
                //MessageBox.Show(temp.grade + "   " + temp.credit);
            }

            this.courseNoselectTableAdapter.Fill(this.学生选课管理系统DataSet1.CourseNoselect, uid);
            StuControl.DataSource = null;
            StuControl.MainView = SelectCView;
            StuControl.DataSource = courseNoselectBindingSource;
            SelectCView.RefreshData();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            /*string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CourseNoselect";// 存储过程的名称
            MySqlParameter parm = new MySqlParameter("SSno",uid);
            command.Parameters.Add(parm);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(学生选课管理系统DataSet1, "CourseNoselect");*/
            //this.courseNoselectTableAdapter.GetData(uid);
            this.courseNoselectTableAdapter.Fill(this.学生选课管理系统DataSet1.CourseNoselect, uid);
            StuControl.DataSource = null;
            StuControl.MainView = SelectCView;
            StuControl.DataSource = courseNoselectBindingSource;
            SelectCView.RefreshData();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            this.selectgrade_nTableAdapter.Fill(this.学生选课管理系统DataSet1.Selectgrade_n, uid);
            StuControl.DataSource = null;
            StuControl.MainView = SelectedView;
            StuControl.DataSource = selectgradenBindingSource;
            SelectedView.RefreshData();
        }

        private void student_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“学生选课管理系统DataSet1.mygrade”中。您可以根据需要移动或删除它。


        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            this.selectgradeTableAdapter.Fill(this.学生选课管理系统DataSet1.Selectgrade, uid);
            StuControl.DataSource = null;
            StuControl.MainView = LearnedView;
            StuControl.DataSource = selectgradeBindingSource;
            LearnedView.RefreshData();
        }

        double CreditSum;
        double GradeSum;
        double getCredit;
        double Anwser;
        private void LearnedView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            int summaryId = Convert.ToInt32((e.Item as DevExpress.XtraGrid.GridSummaryItem).Tag);
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                CreditSum = 0;
                GradeSum = 0;
                getCredit = 0;
            }
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                CreditSum = 0;
                GradeSum = 0;
                getCredit = 0;
                foreach (var temp in MyGrade)
                {
                    double Grade = temp.grade;
                    double Credit = temp.credit;
                    if (Grade >= 50)
                    {
                        GradeSum += ((Grade - 50) / 10) * Credit;
                    }
                    else
                    {
                        GradeSum += 0;
                    }
                    CreditSum += Credit;
                    if (Grade >= 60)
                    {
                        getCredit += Credit;
                    }
                }
            }
            Anwser = GradeSum / CreditSum;
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                /*e.Row.Cell[2] =;
                e.Row.Cell[3] =;*/
                switch (summaryId)
                {
                    case 1:
                        e.TotalValue = getCredit;
                        break;
                    case 2:
                        if (CreditSum == 0) e.TotalValue = 0;
                        else e.TotalValue = Anwser;
                        break;
                }
            }
        }

        private void SelectedView_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = SelectedView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hInfo.InRow)
                {
                    string Cname = SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Cname").ToString();
                    string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
                    MySqlConnection connection = new MySqlConnection(connString);
                    connection.Open();
                    string sql = "select * FROM selectcourse where Cname=@Cname";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Cname", Cname);
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    String Cid = dr[0].ToString();
                    String Credit = dr[2].ToString();
                    String Tname = dr[3].ToString();
                    String Rid = dr[4].ToString();
                    connection.Close();
                    MessageBox.Show("课程号:" + Cid + "\t课程名称:" + Cname + "\n课程学分:" + Credit + "\t授课教师:" + Tname + "\n上课地点:" + Rid);
                }
            }
        }

        private void LearnedView_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = LearnedView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (hInfo.InRow)
                {
                    string Cname = LearnedView.GetRowCellValue(LearnedView.FocusedRowHandle, "Cname").ToString();
                    string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
                    MySqlConnection connection = new MySqlConnection(connString);
                    connection.Open();
                    string sql = "select * FROM selectcourse where Cname=@Cname";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("Cname", Cname);
                    MySqlDataReader dr;
                    dr = command.ExecuteReader();
                    dr.Read();
                    String Cid = dr[0].ToString();
                    String Credit = dr[2].ToString();
                    String Tname = dr[3].ToString();
                    String Rid = dr[4].ToString();
                    connection.Close();
                    MessageBox.Show("课程号:" + Cid + "\t课程名称:" + Cname + "\n课程学分:" + Credit + "\t授课教师:" + Tname + "\n上课地点:" + Rid);
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void repositoryIbtUp_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string Cid = SelectCView.GetRowCellValue(SelectCView.FocusedRowHandle, "Cid").ToString();
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string sql = "insert into gradelist values(@uid,@Cid,NULL)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("uid", uid);
            command.Parameters.AddWithValue("Cid", Cid);
            command.ExecuteNonQuery();
            this.学生选课管理系统DataSet1.AcceptChanges();
            this.courseNoselectTableAdapter.Fill(this.学生选课管理系统DataSet1.CourseNoselect, uid);
            this.selectgrade_nTableAdapter.Fill(this.学生选课管理系统DataSet1.Selectgrade_n, uid);
            SelectCView.RefreshData();
        }

        private void repositoryIbtUp1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string Cname = SelectedView.GetRowCellValue(SelectedView.FocusedRowHandle, "Cname").ToString();
            string connString = "server=localhost;user id=root; password=usb2.030mbs;database=学生选课管理系统;Charset=utf8;";
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            String sql = "select Cid from mycourse where Cname=@Cname";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("Cname", Cname);
            String Cid = (String)command.ExecuteScalar();
            sql = "delete from gradelist where Sno=@uid and Cid=@Cid";
            command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("uid", uid);
            command.Parameters.AddWithValue("Cid", Cid);
            command.ExecuteNonQuery();
            this.学生选课管理系统DataSet1.AcceptChanges();
            this.courseNoselectTableAdapter.Fill(this.学生选课管理系统DataSet1.CourseNoselect, uid);
            this.selectgrade_nTableAdapter.Fill(this.学生选课管理系统DataSet1.Selectgrade_n, uid);
            SelectedView.RefreshData();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
            _login.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            saveFileDialog.FileName = "课程列表" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                StuControl.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出pdf";
            saveFileDialog.Filter = "pdf文件(*.pdf)|*.pdf";
            saveFileDialog.FileName = "课程列表" + DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                StuControl.ExportToPdf(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
