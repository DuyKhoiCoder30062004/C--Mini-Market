namespace MiniStore.Modules.SupplierManager.UI
{
    partial class FormCreareSupplier
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
            splitContainer1 = new SplitContainer();
            LableContact = new Label();
            InputContact = new TextBox();
            InputStatus = new ComboBox();
            label6 = new Label();
            LabelEmail = new Label();
            InputEmail = new TextBox();
            LabelAddress = new Label();
            InputAddress = new TextBox();
            LableName = new Label();
            InputName = new TextBox();
            label1 = new Label();
            InputPhone = new TextBox();
            ButtonCancel = new FontAwesome.Sharp.IconButton();
            ButtonSave = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(LableContact);
            splitContainer1.Panel1.Controls.Add(InputContact);
            splitContainer1.Panel1.Controls.Add(InputStatus);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(LabelEmail);
            splitContainer1.Panel1.Controls.Add(InputEmail);
            splitContainer1.Panel1.Controls.Add(LabelAddress);
            splitContainer1.Panel1.Controls.Add(InputAddress);
            splitContainer1.Panel1.Controls.Add(LableName);
            splitContainer1.Panel1.Controls.Add(InputName);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(InputPhone);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ButtonCancel);
            splitContainer1.Panel2.Controls.Add(ButtonSave);
            splitContainer1.Size = new Size(582, 703);
            splitContainer1.SplitterDistance = 632;
            splitContainer1.TabIndex = 0;
            // 
            // LableContact
            // 
            LableContact.AutoSize = true;
            LableContact.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableContact.Location = new Point(22, 29);
            LableContact.Name = "LableContact";
            LableContact.Size = new Size(114, 23);
            LableContact.TabIndex = 27;
            LableContact.Text = "Người liên hệ";
            // 
            // InputContact
            // 
            InputContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputContact.Location = new Point(22, 65);
            InputContact.Name = "InputContact";
            InputContact.Size = new Size(534, 34);
            InputContact.TabIndex = 0;
            // 
            // InputStatus
            // 
            InputStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputStatus.FormattingEnabled = true;
            InputStatus.Location = new Point(22, 552);
            InputStatus.Name = "InputStatus";
            InputStatus.Size = new Size(534, 33);
            InputStatus.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 516);
            label6.Name = "label6";
            label6.Size = new Size(87, 23);
            label6.TabIndex = 24;
            label6.Text = "Trạng thái";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelEmail.Location = new Point(22, 417);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(51, 23);
            LabelEmail.TabIndex = 23;
            LabelEmail.Text = "Email";
            // 
            // InputEmail
            // 
            InputEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputEmail.Location = new Point(22, 453);
            InputEmail.Name = "InputEmail";
            InputEmail.Size = new Size(534, 34);
            InputEmail.TabIndex = 4;
            // 
            // LabelAddress
            // 
            LabelAddress.AutoSize = true;
            LabelAddress.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelAddress.Location = new Point(22, 327);
            LabelAddress.Name = "LabelAddress";
            LabelAddress.Size = new Size(62, 23);
            LabelAddress.TabIndex = 20;
            LabelAddress.Text = "Địa chỉ";
            // 
            // InputAddress
            // 
            InputAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputAddress.Location = new Point(22, 363);
            InputAddress.Name = "InputAddress";
            InputAddress.Size = new Size(534, 34);
            InputAddress.TabIndex = 3;
            // 
            // LableName
            // 
            LableName.AutoSize = true;
            LableName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableName.Location = new Point(22, 128);
            LableName.Name = "LableName";
            LableName.Size = new Size(145, 23);
            LableName.TabIndex = 16;
            LableName.Text = "Tên nhà cung cấp";
            // 
            // InputName
            // 
            InputName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputName.Location = new Point(22, 164);
            InputName.Name = "InputName";
            InputName.Size = new Size(534, 34);
            InputName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 230);
            label1.Name = "label1";
            label1.Size = new Size(111, 23);
            label1.TabIndex = 14;
            label1.Text = "Số điện thoại";
            // 
            // InputPhone
            // 
            InputPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputPhone.Location = new Point(22, 266);
            InputPhone.Name = "InputPhone";
            InputPhone.Size = new Size(534, 34);
            InputPhone.TabIndex = 2;
            // 
            // ButtonCancel
            // 
            ButtonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonCancel.IconColor = Color.Black;
            ButtonCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonCancel.Location = new Point(272, 15);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(94, 29);
            ButtonCancel.TabIndex = 1;
            ButtonCancel.Text = "iconButton2";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSave.IconColor = Color.Black;
            ButtonSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSave.Location = new Point(442, 15);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(94, 29);
            ButtonSave.TabIndex = 0;
            ButtonSave.Text = "iconButton1";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // FormCreareSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 703);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Name = "FormCreareSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCreareSupplier";
            Load += FormCreareSupplier_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconButton ButtonCancel;
        private FontAwesome.Sharp.IconButton ButtonSave;
        private Label LableContact;
        private TextBox InputContact;
        private ComboBox InputStatus;
        private Label label6;
        private Label LabelEmail;
        private TextBox InputEmail;
        private Label LabelAddress;
        private TextBox InputAddress;
        private Label LableName;
        private TextBox InputName;
        private Label label1;
        private TextBox InputPhone;
    }
}