using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using static homework_writer.Form1;



namespace homework_writer
{
    public partial class Form1 : Form
    {
        // Класс для хранения словарей с данными
        public class HomeworkData
        {
            // Словарь со всеми невыполненными дз
            public Dictionary<DateTime, List<string>> Tasks { get; set; } = new Dictionary<DateTime, List<string>>();

            // Словарь со всеми выполненными дз
            public Dictionary<DateTime, List<string>> CompletedTasks { get; set; } = new Dictionary<DateTime, List<string>>();
        }

        // Создаём объект класса HomeworkData
        private HomeworkData homeworkByDate = new HomeworkData();
        // Берём за константу переменную, храняющую имя файла
        private const string DataFile = "homework_data.json";


        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы
            LoadData(); // Сразу загружаем данные после создания формы
        }

        // Загрузка данных из json
        private void LoadData()
        {
            if (File.Exists(DataFile))
            {
                try
                {
                    string json = File.ReadAllText(DataFile);
                    // десириализуем из строки в объект, для дальнейшей работы
                    homeworkByDate = JsonSerializer.Deserialize<HomeworkData>(json);

                    // Обновляем выделенные даты (на которые есть дз) в календаре
                    foreach (var date in homeworkByDate.Tasks.Keys)
                    {
                        monthCalendar1.AddBoldedDate(date);
                    }
                    monthCalendar1.UpdateBoldedDates();
                }
                catch (Exception ex)
                {
                    // Если файл не найден, выводит эту ошибку
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Сохранение данных в JSON
        private void SaveData()
        {
            try
            {
                // Переменная настроек сериализации
                var options = new JsonSerializerOptions { WriteIndented = true }; // красивый вывод json с отступами и переносами строк
                // Сериализация объекта в json. (преобразуем словарь в строку)
                string json = JsonSerializer.Serialize(homeworkByDate, options);
                // Записываем данные в json файл
                File.WriteAllText(DataFile, json);
            }
            catch (Exception ex)
            {
                // Если происходит ошибка записи данных, показывается данная ошибка:
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для скрытия режима редактирования
        private void editMode_OFF()
        {
            textBox3.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            comboBox2.Visible = false;
            label7.Visible = false;
        }

        // Метод для показа режима редактирования
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

        // кнопка добавления дз
        private void button1_Click(object sender, EventArgs e)
        {

            // Проверка заполнения всех полей
            if (dateTimePicker1.Text != "" && textBox2.Text != "" && textBox1.Text != "" && comboBox1.Text != "")
            {
                // Записываем выбранную дату в переменную selectedDate
                DateTime selectedDate = dateTimePicker1.Value.Date;
                // Переменная, содержащая в себе всё домашнее задание
                string homeworkEntry = $"{textBox2.Text}: {textBox1.Text} ({comboBox1.Text})";

                // Если даты ещё нет в словаре, выполняем действия ниже
                // (Это нужно для того, чтобы для первого, добавленного на эту дату дз создавался список,
                // в который будут записываться возможные новые дз)
                if (!homeworkByDate.Tasks.ContainsKey(selectedDate))
                {
                    // Создаём список на выбранную дату
                    homeworkByDate.Tasks[selectedDate] = new List<string>();
                    // Выделяем дату, на которую теперь добавлено введённое пользователем домашнее задание
                    monthCalendar1.AddBoldedDate(selectedDate);
                    // Перерисовывает (обновляет) выделенные даты в календаре
                    monthCalendar1.UpdateBoldedDates();
                }

                // Добавляет дз на выбранную ключ дату в словаре
                homeworkByDate.Tasks[selectedDate].Add(homeworkEntry);
                // Сразу сохраняет данные в json файл для работы в реальном времени
                SaveData();

                MessageBox.Show("Домашнее задание добавлено");
                // Очищение полей после добавления дз
                textBox2.Clear();
                textBox1.Clear();

                // Обновляем отображение для текущей даты (если она совпадает с выбранной)
                if (monthCalendar1.SelectionStart.Date == selectedDate)
                {
                    UpdateHomeworkListForDate(selectedDate);
                }
            }
            else
            {
                MessageBox.Show("Вы заполнили не все поля", "Незаполненные поля", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Метод для того, чтобы на выбранную дату корректно отображались домашние задания
        private void UpdateHomeworkListForDate(DateTime date)
        {
            // Очищает все записанны в listbox дз, чтобы не 
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            if (homeworkByDate.Tasks.ContainsKey(date))
            {
                // Записываем в listbox дз в виде списка
                listBox1.Items.AddRange(homeworkByDate.Tasks[date].ToArray());
            }
            else
            {
                // Иначе в listbox выводится надпись о том, что дз нет
                listBox1.Items.Add("На эту дату нет домашнего задания");
            }

            if (homeworkByDate.CompletedTasks.ContainsKey(date))
            {
                // Добавляем в listbox2 выполненные дз в виде списка
                listBox2.Items.AddRange(homeworkByDate.CompletedTasks[date].ToArray());
            }
        }

        // Обработчик закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Сохраняем всё при закрытии
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
            // Метод, для того, чтобы при выборе другой даты сворачивался режим редактирования дз
            editMode_OFF();
            // Каждый раз при нажатии на новую дату, у нас будет вызываться метод для корректного отображения дз,
            // записанного на выбранную дату
            UpdateHomeworkListForDate(monthCalendar1.SelectionStart.Date);
            // Для удобства пользователя меняем значение dateTimePicker1 в зависимости от выбранного в monthCalendar1
            dateTimePicker1.Value = monthCalendar1.SelectionStart;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Метод кнопки, при нажатии на которую выбранное дз перемещается в список выполненных дз
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Переменная, содержащая выьбранную дату
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            // Переменная, содержащая индекс выбранного дз в listbox1
            int selected_index = listBox1.SelectedIndex;

            // Проверяет, выбрал ли пользователь именно дз
            if (selected_index != -1 && listBox1.Text != "На эту дату нет домашнего задания")
            {
                // Выбираем, какое именно дз было помечено выполненным
                string completedHomework = homeworkByDate.Tasks[selectedDate][selected_index];

                // Если в словаре выполненных дз нету ключа с выбранной датой
                if (!homeworkByDate.CompletedTasks.ContainsKey(selectedDate))
                {
                    // Создаётся список под выполненные дз
                    homeworkByDate.CompletedTasks[selectedDate] = new List<string>();
                }
                // Запись выполненного дз в словарь
                homeworkByDate.CompletedTasks[selectedDate].Add(completedHomework);
                // Запись выполненного дз в listBox2
                listBox2.Items.Add(completedHomework);

                // Удаляем из списка незавершённых дз только что выполлненное дз
                homeworkByDate.Tasks[selectedDate].RemoveAt(selected_index);

                // Если это было последнее задание на эту дату
                if (homeworkByDate.Tasks[selectedDate].Count == 0)
                {
                    // Добавляем обратно надпись, что на эту дату нет домашних заданий
                    listBox1.Items.Add("На эту дату нет домашнего задания");
                    // Удаляем со словаря ключ-дату
                    homeworkByDate.Tasks.Remove(selectedDate);
                    // Убираем выделение даты, так как дз на эту дату больше ни одного нету
                    monthCalendar1.RemoveBoldedDate(selectedDate);
                    // Обновляем календарь
                    monthCalendar1.UpdateBoldedDates();
                }

                // Обновляем listBox1, удаляя выполненное дз
                listBox1.Items.RemoveAt(selected_index);

                // Обновляем дз на выбранную дату
                UpdateHomeworkListForDate(selectedDate);

                // Сохраняем изменения
                SaveData();
            }
            else
            {
                // Если пользователь не выделил дз, на экран выводится данная ошибка
                MessageBox.Show("Выделите нужное домашнее задание для его выполнения!", "нет выделенного дз", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Убираем режим редактирования, если он был включен
            editMode_OFF();
        }

        // Метод кнопки редактирования дз
        private void button3_Click(object sender, EventArgs e)
        {
            // Записываем в переменную выбранную дату
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            // Записываем в переменную индекс выделенного дз из списка дз (listbox1)
            int selected_index = listBox1.SelectedIndex;

            // Если выбранное дз, содержит в себе записанное дз
            if (selected_index != -1 && listBox1.Text != "На эту дату нет домашнего задания")
            {
                // Сплитуем дз, по определённым символам, чтобы разбить его на 3 части (1: педмет, 2: само дз, 3: приоритет)
                string[] subject = homeworkByDate.Tasks[selectedDate][selected_index].Split(new char[] { ':' });
                string[] homeworkText = homeworkByDate.Tasks[selectedDate][selected_index].Split(new char[] { '(', ':' });

                // Включаем режим редактирования
                editMode_ON();
                // Записываем в каждый textbox выбранное дз (textBox3: предмет, textBox4: само дз, comboBox2: приоритет)
                textBox3.Text = subject[0];
                textBox4.Text = homeworkText[1];
                comboBox2.Text = homeworkText[2];

            }
            else
            {
                // Если пользователь не выбрал дз на редактирование, на экране появится данная ошибка:
                MessageBox.Show("Выделите нужное домашнее задание для редактирования!", "нет выделенного дз", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Метод кнопки, которая добавляет отредактированное дз
        private void button4_Click(object sender, EventArgs e)
        {
            // Записываем в переменные выделенную дату и индекс выделенного дз
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            int selected_index = listBox1.SelectedIndex;

            // Создаём переменную, которая содержит в себе отредактированное дз
            string edited_text = $"{textBox3.Text}: {textBox4.Text} ({comboBox2.Text})";

            // Записываем отредактированное дз в словарь
            homeworkByDate.Tasks[selectedDate][selected_index] = edited_text;
            // Записываем отредактированное дз в listBox1
            listBox1.Items[selected_index] = edited_text;

            // Вызываем метод для сохранения данных в json 
            SaveData();

            // Отображаем окно, сообщающее об успешном редактировании дз
            MessageBox.Show("Домашнее задание отредактированно!");

            // Сворачиваем режим редактирования
            editMode_OFF();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Создаём переменные, содержащие выбранную дату в календаре и выбранный индекс дз из listbox1
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            int selectedIndex = listBox1.SelectedIndex;

            // Проверяем, что задание выбрано и это не сообщение "Нет ДЗ"
            if (selectedIndex != -1 && listBox1.Items[selectedIndex].ToString() != "На эту дату нет домашнего задания")
            {
                // Удаляем элемент с указанным индексом из словаря
                homeworkByDate.Tasks[selectedDate].RemoveAt(selectedIndex);

                // Удаляем из listBox1 (списка дз)
                listBox1.Items.RemoveAt(selectedIndex);

                // Если это было последнее задание на дату
                if (homeworkByDate.Tasks[selectedDate].Count == 0)
                {
                    // Удаляем из словаря все дз на выбранную дату
                    homeworkByDate.Tasks.Remove(selectedDate);
                    // Отменяем выдыление у даты в календаре, так как на неё больше нету никаких дз
                    monthCalendar1.RemoveBoldedDate(selectedDate);
                    // Обновляем календарь
                    monthCalendar1.UpdateBoldedDates();
                    // Выводим надпись в listBox1 о том, что больше нет домашних заданий
                    listBox1.Items.Add("На эту дату нет домашнего задания");
                    // Сохраняем данные в json
                    SaveData();
                }

                // Отображаем сообщение об успешном удалении дз
                MessageBox.Show("Домашнее задание удалено!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Убираем режим редактирования (если он был включен)
                editMode_OFF();
            }
            else
            {
                // Если пользователь не выбрал нужного дз для удаления, отображается данная ошибка: 
                MessageBox.Show("Выберите задание для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
