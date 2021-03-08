namespace 课程设计
{
    partial class giveGrade
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
            this.label5 = new System.Windows.Forms.Label();
            this.stuno = new System.Windows.Forms.TextBox();
            this.cno = new System.Windows.Forms.TextBox();
            this.grade = new System.Windows.Forms.TextBox();
            this.stuname = new System.Windows.Forms.TextBox();
            this.cname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "学号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "课程号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(326, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "课程名称";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "分数";
            // 
            // stuno
            // 
            this.stuno.Location = new System.Drawing.Point(155, 72);
            this.stuno.Name = "stuno";
            this.stuno.ReadOnly = true;
            this.stuno.Size = new System.Drawing.Size(144, 29);
            this.stuno.TabIndex = 5;
            // 
            // cno
            // 
            this.cno.Location = new System.Drawing.Point(155, 154);
            this.cno.Name = "cno";
            this.cno.ReadOnly = true;
            this.cno.Size = new System.Drawing.Size(144, 29);
            this.cno.TabIndex = 6;
            // 
            // grade
            // 
            this.grade.Location = new System.Drawing.Point(155, 242);
            this.grade.Name = "grade";
            this.grade.Size = new System.Drawing.Size(144, 29);
            this.grade.TabIndex = 7;
            // 
            // stuname
            // 
            this.stuname.Location = new System.Drawing.Point(426, 72);
            this.stuname.Name = "stuname";
            this.stuname.ReadOnly = true;
            this.stuname.Size = new System.Drawing.Size(144, 29);
            this.stuname.TabIndex = 8;
            // 
            // cname
            // 
            this.cname.Location = new System.Drawing.Point(426, 154);
            this.cname.Name = "cname";
            this.cname.ReadOnly = true;
            this.cname.Size = new System.Drawing.Size(144, 29);
            this.cname.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(331, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 44);
            this.button1.TabIndex = 10;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // giveGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cname);
            this.Controls.Add(this.stuname);
            this.Controls.Add(this.grade);
            this.Controls.Add(this.cno);
            this.Controls.Add(this.stuno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "giveGrade";
            this.Text = "学生评分";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stuno;
        private System.Windows.Forms.TextBox cno;
        private System.Windows.Forms.TextBox grade;
        private System.Windows.Forms.TextBox stuname;
        private System.Windows.Forms.TextBox cname;
        private System.Windows.Forms.Button button1;
    }
}