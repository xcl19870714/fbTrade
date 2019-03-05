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
            this.SuspendLayout();
            // 
            // labelOldPwd
            // 
            this.labelOldPwd.AutoSize = true;
            this.labelOldPwd.Location = new System.Drawing.Point(272, 130);
            this.labelOldPwd.Name = "labelOldPwd";
            this.labelOldPwd.Size = new System.Drawing.Size(67, 15);
            this.labelOldPwd.TabIndex = 2;
            this.labelOldPwd.Text = "原密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "    新密码：";
            // 
            // labelCfmPwd
            // 
            this.labelCfmPwd.AutoSize = true;
            this.labelCfmPwd.Location = new System.Drawing.Point(273, 197);
            this.labelCfmPwd.Name = "labelCfmPwd";
            this.labelCfmPwd.Size = new System.Drawing.Size(82, 15);
            this.labelCfmPwd.TabIndex = 6;
            this.labelCfmPwd.Text = "确认密码：";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(376, 124);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(122, 25);
            this.txtOldPwd.TabIndex = 3;
            this.txtOldPwd.UseSystemPasswordChar = true;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(376, 158);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(122, 25);
            this.txtNewPwd.TabIndex = 5;
            this.txtNewPwd.UseSystemPasswordChar = true;
            // 
            // txtCfmPwd
            // 
            this.txtCfmPwd.Location = new System.Drawing.Point(376, 191);
            this.txtCfmPwd.Name = "txtCfmPwd";
            this.txtCfmPwd.Size = new System.Drawing.Size(122, 25);
            this.txtCfmPwd.TabIndex = 7;
            this.txtCfmPwd.UseSystemPasswordChar = true;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(297, 258);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 31);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "确定";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 258);
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
            this.lableName.Location = new System.Drawing.Point(276, 95);
            this.lableName.Name = "lableName";
            this.lableName.Size = new System.Drawing.Size(52, 15);
            this.lableName.TabIndex = 0;
            this.lableName.Text = "账号：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(376, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(122, 25);
            this.txtName.TabIndex = 1;
            // 
            // FrmSelfInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}