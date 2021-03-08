namespace 课程设计
{
    partial class AddCourse
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
            this.name = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.credit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.where = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程名";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "课程号";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 62);
            this.label3.TabIndex = 2;
            this.label3.Text = "课程学分";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 51);
            this.label4.TabIndex = 3;
            this.label4.Text = "上课地点";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(142, 55);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(152, 29);
            this.name.TabIndex = 4;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(407, 55);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(152, 29);
            this.id.TabIndex = 5;
            // 
            // credit
            // 
            this.credit.Location = new System.Drawing.Point(142, 177);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(152, 29);
            this.credit.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(309, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // where
            // 
            this.where.FormattingEnabled = true;
            this.where.Location = new System.Drawing.Point(407, 177);
            this.where.Name = "where";
            this.where.Size = new System.Drawing.Size(152, 30);
            this.where.TabIndex = 9;
            this.where.SelectedIndexChanged += new System.EventHandler(this.where_SelectedIndexChanged);
            // 
            // AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.where);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.id);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddCourse";
            this.Text = "添加课程信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox credit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox where;
    }
}