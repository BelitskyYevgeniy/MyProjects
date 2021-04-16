using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak_
{
    public partial class Form1 : Form
    {
        private int a = 30;
        private int b = 45;

        private int find(Button f, MouseEventArgs e)// поиск положения
        {

            if (e.X <= f.Left)
            {
                if (e.Y <= f.Top)
                    return 1;
                if (e.Y <= f.Bottom)
                    return 2;
                return 3;
            }
            if (e.X <= f.Right)
            {
                if (e.Y <= f.Top)
                    return 4;
                return 5;
            }
            if (e.Y <= f.Top)
                return 6;
            if (e.Y <= f.Bottom)
                return 7;
            return 8;


        }
        private bool checking(Button f)// работа с границами
        {
            if (f.Left <= 0)
                return true;
            if (f.Top <= 0)
                return true;
            if (f.Right >= this.Width)
                return true;
            if (f.Bottom >= this.Height)
                return true;
            return false;
        }
        private bool movecheck(Button f, MouseEventArgs e)// входит ли курсорd сектор, чтобы можно было двигать
        {
            if ((e.X > f.Left - a && e.X < f.Right + a) && (e.Y > f.Top - a && e.Y < f.Bottom + a))
                return true;
            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }



        private void btn_no_MouseMove(object sender, MouseEventArgs e)
        {
            btn_no.Enabled = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (movecheck(btn_no, e))
            {
                btn_no.Enabled = true;
                switch (find(btn_no, e))
                {
                    case 1:
                        {
                            btn_no.Left += b;
                            btn_no.Top += b;
                        }; break;
                    case 2:
                        {
                            btn_no.Left += b;
                        }; break;
                    case 3:
                        {
                            btn_no.Left += b;
                            btn_no.Top -= b;
                        }; break;
                    case 4:
                        {
                            btn_no.Top += b;
                        }; break;
                    case 5:
                        {
                            btn_no.Top -= b;
                        }; break;
                    case 6:
                        {
                            btn_no.Left -= b;
                            btn_no.Top += b;
                        }; break;
                    case 7:
                        {
                            btn_no.Left -= b;
                        }; break;
                    case 8:
                        {
                            btn_no.Left -= 5;
                            btn_no.Top -= 5;
                        }; break;
                    default:
                        {
                            btn_no.Location = new Point(this.Width / 2, this.Height / 2);
                        }; break;
                }
                if (checking(btn_no))
                {
                    btn_no.Location = new Point(this.Width / 2, this.Height / 2);
                }

            }
        }



        private void lb_MouseMove(object sender, MouseEventArgs e)
        {
            if (movecheck(btn_no, e))
            {
                btn_no.Enabled = true;
                switch (find(btn_no, e))
                {
                    case 1:
                        {
                            btn_no.Left += b;
                            btn_no.Top += b;
                        }; break;
                    case 2:
                        {
                            btn_no.Left += b;
                        }; break;
                    case 3:
                        {
                            btn_no.Left += b;
                            btn_no.Top -= b;
                        }; break;
                    case 4:
                        {
                            btn_no.Top += b;
                        }; break;
                    case 5:
                        {
                            btn_no.Top -= b;
                        }; break;
                    case 6:
                        {
                            btn_no.Left -= b;
                            btn_no.Top += b;
                        }; break;
                    case 7:
                        {
                            btn_no.Left -= b;
                        }; break;
                    case 8:
                        {
                            btn_no.Left -= 5;
                            btn_no.Top -= 5;
                        }; break;
                    default:
                        {
                            btn_no.Location = new Point(this.Width / 2, this.Height / 2);
                        }; break;
                }
                if (checking(btn_no))
                {
                    btn_no.Location = new Point(this.Width / 2, this.Height / 2);
                }

            }
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            btn_no.Enabled = false;
            MessageBox.Show("Да - провода!\nТы дурак! ГЫ)");
        }
        private void btn_yes_MouseMove(object sender, MouseEventArgs e)
        {
            btn_no.Enabled = false;
        }





        private void btn_no_MouseHover(object sender, EventArgs e)
        {
            btn_no.Enabled = false;
        }

        private void btn_yes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.Alt)
                    MessageBox.Show("Ты не дурак!");
        }
    }
}