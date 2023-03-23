namespace FormsApp0121_訂購系統
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbl密碼 = new System.Windows.Forms.Label();
            this.lbl電話 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.timerforerror = new System.Windows.Forms.Timer(this.components);
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl密碼
            // 
            this.lbl密碼.AutoSize = true;
            this.lbl密碼.Location = new System.Drawing.Point(83, 212);
            this.lbl密碼.Name = "lbl密碼";
            this.lbl密碼.Size = new System.Drawing.Size(39, 16);
            this.lbl密碼.TabIndex = 4;
            this.lbl密碼.Text = "密碼";
            // 
            // lbl電話
            // 
            this.lbl電話.AutoSize = true;
            this.lbl電話.Location = new System.Drawing.Point(59, 148);
            this.lbl電話.Name = "lbl電話";
            this.lbl電話.Size = new System.Drawing.Size(87, 16);
            this.lbl電話.TabIndex = 4;
            this.lbl電話.Text = "電話(帳號)";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(152, 209);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(184, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(152, 145);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(184, 27);
            this.txtPhone.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Orange;
            this.lblInfo.Location = new System.Drawing.Point(42, 28);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(352, 79);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "秀資訊";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerforerror
            // 
            this.timerforerror.Interval = 1000;
            this.timerforerror.Tick += new System.EventHandler(this.timerforerror_Tick);
            // 
            // btnLogin
            // 
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(177, 271);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(76, 51);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(310, 271);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(73, 51);
            this.btnHome.TabIndex = 3;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(31, 271);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(76, 51);
            this.btnNew.TabIndex = 4;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(355, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "顯示";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(435, 358);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lbl電話);
            this.Controls.Add(this.lbl密碼);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.登入畫面_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl密碼;
        private System.Windows.Forms.Label lbl電話;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer timerforerror;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}