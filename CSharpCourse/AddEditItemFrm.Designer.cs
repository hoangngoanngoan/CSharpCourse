namespace CSharpCourse
{
    partial class AddEditItemFrm
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.comboItemType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.comboDiscount = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Mặt Hàng:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(217, 58);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(191, 27);
            this.txtId.TabIndex = 1;
            this.txtId.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Mặt Hàng:";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(217, 102);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(191, 27);
            this.txtItemName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại Mặt Hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số Lượng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hãng Sản Xuất:";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(217, 234);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(191, 27);
            this.txtBrand.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giá Bán:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Khuyến Mãi:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ngày Sản Xuất:";
            // 
            // numericQuantity
            // 
            this.numericQuantity.Location = new System.Drawing.Point(217, 193);
            this.numericQuantity.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(191, 27);
            this.numericQuantity.TabIndex = 18;
            // 
            // comboItemType
            // 
            this.comboItemType.FormattingEnabled = true;
            this.comboItemType.Items.AddRange(new object[] {
            "Thời trang",
            "Điện tử",
            "Thực phẩm",
            "Vật liệu xây dựng"});
            this.comboItemType.Location = new System.Drawing.Point(216, 146);
            this.comboItemType.Name = "comboItemType";
            this.comboItemType.Size = new System.Drawing.Size(192, 28);
            this.comboItemType.TabIndex = 19;
            // 
            // dateTimePickerReleaseDate
            // 
            this.dateTimePickerReleaseDate.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReleaseDate.Location = new System.Drawing.Point(216, 276);
            this.dateTimePickerReleaseDate.Name = "dateTimePickerReleaseDate";
            this.dateTimePickerReleaseDate.Size = new System.Drawing.Size(192, 27);
            this.dateTimePickerReleaseDate.TabIndex = 20;
            // 
            // numericPrice
            // 
            this.numericPrice.Location = new System.Drawing.Point(217, 323);
            this.numericPrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(192, 27);
            this.numericPrice.TabIndex = 21;
            // 
            // comboDiscount
            // 
            this.comboDiscount.FormattingEnabled = true;
            this.comboDiscount.Location = new System.Drawing.Point(216, 366);
            this.comboDiscount.Name = "comboDiscount";
            this.comboDiscount.Size = new System.Drawing.Size(193, 28);
            this.comboDiscount.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CSharpCourse.Properties.Resources.multiply;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(245, 439);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(162, 43);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Hủy bỏ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::CSharpCourse.Properties.Resources.plus1;
            this.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.Location = new System.Drawing.Point(68, 439);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(162, 43);
            this.btnAddItem.TabIndex = 16;
            this.btnAddItem.Text = "Thêm mới";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // AddEditItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 543);
            this.Controls.Add(this.comboDiscount);
            this.Controls.Add(this.numericPrice);
            this.Controls.Add(this.dateTimePickerReleaseDate);
            this.Controls.Add(this.comboItemType);
            this.Controls.Add(this.numericQuantity);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditItemFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI MẶT HÀNG";
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.ComboBox comboItemType;
        private System.Windows.Forms.DateTimePicker dateTimePickerReleaseDate;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.ComboBox comboDiscount;
    }
}