using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Patnashki_serialization
{
    class Patnashki : Button
    {
        private int i_;
        private int j_;
        public int I
        {
            get
            {
                return i_;
            }
            set
            {
                i_ = value;
            }
        }
        public int J
        {
            get
            {
                return j_;

            }
            set
            {
                j_ = value;
            }
        }


        public int[,] Table { get; private set; }
        public bool proverka()
        {
            int[] m = new int[15];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    m[i * 4 + j] = Table[i, j];
            for (int i = 0; i < 3; i++)
                m[12 + i] = Table[3, i];
            int sum = 0;

            for (int i = 0; i < 16; i++)
                for (int j = i + 1; j < 15; j++)
                    if (m[i] > m[j])
                        sum++;

            if (sum % 2 == 1)
                return false;
            else
                return true;
        }
        public void createButton(Button btn, Form f, int width, int height, string text, int x, int y, EventHandler even, string name, Padding padding)
        {
            btn = new Button();
            btn.Text = text;
            btn.Left = x;
            btn.Top = y;
            btn.Width = width;
            btn.Height = height;
            btn.TabStop = false;
            btn.Name = name;
            btn.Margin = padding;
            btn.Click += even;
            f.Controls.Add(btn);
        }
        public void vvod()
        {
            System.Collections.Generic.List<int> a;
            a = new List<int>();
            for (int i = 1; i < 16; i++)
                a.Add(i);
            int k = 15;
            Random f = new Random();
            while (a.Count != 0)
            {
                int value = f.Next(0, k - 1);
                if (k % 4 == 0)
                    Table[k / 4 - 1, 3] = a[value];
                else
                    Table[k / 4, k % 4 - 1] = a[value];
                k--;
                a.RemoveAt(value);
            };

            if (Table[3, 3] != 0)
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        if (Table[i, j] == 0)
                        {
                            if (i != 3 || j != 3)
                            {

                                Table[i, j] = Table[3, 3];
                                Table[3, 3] = 0;
                            }
                            else
                                continue;
                            break;
                        };
                    }
            i_ = 3;
            j_ = 3;
        }
        public bool IsFinished()
        {
            int t = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (t == Table[i, j] - 1)
                        t++;
            if (t == 15 && Table[3, 3] == 0)
                return true;
            else
                return false;
        }
        public Patnashki()
        {

            Table = new int[4, 4];


            do
            {
                vvod();
            }
            while (!proverka());
        }
    }
}

