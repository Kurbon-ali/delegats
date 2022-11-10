using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountClass.Class;

namespace delegat
{
    public partial class Form1 : Form
    {
        string message;
        void PrintSimpleMessag(string message) => listBox1.Items.Add(message);
        public Form1()
        {
            InitializeComponent();
        }
        Account account;

        void DisplayMessage(Account sender, AccountEventArgs e)
        {
            MessageBox.Show($"Сумма транзакции: {e.Sum}\n" + e.Message + $"\nТекущая сумма на счете: {sender.Sum}");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            account = new Account(Convert.ToInt32(textBox2.Text), textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {account.Fio}, состояние счета: {account.Sum}");
            MessageBox.Show($"Владелец счёта: {account.Fio}, состояние счета: {account.Sum}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            account.Add(Convert.ToInt32(textBox3.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец счёта: {account.Fio}, сумма на счете: {account.Sum}");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            if (account.Sum < x)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("На счету нету денег - получается БОМЖ");
            }
            else
            {
                account.Take(Convert.ToInt32(textBox3.Text));
                listBox1.Items.Clear();
                listBox1.Items.Add($"Владелец счёта: {account.Fio}, сумма на счете: {account.Sum}");
            }


        }
    }
}
