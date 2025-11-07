namespace MiniStore.Modules.PurchaseOrder.UI
{
    partial class PurchaseOrderHeader
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonDelete = new FontAwesome.Sharp.IconButton();
            ButtonSearch = new FontAwesome.Sharp.IconButton();
            ButtonExport = new FontAwesome.Sharp.IconButton();
            ButtonAdd = new FontAwesome.Sharp.IconButton();
            SearchInput = new TextBox();
            LabelNameUI = new Label();
            SuspendLayout();
            // 
            // ButtonDelete
            // 
            ButtonDelete.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonDelete.IconColor = Color.Black;
            ButtonDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonDelete.Location = new Point(1043, 48);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(100, 40);
            ButtonDelete.TabIndex = 14;
            ButtonDelete.Text = "iconButton1";
            ButtonDelete.UseVisualStyleBackColor = true;
            // 
            // ButtonSearch
            // 
            ButtonSearch.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSearch.IconColor = Color.Black;
            ButtonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSearch.Location = new Point(433, 48);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(150, 40);
            ButtonSearch.TabIndex = 13;
            ButtonSearch.Text = "iconButton1";
            ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // ButtonExport
            // 
            ButtonExport.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonExport.IconColor = Color.Black;
            ButtonExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonExport.Location = new Point(706, 48);
            ButtonExport.Name = "ButtonExport";
            ButtonExport.Size = new Size(150, 40);
            ButtonExport.TabIndex = 12;
            ButtonExport.Text = "iconButton2";
            ButtonExport.UseVisualStyleBackColor = true;
            // 
            // ButtonAdd
            // 
            ButtonAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonAdd.IconColor = Color.Black;
            ButtonAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonAdd.Location = new Point(877, 48);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(150, 40);
            ButtonAdd.TabIndex = 11;
            ButtonAdd.Text = "ButtonAdd";
            ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // SearchInput
            // 
            SearchInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchInput.Location = new Point(12, 48);
            SearchInput.Name = "SearchInput";
            SearchInput.Size = new Size(400, 34);
            SearchInput.TabIndex = 10;
            // 
            // LabelNameUI
            // 
            LabelNameUI.AutoSize = true;
            LabelNameUI.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNameUI.ForeColor = SystemColors.WindowText;
            LabelNameUI.Location = new Point(5, 0);
            LabelNameUI.Name = "LabelNameUI";
            LabelNameUI.Size = new Size(215, 31);
            LabelNameUI.TabIndex = 9;
            LabelNameUI.Text = "Quản lý phiếu nhập";
            LabelNameUI.Click += LabelNameUI_Click;
            // 
            // PurchaseOrderHeader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonSearch);
            Controls.Add(ButtonExport);
            Controls.Add(ButtonAdd);
            Controls.Add(SearchInput);
            Controls.Add(LabelNameUI);
            Name = "PurchaseOrderHeader";
            Size = new Size(1210, 100);
            Load += PurchaseOrderHeader_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton ButtonDelete;
        private FontAwesome.Sharp.IconButton ButtonSearch;
        private FontAwesome.Sharp.IconButton ButtonExport;
        private FontAwesome.Sharp.IconButton ButtonAdd;
        private TextBox SearchInput;
        private Label LabelNameUI;
    }
}
