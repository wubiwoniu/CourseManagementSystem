namespace 课程设计
{
    partial class Add_M
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
            this.name_label = new System.Windows.Forms.Label();
            this.id_label = new System.Windows.Forms.Label();
            this.sex_label = new System.Windows.Forms.Label();
            this.age_label = new System.Windows.Forms.Label();
            this.major_label = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.major = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sex = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(49, 70);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(74, 36);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "姓名";
            this.name_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // id_label
            // 
            this.id_label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_label.Location = new System.Drawing.Point(293, 70);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(104, 36);
            this.id_label.TabIndex = 1;
            this.id_label.Text = "学号";
            // 
            // sex_label
            // 
            this.sex_label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sex_label.Location = new System.Drawing.Point(49, 161);
            this.sex_label.Name = "sex_label";
            this.sex_label.Size = new System.Drawing.Size(74, 36);
            this.sex_label.TabIndex = 2;
            this.sex_label.Text = "性别";
            // 
            // age_label
            // 
            this.age_label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.age_label.Location = new System.Drawing.Point(293, 154);
            this.age_label.Name = "age_label";
            this.age_label.Size = new System.Drawing.Size(74, 36);
            this.age_label.TabIndex = 3;
            this.age_label.Text = "年龄";
            // 
            // major_label
            // 
            this.major_label.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.major_label.Location = new System.Drawing.Point(49, 244);
            this.major_label.Name = "major_label";
            this.major_label.Size = new System.Drawing.Size(74, 36);
            this.major_label.TabIndex = 4;
            this.major_label.Text = "专业";
            // 
            // name
            // 
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Location = new System.Drawing.Point(118, 73);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(151, 22);
            this.name.TabIndex = 6;
            // 
            // major
            // 
            this.major.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.major.Location = new System.Drawing.Point(118, 247);
            this.major.Name = "major";
            this.major.Size = new System.Drawing.Size(151, 22);
            this.major.TabIndex = 8;
            // 
            // age
            // 
            this.age.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.age.Location = new System.Drawing.Point(403, 167);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(151, 22);
            this.age.TabIndex = 9;
            // 
            // id
            // 
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.id.Location = new System.Drawing.Point(403, 73);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(151, 22);
            this.id.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 42);
            this.button1.TabIndex = 12;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sex
            // 
            this.sex.FormattingEnabled = true;
            this.sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.sex.Location = new System.Drawing.Point(118, 161);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(151, 30);
            this.sex.TabIndex = 13;
            // 
            // Add_M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.sex);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.id);
            this.Controls.Add(this.age);
            this.Controls.Add(this.major);
            this.Controls.Add(this.name);
            this.Controls.Add(this.major_label);
            this.Controls.Add(this.age_label);
            this.Controls.Add(this.sex_label);
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.name_label);
            this.Name = "Add_M";
            this.Text = "添加信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label sex_label;
        private System.Windows.Forms.Label age_label;
        private System.Windows.Forms.Label major_label;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox major;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox sex;
    }
}