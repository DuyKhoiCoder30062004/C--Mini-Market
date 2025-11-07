namespace MiniStore.Modules.PurchaseOrder.UI
{
    partial class PopupPurchaseOrder
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
            ButtonCancel = new FontAwesome.Sharp.IconButton();
            ButtonSave = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
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
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ButtonCancel);
            splitContainer1.Panel2.Controls.Add(ButtonSave);
            splitContainer1.Size = new Size(1182, 853);
            splitContainer1.SplitterDistance = 803;
            splitContainer1.TabIndex = 0;
            // 
            // ButtonCancel
            // 
            ButtonCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonCancel.IconColor = Color.Black;
            ButtonCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonCancel.Location = new Point(862, 3);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(94, 29);
            ButtonCancel.TabIndex = 1;
            ButtonCancel.Text = "iconButton2";
            ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonSave
            // 
            ButtonSave.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSave.IconColor = Color.Black;
            ButtonSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSave.Location = new Point(1032, 3);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(94, 29);
            ButtonSave.TabIndex = 0;
            ButtonSave.Text = "iconButton1";
            ButtonSave.UseVisualStyleBackColor = true;
            // 
            // PopupPurchaseOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Name = "PopupPurchaseOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PopupPurchaseOrder";
            Load += PopupPurchaseOrder_Load;
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FontAwesome.Sharp.IconButton ButtonCancel;
        private FontAwesome.Sharp.IconButton ButtonSave;
    }
}