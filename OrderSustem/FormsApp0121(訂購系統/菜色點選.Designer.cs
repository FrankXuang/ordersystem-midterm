namespace FormsApp0121_訂購系統
{
    partial class 菜色點選
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(菜色點選));
            this.lbl名字 = new System.Windows.Forms.Label();
            this.lbl價格 = new System.Windows.Forms.Label();
            this.picture1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl名字
            // 
            this.lbl名字.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl名字.Location = new System.Drawing.Point(8, 135);
            this.lbl名字.Name = "lbl名字";
            this.lbl名字.Size = new System.Drawing.Size(134, 17);
            this.lbl名字.TabIndex = 1;
            this.lbl名字.Text = "冰鎮檸檬香綠茶";
            this.lbl名字.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl價格
            // 
            this.lbl價格.Location = new System.Drawing.Point(42, 157);
            this.lbl價格.Name = "lbl價格";
            this.lbl價格.Size = new System.Drawing.Size(59, 20);
            this.lbl價格.TabIndex = 2;
            this.lbl價格.Text = "$ 110";
            this.lbl價格.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picture1
            // 
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.Location = new System.Drawing.Point(3, 3);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(142, 136);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            this.picture1.Click += new System.EventHandler(this.picture1_Click);
            // 
            // 菜色點選
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.lbl價格);
            this.Controls.Add(this.lbl名字);
            this.Controls.Add(this.picture1);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "菜色點選";
            this.Size = new System.Drawing.Size(148, 177);
            this.Load += new System.EventHandler(this.菜色點選_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picture1;
        public System.Windows.Forms.Label lbl名字;
        public System.Windows.Forms.Label lbl價格;
    }
}
