namespace MiniStore.Modules.PurchaseOrder.UI
{
    partial class PopupAction
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
            ButtonCancel = new FontAwesome.Sharp.IconButton();
            ButtonSave = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // ButtonCancel
            // 
            ButtonCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonCancel.IconColor = Color.Black;
            ButtonCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonCancel.Location = new Point(30, 13);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(94, 29);
            ButtonCancel.TabIndex = 0;
            ButtonCancel.Text = "iconButton1";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += iconButton1_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonSave.IconColor = Color.Black;
            ButtonSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonSave.Location = new Point(168, 13);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(94, 29);
            ButtonSave.TabIndex = 1;
            ButtonSave.Text = "iconButton2";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += this.iconButton2_Click;
            // 
            // PopupAction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonSave);
            Controls.Add(ButtonCancel);
            Name = "PopupAction";
            Size = new Size(1200, 60);
            Load += PopupHeader_Load;
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton ButtonCancel;
        private FontAwesome.Sharp.IconButton ButtonSave;
    }
}
