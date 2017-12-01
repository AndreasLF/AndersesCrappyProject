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

        int startVelocityX = 0;
        int startVelocityY = 0;

        int projectilePosX = 0;
        int projectilePosY = 0;

        int v1 = 0;
        int v2 = 0;

        Boolean fireButtonPressed = false;


        public Form1()
        {
            InitializeComponent();

            gameTimer.Interval = 1000;
            gameTimer.Tick += new EventHandler(this.gameLoop);
            gameTimer.Enabled = true;

        }

        private void gameLoop(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Math.Sin(Math.PI * Double.Parse(textBox1.Text) / 180) * Int32.Parse(textBox2.Text));
            int y = Convert.ToInt32(Math.Cos(Math.PI * Double.Parse(textBox1.Text) / 180) * Int32.Parse(textBox2.Text));

            Console.WriteLine("Så er vi igang??" + x + " " + y);

            startVelocityX = x;
            startVelocityY = y;

            label3.Text = "Position Projektil" + this.projectilePosX + "," + this.projectilePosY;


            if (!fireButtonPressed)
            {
                this.v1 = startVelocityX;
                this.v2 = startVelocityY;
            }

            if (fireButtonPressed)
            {

                v1 = v1;
                v2 = v2 - tg;

                if (this.projectilePosY > 0)
                {
                    this.projectilePosX = this.projectilePosX + v1;
                    this.projectilePosY = this.projectilePosY + v2;
                }

                if (y <= 0)
                {
                    this.projectilePosY = 0;
                }

            }

            if (Math.Sqrt((this.projectilePosX - 100) * (this.projectilePosX - 100) + this.projectilePosY * this.projectilePosY) <= 4)
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

            if (!fireButtonPressed)
            {
                v1 = startVelocityX;
                v2 = startVelocityY;
            }

            fireButtonPressed = true;

            v2 = v2 - tg;

            projectilePosX = projectilePosX + v1;
            projectilePosY = projectilePosY + v2;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fireButtonPressed = false;

            startVelocityX = 0;
            startVelocityY = 0;

            projectilePosX = 0;
            projectilePosY = 0;

            v1 = 0;
            v2 = 0;

        }
    }
}
