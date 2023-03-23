namespace FormsApp0121_訂購系統
{
    partial class 折扣抽獎
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
            this.btn返回 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn返回
            // 
            this.btn返回.Location = new System.Drawing.Point(260, 357);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(126, 40);
            this.btn返回.TabIndex = 6;
            this.btn返回.Text = "返回";
            this.btn返回.UseVisualStyleBackColor = true;
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // 折扣抽獎
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(398, 409);
            this.Controls.Add(this.btn返回);
            this.Name = "折扣抽獎";
            this.Text = "折扣項目";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn返回;
    }
}