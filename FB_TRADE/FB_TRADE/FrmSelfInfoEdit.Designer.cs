namespace FB_TRADE
{
    partial class FrmSelfInfoEdit
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
            this.labelOldPwd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCfmPwd = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtCfmPwd = new System.Windows.Forms.TextBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lableName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelOldPwd
            // 
            this.labelOldPwd.AutoSize = true;
            this.labelOldPwd.Location = new System.Drawing.Point(148, 98);
            this.labelOldPwd.Name = "labelOldPwd";
            this.labelOldPwd.Size = new System.Drawing.Size(67, 15);
            this.labelOldPwd.TabIndex = 2;
            this.labelOldPwd.Text = "原密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "    新密码：";
            // 
            // labelCfmPwd
            // 
            this.labelCfmPwd.AutoSize = true;
            this.labelCfmPwd.Location = new System.Drawing.Point(133, 169);
            this.labelCfmPwd.Name = "labelCfmPwd";
            this.labelCfmPwd.Size = new System.Drawing.Size(82, 15);
            this.labelCfmPwd.TabIndex = 6;
            this.labelCfmPwd.Text = "确认密码：";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(221, 94);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(134, 25);
            this.txtOldPwd.TabIndex = 3;
            this.txtOldPwd.UseSystemPasswordChar = true;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(221, 128);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(134, 25);
            this.txtNewPwd.TabIndex = 5;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // txtCfmPwd
            // 
            this.txtCfmPwd.Location = new System.Drawing.Point(221, 164);
            this.txtCfmPwd.Name = "txtCfmPwd";
            this.txtCfmPwd.Size = new System.Drawing.Size(134, 25);
            this.txtCfmPwd.TabIndex = 7;
            this.txtCfmPwd.UseSystemPasswordChar = true;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(179, 228);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 31);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "确定";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lableName
            // 
            this.lableName.AutoSize = true;
            this.lableName.Location = new System.Drawing.Point(163, 64);
            this.lableName.Name = "lableName";
            this.lableName.Size = new System.Drawing.Size(52, 15);
            this.lableName.TabIndex = 0;
            this.lableName.Text = "账号：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(221, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(134, 25);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(361, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(361, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(361, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(361, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "*";
            // 
            // FrmSelfInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 376);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lableName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.txtCfmPwd);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.labelCfmPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelOldPwd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelfInfoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOldPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCfmPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtCfmPwd;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lableName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}