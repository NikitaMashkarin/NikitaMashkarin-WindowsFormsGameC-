using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string currentWord;
        string hiddenWord;
        string[] words = new string[]
        {
            "дом", "зима", "лес", "книга", "море", "зерно", "свет", "утюг", "птица", "рыба", "часы"
        };

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            currentWord = getWord();
            hiddenWord = closeWord(currentWord);
            label1.Text = hiddenWord;
            label2.Text = "Угадайте букву!";
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
            {
                char guessedLetter = textBox1.Text[0];
                string updatedHiddenWord = openWord(currentWord, hiddenWord, guessedLetter);

                if (hiddenWord != updatedHiddenWord)
                {
                    hiddenWord = updatedHiddenWord;
                    label1.Text = hiddenWord;
                    label2.Text = "Вы угадали букву!";
                }
                else
                {
                    label2.Text = "Вы не угадали букву.";
                }

                if (hiddenWord == currentWord)
                {
                    label2.Text = "Вы угадали слово!";
                    textBox1.Enabled = false;
                }

                textBox1.Text = "";
            }
        }

        public string getWord()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int rndInt = rnd.Next(0, words.Length);
            return words[rndInt];
        }

        public string closeWord(string word)
        {
            return new string('*', word.Length);
        }

        public string openWord(string openWord, string closeWord, char letter)
        {
            char[] updatedWord = closeWord.ToCharArray();
            bool letterFound = false;

            for (int i = 0; i < openWord.Length; i++)
            {
                if (openWord[i] == letter)
                {
                    updatedWord[i] = letter; 
                    letterFound = true;
                }
            }

            return letterFound ? new string(updatedWord) : closeWord;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
