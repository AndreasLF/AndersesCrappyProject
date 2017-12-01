using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndersesCrappyProjectFinal1
{
    public partial class Form1 : Form
    {
        Timer gameTimer = new Timer();

        int tg = 1;

        int startX = 0;
        int startY = 0;

        int x = 0;
        int y = 0;

        int v1 = 0;
        int v2 = 0;

        Boolean s = false;


        public Form1()
        {
            InitializeComponent();

            gameTimer.Interval = 1000;
            gameTimer.Tick += new EventHandler(this.m);
            gameTimer.Enabled = true;

        }

        private void m(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Math.Sin(Math.PI * Double.Parse(textBox1.Text) / 180) * Int32.Parse(textBox2.Text));
            int y = Convert.ToInt32(Math.Cos(Math.PI * Double.Parse(textBox1.Text) / 180) * Int32.Parse(textBox2.Text));

            Console.WriteLine("Så er vi igang??" + x + " " + y);

            startX = x;
            startY = y;

            label3.Text = "Position Projektil" + this.x + "," + this.y;


            if (!s)
            {
                this.v1 = startX;
                this.v2 = startY;
            }

            if (s)
            {

                v1 = v1;
                v2 = v2 - tg;

                if (this.y > 0)
                {
                    this.x = this.x + v1;
                    this.y = this.y + v2;
                }

                if (y <= 0)
                {
                    this.y = 0;
                }

            }

            if (Math.Sqrt((this.x - 100) * (this.x - 100) + this.y * this.y) <= 4)
            {
                label4.Text = "TARGET DESTROYED!!";

            }
            else
            {
                label4.Text = "Position Target" + 100 + "," + 0;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!s)
            {
                v1 = startX;
                v2 = startY;
            }

            s = true;

            v2 = v2 - tg;

            x = x + v1;
            y = y + v2;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = false;

            startX = 0;
            startY = 0;

            x = 0;
            y = 0;

            v1 = 0;
            v2 = 0;

        }
    }
}
