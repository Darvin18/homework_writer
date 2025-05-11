using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using static homework_writer.Form1;



namespace homework_writer
{
    public partial class Form1 : Form
    {
        // ����� ��� �������� �������� � �������
        public class HomeworkData
        {
            // ������� �� ����� �������������� ��
            public Dictionary<DateTime, List<string>> Tasks { get; set; } = new Dictionary<DateTime, List<string>>();

            // ������� �� ����� ������������ ��
            public Dictionary<DateTime, List<string>> CompletedTasks { get; set; } = new Dictionary<DateTime, List<string>>();
        }

        // ������ ������ ������ HomeworkData
        private HomeworkData homeworkByDate = new HomeworkData();
        // ���� �� ��������� ����������, ��������� ��� �����
        private const string DataFile = "homework_data.json";


        public Form1()
        {
            InitializeComponent(); // ������������� ����������� �����
            LoadData(); // ����� ��������� ������ ����� �������� �����
        }

        // �������� ������ �� json
        private void LoadData()
        {
            if (File.Exists(DataFile))
            {
                try
                {
                    string json = File.ReadAllText(DataFile);
                    // ������������� �� ������ � ������, ��� ���������� ������
                    homeworkByDate = JsonSerializer.Deserialize<HomeworkData>(json);

                    // ��������� ���������� ���� (�� ������� ���� ��) � ���������
                    foreach (var date in homeworkByDate.Tasks.Keys)
                    {
                        monthCalendar1.AddBoldedDate(date);
                    }
                    monthCalendar1.UpdateBoldedDates();
                }
                catch (Exception ex)
                {
                    // ���� ���� �� ������, ������� ��� ������
                    MessageBox.Show($"������ �������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ���������� ������ � JSON
        private void SaveData()
        {
            try
            {
                // ���������� �������� ������������
                var options = new JsonSerializerOptions { WriteIndented = true }; // �������� ����� json � ��������� � ���������� �����
                // ������������ ������� � json. (����������� ������� � ������)
                string json = JsonSerializer.Serialize(homeworkByDate, options);
                // ���������� ������ � json ����
                File.WriteAllText(DataFile, json);
            }
            catch (Exception ex)
            {
                // ���� ���������� ������ ������ ������, ������������ ������ ������:
                MessageBox.Show($"������ ���������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ����� ��� ������� ������ ��������������
        private void editMode_OFF()
        {
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            comboBox2.Visible = false;
            label7.Visible = false;
        }

        // ����� ��� ������ ������ ��������������
        private void editMode_ON()
        {
            textBox3.Visible = true;
            textBox4.Visible = true;
            button4.Visible = true;
            comboBox2.Visible = true;
            label7.Visible = true;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // ������ ���������� ��
        private void button1_Click(object sender, EventArgs e)
        {

            // �������� ���������� ���� �����
            if (dateTimePicker1.Text != "" && textBox2.Text != "" && textBox1.Text != "" && comboBox1.Text != "")
            {
                // ���������� ��������� ���� � ���������� selectedDate
                DateTime selectedDate = dateTimePicker1.Value.Date;
                // ����������, ���������� � ���� �� �������� �������
                string homeworkEntry = $"{textBox2.Text}: {textBox1.Text} ({comboBox1.Text})";

                // ���� ���� ��� ��� � �������, ��������� �������� ����
                // (��� ����� ��� ����, ����� ��� �������, ������������ �� ��� ���� �� ���������� ������,
                // � ������� ����� ������������ ��������� ����� ��)
                if (!homeworkByDate.Tasks.ContainsKey(selectedDate))
                {
                    // ������ ������ �� ��������� ����
                    homeworkByDate.Tasks[selectedDate] = new List<string>();
                    // �������� ����, �� ������� ������ ��������� �������� ������������� �������� �������
                    monthCalendar1.AddBoldedDate(selectedDate);
                    // �������������� (���������) ���������� ���� � ���������
                    monthCalendar1.UpdateBoldedDates();
                }

                // ��������� �� �� ��������� ���� ���� � �������
                homeworkByDate.Tasks[selectedDate].Add(homeworkEntry);
                // ����� ��������� ������ � json ���� ��� ������ � �������� �������
                SaveData();

                MessageBox.Show("�������� ������� ���������");
                // �������� ����� ����� ���������� ��
                textBox2.Clear();
                textBox1.Clear();

                // ��������� ����������� ��� ������� ���� (���� ��� ��������� � ���������)
                if (monthCalendar1.SelectionStart.Date == selectedDate)
                {
                    UpdateHomeworkListForDate(selectedDate);
                }
            }
            else
            {
                MessageBox.Show("�� ��������� �� ��� ����", "������������� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // ����� ��� ����, ����� �� ��������� ���� ��������� ������������ �������� �������
        private void UpdateHomeworkListForDate(DateTime date)
        {
            // ������� ��� ��������� � listbox ��, ����� �� 
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            if (homeworkByDate.Tasks.ContainsKey(date))
            {
                // ���������� � listbox �� � ���� ������
                listBox1.Items.AddRange(homeworkByDate.Tasks[date].ToArray());
            }
            else
            {
                // ����� � listbox ��������� ������� � ���, ��� �� ���
                listBox1.Items.Add("�� ��� ���� ��� ��������� �������");
            }

            if (homeworkByDate.CompletedTasks.ContainsKey(date))
            {
                // ��������� � listbox2 ����������� �� � ���� ������
                listBox2.Items.AddRange(homeworkByDate.CompletedTasks[date].ToArray());
            }
        }

        // ���������� �������� �����
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��������� �� ��� ��������
            SaveData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // �����, ��� ����, ����� ��� ������ ������ ���� ������������ ����� �������������� ��
            editMode_OFF();
            // ������ ��� ��� ������� �� ����� ����, � ��� ����� ���������� ����� ��� ����������� ����������� ��,
            // ����������� �� ��������� ����
            UpdateHomeworkListForDate(monthCalendar1.SelectionStart.Date);
            // ��� �������� ������������ ������ �������� dateTimePicker1 � ����������� �� ���������� � monthCalendar1
            dateTimePicker1.Value = monthCalendar1.SelectionStart;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ����� ������, ��� ������� �� ������� ��������� �� ������������ � ������ ����������� ��
        private void button2_Click_1(object sender, EventArgs e)
        {
            // ����������, ���������� ���������� ����
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            // ����������, ���������� ������ ���������� �� � listbox1
            int selected_index = listBox1.SelectedIndex;

            // ���������, ������ �� ������������ ������ ��
            if (selected_index != -1 && listBox1.Text != "�� ��� ���� ��� ��������� �������")
            {
                // ��������, ����� ������ �� ���� �������� �����������
                string completedHomework = homeworkByDate.Tasks[selectedDate][selected_index];

                // ���� � ������� ����������� �� ���� ����� � ��������� �����
                if (!homeworkByDate.CompletedTasks.ContainsKey(selectedDate))
                {
                    // �������� ������ ��� ����������� ��
                    homeworkByDate.CompletedTasks[selectedDate] = new List<string>();
                }
                // ������ ������������ �� � �������
                homeworkByDate.CompletedTasks[selectedDate].Add(completedHomework);
                // ������ ������������ �� � listBox2
                listBox2.Items.Add(completedHomework);

                // ������� �� ������ ������������� �� ������ ��� ������������ ��
                homeworkByDate.Tasks[selectedDate].RemoveAt(selected_index);

                // ���� ��� ���� ��������� ������� �� ��� ����
                if (homeworkByDate.Tasks[selectedDate].Count == 0)
                {
                    // ��������� ������� �������, ��� �� ��� ���� ��� �������� �������
                    listBox1.Items.Add("�� ��� ���� ��� ��������� �������");
                    // ������� �� ������� ����-����
                    homeworkByDate.Tasks.Remove(selectedDate);
                    // ������� ��������� ����, ��� ��� �� �� ��� ���� ������ �� ������ ����
                    monthCalendar1.RemoveBoldedDate(selectedDate);
                    // ��������� ���������
                    monthCalendar1.UpdateBoldedDates();
                }

                // ��������� listBox1, ������ ����������� ��
                listBox1.Items.RemoveAt(selected_index);

                // ��������� �� �� ��������� ����
                UpdateHomeworkListForDate(selectedDate);

                // ��������� ���������
                SaveData();
            }
            else
            {
                // ���� ������������ �� ������� ��, �� ����� ��������� ������ ������
                MessageBox.Show("�������� ������ �������� ������� ��� ��� ����������!", "��� ����������� ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // ������� ����� ��������������, ���� �� ��� �������
            editMode_OFF();
        }

        // ����� ������ �������������� ��
        private void button3_Click(object sender, EventArgs e)
        {
            // ���������� � ���������� ��������� ����
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            // ���������� � ���������� ������ ����������� �� �� ������ �� (listbox1)
            int selected_index = listBox1.SelectedIndex;

            // ���� ��������� ��, �������� � ���� ���������� ��
            if (selected_index != -1 && listBox1.Text != "�� ��� ���� ��� ��������� �������")
            {
                // �������� ��, �� ����������� ��������, ����� ������� ��� �� 3 ����� (1: ������, 2: ���� ��, 3: ���������)
                string[] subject = homeworkByDate.Tasks[selectedDate][selected_index].Split(new char[] { ':' });
                string[] homeworkText = homeworkByDate.Tasks[selectedDate][selected_index].Split(new char[] { '(', ':' });

                // �������� ����� ��������������
                editMode_ON();
                // ���������� � ������ textbox ��������� �� (textBox3: �������, textBox4: ���� ��, comboBox2: ���������)
                textBox3.Text = subject[0];
                textBox4.Text = homeworkText[1];
                comboBox2.Text = homeworkText[2];

            }
            else
            {
                // ���� ������������ �� ������ �� �� ��������������, �� ������ �������� ������ ������:
                MessageBox.Show("�������� ������ �������� ������� ��� ��������������!", "��� ����������� ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        // ����� ������, ������� ��������� ����������������� ��
        private void button4_Click(object sender, EventArgs e)
        {
            // ���������� � ���������� ���������� ���� � ������ ����������� ��
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            int selected_index = listBox1.SelectedIndex;

            // ������ ����������, ������� �������� � ���� ����������������� ��
            string edited_text = $"{textBox3.Text}: {textBox4.Text} ({comboBox2.Text})";

            // ���������� ����������������� �� � �������
            homeworkByDate.Tasks[selectedDate][selected_index] = edited_text;
            // ���������� ����������������� �� � listBox1
            listBox1.Items[selected_index] = edited_text;

            // �������� ����� ��� ���������� ������ � json 
            SaveData();

            // ���������� ����, ���������� �� �������� �������������� ��
            MessageBox.Show("�������� ������� ����������������!");

            // ����������� ����� ��������������
            editMode_OFF();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // ������ ����������, ���������� ��������� ���� � ��������� � ��������� ������ �� �� listbox1
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            int selectedIndex = listBox1.SelectedIndex;

            // ���������, ��� ������� ������� � ��� �� ��������� "��� ��"
            if (selectedIndex != -1 && listBox1.Items[selectedIndex].ToString() != "�� ��� ���� ��� ��������� �������")
            {
                // ������� ������� � ��������� �������� �� �������
                homeworkByDate.Tasks[selectedDate].RemoveAt(selectedIndex);

                // ������� �� listBox1 (������ ��)
                listBox1.Items.RemoveAt(selectedIndex);

                // ���� ��� ���� ��������� ������� �� ����
                if (homeworkByDate.Tasks[selectedDate].Count == 0)
                {
                    // ������� �� ������� ��� �� �� ��������� ����
                    homeworkByDate.Tasks.Remove(selectedDate);
                    // �������� ��������� � ���� � ���������, ��� ��� �� �� ������ ���� ������� ��
                    monthCalendar1.RemoveBoldedDate(selectedDate);
                    // ��������� ���������
                    monthCalendar1.UpdateBoldedDates();
                    // ������� ������� � listBox1 � ���, ��� ������ ��� �������� �������
                    listBox1.Items.Add("�� ��� ���� ��� ��������� �������");
                    // ��������� ������ � json
                    SaveData();
                }

                // ���������� ��������� �� �������� �������� ��
                MessageBox.Show("�������� ������� �������!", "��������", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ������� ����� �������������� (���� �� ��� �������)
                editMode_OFF();
            }
            else
            {
                // ���� ������������ �� ������ ������� �� ��� ��������, ������������ ������ ������: 
                MessageBox.Show("�������� ������� ��� ��������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
