using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_zad_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Шифр Цезаря
        /// </summary>
        class Shifr
        {
            int k;//Ключ для шифра
            string text; //Текст, который необходимо зашифровать
            readonly string alf = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";//Русский алфавит
            //string fullAlf = alf + alf.ToLower();
            /// <summary>
            /// Конструктор класса
            /// </summary>
            /// <param name="t">Ключ, заданный пользователем</param>
            /// <param name="m">Текст для шифрования, введенный пользователем</param>
            public Shifr(int t, string m)
            {
                k = t;
                text = m;
            }
            /// <summary>
            /// Геттер и сеттер для text
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            /// <summary>
            /// Геттер и сеттер для k
            /// </summary>
            public int K
            {
                get { return k; }
                set { k = value; }
            }
            /// <summary>
            /// Шифрование текста
            /// </summary>
            /// <returns>Зашифрованный текст</returns>
            public string Shifrat()
            {
                string rez = "";
                char r;
                string tex = text.ToUpper();
                for (int i = 0; i < tex.Length; i++)
                {
                    if (!alf.Contains(tex[i])) rez += tex[i];
                    else
                    {
                        int index = alf.IndexOf(tex[i]); //Положение символа из текста в алфавите
                        int nuzInd = (index + k) % alf.Length; //Индекс символа после шифрования
                        if (nuzInd < 0) r = alf[alf.Length + nuzInd]; //устранение ошибки отрицательного индекса
                        else r = alf[nuzInd];
                        if (tex[i] != text[i]) rez += (r.ToString()).ToLower(); //Запись результата
                        else rez += r;
                    }
                }
                return rez;
            }
            /// <summary>
            /// Дешифрация текста
            /// </summary>
            /// <returns>Дешифрованный текст</returns>
            public string Deshifrat()
            {
                string rez = "";
                char r;
                string tex = text.ToUpper();
                for (int i = 0; i < tex.Length; i++)
                {
                    if (!alf.Contains(tex[i])) rez += tex[i];
                    else
                    {
                        int index = alf.IndexOf(tex[i]);//Положение символа из текста в алфавите
                        int nuzInd = (index - k) % alf.Length;//Индекс символа после дешифрования
                        if (nuzInd < 0) r = alf[alf.Length + nuzInd];//устранение ошибки отрицательного индекса
                        else r = alf[nuzInd];
                        if (tex[i] != text[i]) rez += (r.ToString()).ToLower();//Запись результата
                        else rez += r;
                    }
                }
                return rez;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Запуск шифрации и дешифрации
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string tet = textBox2.Text, tot;
            int kl = Convert.ToInt32(textBox3.Text);
            Shifr S = new Shifr(kl, tet);
            string rez = S.Shifrat(); //Вызов метода шифрования
            textBox1.Text = rez; // вывод результата на форму
            System.IO.StreamWriter f = new System.IO.StreamWriter("test.txt"); //открытие потока для записи в файл
            f.WriteLine(rez); //запись в файл
            f.Close();//закрытие потока
            System.IO.StreamReader f2 = new System.IO.StreamReader("test.txt");//открытие потока для чтения файла
            tot = f2.ReadLine();//чтение из файла
            f2.Close();//закрытие потока
            Shifr DS = new Shifr(kl, tot); 
            string rez2 = DS.Deshifrat();//Вызов метода дешифрования
            textBox4.Text = rez2; //вывод результата на форму
            if (tet == rez2) MessageBox.Show("Сходится");
        }
    }
}
