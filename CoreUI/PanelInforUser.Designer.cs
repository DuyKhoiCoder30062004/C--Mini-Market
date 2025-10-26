namespace MiniStore.CoreUI
{
    partial class PanelInforUser
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
            pictureBox1 = new PictureBox();
            LableName = new Label();
            LabelName = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(19, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LableName
            // 
            LableName.AutoSize = true;
            LableName.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LableName.ForeColor = SystemColors.ControlDarkDark;
            LableName.Location = new Point(105, 12);
            LableName.Name = "LableName";
            LableName.Size = new Size(162, 25);
            LableName.TabIndex = 1;
            LableName.Text = "Nhân viên quản lý";
            LableName.Click += label1_Click;
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelName.Location = new Point(105, 46);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(140, 28);
            LabelName.TabIndex = 2;
            LabelName.Text = "Nguyen Van a";
            // 
            // PanelInforUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LabelName);
            Controls.Add(LableName);
            Controls.Add(pictureBox1);
            Name = "PanelInforUser";
            Size = new Size(280, 100);
            Load += PanelInforUser_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        public Label LableName;
        private Label LabelName;
    }
}
