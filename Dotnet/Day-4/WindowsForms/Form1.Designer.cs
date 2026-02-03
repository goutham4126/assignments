namespace WindowsForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(369, 549);
            button1.Name = "button1";
            button1.Size = new Size(418, 71);
            button1.TabIndex = 0;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(478, 152);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(414, 39);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(290, 152);
            label1.Name = "label1";
            label1.Size = new Size(155, 32);
            label1.TabIndex = 2;
            label1.Text = "Person name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(290, 249);
            label2.Name = "label2";
            label2.Size = new Size(151, 32);
            label2.TabIndex = 3;
            label2.Text = "Father name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(478, 249);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(414, 39);
            textBox2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(478, 345);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(414, 39);
            dateTimePicker1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(290, 350);
            label3.Name = "label3";
            label3.Size = new Size(146, 32);
            label3.TabIndex = 6;
            label3.Text = "DateOfBirth";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Investments", "Banking", "Finance" });
            comboBox1.Location = new Point(478, 444);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(414, 40);
            comboBox1.TabIndex = 7;
            comboBox1.Text = "Investments";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(290, 447);
            label4.Name = "label4";
            label4.Size = new Size(141, 32);
            label4.TabIndex = 8;
            label4.Text = "Preferences";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1180, 793);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Red;
            Name = "Form1";
            Text = "Person Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
    }
}
