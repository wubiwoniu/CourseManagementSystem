namespace 课程设计
{
    partial class ShowDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.major = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(39, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(39, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(260, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "年龄";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(39, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 46);
            this.label4.TabIndex = 3;
            this.label4.Text = "专业";
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(260, 68);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(94, 46);
            this.chart.TabIndex = 4;
            this.chart.Text = "学号";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(39, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 46);
            this.label6.TabIndex = 5;
            this.label6.Text = "密码";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(264, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "提交修改";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(106, 68);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(131, 46);
            this.name.TabIndex = 7;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(322, 68);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(131, 46);
            this.id.TabIndex = 8;
            // 
            // sex
            // 
            this.sex.Location = new System.Drawing.Point(106, 131);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(131, 46);
            this.sex.TabIndex = 9;
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(322, 131);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(131, 46);
            this.age.TabIndex = 10;
            // 
            // major
            // 
            this.major.Location = new System.Drawing.Point(110, 193);
            this.major.Name = "major";
            this.major.Size = new System.Drawing.Size(162, 29);
            this.major.TabIndex = 11;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(110, 255);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(162, 29);
            this.pwd.TabIndex = 12;
            // 
            // StuShowDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 404);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.major);
            this.Controls.Add(this.age);
            this.Controls.Add(this.sex);
            this.Controls.Add(this.id);
            this.Controls.Add(this.name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StuShowDetail";
            this.Text = "学生详细信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label chart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label sex;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.TextBox major;
        private System.Windows.Forms.TextBox pwd;
    }
}