namespace homework_writer
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
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            monthCalendar1 = new MonthCalendar();
            listBox1 = new ListBox();
            button3 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button4 = new Button();
            comboBox2 = new ComboBox();
            button5 = new Button();
            listBox2 = new ListBox();
            label6 = new Label();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15F);
            label1.ForeColor = Color.CornflowerBlue;
            label1.Location = new Point(125, 23);
            label1.Name = "label1";
            label1.Size = new Size(281, 23);
            label1.TabIndex = 1;
            label1.Text = "Записать домашнее задание:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(34, 106);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(231, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 13F);
            label2.Location = new Point(102, 77);
            label2.Name = "label2";
            label2.Size = new Size(55, 21);
            label2.TabIndex = 3;
            label2.Text = "Дата:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 13F);
            label3.Location = new Point(188, 147);
            label3.Name = "label3";
            label3.Size = new Size(177, 21);
            label3.TabIndex = 4;
            label3.Text = "Домашнее задание:";
            label3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 11F);
            textBox1.Location = new Point(102, 177);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(368, 62);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "🚩 Приоритет 1", "🚩 Приоритет 2", "🚩 Приоритет 3" });
            comboBox1.Location = new Point(102, 243);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(185, 23);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "🚩 Приоритет 1";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 13F);
            label5.Location = new Point(371, 77);
            label5.Name = "label5";
            label5.Size = new Size(93, 21);
            label5.TabIndex = 8;
            label5.Text = "Предмет: ";
            label5.Click += label5_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Location = new Point(315, 103);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(213, 27);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Chartreuse;
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(300, 243);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(170, 45);
            button1.TabIndex = 10;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(2, 1);
            monthCalendar1.Location = new Point(599, 77);
            monthCalendar1.Margin = new Padding(8, 7, 8, 7);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 11;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 10F);
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(599, 266);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(512, 123);
            listBox1.TabIndex = 12;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveBorder;
            button3.Location = new Point(726, 394);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(121, 32);
            button3.TabIndex = 15;
            button3.Text = "Редактировать ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(726, 454);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(181, 23);
            textBox3.TabIndex = 16;
            textBox3.Visible = false;
            textBox3.TextChanged += textBox3_TextChanged_1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(726, 503);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(301, 62);
            textBox4.TabIndex = 17;
            textBox4.Visible = false;
            textBox4.TextChanged += textBox4_TextChanged_1;
            // 
            // button4
            // 
            button4.Location = new Point(882, 575);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(144, 39);
            button4.TabIndex = 18;
            button4.Text = "Добавить";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "🚩 Приоритет 1", "🚩 Приоритет 2", "🚩 Приоритет 3" });
            comboBox2.Location = new Point(726, 575);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 23);
            comboBox2.TabIndex = 19;
            comboBox2.Text = "🚩 Приоритет 1";
            comboBox2.Visible = false;
            // 
            // button5
            // 
            button5.BackColor = Color.OrangeRed;
            button5.Location = new Point(864, 394);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(124, 32);
            button5.TabIndex = 20;
            button5.Text = "Удалить";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.HorizontalScrollbar = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(34, 500);
            listBox2.Margin = new Padding(3, 2, 3, 2);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(436, 109);
            listBox2.TabIndex = 21;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(34, 474);
            label6.Name = "label6";
            label6.Size = new Size(153, 25);
            label6.TabIndex = 22;
            label6.Text = "Выполненные дз:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(599, 239);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 23;
            label4.Text = "Список дз:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(726, 434);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 24;
            label7.Text = "Предмет:";
            label7.Visible = false;
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(726, 484);
            label8.Name = "label8";
            label8.Size = new Size(116, 15);
            label8.TabIndex = 25;
            label8.Text = "Домашнее задание:";
            label8.Visible = false;
            label8.Click += label8_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.PaleGreen;
            button2.Location = new Point(599, 394);
            button2.Name = "button2";
            button2.Size = new Size(109, 32);
            button2.TabIndex = 26;
            button2.Text = "Выполнить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 634);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(listBox2);
            Controls.Add(button5);
            Controls.Add(comboBox2);
            Controls.Add(button4);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(listBox1);
            Controls.Add(monthCalendar1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label5;
        private TextBox textBox2;
        private Button button1;
        private MonthCalendar monthCalendar1;
        private ListBox listBox1;
        private Button button3;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button4;
        private ComboBox comboBox2;
        private Button button5;
        private ListBox listBox2;
        private Label label6;
        private Label label4;
        private Label label7;
        private Label label8;
        private Button button2;
    }
}
