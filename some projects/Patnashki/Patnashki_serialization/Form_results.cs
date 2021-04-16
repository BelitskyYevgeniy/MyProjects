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
    class Form_results : Form
    {

        Form1 form;
        int nowNonenabled = 0;
        ErrorProvider ep;
        int start_button_pos_Y = 30;
        int start_button_pos_X = 30;
        int interval = 10;
        Button[] but;
        TextBox tb;
        Label lb;
        private void Form_results_Closed(object sender, FormClosedEventArgs e)
        {
            form.form = null;
        }
        public Form_results(Form1 b):base()
        {
            form = b;
            this.Load += Form_results_Load;
            this.Show();
            top_time(but[0], new EventArgs());
        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
           
            DateTime a;
            if(DateTime.TryParse(tb.Text, out a))
            {
                but[4].Enabled = true;
                ep.Clear();
            }
            else
            {
                but[4].Enabled = false;
                if (tb.Text == "")
                    ep.Clear();
                else
                ep.SetError(tb, "Неверный формат ввода!");
            }
        }
        private void reverse(int j, List<Results> clon)
        {
            lb.Text = "  Имя игрока/Время сборки/Дата начала сборки/Число ходов" + Environment.NewLine;
            but[nowNonenabled].Enabled = true;
            but[j].Enabled = false;
            nowNonenabled = j;

            int m = form.results.Count - 1;
            for (int i=1;i<=10; i++)
            {
                lb.Text += (i).ToString() + ") ";
                if (m<0)
                    lb.Text += "(Пусто!)" + Environment.NewLine;
                else
                    lb.Text += clon[m].Name + "     " + clon[m].Period.ToString() + " c     " + clon[m].StartTime.ToString() + "     " + clon[m].Steps.ToString() + Environment.NewLine;
                m--;
            }
        }
        private void top_time(object sender, EventArgs e)
        {
                form.Deserialize();
                List<Results> clon = new List<Results>(form.results);
                clon.Sort();
                reverse(0, clon);
            
        }
        private void top_numb(object sender, EventArgs e)
        {
            form.Deserialize();
            List<Results> clon = new List<Results>(form.results);
            clon.Sort(new ComparerResults());
            reverse(1, clon);
        }
        private void top_last(object sender, EventArgs e)
        {
            form.Deserialize();
            reverse(2, form.results);
        }
        private void Delete_last(object sender, EventArgs e)
        {
            form.Deserialize();
            int l;
            if(form.results.Count==0)
            {
                MessageBox.Show("Удаление отменено: список пуст");
                return;
            }
            if (form.results.Count > 10)
                l = 10;
            else
            {
                l = form.results.Count;
                
            }
            form.results.RemoveRange(form.results.Count - l-1, l);

            form.Serialize_();
            string a;
            if (form.results.Count == 0)
                a = "Cписок пуст!";
            else
                a = "Осталось записей: " + form.results.Count.ToString();
            Update(but[5], new EventArgs());
            MessageBox.Show("Удаление прошло успешно. "+a);
        }

        private void Delete_data(object sender, EventArgs e)//поправить
        {
            form.Deserialize();
            int i = form.results.Count - 1;
            DateTime a = DateTime.Parse(tb.Text);
            if (DateTime.Compare(form.results[i].StartTime, a) < 0)
            {
                MessageBox.Show("Удаление не было выполнено:в списке результатов нет дат позже " + a.ToString());
            }
            else
            {
                while (i>=0 && DateTime.Compare(form.results[i].StartTime, a) >= 0 )
                {
                    form.results.RemoveAt(i);
                    i--;
                }
                (sender as Button).Enabled = false;
                tb.Text = "";
                form.Serialize_();
                Update(but[5], new EventArgs());
                MessageBox.Show("Удаление всех решений, начавшихся после "+ a.ToString()+ ", прошло успесшно!"+"Осталось записей: " + form.results.Count.ToString());
            }
        }
        
        private void Form_results_Load(object sender, EventArgs e)
        {
            //настроить размеры
            this.ep = new ErrorProvider();
            ep.RightToLeft = true;
            this.FormClosed += Form_results_Closed;
            Size a = new Size(600, 400);

            this.MaximumSize = a;
            this.MinimumSize = a;
            but = new Button[6];
            for (int i = 0; i < but.Length; i++)
            {
                but[i] = new Button();
                if (i != 5)
                {
                    but[i].Width = 100;
                    but[i].Height = 40;
                    but[i].Top = start_button_pos_Y;
                    but[i].Left = start_button_pos_X + but[i].Size.Width * i + interval * i;
                }
                else
                {
                    but[i].Width = 100;
                    but[i].Height = 40;
                    but[i].Top = but[4].Top+100;
                    but[i].Left = but[4].Left;
                }
                switch (i)
                {
                    case 0:
                        {
                            but[i].Text = "По времени сборки";
                            but[i].Click +=top_time;
                        };break;
                    case 1:
                        {
                            but[i].Text = "По количеству ходов";
                            but[i].Click += top_numb;
                        };break;
                    case 2:
                        {
                            but[i].Text = "Последние сыгранные игры";
                            but[i].Click += top_last;
                        };break;
                    case 3:
                        {
                            but[i].Text = "Удалить 10 последних игры";
                            but[i].Click += Delete_last;
                        };break;
                    case 4:
                        {
                            but[i].Text = "Удалить ";
                            but[i].Enabled = false;
                            but[i].Click += Delete_data;
                        }; break;
                    case 5:
                        {
                            but[i].Text = "Обновить";
                            but[i].Click += Update;
                        }; break;
                    default:
                        {
                            throw new Exception("Ошибка работы конструктора!");
                        };
                }


                
                this.Controls.Add(but[i]);
            }
            tb = new TextBox();
            tb.Left = but[4].Left;
            tb.Top = but[4].Bottom + interval;
            this.Text = "Достижения";
            tb.TextChanged += tb_TextChanged;
            lb = new Label();
            lb.Text = "  Имя игрока/Время сборки/Дата начала сборки/Число ходов" + Environment.NewLine;
            lb.Top = but[0].Bottom + 20;
            lb.Left = but[0].Left;
            lb.Size = new Size(400, 500);
            this.Controls.Add(lb);
            this.Controls.Add(tb);

        }

        private void Update(object sender, EventArgs e)
        {

            switch(nowNonenabled)
            {
                case 0:
                    {
                        top_time(but[nowNonenabled], new EventArgs());
                    };break;
                case 1:
                    {
                        top_numb(but[nowNonenabled], new EventArgs());
                    };break;
                case 2:
                    {
                        top_last(but[nowNonenabled], new EventArgs());
                    }; break;
                default:
                    {
                        throw new Exception("Ошибка при обновлении!");
                    }
            }


        }

    }
}
