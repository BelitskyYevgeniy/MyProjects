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

    public partial class Form1 : Form
    {
        internal DateTime start;
        
        internal List<Results> results;
        internal Form_results form;
        private Label[] lbltime = new Label[2];
        private Label[] lbltime_ = new Label[2];
        private Timer timer;
        private ulong timertickrecord = ulong.MaxValue;
        internal ulong timertick;

        MenuStrip menu;
        Label[] lbl = new Label[2];
        Label[] lbl_ = new Label[2];
        Patnashki a = new Patnashki();

        private int x = 71;
        private int y = 50;
        internal ulong score = 0;
        private int size = 40;
        private ulong record = ulong.MaxValue;

        private void azap(Patnashki a)
        {
            for (int i = 0; i < 3; i++)
            {
                a.Table[3, i] = Int32.Parse(table[3, i].Text);

                for (int j = 0; j < 4; j++)
                    a.Table[i, j] = Int32.Parse(table[i, j].Text);
            }
            a.Table[3, 3] = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    a.createButton(table[i, j], this, size, size, table[i, j].Text, table[i, j].Left, table[i, j].Top, Event_MouseClick, table[i, j].Name, table[i, j].Margin);
            for (int j = 0; j < 3; j++)
                a.createButton(table[3, j], this, size, size, table[3, j].Text, table[3, j].Left, table[3, j].Top, Event_MouseClick, table[3, j].Name, table[3, j].Margin);
            a.I = 3;
            a.J = 3;
        }
        private void zap(Patnashki a)
        {


            table[0, 0] = new Button();
            table[0, 0].Left = x;
            table[0, 0].Top = y;
            table[0, 0].Text = a.Table[0, 0].ToString();
            table[0, 0].Margin = new Padding(0);

            for (int i = 1; i < 4; i++)
            {
                table[i, 0] = new Button();
                table[i, 0].Top = table[i - 1, 0].Top + size;
                table[i, 0].Left = table[0, 0].Left;
                table[i, 0].Text = a.Table[i, 0].ToString();
                table[i, 0].Margin = new Padding(0);


                table[0, i] = new Button();
                table[0, i].Top = table[0, 0].Top;
                table[0, i].Left = table[0, i - 1].Left + size;
                table[0, i].Text = a.Table[0, i].ToString();
                table[0, i].Margin = new Padding(0);


                for (int j = 1; j < 4; j++)
                {
                    table[i, j] = new Button();
                    table[i, j].Text = a.Table[i, j].ToString();
                    table[i, j].Left = size + table[i, j - 1].Left;
                    table[i, j].Top = table[i, 0].Top;
                    table[i, j].Margin = new Padding();


                }
            }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    a.createButton(table[i, j], this, size, size, table[i, j].Text, table[i, j].Left, table[i, j].Top, Event_MouseClick, table[i, j].Name, table[i, j].Margin);
            for (int j = 0; j < 3; j++)
                a.createButton(table[3, j], this, size, size, table[3, j].Text, table[3, j].Left, table[3, j].Top, Event_MouseClick, table[3, j].Name, table[3, j].Margin);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            start = DateTime.Now;
            table = new Button[4, 4];
            zap(a);
            zapolnagka();

            
        }
        private void createMenu(EventHandler e, int i)
        {

            ToolStripMenuItem Item;

            switch (i)
            {
                case 1:
                    {
                        Item = new ToolStripMenuItem("Новая игра");
                    }; break;
                case 2:
                    {
                        Item = new ToolStripMenuItem("Начать сначала");
                    }; break;
                case 3:
                    {
                        Item = new ToolStripMenuItem("Достижения");
                    }; break;
                default:
                    {
                        return;
                    };

            }

            Item.Click += e;
            (menu).Items.Add(Item);





        }
        public Button[,] table { get; private set; }
        public Form1()
        {

            InitializeComponent();

        }

        private void proverka()
        {
            if (a.IsFinished())
            {
                timer.Stop();
                if (score < record)
                {
                    record = score;
                    lbl_[1].Text = record.ToString();
                }
                if (timertick < timertickrecord)
                {
                    timertickrecord = timertick;
                    lbltime_[1].Text = timertickrecord.ToString();
                }

                Deserialize();
                Form_input form_input = new Form_input(this);
                MessageBox.Show("Поздравляем! Вы победили!\nЧисло ваших ходов: " + score.ToString() + '\n' + "Вы прошли игру за " + timertick.ToString()+ " c"+"\nВвведиет пожалуйста ваше имя");

            }
        }


        private void move(Patnashki a, int j, int f_i, int f_j, object sender)
        {

            switch (j)
            {
                case 1:
                    {
                        move_info(a, f_i, f_j);
                        for (int i = 0; i < size; i++)
                            ((Button)sender).Left++;
                        proverka();

                    }; break;
                case 2:
                    {
                        move_info(a, f_i, f_j);

                        for (int i = 0; i < size; i++)
                            ((Button)sender).Left--;
                        proverka();
                    }; break;
                case 3:
                    {
                        move_info(a, f_i, f_j);
                        for (int i = 0; i < size; i++)
                            ((Button)sender).Top++;
                        proverka();
                    }; break;
                case 4:
                    {
                        move_info(a, f_i, f_j);
                        for (int i = 0; i < size; i++)
                            ((Button)sender).Top--;
                        proverka();
                    }; break;
            }
        }
        private void move_info(Patnashki a, int f_i, int f_j)
        {
            a.Table[a.I, a.J] = a.Table[f_i, f_j];
            a.Table[f_i, f_j] = 0;
            a.J = f_j;
            a.I = f_i;
            score++;
            lbl_[0].Text = score.ToString();
        }
        private void Event_MouseClick(object sender, EventArgs e)
        {

            if (!timer.Enabled)
                timer.Start();
            int p = a.I * 4 + a.J + 1;
            int f = Int32.Parse(((Button)sender).Text);
            int f_i = 0;
            int f_j = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (a.Table[i, j] == f)
                    {
                        f_i = i;
                        f_j = j;
                        break;
                    }
                }
            if (a.I == f_i)
            {
                if (a.J - 1 == f_j)
                {
                    move(a, 1, f_i, f_j, sender);
                }
                if (a.J + 1 == f_j)
                {
                    move(a, 2, f_i, f_j, sender);
                }
            }
            if (a.J == f_j)
            {
                if (a.I - 1 == f_i)
                {
                    move(a, 3, f_i, f_j, sender);
                }
                if (a.I + 1 == f_i)
                {
                    move(a, 4, f_i, f_j, sender);
                }
            }

        }

        private void tmi_new_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timertick = 0;
            Controls.Clear();
            do
            {
                a.vvod();
            }
            while (!a.proverka());
            zap(a);
            zapolnagka();

        }
        private void tmi_restart_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timertick = 0;
            Controls.Clear();
            azap(a);
            zapolnagka();
        }
        internal void Deserialize()
        {
            using (FileStream fr = new FileStream("Results.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                if(fr.Length!=0)
                results = (List<Results>)bf.Deserialize(fr);
            }
        }
        internal void Serialize_()
        {
            using (FileStream fs = new FileStream("Results.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, results);
            }
        }
        private void results_Click(object sender, EventArgs e)
        {

            if (form == null)
            {
                Deserialize();
                form = new Form_results(this);
            }
            else
                form.Focus();
        }
        private void TimerTickevent(object sender, EventArgs e)
        {
            lbltime_[0].Text = timertick.ToString();
            timertick++;
        }
        private void zapolnagka()
        {

            results = new List<Results>();
            score = 0;
            menu = null;

            timer = new Timer();
            timertick = 0;
            //работа с текстовыми полями времени
            lbltime[0] = new Label() { Left = 347, Top = 64, Size = new Size(48, 15), Text = "Время: " };
            lbltime_[0] = new Label() { Left = lbltime[0].Right, Top = 64, Size = new Size(300, 15), Text = timertick.ToString() };
            lbltime[1] = new Label() { Left = 347, Top = 79, Size = new Size(250, 15), Text = "Самая скоростная сборка за текущую сессию: " };
            if (record == ulong.MaxValue)
                lbltime_[1] = new Label() { Left = lbltime[1].Right, Top = 79, Size = new Size(200, 15), Text = "" };
            else
                lbltime_[1] = new Label() { Left = lbltime[1].Right, Top = 79, Size = new Size(280, 15), Text = timertickrecord.ToString() };
            //работа с таймером
            this.Controls.Add(lbltime_[0]);
            this.Controls.Add(lbltime_[1]);
            this.Controls.Add(lbltime[0]);
            this.Controls.Add(lbltime[1]);
            timer.Tick += TimerTickevent;
            timer.Interval = 1000;
            Text = "Пятнашки";
            //работа с текстовыми полями очков
            lbl[0] = new Label() { Left = 347, Top = 35, Size = new Size(150, 15), Text = "Количество перестановок: " };
            lbl_[0] = new Label() { Left = lbl[0].Right, Top = 35, Size = new Size(300, 15), Text = score.ToString() };
            lbl[1] = new Label() { Left = 347, Top = 49, Size = new Size(150, 15), Text = "Рекорд за текущую сессию: " };
            if (record == ulong.MaxValue)
                lbl_[1] = new Label() { Left = lbl[1].Right, Top = 49, Size = new Size(300, 15), Text = "" };
            else
                lbl_[1] = new Label() { Left = lbl[1].Right, Top = 69, Size = new Size(300, 15), Text = record.ToString() };
            Controls.Add(lbl_[0]);
            Controls.Add(lbl_[1]);
            Controls.Add(lbl[0]);
            Controls.Add(lbl[1]);
            //работа с полями
            menu = new MenuStrip();
            this.Controls.Add(this.menu);
            createMenu(tmi_new_Click, 1);
            createMenu(tmi_restart_Click, 2);
            createMenu(results_Click, 3);
        }


    }

    
}

