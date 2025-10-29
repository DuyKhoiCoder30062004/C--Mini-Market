namespace MiniStore.Modules.SupplierManager.UI
{
    partial class SupplierFilter
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
            comboBox1 = new ComboBox();
            ButtonRefresh = new FontAwesome.Sharp.IconButton();
            ButtonFilter = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            RadioButtonDecre = new RadioButton();
            RadioButtonIncre = new RadioButton();
            LableDatePick = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            LabelFilter = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(745, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(141, 28);
            comboBox1.TabIndex = 16;
            // 
            // ButtonRefresh
            // 
            ButtonRefresh.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonRefresh.IconColor = Color.Black;
            ButtonRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonRefresh.Location = new Point(1055, 16);
            ButtonRefresh.Name = "ButtonRefresh";
            ButtonRefresh.Size = new Size(94, 29);
            ButtonRefresh.TabIndex = 15;
            ButtonRefresh.Text = "iconButton1";
            ButtonRefresh.UseVisualStyleBackColor = true;
            // 
            // ButtonFilter
            // 
            ButtonFilter.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonFilter.IconColor = Color.Black;
            ButtonFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonFilter.Location = new Point(900, 16);
            ButtonFilter.Name = "ButtonFilter";
            ButtonFilter.RightToLeft = RightToLeft.Yes;
            ButtonFilter.Size = new Size(138, 29);
            ButtonFilter.TabIndex = 14;
            ButtonFilter.Text = "iconButton1";
            ButtonFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(RadioButtonDecre);
            groupBox1.Controls.Add(RadioButtonIncre);
            groupBox1.Location = new Point(466, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 48);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // RadioButtonDecre
            // 
            RadioButtonDecre.AutoSize = true;
            RadioButtonDecre.Location = new Point(129, 15);
            RadioButtonDecre.Name = "RadioButtonDecre";
            RadioButtonDecre.Size = new Size(117, 24);
            RadioButtonDecre.TabIndex = 1;
            RadioButtonDecre.TabStop = true;
            RadioButtonDecre.Text = "radioButton2";
            RadioButtonDecre.UseVisualStyleBackColor = true;
            // 
            // RadioButtonIncre
            // 
            RadioButtonIncre.AutoSize = true;
            RadioButtonIncre.Location = new Point(0, 15);
            RadioButtonIncre.Name = "RadioButtonIncre";
            RadioButtonIncre.Size = new Size(117, 24);
            RadioButtonIncre.TabIndex = 0;
            RadioButtonIncre.TabStop = true;
            RadioButtonIncre.Text = "radioButton1";
            RadioButtonIncre.UseVisualStyleBackColor = true;
            // 
            // LableDatePick
            // 
            LableDatePick.AutoSize = true;
            LableDatePick.Location = new Point(265, 20);
            LableDatePick.Name = "LableDatePick";
            LableDatePick.Size = new Size(50, 20);
            LableDatePick.TabIndex = 12;
            LableDatePick.Text = "label1";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(317, 17);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(140, 27);
            dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Location = new Point(124, 17);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(132, 27);
            dateTimePicker1.TabIndex = 10;
            // 
            // LabelFilter
            // 
            LabelFilter.AutoSize = true;
            LabelFilter.Location = new Point(5, 20);
            LabelFilter.Name = "LabelFilter";
            LabelFilter.Size = new Size(50, 20);
            LabelFilter.TabIndex = 9;
            LabelFilter.Text = "label1";
            // 
            // SupplierFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox1);
            Controls.Add(ButtonRefresh);
            Controls.Add(ButtonFilter);
            Controls.Add(groupBox1);
            Controls.Add(LableDatePick);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(LabelFilter);
            Name = "SupplierFilter";
            Size = new Size(1210, 60);
            Load += SupplierFilter_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private FontAwesome.Sharp.IconButton ButtonRefresh;
        private FontAwesome.Sharp.IconButton ButtonFilter;
        private GroupBox groupBox1;
        private RadioButton RadioButtonDecre;
        private RadioButton RadioButtonIncre;
        private Label LableDatePick;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label LabelFilter;
    }
}
