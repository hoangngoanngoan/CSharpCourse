namespace CSharpCourse
{
    partial class PaymentFrm
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
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtCreatedTime = new System.Windows.Forms.TextBox();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.txtTotalDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.comboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời gian:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng sản phẩm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tổng khuyến mãi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tổng tiền:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Hình thức thanh toán:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(229, 60);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(191, 27);
            this.txtCustomerName.TabIndex = 9;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Enabled = false;
            this.txtStaffName.Location = new System.Drawing.Point(229, 117);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(191, 27);
            this.txtStaffName.TabIndex = 10;
            // 
            // txtCreatedTime
            // 
            this.txtCreatedTime.Enabled = false;
            this.txtCreatedTime.Location = new System.Drawing.Point(229, 174);
            this.txtCreatedTime.Name = "txtCreatedTime";
            this.txtCreatedTime.Size = new System.Drawing.Size(191, 27);
            this.txtCreatedTime.TabIndex = 11;
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Enabled = false;
            this.txtTotalItem.Location = new System.Drawing.Point(229, 231);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.Size = new System.Drawing.Size(191, 27);
            this.txtTotalItem.TabIndex = 12;
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.Enabled = false;
            this.txtTotalDiscount.Location = new System.Drawing.Point(229, 288);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.Size = new System.Drawing.Size(191, 27);
            this.txtTotalDiscount.TabIndex = 13;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(229, 345);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(191, 27);
            this.txtTotalAmount.TabIndex = 14;
            // 
            // comboPaymentMethod
            // 
            this.comboPaymentMethod.FormattingEnabled = true;
            this.comboPaymentMethod.Items.AddRange(new object[] {
            "Thanh toán tiền mặt",
            "Thanh toán chuyển khoản",
            "Thanh toán quẹt thẻ"});
            this.comboPaymentMethod.Location = new System.Drawing.Point(229, 402);
            this.comboPaymentMethod.Name = "comboPaymentMethod";
            this.comboPaymentMethod.Size = new System.Drawing.Size(191, 28);
            this.comboPaymentMethod.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::CSharpCourse.Properties.Resources.multiply2;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(251, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 43);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnFinish
            // 
            this.btnFinish.Image = global::CSharpCourse.Properties.Resources.check;
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(68, 489);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(162, 43);
            this.btnFinish.TabIndex = 0;
            this.btnFinish.Text = "Hoàn tất";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinishClick);
            // 
            // PaymentFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 601);
            this.Controls.Add(this.comboPaymentMethod);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtTotalDiscount);
            this.Controls.Add(this.txtTotalItem);
            this.Controls.Add(this.txtCreatedTime);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentFrm";
            this.Text = "BẢNG HÓA ĐƠN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtCreatedTime;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.TextBox txtTotalDiscount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox comboPaymentMethod;
    }
}