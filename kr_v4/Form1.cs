using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kr_v4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text != string.Empty || text2.Text != string.Empty)
                {
                    string t1 = text1.Text;
                    string t2 = text2.Text;
                    bool verno = true;
                    Stack<char> chars1 = new Stack<char>();
                    Stack<char> chars2 = new Stack<char>(); //Использование стека

                    foreach (char i in t1.Reverse()) //Использование LINQ
                    {
                        chars1.Push(i);
                    }
                    foreach (char i in t2)
                    {
                        chars2.Push(i);
                    }
                    if (t1.Length != t2.Length)
                    {
                        MessageBox.Show("Утверждение неверно");
                    }
                    else
                    {
                        
                        int to = t2.Length;
                        for (int i = 0; i < to; i++)
                        {
                            char first = chars1.Pop();
                            char second = chars2.Pop();
                            MessageBox.Show(first + "\n" + second);
                            if (first != second)
                            {
                                verno = false;
                            }
                        }
                        if (verno)
                        {
                            MessageBox.Show("Утверждение верно, s2 это перевернутое s1");
                        }
                        else
                        {
                            MessageBox.Show("Утверждение неверно");
                        }
                    }
                    }
                else
                {
                    MessageBox.Show("Введите строки!");

                }
                }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }


        }
    }
}
