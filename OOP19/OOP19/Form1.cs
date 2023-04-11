using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace OOP19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "OK";
            button3.Text = "OK";
            button2.Text = "Cancel";
            button4.Text = "Delete word";
            textBox2.Enabled = false;
            button3.Visible = false;
            label1.Text = "";
            label2.Text = "";
            button4.Enabled = false;
            label3.Text = "";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox1.Enabled = false;
            string input = textBox1.Text;
            // Розбиваємо рядок на масив слів
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //З'єднуємо масив слів і між ними ставимо кому
            string output1 = string.Join(", ", words);
            // Виводимо результат у елемент label1
            label1.Text = output1;
            button1.Visible = false;
            button3.Visible = true;
            button4.Enabled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ' '))
            {
                // крапку замінемо проб
                e.KeyChar = ' ';
                return;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Enabled = false;
            textBox1.Enabled = true;
            button3.Visible = false;
            button1.Visible = true;
            label1.Text = "";
            label2.Text = "";
            button4.Enabled = false;
            label3.Text = "Поля очищені!";
            await Task.Delay(2000);
            label3.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            // Розбиваємо рядок на масив слів
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //З'єднуємо масив слів і між ними ставимо кому
            int count = 0;
            //Слово яке знаходимо
            string searchWord = textBox2.Text;

            // Заповнення масиву
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == searchWord)
                {
                    count++;
                }
            }
            // Створити рядок для зберігання результатів
            string result = "";
            // Вивести результати
            if (count > 0)
            {
                result = string.Format("{0} зустрічається {1}  раз(-ів, -и)", searchWord, count);
                button4.Enabled = true;
            }
            else
            {
                result = string.Format("{0} не зустрічається в рядку", searchWord);
            }

            // Показати результати в label2
            label2.Text = result;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string input = textBox1.Text;
                string searchWord = textBox2.Text;
                string newInput = input.Replace(searchWord, "");
                textBox1.Text = newInput;
                textBox2.Clear();
                label3.Text = string.Format("Слово '{0}' було видалено", searchWord);

                // Розбиваємо рядок на масив слів
                string[] words = newInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //З'єднуємо масив слів і між ними ставимо кому
                string output1 = string.Join(", ", words);
                // Виводимо результат у елемент label1
                label1.Text = output1;
                label2.Text = "";
            }
            else
            {
                label3.Text = "Пусте поле!";
                label2.Text = "";
            }
        }
    }
}
