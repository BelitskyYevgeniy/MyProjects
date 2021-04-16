using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Patnashki_serialization
{
    class Form_input:Form
    {
        bool click=false;
        Form1 form;
        Label lb;
        TextBox tb;
        Button bt;
        


        public Form_input(Form1 a):base()
        {

            form = a;
            this.Text = "Сохранение результатов игры";
            Size size = new Size(300, 200);
            this.MaximumSize = size;
            this.MinimumSize = size;

            tb = new TextBox();
            tb.Left = 20;
            tb.Top = 50;

            lb = new Label();
            lb.Top = tb.Top - 30;
            lb.Left = tb.Left;
            lb.Text = "Введите ваше имя";

            bt = new Button();
            bt.Left = tb.Right + 20;
            bt.Top = tb.Top;
            bt.Text = "Ввести";
            bt.Click += bt_Click;

            this.FormClosing += Form_input_close;
            this.Controls.Add(bt);
            this.Controls.Add(lb);
            this.Controls.Add(tb);
            this.Show();
        }
        private void Form_input_close(object sender, FormClosingEventArgs e)
        {
            if (!click)
            {
                e.Cancel = true;
                MessageBox.Show("Подтвердите ввод! Если не хотите его указывать оставьте поле пустым!");
            }

               

        }
        private bool check(string a)
        {
            int i = 0;
            while(i!=a.Length)
            {
                if (a[i] != ' ' && a[i] != '\n' && a[i] != '\t')
                    return true;
                i++;
            }
            return false;
        }
        private void bt_Click(object sender, EventArgs e)
        {
            string Name;
            click = !click;
            if (tb.Text == "" || !check(tb.Text))
                Name = "Безымянный";
            else
                Name = tb.Text;
            Results a = new Results(Name, form.timertick, form.start, form.score);
            form.results.Add(a);
            form.Serialize_();
            MessageBox.Show("Ваши результыты успешно сохранились!");
            this.Close();
        }
    }
}
