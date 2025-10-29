namespace MiniStore.Modules.SupplierManager.UI
{
    partial class SupplierHeader
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
            LabelSupplier = new Label();
            InputSearch = new TextBox();
            ButtonSearch = new FontAwesome.Sharp.IconButton();
            ButtonReport = new FontAwesome.Sharp.IconButton();
            ButtonAdd = new FontAwesome.Sharp.IconButton();
            ButtonDelete = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // LabelSupplier
            // 
            LabelSupplier.AutoSize = true;
            LabelSupplier.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelSupplier.Location = new Point(0, 0);
            LabelSupplier.Name = "LabelSupplier";
            LabelSupplier.Size = new Size(237, 31);
            LabelSupplier.TabIndex = 0;
            LabelSupplier.Text = "Quản lý nhà cung cấp";
            // 
            // InputSearch
            // 
            InputSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InputSearch.Location = new Point(10, 50);
            InputSearch.Name = "InputSearch";
            InputSearch.Size = new Size(400, 34);
            InputSearch.TabIndex = 1;
            // 
            // ButtonSearch
            // 
            ButtonSearch.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSearch.IconColor = Color.Black;
            ButtonSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSearch.Location = new Point(431, 48);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(150, 40);
            ButtonSearch.TabIndex = 2;
            ButtonSearch.Text = "iconButton1";
            ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // ButtonReport
            // 
            ButtonReport.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonReport.IconColor = Color.Black;
            ButtonReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonReport.Location = new Point(704, 48);
            ButtonReport.Name = "ButtonReport";
            ButtonReport.Size = new Size(150, 40);
            ButtonReport.TabIndex = 3;
            ButtonReport.Text = "iconButton2";
            ButtonReport.UseVisualStyleBackColor = true;
            // 
            // ButtonAdd
            // 
            ButtonAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonAdd.IconColor = Color.Black;
            ButtonAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonAdd.Location = new Point(875, 48);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(150, 40);
            ButtonAdd.TabIndex = 4;
            ButtonAdd.Text = "iconButton3";
            ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // ButtonDelete
            // 
            ButtonDelete.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonDelete.IconColor = Color.Black;
            ButtonDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonDelete.Location = new Point(1041, 48);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(100, 40);
            ButtonDelete.TabIndex = 5;
            ButtonDelete.Text = "iconButton4";
            ButtonDelete.UseVisualStyleBackColor = true;
            // 
            // SupplierHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonAdd);
            Controls.Add(ButtonReport);
            Controls.Add(ButtonSearch);
            Controls.Add(InputSearch);
            Controls.Add(LabelSupplier);
            Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SupplierHeader";
            Size = new Size(1210, 100);
            Load += SupplierHeader_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelSupplier;
        private TextBox InputSearch;
        private FontAwesome.Sharp.IconButton ButtonSearch;
        private FontAwesome.Sharp.IconButton ButtonReport;
        private FontAwesome.Sharp.IconButton ButtonAdd;
        private FontAwesome.Sharp.IconButton ButtonDelete;
    }
}
