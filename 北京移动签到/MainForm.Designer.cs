namespace 北京移动签到
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.userNameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.queryCardTicketListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.loginMethodComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dynamicCodeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(205, 10);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(129, 25);
            this.userNameText.TabIndex = 0;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(205, 41);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(129, 25);
            this.passwordText.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(153, 86);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 25);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(132, 15);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(67, 15);
            this.userNameLabel.TabIndex = 4;
            this.userNameLabel.Text = "手机号码";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(132, 44);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(67, 15);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "统一密码";
            // 
            // queryCardTicketListView
            // 
            this.queryCardTicketListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.queryCardTicketListView.FullRowSelect = true;
            this.queryCardTicketListView.GridLines = true;
            this.queryCardTicketListView.Location = new System.Drawing.Point(12, 145);
            this.queryCardTicketListView.Name = "queryCardTicketListView";
            this.queryCardTicketListView.Size = new System.Drawing.Size(333, 158);
            this.queryCardTicketListView.TabIndex = 6;
            this.queryCardTicketListView.UseCompatibleStateImageBehavior = false;
            this.queryCardTicketListView.View = System.Windows.Forms.View.Details;
            this.queryCardTicketListView.Click += new System.EventHandler(this.queryCardTicketListView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "卡号";
            this.columnHeader1.Width = 45;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "流量";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "有效期";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 140;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "当前可兑换卡券";
            // 
            // signInButton
            // 
            this.signInButton.Location = new System.Drawing.Point(259, 86);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(75, 26);
            this.signInButton.TabIndex = 8;
            this.signInButton.Text = "签到";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // loginMethodComboBox
            // 
            this.loginMethodComboBox.FormattingEnabled = true;
            this.loginMethodComboBox.Location = new System.Drawing.Point(15, 36);
            this.loginMethodComboBox.Name = "loginMethodComboBox";
            this.loginMethodComboBox.Size = new System.Drawing.Size(96, 23);
            this.loginMethodComboBox.TabIndex = 10;
            this.loginMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.loginMethodComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "登录方式";
            // 
            // dynamicCodeButton
            // 
            this.dynamicCodeButton.Location = new System.Drawing.Point(15, 86);
            this.dynamicCodeButton.Name = "dynamicCodeButton";
            this.dynamicCodeButton.Size = new System.Drawing.Size(109, 25);
            this.dynamicCodeButton.TabIndex = 12;
            this.dynamicCodeButton.Text = "获得验证码";
            this.dynamicCodeButton.UseVisualStyleBackColor = true;
            this.dynamicCodeButton.Click += new System.EventHandler(this.dynamicCodeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 315);
            this.Controls.Add(this.dynamicCodeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loginMethodComboBox);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.queryCardTicketListView);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.userNameText);
            this.Name = "MainForm";
            this.Text = "北京移动签到";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ListView queryCardTicketListView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.ComboBox loginMethodComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button dynamicCodeButton;
    }
}

