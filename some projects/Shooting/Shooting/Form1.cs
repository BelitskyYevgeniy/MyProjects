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

namespace Shooting
{
    
   

    public partial class Form1 : Form
    {

        int rad_sh = 2;
        float R = 125;
        float r = 125;
        int N = 10;
        int n;
        int padding_ = 25;
        PointF O;
        List<PointF> shoots = new List<PointF>();
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
            g.DrawLine(pen, 10,  O.Y, a, O.Y);
            g.DrawLine(pen, a, O.Y, a-5, O.Y - 5);
            g.DrawLine(pen, a, O.Y, a - 5, O.Y + 5);
            
            //y
            g.DrawLine(pen, O.X, O.Y + R + 10, O.X, 15);
            g.DrawLine(pen, O.X, 15, O.X-5, 20);
            g.DrawLine(pen, O.X, 15, O.X+5, 20);
           
            g.DrawLine(pen, O.X, O.Y, f.X, f.Y);
            g.DrawLine(pen, f.X, f.Y, f.X + 5, f.Y);
            g.DrawLine(pen, f.X, f.Y, f.X , f.Y+5);


            int z = 0, dz =5 ; 
            while(z<=R)
            {
                g.DrawLine(pen, O.X + R / 2, O.Y+z, O.X + R / 2, O.Y + z+dz);
                z+=2*dz;
            }
            z = 0;
            dz = 3;
            int k =Convert.ToInt32(R / 2);
            while (z <= k)
            {
                g.DrawLine(pen, O.X+z, O.Y + R, O.X +z+dz, O.Y+R );
                z += 2 * dz;
            }
            g.DrawString("R", font, brush, O.X -10, O.Y +R-7, drawFormat);
            g.DrawString("R/2", font, brush, O.X + R/2-10, O.Y - 15, drawFormat);
            g.DrawString("R", font, brush, O.X+R-10, O.Y-15, drawFormat);
            g.DrawString("R", font, brush, f.X +10, f.Y+10, drawFormat);
            g.DrawString("Y", font, brush, O.X + 5, 15, drawFormat);
            g.DrawString("X", font, brush, a - 5, O.Y, drawFormat);
            g.DrawString("(0, 0)", font,brush, O.X-40, O.Y +5,  drawFormat);

            brush.Dispose();
            pen.Dispose();
            g.Dispose();
            drawFormat.Dispose();
            font.Dispose();
        }
        private void DrawTarget(Rectangle r, Graphics g)
        {
 
            O = new PointF(R+padding_, R+padding_);      

            SolidBrush brush = new SolidBrush(Color.Gray);
            g.FillEllipse(brush,padding_,padding_, R*2,R*2);

            brush.Color = Color.LimeGreen;
            g.FillRectangle(brush, padding_+ R, padding_, R, R);
            g.FillRectangle(brush, padding_, padding_+R, 2*R, R);

            brush.Color = Color.Gray;
            g.FillPolygon(brush, new PointF[3]{ O, new PointF(O.X + R, O.Y), new PointF(O.X + R / 2, O.Y + R)});
            brush.Dispose();

            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, tb_shoots.Left, tb_shoots.Bottom, tb_shoots.Left, this.Height);

            //границы у кнопопок 
            g.DrawLine(pen, tb_shoots.Left, bt_shoot.Bottom, this.Width, bt_shoot.Bottom );
            pen.Dispose();
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
           DrawTarget(ClientRectangle, e.Graphics);
            foreach (PointF x in shoots)
            {
                SolidBrush brush = new SolidBrush(Color.Red);
                e.Graphics.FillEllipse(brush, x.X - rad_sh, x.Y - rad_sh, 4, 4);
                brush.Dispose();
            }
            DrawArrowandLines(ClientRectangle, e.Graphics);
        }

        public Form1()
        {
            InitializeComponent();
        }
        
        //Стрельба
       private void shoot(PointF a)
        {
            N--;
            
            tb_shoots.Text += (Int32.Parse(lb_N.Text)-N).ToString() + ")(" + (a.X).ToString() + ", " + ( a.Y).ToString() + ") - ";
            
           
            if ((a.X <= 0 && a.Y >= 0 && a.X * a.X + a.Y * a.Y <= r * r || a.Y <= 0 && a.Y >= (-2) * a.X && a.Y >= 2 * a.X - 2*r))
                {
                    n++;
                    tb_shoots.Text += "Попадание!"+ Environment.NewLine; 

                }
            else
            {
                tb_shoots.Text += "Промах!"+ Environment.NewLine;
            }
            tb_shoots.Text+= "Общее число попаданий: "+ n.ToString() + Environment.NewLine+"Осталось пуль: " +N.ToString()+ Environment.NewLine+ Environment.NewLine;
            
            a.X = a.X*R/r+O.X;
            a.Y = O.Y - a.Y*R/r;
            if (!shoots.Contains(a))
            {
                shoots.Add(a);
                Invalidate();
            }
            tb_shoots.SelectionStart = tb_shoots.Text.Length;
            tb_shoots.ScrollToCaret();

            tb_x.ForeColor = Color.Gray;
            tb_y.ForeColor = Color.Gray;
            tb_x.Text = "Значение по X";
            tb_y.Text = "Значение по Y";
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (N == 0)
            {
                bt_restart.Focus();
                MessageBox.Show("Пуль больше нет!");
            }
            else
            {
                tb_shoots.Focus();
                PointF b = new PointF((e.Location.X - O.X)*r/R, (O.Y - e.Location.Y)*r/R);
                if (e.Location.X < tb_shoots.Left)
                        shoot(b);
                 
            }
        }
        private void bt_shoot_Click(object sender, EventArgs e)
        {
            if (N == 0)
            {
                bt_restart.Focus();
                MessageBox.Show("Пуль больше нет!");
                
            }
            else
            {
                tb_shoots.Focus();
                PointF c = new PointF(float.Parse(tb_x.Text), float.Parse(tb_y.Text));
                if (c.X+O.X < tb_shoots.Left)
                        shoot(c);
                    
            }
        }



        //Текстовые поля
        private void Toplaceholder_(TextBox a, ErrorProvider b, string c, Button f)
        {

            if (a.Text.Length == 0)
            {
                b.Clear();
                a.ForeColor = Color.Gray;
                if (f == bt_shoot)
                    f.Enabled = false;
                else
                    f.Enabled = true;
                a.Text = c;
            }
        }
        private void placeholderOut(TextBox a, ErrorProvider b)
        {
            if (a.ForeColor == Color.Gray)
            {
                a.Text = "";
                a.ForeColor = Color.Black;
                b.Clear();
            }
        }
        private void restartInput(TextBox a, Label b, string c)//поправить
        {
            if (a.ForeColor != Color.Gray)
            {
               
               
                if(a==tb_R && a.ForeColor!=Color.Gray)
                    r = float.Parse(a.Text);
                if (a == tb_N && a.ForeColor != Color.Gray)
                    N = Int32.Parse(a.Text);
                a.ForeColor = Color.Gray;
                b.Text = a.Text;
                a.Text = c;
            }

        }
       
        private bool Tryparse(TextBox a)
        {

            float x;
            bool f;

                f = float.TryParse(a.Text,out x);
            if (a == tb_N)
                x = Convert.ToInt32(x);
            if (f)
                if (x <= 0)
                    return false;
                else
                    return true;
            else return false;
        }
        private bool Tryparse(string a, out int x)
        {

            bool f = Int32.TryParse(a, out x);
            if (f)
                if (x <= 0)
                    return false;
                else
                    return true;
            else return false;
        }
        private void TextChanger(TextBox a, ErrorProvider b, Button c, TextBox f)
        {
            if (a.ForeColor != Color.Gray)
            {
                if (c == bt_shoot)
                {
                    float x;
                    if (!float.TryParse(a.Text, out x))
                    {
                        b.SetError(a, "Неверный формат ввода");
                        c.Enabled = false;

                    }
                    else
                    {
                        b.Clear();
                        c.Enabled = float.TryParse(f.Text, out x);
                    }
                }
                if (c == bt_restart)
                {
                    if (a.Text == "" || a.ForeColor == Color.Gray)
                    {
                        b.Clear();
                        if (f.ForeColor == Color.Gray)
                        {
                            c.Enabled = true;
                        }
                        else
                            c.Enabled = Tryparse(f);
                    }
                    else
                    {
                        if (!Tryparse(a))
                        {
                            b.SetError(a, "Неверный форма");
                            c.Enabled = false;
                        }
                        else
                        {
                            b.Clear();
                        }
                    }


                }
            }
        }


        private void bt_restart_Click(object sender, EventArgs e)
        {
            N=Int32.Parse(lb_N.Text);
            restartInput(tb_N, lb_N, "Число пуль");
            restartInput(tb_R, lb_R, "Радиус");
            n = 0;
            tb_shoots.Text = "";
            shoots.Clear();
            tb_x.ForeColor = Color.Gray;
            tb_y.ForeColor = Color.Gray;
            tb_x.Text = "Значение по X";
            tb_y.Text = "Значение по Y";
            error_pr_x.Clear();
            error_pr_y.Clear();
            bt_shoot.Enabled = false;
            Invalidate();
        }
        private void tb_x_GotFocus(object sender, EventArgs e)
        {
            placeholderOut(tb_x, error_pr_x);
        }

        private void tb_y_GotFocus(object sender, EventArgs e)
        {
            placeholderOut(tb_y, error_pr_y);
        }
       
        private void tb_x_Validated(object sender, EventArgs e)
        {
            Toplaceholder_(tb_x, error_pr_x, "Значение по X", bt_shoot);
            
        }

        private void tb_y_Validated(object sender, EventArgs e)
        {
            Toplaceholder_(tb_y, error_pr_y, "Значение по Y", bt_shoot);


        }
    
        private void tb_x_TextChanged(object sender, EventArgs e)
        {
            TextChanger(tb_x, error_pr_x, bt_shoot, tb_y);

        }

        private void tb_y_TextChanged(object sender, EventArgs e)
        {
            TextChanger(tb_y, error_pr_y, bt_shoot,tb_x);
        }



        private void tb_R_Validated(object sender, EventArgs e)
        {
            Toplaceholder_(tb_R, error_pr_R, "Радиус", bt_restart);
        }

        private void tb_N_Validated(object sender, EventArgs e)
        {
            Toplaceholder_(tb_N, error_pr_N, "Число пуль", bt_restart);
        }

        private void tb_R_TextChanged(object sender, EventArgs e)
        {
            TextChanger(tb_R, error_pr_R, bt_restart,tb_N);
        }

        private void tb_N_TextChanged(object sender, EventArgs e)
        {
            TextChanger(tb_N, error_pr_N, bt_restart,tb_R);
        }
        private void tb_N_GotFocus(object sender, EventArgs e)
        {
            placeholderOut(tb_N, error_pr_N);
        }
        private void tb_R_GotFocus(object sender, EventArgs e)
        {
            placeholderOut(tb_R, error_pr_R);
        }

    }
}
