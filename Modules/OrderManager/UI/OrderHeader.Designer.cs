namespace MiniStore.Modules.OrderManager.UI
{
    partial class OrderHeader
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
            LabelNameUI = new Label();
            SearchInput = new TextBox();
            ButtonAdd = new FontAwesome.Sharp.IconButton();
            ButtonExport = new FontAwesome.Sharp.IconButton();
            ButtonSearch = new FontAwesome.Sharp.IconButton();
            ButtonDelete = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // LabelNameUI
            // 
            LabelNameUI.AutoSize = true;
            LabelNameUI.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelNameUI.ForeColor = SystemColors.WindowText;
            LabelNameUI.Location = new Point(3, 0);
            LabelNameUI.Name = "LabelNameUI";
            LabelNameUI.Size = new Size(198, 31);
            LabelNameUI.TabIndex = 0;
            LabelNameUI.Text = "Quản lý đơn hàng";
            // 
            // SearchInput
            // 
            SearchInput.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchInput.Location = new Point(3, 48);
            SearchInput.Name = "SearchInput";
            SearchInput.Size = new Size(400, 34);
            SearchInput.TabIndex = 1;
            // 
            // ButtonAdd
            // 
            ButtonAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonAdd.IconColor = Color.Black;
            ButtonAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonAdd.Location = new Point(875, 48);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(150, 40);
            ButtonAdd.TabIndex = 5;
            ButtonAdd.Text = "ButtonAdd";
            ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // ButtonExport
            // 
            ButtonExport.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonExport.IconColor = Color.Black;
            ButtonExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonExport.Location = new Point(704, 48);
            ButtonExport.Name = "ButtonExport";
            ButtonExport.Size = new Size(150, 40);
            ButtonExport.TabIndex = 6;
            ButtonExport.Text = "iconButton2";
            ButtonExport.UseVisualStyleBackColor = true;
            // 
            // ButtonSearch
            // 
            ButtonSearch.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSearch.IconColor = Color.Black;
            ButtonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSearch.Location = new Point(431, 48);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(150, 40);
            ButtonSearch.TabIndex = 7;
            ButtonSearch.Text = "iconButton1";
            ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // ButtonDelete
            // 
            ButtonDelete.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonDelete.IconColor = Color.Black;
            ButtonDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonDelete.Location = new Point(1041, 48);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(100, 40);
            ButtonDelete.TabIndex = 8;
            ButtonDelete.Text = "iconButton1";
            ButtonDelete.UseVisualStyleBackColor = true;
            // 
            // OrderHeader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonSearch);
            Controls.Add(ButtonExport);
            Controls.Add(ButtonAdd);
            Controls.Add(SearchInput);
            Controls.Add(LabelNameUI);
            Name = "OrderHeader";
            Size = new Size(1210, 100);
            Load += Header_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelNameUI;
        private TextBox SearchInput;
        private FontAwesome.Sharp.IconButton ButtonAdd;
        private FontAwesome.Sharp.IconButton ButtonExport;
        private FontAwesome.Sharp.IconButton ButtonSearch;
        private FontAwesome.Sharp.IconButton ButtonDelete;
    }
}
