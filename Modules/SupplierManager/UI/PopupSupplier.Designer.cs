namespace MiniStore.Modules.SupplierManager.UI
{
    partial class PopupSupplier
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
            panel2 = new Panel();
            PanelInfo = new Panel();
            label2 = new Label();
            LableHistoryTransaction = new Label();
            InputStatus = new ComboBox();
            label9 = new Label();
            InputUpdateAt = new TextBox();
            label8 = new Label();
            InputCreateAt = new TextBox();
            LableContact = new Label();
            InputContact = new TextBox();
            label6 = new Label();
            LabelEmail = new Label();
            InputEmail = new TextBox();
            LableId = new Label();
            InputId = new TextBox();
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
            PanelInfo.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(PanelInfo);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ButtonCancel);
            splitContainer1.Panel2.Controls.Add(ButtonSave);
            splitContainer1.Size = new Size(1182, 853);
            splitContainer1.SplitterDistance = 789;
            splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(3, 389);
            panel2.Name = "panel2";
            panel2.Size = new Size(1176, 397);
            panel2.TabIndex = 1;
            // 
            // PanelInfo
            // 
            PanelInfo.BackColor = Color.White;
            PanelInfo.Controls.Add(label2);
            PanelInfo.Controls.Add(LableHistoryTransaction);
            PanelInfo.Controls.Add(InputStatus);
            PanelInfo.Controls.Add(label9);
            PanelInfo.Controls.Add(InputUpdateAt);
            PanelInfo.Controls.Add(label8);
            PanelInfo.Controls.Add(InputCreateAt);
            PanelInfo.Controls.Add(LableContact);
            PanelInfo.Controls.Add(InputContact);
            PanelInfo.Controls.Add(label6);
            PanelInfo.Controls.Add(LabelEmail);
            PanelInfo.Controls.Add(InputEmail);
            PanelInfo.Controls.Add(LableId);
            PanelInfo.Controls.Add(InputId);
            PanelInfo.Controls.Add(LabelAddress);
            PanelInfo.Controls.Add(InputAddress);
            PanelInfo.Controls.Add(LableName);
            PanelInfo.Controls.Add(InputName);
            PanelInfo.Controls.Add(label1);
            PanelInfo.Controls.Add(InputPhone);
            PanelInfo.Location = new Point(3, 3);
            PanelInfo.Name = "PanelInfo";
            PanelInfo.Size = new Size(1176, 380);
            PanelInfo.TabIndex = 0;
            PanelInfo.Paint += PanelInfo_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 316);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 0;
            label2.Click += label2_Click;
            // 
            // LableHistoryTransaction
            // 
            LableHistoryTransaction.AutoSize = true;
            LableHistoryTransaction.Location = new Point(9, 331);
            LableHistoryTransaction.Name = "LableHistoryTransaction";
            LableHistoryTransaction.Size = new Size(120, 20);
            LableHistoryTransaction.TabIndex = 20;
            LableHistoryTransaction.Text = "Lịch sử giao dịch";
            // 
            // InputStatus
            // 
            InputStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputStatus.FormattingEnabled = true;
            InputStatus.Location = new Point(427, 240);
            InputStatus.Name = "InputStatus";
            InputStatus.Size = new Size(325, 33);
            InputStatus.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(822, 204);
            label9.Name = "label9";
            label9.Size = new Size(123, 23);
            label9.TabIndex = 17;
            label9.Text = "Ngày cập nhật";
            // 
            // InputUpdateAt
            // 
            InputUpdateAt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputUpdateAt.Location = new Point(822, 240);
            InputUpdateAt.Name = "InputUpdateAt";
            InputUpdateAt.Size = new Size(325, 34);
            InputUpdateAt.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(822, 112);
            label8.Name = "label8";
            label8.Size = new Size(81, 23);
            label8.TabIndex = 15;
            label8.Text = "Ngày tạo";
            // 
            // InputCreateAt
            // 
            InputCreateAt.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputCreateAt.Location = new Point(822, 148);
            InputCreateAt.Name = "InputCreateAt";
            InputCreateAt.Size = new Size(325, 30);
            InputCreateAt.TabIndex = 8;
            // 
            // LableContact
            // 
            LableContact.AutoSize = true;
            LableContact.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableContact.Location = new Point(822, 6);
            LableContact.Name = "LableContact";
            LableContact.Size = new Size(114, 23);
            LableContact.TabIndex = 13;
            LableContact.Text = "Người liên hệ";
            // 
            // InputContact
            // 
            InputContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputContact.Location = new Point(822, 42);
            InputContact.Name = "InputContact";
            InputContact.Size = new Size(325, 34);
            InputContact.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(427, 204);
            label6.Name = "label6";
            label6.Size = new Size(87, 23);
            label6.TabIndex = 11;
            label6.Text = "Trạng thái";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelEmail.Location = new Point(427, 112);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(51, 23);
            LabelEmail.TabIndex = 9;
            LabelEmail.Text = "Email";
            // 
            // InputEmail
            // 
            InputEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputEmail.Location = new Point(427, 148);
            InputEmail.Name = "InputEmail";
            InputEmail.Size = new Size(325, 34);
            InputEmail.TabIndex = 5;
            // 
            // LableId
            // 
            LableId.AutoSize = true;
            LableId.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableId.Location = new Point(9, 6);
            LableId.Name = "LableId";
            LableId.Size = new Size(27, 23);
            LableId.TabIndex = 0;
            LableId.Text = "ID";
            // 
            // InputId
            // 
            InputId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputId.Location = new Point(9, 42);
            InputId.Name = "InputId";
            InputId.Size = new Size(325, 34);
            InputId.TabIndex = 1;
            // 
            // LabelAddress
            // 
            LabelAddress.AutoSize = true;
            LabelAddress.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelAddress.Location = new Point(427, 6);
            LabelAddress.Name = "LabelAddress";
            LabelAddress.Size = new Size(62, 23);
            LabelAddress.TabIndex = 5;
            LabelAddress.Text = "Địa chỉ";
            LabelAddress.Click += label3_Click;
            // 
            // InputAddress
            // 
            InputAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputAddress.Location = new Point(427, 42);
            InputAddress.Name = "InputAddress";
            InputAddress.Size = new Size(325, 34);
            InputAddress.TabIndex = 4;
            // 
            // LableName
            // 
            LableName.AutoSize = true;
            LableName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableName.Location = new Point(9, 112);
            LableName.Name = "LableName";
            LableName.Size = new Size(145, 23);
            LableName.TabIndex = 3;
            LableName.Text = "Tên nhà cung cấp";
            // 
            // InputName
            // 
            InputName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputName.Location = new Point(9, 148);
            InputName.Name = "InputName";
            InputName.Size = new Size(325, 34);
            InputName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 204);
            label1.Name = "label1";
            label1.Size = new Size(111, 23);
            label1.TabIndex = 1;
            label1.Text = "Số điện thoại";
            // 
            // InputPhone
            // 
            InputPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputPhone.Location = new Point(9, 240);
            InputPhone.Name = "InputPhone";
            InputPhone.Size = new Size(325, 34);
            InputPhone.TabIndex = 3;
            // 
            // ButtonCancel
            // 
            ButtonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonCancel.IconColor = Color.Black;
            ButtonCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonCancel.Location = new Point(845, 19);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(94, 29);
            ButtonCancel.TabIndex = 3;
            ButtonCancel.Text = "iconButton2";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSave.IconColor = Color.Black;
            ButtonSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSave.Location = new Point(1015, 19);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(94, 29);
            ButtonSave.TabIndex = 2;
            ButtonSave.Text = "iconButton1";
            ButtonSave.UseVisualStyleBackColor = true;
            // 
            // PopupSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1182, 853);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Name = "PopupSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PopupSupplier";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            PanelInfo.ResumeLayout(false);
            PanelInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconButton ButtonCancel;
        private FontAwesome.Sharp.IconButton ButtonSave;
        private Panel panel2;
        private Panel PanelInfo;
        private TextBox InputUpdateAt;
        private Label label8;
        private TextBox InputCreateAt;
        private Label LableContact;
        private TextBox InputContact;
        private Label label6;
        private Label LabelEmail;
        private TextBox InputEmail;
        private Label LableId;
        private TextBox InputId;
        private Label LabelAddress;
        private TextBox InputAddress;
        private Label LableName;
        private TextBox InputName;
        private Label label1;
        private TextBox InputPhone;
        private ComboBox InputStatus;
        private Label label9;
        private Label LableHistoryTransaction;
        private Label label2;
    }
}