using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace First_try_of_game
{

    
   
    public partial class Form1 : Form
    {
        //создание переменных
        Bitmap scene;
        const int ogranichitel = 10;
        Graphics game;
        Player start;
        Brush blackbrush;
        int gametimer = 0;
        Pen blackpen;
        PointF now;
        PointF old;
        public Form1()
        {
            InitializeComponent();
            //инициализация

            
            scene = new Bitmap(canvas.Width, canvas.Height);
            game = Graphics.FromImage(scene);
            
            blackpen = new Pen(Color.Black);
            blackbrush = new SolidBrush(Color.Black);
            start = new Player(new PointF(0,0),new PointF(0,0),new PointF(0,0));
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();

            //game.Clear(Color.White);
            //game.FillEllipse(blackbrush, player.A.X , player.A.Y , player.size, player.size);
            //game.FillEllipse(blackbrush, player.B.X , player.B.Y , player.size, player.size);
            //game.FillEllipse(blackbrush, player.C.X , player.C.Y , player.size, player.size);
            // game.DrawLine(,player.pos.X, player.pos.Y, player.pos.X, player.pos.Y);
            old = now;
            switch ( rand.Next(0, 3))
            {
                case 0:
                    if ((Math.Abs(start.A.X - now.X)> ogranichitel) && (Math.Abs(start.A.Y - now.Y)> ogranichitel)) { 
                    now.X += (0.5f * (start.A.X-now.X));
                    now.Y += (0.5f * (start.A.Y-now.Y));
                        game.FillEllipse(blackbrush, now.X, now.Y, 5, 5);
                    }
                    break;
                case 1:
                    if ((Math.Abs(start.B.X - now.X) > ogranichitel) && (Math.Abs(start.B.Y - now.Y) > ogranichitel))
                    {
                        now.X += (0.5f * (start.B.X - now.X));
                        now.Y += (0.5f * (start.B.Y - now.Y));
                        game.FillEllipse(blackbrush, now.X, now.Y, 5, 5);
                    }
                    break;
                case 2:
                    if ((Math.Abs(start.C.X - now.X) > ogranichitel) && (Math.Abs(start.C.Y - now.Y) > ogranichitel))
                    {
                        now.X += (0.5f * (start.C.X - now.X));
                        now.Y += (0.5f * (start.C.Y - now.Y));
                        game.FillEllipse(blackbrush, now.X, now.Y, 5, 5);
                    }
                    break; }
           
            canvas.Image = scene;
            gametimer++;
            
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if ( (start.A.X>0)&&(start.A.X < scene.Width) &&
                (start.A.Y > 0) && (start.A.Y < scene.Width) &&
                (start.B.X > 0) && (start.B.X < scene.Width) &&
                (start.B.Y > 0) && (start.B.Y < scene.Width) &&
                (start.C.X > 0) && (start.C.X < scene.Width) &&
                (start.C.Y > 0) && (start.C.Y < scene.Width) )
            {
                label_Ax.Enabled = false;
                label_Bx.Enabled = false;
                label_Cx.Enabled = false;
                label_Ay.Enabled = false;
                label_By.Enabled = false;
                label_Cy.Enabled = false;
                Enter.Enabled = false;
                gameTimer.Start();
                game.FillEllipse(blackbrush, start.A.X, start.A.Y, start.size, start.size);
                game.FillEllipse(blackbrush, start.B.X, start.B.Y, start.size, start.size);
                game.FillEllipse(blackbrush, start.C.X, start.C.Y, start.size, start.size);
                now = start.A;
            }
            
           
        }

        public int stringToInt(string c)
        {
            int x=0;
            for (int i = 0; i < c.Length; i++)
            {
                if ((c[i]=='0')|| (c[i] == '1') || (c[i] == '2') || (c[i] == '3') || (c[i] == '4') || (c[i] == '5') || (c[i] == '6') || (c[i] == '7') || (c[i] == '8') || (c[i] == '9'))
                {
                    switch (c[i])
                    {
                        case '0':
                            x = x * 10 + 0;
                            break;
                        case '1':
                            x = x * 10 + 1;
                            break;
                        case '2':
                            x = x * 10 + 2;
                            break;
                        case '3':
                            x = x * 10 + 3;
                            break;
                        case '4':
                            x = x * 10 + 4;
                            break;
                        case '5':
                            x = x * 10 + 5;
                            break;
                        case '6':
                            x = x * 10 + 6;
                            break;
                        case '7':
                            x = x * 10 + 7;
                            break;
                        case '8':
                            x = x * 10 + 8;
                            break;
                        case '9':
                            x = x * 10 + 9;
                            break;
                        
                    }
                }
                else { return -1; }
            }
            
            return x;
        }

        private void label_Ax_TextChanged(object sender, EventArgs e)
        {

            if (stringToInt(label_Ax.Text) == -1) { label_Ax.Text = "Это не цифра"; } else { start.A.X = stringToInt(label_Ax.Text); }
        }

        private void label_Bx_TextChanged(object sender, EventArgs e)
        {
            if (stringToInt(label_Bx.Text) == -1) { label_Bx.Text = "Это не цифра"; } else { start.B.X = stringToInt(label_Bx.Text); }
        }

        private void label_Cx_TextChanged(object sender, EventArgs e)
        {
            if (stringToInt(label_Cx.Text) == -1) { label_Cx.Text = "Это не цифра"; } else { start.C.X = stringToInt(label_Cx.Text); }
        }

        private void label_Cy_TextChanged(object sender, EventArgs e)
        {
            if (stringToInt(label_Cy.Text) == -1) { label_Cy.Text = "Это не цифра"; } else { start.C.Y = stringToInt(label_Cy.Text); }
        }

        private void label_By_TextChanged(object sender, EventArgs e)
        {
            if (stringToInt(label_By.Text) == -1) { label_By.Text = "Это не цифра"; } else { start.B.Y = stringToInt(label_By.Text); }
        }

        private void label_Ay_TextChanged(object sender, EventArgs e)
        {
            if (stringToInt(label_Ay.Text) == -1) { label_Ay.Text = "Это не цифра"; } else { start.A.Y = stringToInt(label_Ay.Text); }
        }
    }
    
    public class Player
    {
        public PointF A;
        public PointF B;
        public PointF C;
        public PointF acc;
        public float size = 30f;

        public Player(PointF A, PointF B, PointF C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.acc = new PointF(0, 0);
        }
    }
}
