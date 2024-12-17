namespace CSharpCourse
{
    partial class AddEditDiscountFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscountId = new System.Windows.Forms.TextBox();
            this.txtDiscountName = new System.Windows.Forms.TextBox();
            this.dateTimeDiscountStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDiscountEnd = new System.Windows.Forms.DateTimePicker();
            this.comboDiscountType = new System.Windows.Forms.ComboBox();
            this.btnAddUpdateDiscount = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numericDiscountPercent = new System.Windows.Forms.NumericUpDown();
            this.numericDiscountAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khuyến mãi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khuyến mãi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày bắt đầu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày kết thúc:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loại khuyến mãi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Phần trăm giá bán:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giá trị khuyến mãi:";
            // 
            // txtDiscountId
            // 
            this.txtDiscountId.Enabled = false;
            this.txtDiscountId.Location = new System.Drawing.Point(214, 63);
            this.txtDiscountId.Name = "txtDiscountId";
            this.txtDiscountId.Size = new System.Drawing.Size(191, 27);
            this.txtDiscountId.TabIndex = 7;
            this.txtDiscountId.Text = "0";
            // 
            // txtDiscountName
            // 
            this.txtDiscountName.Location = new System.Drawing.Point(214, 116);
            this.txtDiscountName.Name = "txtDiscountName";
            this.txtDiscountName.Size = new System.Drawing.Size(191, 27);
            this.txtDiscountName.TabIndex = 7;
            // 
            // dateTimeDiscountStart
            // 
            this.dateTimeDiscountStart.CustomFormat = "dd/MM/yyyy HH:m:ss";
            this.dateTimeDiscountStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDiscountStart.Location = new System.Drawing.Point(214, 167);
            this.dateTimeDiscountStart.Name = "dateTimeDiscountStart";
            this.dateTimeDiscountStart.Size = new System.Drawing.Size(191, 27);
            this.dateTimeDiscountStart.TabIndex = 8;
            // 
            // dateTimeDiscountEnd
            // 
            this.dateTimeDiscountEnd.CustomFormat = "dd/MM/yyyy HH:m:ss";
            this.dateTimeDiscountEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeDiscountEnd.Location = new System.Drawing.Point(214, 220);
            this.dateTimeDiscountEnd.Name = "dateTimeDiscountEnd";
            this.dateTimeDiscountEnd.Size = new System.Drawing.Size(191, 27);
            this.dateTimeDiscountEnd.TabIndex = 8;
            // 
            // comboDiscountType
            // 
            this.comboDiscountType.FormattingEnabled = true;
            this.comboDiscountType.Items.AddRange(new object[] {
            "Không áp dụng",
            "Khuyến mãi theo phần trăm giá bán",
            "Khuyến mãi giảm giá trực tiếp"});
            this.comboDiscountType.Location = new System.Drawing.Point(213, 275);
            this.comboDiscountType.Name = "comboDiscountType";
            this.comboDiscountType.Size = new System.Drawing.Size(191, 28);
            this.comboDiscountType.TabIndex = 9;
            // 
            // btnAddUpdateDiscount
            // 
            this.btnAddUpdateDiscount.Image = global::CSharpCourse.Properties.Resources.plus;
            this.btnAddUpdateDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUpdateDiscount.Location = new System.Drawing.Point(61, 442);
            this.btnAddUpdateDiscount.Name = "btnAddUpdateDiscount";
            this.btnAddUpdateDiscount.Size = new System.Drawing.Size(162, 43);
            this.btnAddUpdateDiscount.TabIndex = 10;
            this.btnAddUpdateDiscount.Text = "Thêm mới";
            this.btnAddUpdateDiscount.UseVisualStyleBackColor = true;
            this.btnAddUpdateDiscount.Click += new System.EventHandler(this.BtnAddEditDiscountClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::CSharpCourse.Properties.Resources.multiply;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(243, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 43);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelDiscountClick);
            // 
            // numericDiscountPercent
            // 
            this.numericDiscountPercent.Location = new System.Drawing.Point(214, 329);
            this.numericDiscountPercent.Name = "numericDiscountPercent";
            this.numericDiscountPercent.Size = new System.Drawing.Size(191, 27);
            this.numericDiscountPercent.TabIndex = 11;
            // 
            // numericDiscountAmount
            // 
            this.numericDiscountAmount.Location = new System.Drawing.Point(213, 382);
            this.numericDiscountAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericDiscountAmount.Name = "numericDiscountAmount";
            this.numericDiscountAmount.Size = new System.Drawing.Size(191, 27);
            this.numericDiscountAmount.TabIndex = 11;
            // 
            // AddEditDiscountFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 546);
            this.Controls.Add(this.numericDiscountAmount);
            this.Controls.Add(this.numericDiscountPercent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddUpdateDiscount);
            this.Controls.Add(this.comboDiscountType);
            this.Controls.Add(this.dateTimeDiscountEnd);
            this.Controls.Add(this.dateTimeDiscountStart);
            this.Controls.Add(this.txtDiscountName);
            this.Controls.Add(this.txtDiscountId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditDiscountFrm";
            this.Text = "THÊM MÃ KHUYẾN MÃI";
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscountAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiscountId;
        private System.Windows.Forms.TextBox txtDiscountName;
        private System.Windows.Forms.DateTimePicker dateTimeDiscountStart;
        private System.Windows.Forms.DateTimePicker dateTimeDiscountEnd;
        private System.Windows.Forms.ComboBox comboDiscountType;
        private System.Windows.Forms.Button btnAddUpdateDiscount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericDiscountPercent;
        private System.Windows.Forms.NumericUpDown numericDiscountAmount;
    }
}