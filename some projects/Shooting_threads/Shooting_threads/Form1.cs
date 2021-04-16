using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
namespace Shooting_threads
{



    public partial class Form1 : Form
    {
        private int restart = 0; 
        int time_calc=500;
        int time_shoot=1000;
        static Thread th_demo;
        static Thread th;
        static float R = 125;
        static float r;

        static List<PointF> shoots = new List<PointF>();
        Demo demo;
        int rad_sh = 2;
        int padding_ = 25;
        static PointF O;
        


        //Рисовалки
        private void DrawArrowandLines(Rectangle r, Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            int a = tb_shoots.Location.X - 30;
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("Courier New", 10, FontStyle.Regular);
            StringFormat drawFormat = new System.Drawing.StringFormat();
            PointF f = new PointF((-0.8f) * R + O.X, O.Y - R * 0.6f);
            //x
            g.DrawLine(pen, 10, O.Y, a, O.Y);
            g.DrawLine(pen, a, O.Y, a - 5, O.Y - 5);
            g.DrawLine(pen, a, O.Y, a - 5, O.Y + 5);

            //y
            g.DrawLine(pen, O.X, O.Y + R + 10, O.X, 15);
            g.DrawLine(pen, O.X, 15, O.X - 5, 20);
            g.DrawLine(pen, O.X, 15, O.X + 5, 20);

            g.DrawLine(pen, O.X, O.Y, f.X, f.Y);
            g.DrawLine(pen, f.X, f.Y, f.X + 5, f.Y);
            g.DrawLine(pen, f.X, f.Y, f.X, f.Y + 5);


            int z = 0, dz = 5;
            while (z <= R)
            {
                g.DrawLine(pen, O.X + R / 2, O.Y + z, O.X + R / 2, O.Y + z + dz);
                z += 2 * dz;
            }
            z = 0;
            dz = 3;
            int k = Convert.ToInt32(R / 2);
            while (z <= k)
            {
                g.DrawLine(pen, O.X + z, O.Y + R, O.X + z + dz, O.Y + R);
                z += 2 * dz;
            }
            g.DrawString("-R", font, brush, O.X - 20, O.Y + R - 7, drawFormat);
            g.DrawString("R/2", font, brush, O.X + R / 2 - 10, O.Y - 15, drawFormat);
            g.DrawString("R", font, brush, O.X + R - 10, O.Y - 15, drawFormat);
            g.DrawString("R", font, brush, f.X + 10, f.Y + 10, drawFormat);
            g.DrawString("Y", font, brush, O.X + 5, 15, drawFormat);
            g.DrawString("X", font, brush, a - 5, O.Y, drawFormat);
            g.DrawString("(0, 0)", font, brush, O.X - 40, O.Y + 5, drawFormat);

            brush.Dispose();
            pen.Dispose();
            g.Dispose();
            drawFormat.Dispose();
            font.Dispose();
        }
        private void DrawTarget(Rectangle r, Graphics g)
        {

            O = new PointF(R + padding_, R + padding_);

            SolidBrush brush = new SolidBrush(Color.Gray);
            g.FillEllipse(brush, padding_, padding_, R * 2, R * 2);

            brush.Color = Color.LimeGreen;
            g.FillRectangle(brush, padding_ + R, padding_, R, R);
            g.FillRectangle(brush, padding_, padding_ + R, 2 * R, R);

            brush.Color = Color.Gray;
            g.FillPolygon(brush, new PointF[3] { O, new PointF(O.X + R, O.Y), new PointF(O.X + R / 2, O.Y + R) });
            brush.Dispose();

            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, tb_shoots.Left, tb_shoots.Bottom, tb_shoots.Left, this.Height);

            //границы у кнопопок 
           // g.DrawLine(pen, tb_shoots.Left, bt_shoot.Bottom, this.Width, bt_shoot.Bottom);
            pen.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTarget(ClientRectangle, e.Graphics);
            for (int i=0;i<demo.N;i++)
            {
                SolidBrush brush = new SolidBrush(Color.Red);
                e.Graphics.FillEllipse(brush, shoots[i].X - rad_sh, shoots[i].Y - rad_sh, 4, 4);
                brush.Dispose();
            }
            DrawArrowandLines(ClientRectangle, e.Graphics);
        }



        public Form1()
        {
            InitializeComponent();
            demo = new Demo(time_shoot, time_calc, tb_shoots,tb_input_calc_changer, bt_stop_calc,bt_stop_shooting, this, 1);
            demo.calc.calc();

        }

        //Стрельба
        internal void shoot()
        {

            while (demo.N < shoots.Count)
            {

                
                
                Action action = () =>
                  {
                      tb_shoots.Text += (demo.N + 1).ToString() + ")(" + (shoots[demo.N].X).ToString() + ", " + (shoots[demo.N].Y).ToString() + ") - ";
                      if ((shoots[demo.N].X <= 0 && shoots[demo.N].Y >= 0 && shoots[demo.N].X * shoots[demo.N].X + shoots[demo.N].Y * shoots[demo.N].Y <= r * r || shoots[demo.N].Y <= 0 && shoots[demo.N].Y >= (-2) * shoots[demo.N].X && shoots[demo.N].Y >= 2 * shoots[demo.N].X - 2 * r))
                      {
                          demo.n++;
                          tb_shoots.Text += "Попадание!" + Environment.NewLine;
                      }
                      else
                      {
                          tb_shoots.Text += "Промах!" + Environment.NewLine;
                      }
                      tb_shoots.Text += "Общее число попаданий: " + demo.n.ToString() + Environment.NewLine;
                      tb_shoots.SelectionStart = tb_shoots.Text.Length;
                      tb_shoots.ScrollToCaret();
                      
                  };
                if (tb_shoots.InvokeRequired)
                    tb_shoots.Invoke(action);
                else
                    action();
                float X = shoots[demo.N].X * R / r + O.X;
                float Y = O.Y - shoots[demo.N].Y * R / r;
                shoots[demo.N] = new PointF(X, Y);
                if (shoots.IndexOf(shoots[demo.N]) == demo.N)
                {
                    Invalidate();
                }
                demo.N++;
                Thread.Sleep(demo.Time);
            }
            Action action_ = () =>
            {

                if (demo.stop && shoots.Count == demo.N)
                {
                    bt_stop_shooting_Click(bt_stop_shooting, new EventArgs());
                }
            };
            if (tb_shoots.InvokeRequired)
                tb_shoots.Invoke(action_);
            else
                action_();




            th_demo.Abort();

        }


        internal class Demo
        {
            internal int N = 0;
            internal int n = 0;
            internal bool stop = false;
            private int time;
            internal int Time
            {
                get
                {
                    return time;
                }
                set
                {
                    if (value <= 0)
                        throw new Exception("Величина промежутка времени между выстрелами не может быть неположительной!");
                    time = value;
                }
            }
            internal Calc calc;
            private Form1 form;
            public Demo(int f,int f_calc, TextBox a,TextBox a_ ,  Button b,Button b_,  Form1 d,float rad)
            {
                
                form = d;
                r = rad;
                time = f;
                calc = new Calc(f_calc, a, a_, b,b_, d, this);
                calc.waitCalc += waitCalc;
                b.Click += calc.stopcalc;
                
                th_demo = new Thread(form.shoot);
            }
           
            public void waitCalc(object sender, EventArgs e)
            {
                
                    if (th_demo.ThreadState == ThreadState.Unstarted)
                        th_demo.Start();
                if (!th_demo.IsAlive)
                {
                    th_demo = new Thread(form.shoot);
                    th_demo.Start();
                }
            }

        }
        internal class Calc
        { 
            TextBox text;
            TextBox text_;
            int time;
            public int Time
            {
                get
                {
                    return time;
                }
                internal set
                {
                    if (value <= 0)
                        throw new Exception("Величина промежутка времени между вычислениями не может быть неположительной!");
                    time = value;
                }
            }
            Button but;
            Button but_;
            Demo demo;
            internal Form1 form;
            public delegate void MyEventHandler(object sender, EventArgs e);
            public event MyEventHandler waitCalc;
            public Calc(int Time, TextBox a, TextBox a_,Button b, Button b_,Form1 d, Demo demo_)
            {
                text_ = a_;
                time = Time;
                but_ = b_;
                text = a;
                but = b;
                form = d;
                demo = demo_;
            }
            public void calc()
            {
                th = new Thread(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {

                        int z= Convert.ToInt32(R);
                        int x = rnd.Next(-z, z + 1);

                        
                        int y = rnd.Next(-z, z + 1);
                        PointF point = new PointF(r*x/R, r*y/R);
                        shoots.Add(point);
                        waitCalc(this, new EventArgs());
                        Thread.Sleep(time);

                    }

                });
                th.Start();
            }
            public void stopcalc(object sender, EventArgs e)
            {
                th.Abort();
                Action action = () => {
                    but.Enabled = false;
                    text_.Enabled = false;
                    text_.Text = "";
                        text.Text += Environment.NewLine + "Вычисления прекращены!"+Environment.NewLine;
                        demo.stop = true;
                    if(demo.N==shoots.Count)
                    {
                        form.bt_stop_shooting_Click(but_, new EventArgs());
                    }
                    text.SelectionStart = text.Text.Length;
                    text.ScrollToCaret();
                };
                th = new Thread(() =>
                {
                    if (text.InvokeRequired)
                        text.Invoke(action);
                    else
                        action();
                });
                th.Start();
            }

        }

        private void bt_stop_shooting_Click(object sender, EventArgs e)
        {
            if (demo.stop)
            {
                th_demo.Abort();
                tb_shoots.Text += Environment.NewLine + "Стрельба прекращена!" + Environment.NewLine;
                tb_shoots.SelectionStart = tb_shoots.Text.Length;
                tb_shoots.ScrollToCaret();
                bt_stop_shooting.Enabled = false;
                tb_input_shoot_changer.Enabled = false;
                tb_input_shoot_changer.Text = "";

            }
            else
            {
                MessageBox.Show("Нeвозможно прекратить стрельбу до того, как завершатся вычисления!");
            }
        }
        
        
       private void check_input(TextBox a, TextBox a_,Button b, ErrorProvider e, ErrorProvider e_)
        {
            bool f;
            int t;
            if ((f=a.Text == "") || Int32.TryParse(a.Text, out t) && t > 0)
            {
                e.Clear();
                if (restart != 2)
                {
                    if (!f)
                        b.Enabled = true;
                    else
                    {
                        b.Enabled = false;
                    }
                }
                else
                {
                    b.Enabled = e_.GetError(a_) == "";
                }
            }
            else
            {
                e.SetError(a, "Неверный формат ввода");
                b.Enabled = false;
            }
        }

        private void tb_input_calc_changer_TextChanged(object sender, EventArgs e)
        {
            if(restart!=2)
                check_input(tb_input_calc_changer,tb_input_shoot_changer, bt_time_changer_calc, ep_calc, ep_shoot) ;
            else
                check_input(tb_input_calc_changer, tb_input_shoot_changer, bt_restart, ep_calc, ep_shoot);
        }
        private void bt_time_changer_calc_Click(object sender, EventArgs e)
        {
            
            if (tb_input_calc_changer.Text != "")
            {
                int t = demo.calc.Time;
                demo.calc.Time = Int32.Parse(tb_input_calc_changer.Text);
                time_calc = demo.calc.Time;
                tb_shoots.Text += Environment.NewLine + "Величина задержки между вычислениями изменена с " + t.ToString() + " на " + demo.calc.Time.ToString() + " мс!" + Environment.NewLine;
                tb_shoots.SelectionStart = tb_shoots.Text.Length;
                tb_shoots.ScrollToCaret();
                tb_input_calc_changer.Text = "";
            }
        }

        private void tb_input_shoot_changer_TextChanged(object sender, EventArgs e)
        {
            if(restart!=2)
                check_input(tb_input_shoot_changer, tb_input_calc_changer, bt_time_changer_shoot, ep_shoot, ep_calc);
            else
                check_input(tb_input_shoot_changer, tb_input_calc_changer, bt_restart, ep_shoot, ep_calc);
        }
        private void bt_time_changer_shoot_Click(object sender, EventArgs e)
        {
            if (tb_input_shoot_changer.Text != "")
            {
                int t = demo.Time;
                demo.Time = Int32.Parse(tb_input_shoot_changer.Text);
                time_shoot = demo.Time;
                tb_shoots.Text += Environment.NewLine + "Величина задержки между выстрелами изменена с " + t.ToString() + " на " + demo.Time.ToString() + " мс!" + Environment.NewLine;
                tb_input_shoot_changer.Text = "";
            }
        }

        private void bt_restart_Click(object sender, EventArgs e)
        {
            switch(restart)
            {
                case 0:
                    {
                        th_demo.Abort();
                        th.Abort();


                        tb_input_rad.Enabled = true;
                        tb_input_calc_changer.Enabled = false;
                        tb_input_shoot_changer.Enabled = false;
                        tb_input_calc_changer.Text = "";
                        tb_input_shoot_changer.Text = "";
                        ep_calc.Clear();
                        ep_shoot.Clear();
                        tb_shoots.Text = "Введите величину радиуса" + Environment.NewLine + "Радиус сейчас: " + r.ToString() + Environment.NewLine;

                        bt_stop_shooting.Enabled = false;
                        bt_stop_calc.Enabled = false;
                        bt_time_changer_calc.Enabled = false;
                        bt_time_changer_shoot.Enabled = false;
                        
                        bt_restart.Text = "Продолжить";
                        restart++;
                    }; break;
                case 1:
                    {

                        if(tb_input_rad.Text!="")
                            r = Int32.Parse(tb_input_rad.Text);
                        tb_input_rad.Text = "";
                        tb_shoots.Text += "Величина нового радиуса: "+r.ToString()+Environment.NewLine+"Введите величину задержки между вычислениями и выстрелами" + Environment.NewLine + "Если менять какой-либо из параметров не нужно, оставьте его пустым";
                        tb_input_rad.Enabled = false;
                        tb_input_calc_changer.Enabled = true;
                        tb_input_shoot_changer.Enabled = true;
                        bt_restart.Enabled = true;
                        bt_restart.Text = "Запуск";
                        restart++;
                    }; break;
                case 2:
                    {
                        bt_time_changer_calc_Click(bt_time_changer_calc, new EventArgs());
                        bt_time_changer_shoot_Click(bt_time_changer_shoot, new EventArgs());

                        tb_input_calc_changer.Text = "";
                        tb_input_shoot_changer.Text="";
                        
                        tb_shoots.Text = "Внимание!" + Environment.NewLine + "В полях ввода необходимо ввести величину > 0 в мс!" + Environment.NewLine + Environment.NewLine + "Задержка между вычислениями: " + demo.calc.Time + " мс" + Environment.NewLine + "Задержка между выстрелами: " + demo.Time + " мс" + Environment.NewLine + "Радиус: " + r.ToString() + Environment.NewLine + Environment.NewLine;
                        tb_input_calc_changer.Text = "";
                        tb_input_shoot_changer.Text = "";
                        bt_time_changer_calc.Enabled = false;
                        bt_time_changer_shoot.Enabled = false;
                        bt_restart.Enabled = true;
                        bt_restart.Text = "Рестарт";
                        bt_stop_calc.Enabled = true;
                        bt_stop_shooting.Enabled = true;
                        shoots.Clear();
                        restart = 0;

                        demo = new Demo(time_shoot, time_calc, tb_shoots, tb_input_calc_changer, bt_stop_calc, bt_stop_shooting, this, r);
                        demo.calc.calc();
                    };break;
                default:
                    {
                        throw new Exception("Ошибка запуска игры!");
                    }; 
            }






            
        }

        private void tb_input_rad_TextChanged(object sender, EventArgs e)
        {
            check_input(tb_input_rad, tb_input_calc_changer, bt_restart, ep_restart, ep_shoot);

        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            th.Abort();
            th_demo.Abort();
        }
    }
}

