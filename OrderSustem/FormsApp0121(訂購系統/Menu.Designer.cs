namespace FormsApp0121_訂購系統
{
    partial class Menu
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblTop = new System.Windows.Forms.Label();
            this.tab菜色點選 = new System.Windows.Forms.TabControl();
            this.tabMainfood = new System.Windows.Forms.TabPage();
            this.listViewMainfood = new System.Windows.Forms.ListView();
            this.tab甜點 = new System.Windows.Forms.TabPage();
            this.listViewDessert = new System.Windows.Forms.ListView();
            this.tab飲料 = new System.Windows.Forms.TabPage();
            this.listViewDrink = new System.Windows.Forms.ListView();
            this.tab主廚推薦 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewCombo = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl冰量 = new System.Windows.Forms.Label();
            this.combo冰量 = new System.Windows.Forms.ComboBox();
            this.combo辣度 = new System.Windows.Forms.ComboBox();
            this.lbl辣度 = new System.Windows.Forms.Label();
            this.lbl甜度 = new System.Windows.Forms.Label();
            this.combo甜度 = new System.Windows.Forms.ComboBox();
            this.text份數 = new System.Windows.Forms.TextBox();
            this.btn加入訂購單 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbl總價 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl單價 = new System.Windows.Forms.Label();
            this.imgListPicture = new System.Windows.Forms.ImageList(this.components);
            this.imgListDrink = new System.Windows.Forms.ImageList(this.components);
            this.imgListDessert = new System.Windows.Forms.ImageList(this.components);
            this.imgListCombo = new System.Windows.Forms.ImageList(this.components);
            this.tab菜色點選.SuspendLayout();
            this.tabMainfood.SuspendLayout();
            this.tab甜點.SuspendLayout();
            this.tab飲料.SuspendLayout();
            this.tab主廚推薦.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.Transparent;
            this.lblTop.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTop.ForeColor = System.Drawing.Color.Black;
            this.lblTop.Location = new System.Drawing.Point(19, 25);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(1020, 24);
            this.lblTop.TabIndex = 70;
            this.lblTop.Text = "菜色點選";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab菜色點選
            // 
            this.tab菜色點選.Controls.Add(this.tabMainfood);
            this.tab菜色點選.Controls.Add(this.tab甜點);
            this.tab菜色點選.Controls.Add(this.tab飲料);
            this.tab菜色點選.Controls.Add(this.tab主廚推薦);
            this.tab菜色點選.Location = new System.Drawing.Point(12, 63);
            this.tab菜色點選.Name = "tab菜色點選";
            this.tab菜色點選.SelectedIndex = 0;
            this.tab菜色點選.Size = new System.Drawing.Size(814, 545);
            this.tab菜色點選.TabIndex = 77;
            this.tab菜色點選.SelectedIndexChanged += new System.EventHandler(this.tab菜色點選_TabPagesChanged);
            // 
            // tabMainfood
            // 
            this.tabMainfood.AutoScroll = true;
            this.tabMainfood.Controls.Add(this.listViewMainfood);
            this.tabMainfood.Location = new System.Drawing.Point(4, 26);
            this.tabMainfood.Name = "tabMainfood";
            this.tabMainfood.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainfood.Size = new System.Drawing.Size(806, 515);
            this.tabMainfood.TabIndex = 0;
            this.tabMainfood.Text = "主食";
            this.tabMainfood.UseVisualStyleBackColor = true;
            // 
            // listViewMainfood
            // 
            this.listViewMainfood.HideSelection = false;
            this.listViewMainfood.Location = new System.Drawing.Point(0, 0);
            this.listViewMainfood.MultiSelect = false;
            this.listViewMainfood.Name = "listViewMainfood";
            this.listViewMainfood.Size = new System.Drawing.Size(803, 509);
            this.listViewMainfood.TabIndex = 0;
            this.listViewMainfood.UseCompatibleStateImageBehavior = false;
            this.listViewMainfood.ItemActivate += new System.EventHandler(this.listViewMainfood_ItemActivate);
            this.listViewMainfood.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewMainfood_ItemCheck);
            this.listViewMainfood.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewMainfood_MouseClick);
            // 
            // tab甜點
            // 
            this.tab甜點.AutoScroll = true;
            this.tab甜點.Controls.Add(this.listViewDessert);
            this.tab甜點.Location = new System.Drawing.Point(4, 26);
            this.tab甜點.Name = "tab甜點";
            this.tab甜點.Padding = new System.Windows.Forms.Padding(3);
            this.tab甜點.Size = new System.Drawing.Size(806, 515);
            this.tab甜點.TabIndex = 1;
            this.tab甜點.Text = "甜點";
            this.tab甜點.UseVisualStyleBackColor = true;
            // 
            // listViewDessert
            // 
            this.listViewDessert.HideSelection = false;
            this.listViewDessert.Location = new System.Drawing.Point(3, 3);
            this.listViewDessert.MultiSelect = false;
            this.listViewDessert.Name = "listViewDessert";
            this.listViewDessert.Size = new System.Drawing.Size(800, 506);
            this.listViewDessert.TabIndex = 0;
            this.listViewDessert.UseCompatibleStateImageBehavior = false;
            this.listViewDessert.ItemActivate += new System.EventHandler(this.listViewDessert_ItemActivate);
            this.listViewDessert.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewDessert_ItemCheck);
            this.listViewDessert.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDessert_MouseClick);
            // 
            // tab飲料
            // 
            this.tab飲料.AutoScroll = true;
            this.tab飲料.Controls.Add(this.listViewDrink);
            this.tab飲料.Location = new System.Drawing.Point(4, 26);
            this.tab飲料.Name = "tab飲料";
            this.tab飲料.Size = new System.Drawing.Size(806, 515);
            this.tab飲料.TabIndex = 2;
            this.tab飲料.Text = "飲料";
            this.tab飲料.UseVisualStyleBackColor = true;
            // 
            // listViewDrink
            // 
            this.listViewDrink.HideSelection = false;
            this.listViewDrink.Location = new System.Drawing.Point(3, 3);
            this.listViewDrink.MultiSelect = false;
            this.listViewDrink.Name = "listViewDrink";
            this.listViewDrink.Size = new System.Drawing.Size(800, 509);
            this.listViewDrink.TabIndex = 0;
            this.listViewDrink.UseCompatibleStateImageBehavior = false;
            this.listViewDrink.ItemActivate += new System.EventHandler(this.listViewDrink_ItemActivate);
            this.listViewDrink.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewDrink_ItemCheck);
            this.listViewDrink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDrink_MouseClick);
            // 
            // tab主廚推薦
            // 
            this.tab主廚推薦.AutoScroll = true;
            this.tab主廚推薦.Controls.Add(this.label1);
            this.tab主廚推薦.Controls.Add(this.listViewCombo);
            this.tab主廚推薦.Location = new System.Drawing.Point(4, 22);
            this.tab主廚推薦.Name = "tab主廚推薦";
            this.tab主廚推薦.Size = new System.Drawing.Size(806, 519);
            this.tab主廚推薦.TabIndex = 3;
            this.tab主廚推薦.Text = "主廚推薦";
            this.tab主廚推薦.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "套餐請先點選加入購物車再點選菜色";
            // 
            // listViewCombo
            // 
            this.listViewCombo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewCombo.HideSelection = false;
            this.listViewCombo.Location = new System.Drawing.Point(3, 62);
            this.listViewCombo.Name = "listViewCombo";
            this.listViewCombo.Size = new System.Drawing.Size(800, 413);
            this.listViewCombo.TabIndex = 0;
            this.listViewCombo.UseCompatibleStateImageBehavior = false;
            this.listViewCombo.SelectedIndexChanged += new System.EventHandler(this.listViewCombo_SelectedIndexChanged);
            this.listViewCombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewCombo_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lbl冰量);
            this.groupBox3.Controls.Add(this.combo冰量);
            this.groupBox3.Controls.Add(this.combo辣度);
            this.groupBox3.Controls.Add(this.lbl辣度);
            this.groupBox3.Controls.Add(this.lbl甜度);
            this.groupBox3.Controls.Add(this.combo甜度);
            this.groupBox3.Controls.Add(this.text份數);
            this.groupBox3.Controls.Add(this.btn加入訂購單);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.lbl總價);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lbl單價);
            this.groupBox3.Location = new System.Drawing.Point(832, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 522);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "餐點金額";
            // 
            // lbl冰量
            // 
            this.lbl冰量.AutoSize = true;
            this.lbl冰量.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl冰量.Location = new System.Drawing.Point(26, 183);
            this.lbl冰量.Name = "lbl冰量";
            this.lbl冰量.Size = new System.Drawing.Size(41, 16);
            this.lbl冰量.TabIndex = 65;
            this.lbl冰量.Text = "冰量";
            // 
            // combo冰量
            // 
            this.combo冰量.FormattingEnabled = true;
            this.combo冰量.Location = new System.Drawing.Point(54, 216);
            this.combo冰量.Name = "combo冰量";
            this.combo冰量.Size = new System.Drawing.Size(121, 24);
            this.combo冰量.TabIndex = 64;
            this.combo冰量.SelectedIndexChanged += new System.EventHandler(this.combo冰量_SelectedIndexChanged);
            // 
            // combo辣度
            // 
            this.combo辣度.FormattingEnabled = true;
            this.combo辣度.Location = new System.Drawing.Point(54, 293);
            this.combo辣度.Name = "combo辣度";
            this.combo辣度.Size = new System.Drawing.Size(121, 24);
            this.combo辣度.TabIndex = 63;
            this.combo辣度.SelectedIndexChanged += new System.EventHandler(this.combo辣度_SelectedIndexChanged);
            // 
            // lbl辣度
            // 
            this.lbl辣度.AutoSize = true;
            this.lbl辣度.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl辣度.Location = new System.Drawing.Point(26, 260);
            this.lbl辣度.Name = "lbl辣度";
            this.lbl辣度.Size = new System.Drawing.Size(41, 16);
            this.lbl辣度.TabIndex = 62;
            this.lbl辣度.Text = "辣度";
            // 
            // lbl甜度
            // 
            this.lbl甜度.AutoSize = true;
            this.lbl甜度.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl甜度.Location = new System.Drawing.Point(26, 113);
            this.lbl甜度.Name = "lbl甜度";
            this.lbl甜度.Size = new System.Drawing.Size(41, 16);
            this.lbl甜度.TabIndex = 59;
            this.lbl甜度.Text = "甜度";
            // 
            // combo甜度
            // 
            this.combo甜度.FormattingEnabled = true;
            this.combo甜度.Location = new System.Drawing.Point(54, 146);
            this.combo甜度.Name = "combo甜度";
            this.combo甜度.Size = new System.Drawing.Size(121, 24);
            this.combo甜度.TabIndex = 58;
            this.combo甜度.SelectedIndexChanged += new System.EventHandler(this.combo甜度_SelectedIndexChanged);
            // 
            // text份數
            // 
            this.text份數.Location = new System.Drawing.Point(74, 61);
            this.text份數.Name = "text份數";
            this.text份數.Size = new System.Drawing.Size(58, 27);
            this.text份數.TabIndex = 57;
            this.text份數.TabStop = false;
            this.text份數.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text份數.TextChanged += new System.EventHandler(this.text份數_TextChanged);
            // 
            // btn加入訂購單
            // 
            this.btn加入訂購單.Location = new System.Drawing.Point(46, 474);
            this.btn加入訂購單.Name = "btn加入訂購單";
            this.btn加入訂購單.Size = new System.Drawing.Size(129, 31);
            this.btn加入訂購單.TabIndex = 55;
            this.btn加入訂購單.TabStop = false;
            this.btn加入訂購單.Text = "加入訂購單";
            this.btn加入訂購單.UseVisualStyleBackColor = true;
            this.btn加入訂購單.Click += new System.EventHandler(this.btn加入訂購單_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(26, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 46;
            this.label9.Text = "份數";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(151, 422);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 16);
            this.label18.TabIndex = 54;
            this.label18.Text = "元";
            // 
            // lbl總價
            // 
            this.lbl總價.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl總價.Location = new System.Drawing.Point(71, 415);
            this.lbl總價.Name = "lbl總價";
            this.lbl總價.Size = new System.Drawing.Size(82, 31);
            this.lbl總價.TabIndex = 52;
            this.lbl總價.Text = "00000";
            this.lbl總價.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(151, 355);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 53;
            this.label17.Text = "元";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(26, 422);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 16);
            this.label14.TabIndex = 50;
            this.label14.Text = "總價";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(138, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 48;
            this.label11.Text = "份";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(26, 355);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 16);
            this.label13.TabIndex = 49;
            this.label13.Text = "單價";
            // 
            // lbl單價
            // 
            this.lbl單價.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl單價.Location = new System.Drawing.Point(71, 348);
            this.lbl單價.Name = "lbl單價";
            this.lbl單價.Size = new System.Drawing.Size(69, 31);
            this.lbl單價.TabIndex = 51;
            this.lbl單價.Text = "000";
            this.lbl單價.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgListPicture
            // 
            this.imgListPicture.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListPicture.ImageSize = new System.Drawing.Size(256, 256);
            this.imgListPicture.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgListDrink
            // 
            this.imgListDrink.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListDrink.ImageSize = new System.Drawing.Size(250, 250);
            this.imgListDrink.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgListDessert
            // 
            this.imgListDessert.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListDessert.ImageSize = new System.Drawing.Size(250, 250);
            this.imgListDessert.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgListCombo
            // 
            this.imgListCombo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListCombo.ImageStream")));
            this.imgListCombo.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListCombo.Images.SetKeyName(0, "21.jpg");
            this.imgListCombo.Images.SetKeyName(1, "4.jpg");
            this.imgListCombo.Images.SetKeyName(2, "5.jpg");
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1055, 620);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.tab菜色點選);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "訂購菜單";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.tab菜色點選.ResumeLayout(false);
            this.tabMainfood.ResumeLayout(false);
            this.tab甜點.ResumeLayout(false);
            this.tab飲料.ResumeLayout(false);
            this.tab主廚推薦.ResumeLayout(false);
            this.tab主廚推薦.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.TabControl tab菜色點選;
        private System.Windows.Forms.TabPage tab甜點;
        private System.Windows.Forms.TabPage tab飲料;
        private System.Windows.Forms.TabPage tab主廚推薦;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn加入訂購單;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label lbl總價;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lbl單價;
        private System.Windows.Forms.TextBox text份數;
        private System.Windows.Forms.ComboBox combo辣度;
        private System.Windows.Forms.Label lbl辣度;
        private System.Windows.Forms.Label lbl甜度;
        private System.Windows.Forms.ComboBox combo甜度;
        private System.Windows.Forms.TabPage tabMainfood;
        public System.Windows.Forms.ListView listViewMainfood;
        public System.Windows.Forms.ListView listViewDessert;
        public System.Windows.Forms.ListView listViewDrink;
        public System.Windows.Forms.ImageList imgListPicture;
        public System.Windows.Forms.ImageList imgListDrink;
        public System.Windows.Forms.ImageList imgListDessert;
        private System.Windows.Forms.Label lbl冰量;
        private System.Windows.Forms.ComboBox combo冰量;
        private System.Windows.Forms.ListView listViewCombo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ImageList imgListCombo;
    }
}

