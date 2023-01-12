using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int num = 1000;
        int lowerBound = 0;
        int upperBound = 2000;
        int attempts = 0;

        public Form1()
        {
            InitializeComponent();

            do
            {
                num = 1000;
                lowerBound = 0;
                upperBound = 2000;
                attempts = 0;

                while (GuessNumber() != DialogResult.Yes)
                {
                    attempts++;
                    ChooseNumber();
                    if (upperBound == lowerBound) break;
                }
            } while (MessageBox.Show($"Число {num}\nКол-во попыток {attempts}", "Отгадал", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry);

            

            
        }

        public DialogResult GuessNumber()
        {        
            return MessageBox.Show($"Число {num}?", $"Попытка №{attempts}", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);      
        }

        public void ChooseNumber()
        {
            DialogResult res = MessageBox.Show($"Число больше чем {num}?", "Поиск номера", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                lowerBound = num;
            }
            else
            {
                upperBound = num;
            }
            num = (upperBound + lowerBound) / 2;
        }
    }
}
