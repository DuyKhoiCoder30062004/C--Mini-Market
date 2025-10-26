namespace MiniStore.Modules.OrderManager.UI
{
    partial class OrderFilter
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
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            LabelFilter = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            LableDatePick = new Label();
            groupBox1 = new GroupBox();
            RadioButtonDecre = new RadioButton();
            RadioButtonIncre = new RadioButton();
            ButtonFilter = new FontAwesome.Sharp.IconButton();
            ButtonRefresh = new FontAwesome.Sharp.IconButton();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // LabelFilter
            // 
            LabelFilter.AutoSize = true;
            LabelFilter.Location = new Point(3, 17);
            LabelFilter.Name = "LabelFilter";
            LabelFilter.Size = new Size(50, 20);
            LabelFilter.TabIndex = 0;
            LabelFilter.Text = "label1";
            LabelFilter.Click += LabelFilter_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Location = new Point(115, 14);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(132, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(308, 14);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(140, 27);
            dateTimePicker2.TabIndex = 3;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // LableDatePick
            // 
            LableDatePick.AutoSize = true;
            LableDatePick.Location = new Point(253, 17);
            LableDatePick.Name = "LableDatePick";
            LableDatePick.Size = new Size(50, 20);
            LableDatePick.TabIndex = 4;
            LableDatePick.Text = "label1";
            LableDatePick.Click += LableDatePick_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(RadioButtonDecre);
            groupBox1.Controls.Add(RadioButtonIncre);
            groupBox1.Location = new Point(460, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 48);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
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
            // ButtonFilter
            // 
            ButtonFilter.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonFilter.IconColor = Color.Black;
            ButtonFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonFilter.Location = new Point(900, 13);
            ButtonFilter.Name = "ButtonFilter";
            ButtonFilter.RightToLeft = RightToLeft.Yes;
            ButtonFilter.Size = new Size(138, 29);
            ButtonFilter.TabIndex = 6;
            ButtonFilter.Text = "iconButton1";
            ButtonFilter.UseVisualStyleBackColor = true;
            ButtonFilter.Click += ButtonFilter_Click;
            // 
            // ButtonRefresh
            // 
            ButtonRefresh.IconChar = FontAwesome.Sharp.IconChar.None;
            ButtonRefresh.IconColor = Color.Black;
            ButtonRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ButtonRefresh.Location = new Point(1056, 13);
            ButtonRefresh.Name = "ButtonRefresh";
            ButtonRefresh.Size = new Size(94, 29);
            ButtonRefresh.TabIndex = 7;
            ButtonRefresh.Text = "iconButton1";
            ButtonRefresh.UseVisualStyleBackColor = true;
            ButtonRefresh.Click += ButtonRefresh_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(738, 13);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(141, 28);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // OrderFilter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(comboBox1);
            Controls.Add(ButtonRefresh);
            Controls.Add(ButtonFilter);
            Controls.Add(groupBox1);
            Controls.Add(LableDatePick);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(LabelFilter);
            Name = "OrderFilter";
            Size = new Size(1210, 60);
            Load += OrderFilter_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private Label LabelFilter;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label LableDatePick;
        private GroupBox groupBox1;
        private RadioButton RadioButtonDecre;
        private RadioButton RadioButtonIncre;
        private FontAwesome.Sharp.IconButton ButtonFilter;
        private FontAwesome.Sharp.IconButton ButtonRefresh;
        private ComboBox comboBox1;
    }
}
