namespace FormsApp0121_訂購系統
{
    partial class OrderList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderList));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl訂購人資料 = new System.Windows.Forms.Label();
            this.lbl訂單總價 = new System.Windows.Forms.Label();
            this.btn清空所有品項 = new System.Windows.Forms.Button();
            this.btn送出 = new System.Windows.Forms.Button();
            this.btn移除所選品項 = new System.Windows.Forms.Button();
            this.btn輸出txt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn折扣 = new System.Windows.Forms.Button();
            this.lbl折扣內容 = new System.Windows.Forms.Label();
            this.gbxShopBagYes = new System.Windows.Forms.GroupBox();
            this.radio購物袋不需要 = new System.Windows.Forms.RadioButton();
            this.radio購物袋需要 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gbx外帶時間 = new System.Windows.Forms.GroupBox();
            this.dtp外帶時間 = new System.Windows.Forms.DateTimePicker();
            this.gbxEatIn = new System.Windows.Forms.GroupBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnEatInSpace = new System.Windows.Forms.Button();
            this.dateTimePickerEatIn = new System.Windows.Forms.DateTimePicker();
            this.radio外帶 = new System.Windows.Forms.RadioButton();
            this.radio內用 = new System.Windows.Forms.RadioButton();
            this.listViewShopDetail = new System.Windows.Forms.ListView();
            this.imgListOrder = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxShopBagYes.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbx外帶時間.SuspendLayout();
            this.gbxEatIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("標楷體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(463, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "訂購品項列表";
            // 
            // lbl訂購人資料
            // 
            this.lbl訂購人資料.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl訂購人資料.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl訂購人資料.Location = new System.Drawing.Point(32, 71);
            this.lbl訂購人資料.Name = "lbl訂購人資料";
            this.lbl訂購人資料.Size = new System.Drawing.Size(271, 42);
            this.lbl訂購人資料.TabIndex = 2;
            this.lbl訂購人資料.Text = "訂購人資料";
            this.lbl訂購人資料.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl訂單總價
            // 
            this.lbl訂單總價.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl訂單總價.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl訂單總價.Location = new System.Drawing.Point(660, 503);
            this.lbl訂單總價.Name = "lbl訂單總價";
            this.lbl訂單總價.Size = new System.Drawing.Size(307, 41);
            this.lbl訂單總價.TabIndex = 3;
            this.lbl訂單總價.Text = "訂單總價00000元";
            this.lbl訂單總價.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn清空所有品項
            // 
            this.btn清空所有品項.Location = new System.Drawing.Point(218, 20);
            this.btn清空所有品項.Name = "btn清空所有品項";
            this.btn清空所有品項.Size = new System.Drawing.Size(160, 34);
            this.btn清空所有品項.TabIndex = 4;
            this.btn清空所有品項.Text = "清空所有品項";
            this.btn清空所有品項.UseVisualStyleBackColor = true;
            this.btn清空所有品項.Click += new System.EventHandler(this.btn清空所有品項_Click);
            // 
            // btn送出
            // 
            this.btn送出.Location = new System.Drawing.Point(762, 567);
            this.btn送出.Name = "btn送出";
            this.btn送出.Size = new System.Drawing.Size(134, 34);
            this.btn送出.TabIndex = 5;
            this.btn送出.Text = "送出";
            this.btn送出.UseVisualStyleBackColor = true;
            this.btn送出.Click += new System.EventHandler(this.btn送出_Click);
            // 
            // btn移除所選品項
            // 
            this.btn移除所選品項.Location = new System.Drawing.Point(6, 20);
            this.btn移除所選品項.Name = "btn移除所選品項";
            this.btn移除所選品項.Size = new System.Drawing.Size(160, 34);
            this.btn移除所選品項.TabIndex = 6;
            this.btn移除所選品項.Text = "移除所選品項";
            this.btn移除所選品項.UseVisualStyleBackColor = true;
            this.btn移除所選品項.Click += new System.EventHandler(this.btn移除所選品項_Click);
            // 
            // btn輸出txt
            // 
            this.btn輸出txt.Location = new System.Drawing.Point(6, 76);
            this.btn輸出txt.Name = "btn輸出txt";
            this.btn輸出txt.Size = new System.Drawing.Size(108, 31);
            this.btn輸出txt.TabIndex = 7;
            this.btn輸出txt.Text = "輸出txt";
            this.btn輸出txt.UseVisualStyleBackColor = true;
            this.btn輸出txt.Click += new System.EventHandler(this.btn輸出txt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.btn輸出txt);
            this.groupBox1.Controls.Add(this.btn移除所選品項);
            this.groupBox1.Controls.Add(this.btn清空所有品項);
            this.groupBox1.Location = new System.Drawing.Point(631, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 119);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "項目";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Tomato;
            this.groupBox2.Controls.Add(this.btn折扣);
            this.groupBox2.Controls.Add(this.lbl折扣內容);
            this.groupBox2.Location = new System.Drawing.Point(826, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 153);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "折扣";
            this.groupBox2.Visible = false;
            // 
            // btn折扣
            // 
            this.btn折扣.Location = new System.Drawing.Point(61, 103);
            this.btn折扣.Name = "btn折扣";
            this.btn折扣.Size = new System.Drawing.Size(77, 44);
            this.btn折扣.TabIndex = 1;
            this.btn折扣.Text = "折扣";
            this.btn折扣.UseVisualStyleBackColor = true;
            this.btn折扣.Click += new System.EventHandler(this.btn折扣_Click);
            // 
            // lbl折扣內容
            // 
            this.lbl折扣內容.Location = new System.Drawing.Point(15, 23);
            this.lbl折扣內容.Name = "lbl折扣內容";
            this.lbl折扣內容.Size = new System.Drawing.Size(168, 65);
            this.lbl折扣內容.TabIndex = 0;
            this.lbl折扣內容.Text = "折扣內容";
            this.lbl折扣內容.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxShopBagYes
            // 
            this.gbxShopBagYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbxShopBagYes.Controls.Add(this.radio購物袋不需要);
            this.gbxShopBagYes.Controls.Add(this.radio購物袋需要);
            this.gbxShopBagYes.Location = new System.Drawing.Point(22, 129);
            this.gbxShopBagYes.Name = "gbxShopBagYes";
            this.gbxShopBagYes.Size = new System.Drawing.Size(157, 66);
            this.gbxShopBagYes.TabIndex = 12;
            this.gbxShopBagYes.TabStop = false;
            this.gbxShopBagYes.Text = "購物袋";
            // 
            // radio購物袋不需要
            // 
            this.radio購物袋不需要.AutoSize = true;
            this.radio購物袋不需要.Location = new System.Drawing.Point(78, 27);
            this.radio購物袋不需要.Name = "radio購物袋不需要";
            this.radio購物袋不需要.Size = new System.Drawing.Size(73, 20);
            this.radio購物袋不需要.TabIndex = 2;
            this.radio購物袋不需要.TabStop = true;
            this.radio購物袋不需要.Text = "不需要";
            this.radio購物袋不需要.UseVisualStyleBackColor = true;
            this.radio購物袋不需要.CheckedChanged += new System.EventHandler(this.radio購物袋不需要_CheckedChanged);
            // 
            // radio購物袋需要
            // 
            this.radio購物袋需要.AutoSize = true;
            this.radio購物袋需要.Location = new System.Drawing.Point(15, 27);
            this.radio購物袋需要.Name = "radio購物袋需要";
            this.radio購物袋需要.Size = new System.Drawing.Size(57, 20);
            this.radio購物袋需要.TabIndex = 1;
            this.radio購物袋需要.TabStop = true;
            this.radio購物袋需要.Text = "需要";
            this.radio購物袋需要.UseVisualStyleBackColor = true;
            this.radio購物袋需要.CheckedChanged += new System.EventHandler(this.radio購物袋需要_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.gbx外帶時間);
            this.groupBox5.Controls.Add(this.gbxEatIn);
            this.groupBox5.Controls.Add(this.radio外帶);
            this.groupBox5.Controls.Add(this.gbxShopBagYes);
            this.groupBox5.Controls.Add(this.radio內用);
            this.groupBox5.Location = new System.Drawing.Point(629, 118);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(398, 209);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "內用外帶";
            // 
            // gbx外帶時間
            // 
            this.gbx外帶時間.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbx外帶時間.Controls.Add(this.dtp外帶時間);
            this.gbx外帶時間.Location = new System.Drawing.Point(185, 129);
            this.gbx外帶時間.Name = "gbx外帶時間";
            this.gbx外帶時間.Size = new System.Drawing.Size(189, 66);
            this.gbx外帶時間.TabIndex = 13;
            this.gbx外帶時間.TabStop = false;
            this.gbx外帶時間.Text = "外帶時間";
            // 
            // dtp外帶時間
            // 
            this.dtp外帶時間.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp外帶時間.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp外帶時間.Location = new System.Drawing.Point(15, 25);
            this.dtp外帶時間.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtp外帶時間.Name = "dtp外帶時間";
            this.dtp外帶時間.Size = new System.Drawing.Size(168, 27);
            this.dtp外帶時間.TabIndex = 0;
            this.dtp外帶時間.ValueChanged += new System.EventHandler(this.dtp外帶時間_ValueChanged);
            // 
            // gbxEatIn
            // 
            this.gbxEatIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gbxEatIn.Controls.Add(this.lblTable);
            this.gbxEatIn.Controls.Add(this.btnEatInSpace);
            this.gbxEatIn.Controls.Add(this.dateTimePickerEatIn);
            this.gbxEatIn.Location = new System.Drawing.Point(22, 54);
            this.gbxEatIn.Name = "gbxEatIn";
            this.gbxEatIn.Size = new System.Drawing.Size(353, 64);
            this.gbxEatIn.TabIndex = 16;
            this.gbxEatIn.TabStop = false;
            this.gbxEatIn.Text = "內用時間";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTable.Location = new System.Drawing.Point(232, 29);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(76, 21);
            this.lblTable.TabIndex = 17;
            this.lblTable.Text = "第幾桌";
            // 
            // btnEatInSpace
            // 
            this.btnEatInSpace.Location = new System.Drawing.Point(217, 22);
            this.btnEatInSpace.Name = "btnEatInSpace";
            this.btnEatInSpace.Size = new System.Drawing.Size(108, 31);
            this.btnEatInSpace.TabIndex = 15;
            this.btnEatInSpace.Text = "內用位置";
            this.btnEatInSpace.UseVisualStyleBackColor = true;
            this.btnEatInSpace.Click += new System.EventHandler(this.btnEatInSpace_Click);
            // 
            // dateTimePickerEatIn
            // 
            this.dateTimePickerEatIn.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerEatIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEatIn.Location = new System.Drawing.Point(15, 26);
            this.dateTimePickerEatIn.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEatIn.Name = "dateTimePickerEatIn";
            this.dateTimePickerEatIn.Size = new System.Drawing.Size(167, 27);
            this.dateTimePickerEatIn.TabIndex = 14;
            this.dateTimePickerEatIn.ValueChanged += new System.EventHandler(this.dateTimePickerEatIn_ValueChanged);
            // 
            // radio外帶
            // 
            this.radio外帶.AutoSize = true;
            this.radio外帶.Location = new System.Drawing.Point(239, 22);
            this.radio外帶.Name = "radio外帶";
            this.radio外帶.Size = new System.Drawing.Size(57, 20);
            this.radio外帶.TabIndex = 1;
            this.radio外帶.TabStop = true;
            this.radio外帶.Text = "外帶";
            this.radio外帶.UseVisualStyleBackColor = true;
            this.radio外帶.CheckedChanged += new System.EventHandler(this.radio外帶_CheckedChanged);
            // 
            // radio內用
            // 
            this.radio內用.AutoSize = true;
            this.radio內用.Location = new System.Drawing.Point(70, 22);
            this.radio內用.Name = "radio內用";
            this.radio內用.Size = new System.Drawing.Size(57, 20);
            this.radio內用.TabIndex = 0;
            this.radio內用.TabStop = true;
            this.radio內用.Text = "內用";
            this.radio內用.UseVisualStyleBackColor = true;
            this.radio內用.CheckedChanged += new System.EventHandler(this.radio內用_CheckedChanged);
            // 
            // listViewShopDetail
            // 
            this.listViewShopDetail.HideSelection = false;
            this.listViewShopDetail.Location = new System.Drawing.Point(36, 116);
            this.listViewShopDetail.Name = "listViewShopDetail";
            this.listViewShopDetail.Size = new System.Drawing.Size(568, 483);
            this.listViewShopDetail.TabIndex = 13;
            this.listViewShopDetail.UseCompatibleStateImageBehavior = false;
            // 
            // imgListOrder
            // 
            this.imgListOrder.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListOrder.ImageSize = new System.Drawing.Size(256, 256);
            this.imgListOrder.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(596, 549);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSalmon;
            this.label2.Location = new System.Drawing.Point(617, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 500);
            this.label2.TabIndex = 15;
            // 
            // OrderList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1055, 620);
            this.Controls.Add(this.listViewShopDetail);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn送出);
            this.Controls.Add(this.lbl訂單總價);
            this.Controls.Add(this.lbl訂購人資料);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderList";
            this.Text = "購物車";
            this.Activated += new System.EventHandler(this.OrderList_Activated_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderList_FormClosed);
            this.Load += new System.EventHandler(this.OrderList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbxShopBagYes.ResumeLayout(false);
            this.gbxShopBagYes.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbx外帶時間.ResumeLayout(false);
            this.gbxEatIn.ResumeLayout(false);
            this.gbxEatIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl訂購人資料;
        private System.Windows.Forms.Label lbl訂單總價;
        private System.Windows.Forms.Button btn清空所有品項;
        private System.Windows.Forms.Button btn送出;
        private System.Windows.Forms.Button btn移除所選品項;
        private System.Windows.Forms.Button btn輸出txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbxShopBagYes;
        private System.Windows.Forms.Label lbl折扣內容;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radio購物袋不需要;
        private System.Windows.Forms.RadioButton radio購物袋需要;
        private System.Windows.Forms.RadioButton radio外帶;
        private System.Windows.Forms.RadioButton radio內用;
        private System.Windows.Forms.Button btn折扣;
        private System.Windows.Forms.ListView listViewShopDetail;
        private System.Windows.Forms.ImageList imgListOrder;
        private System.Windows.Forms.GroupBox gbxEatIn;
        private System.Windows.Forms.Button btnEatInSpace;
        private System.Windows.Forms.DateTimePicker dateTimePickerEatIn;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.GroupBox gbx外帶時間;
        private System.Windows.Forms.DateTimePicker dtp外帶時間;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}