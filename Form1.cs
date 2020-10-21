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

namespace First_try_of_game
{

    public class Player
    {
        public PointF pos;
        public PointF acc;
        public float size = 30f;
        public float speed = 5f;
        public float fade = 0.9f;
        
        public Player(PointF pos)
        {
            this.pos = pos;
            this.acc = new PointF(0, 0);
        
    }
    }
    public class Shot
    {
        public PointF pos;
        public PointF acc;
        public float size = 10;
        public float lifeTime = 200;

        public Shot(PointF pos, PointF acc)
        {
            this.pos = pos;
            this.acc = acc;
        }
    }


    public partial class Form1 : Form
    {
        //создание переменных
        Bitmap scene;
        int gametimer = 0;
        Graphics game;
        Player player;
        Font mainFont;
        Brush blackbrush;

      
         List<Shot> shots;
        bool keyW = false;
        bool keyA = false;
        bool keyS = false;
        bool keyD = false;
        bool keySpace = false;

        public Form1()
        {
            InitializeComponent();
            //инициализация


            gameTimer.Interval = 1000 / 30;
            gameTimer.Start();


            scene = new Bitmap(canvas.Width, canvas.Height);
            game = Graphics.FromImage(scene);  
            blackbrush = new SolidBrush(Color.Black);
            player = new Player(new PointF(scene.Width / 2, scene.Height / 2));
            shots = new List<Shot>();
            mainFont = new Font(FontFamily.GenericSansSerif, 15);

        }
        // Обработка нажатия кнопок клавиатуры
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) this.keyW = true;
            if (e.KeyCode == Keys.A) this.keyA = true;
            if (e.KeyCode == Keys.S) this.keyS = true;
            if (e.KeyCode == Keys.D) this.keyD = true;
            if (e.KeyCode == Keys.Space) this.keySpace = true;
        }

        // Обработка нажатия кнопок клавиатуры
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) this.keyW = false;
            if (e.KeyCode == Keys.A) this.keyA = false;
            if (e.KeyCode == Keys.S) this.keyS = false;
            if (e.KeyCode == Keys.D) this.keyD = false;
            if (e.KeyCode == Keys.Space) this.keySpace = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.FillEllipse(
                blackbrush,
                player.pos.X - player.size / 2f,
                player.pos.Y - player.size / 2f,
                player.size,
                player.size
            );
            game.Clear(Color.Black);
          //  game.DrawImage( 0, 0, scene.Width, scene.Height);

            game.DrawString(
                  Convert.ToString(player.pos),
                  mainFont,
                  blackbrush,
                  0,
                  0
              );
            canvas.Image = scene;
            gametimer++;
            if (keyW) player.acc.Y -= player.speed;
            if (keyA) player.acc.X -= player.speed;
            if (keyS) player.acc.Y += player.speed;
            if (keyD) player.acc.X += player.speed;

            // Логика игрового перемещения
            player.pos.X += player.acc.X;
            player.pos.Y += player.acc.Y;
            player.acc.X *= player.fade;
            player.acc.Y *= player.fade;


            if (player.pos.X < 0)
            {
                player.pos.X = 0;
                player.acc.X *= -1f;
            }
            if (player.pos.Y < 0)
            {
                player.pos.Y = 0;
                player.acc.Y *= -1f;
            }
            if (player.pos.X > scene.Width)
            {
                player.pos.X = scene.Width;
                player.acc.X *= -1f;
            }
            if (player.pos.Y > scene.Height)
            {
                player.pos.Y = scene.Height;
                player.acc.Y *= -1f;
            }
            var direction = new PointF(
                    (float)Math.Sin(gametimer / 10f),
                    (float)Math.Cos(gametimer / 10f)
            );
            game.DrawLine(
               new Pen(Color.Red, 3),
               player.pos,
               new PointF(
                   player.pos.X + direction.X * player.size / 2f,
                   player.pos.Y + direction.Y * player.size / 2f
               )
           );
            if (keySpace)
            {
                var speed = 5f;
                shots.Add(new Shot(player.pos, new PointF(direction.X * speed, direction.Y * speed)));
            }
            for (var i = 0; i < shots.Count; i++)
            {
                var shot = shots[i];

                game.FillEllipse(
                   new SolidBrush(Color.FromArgb(255 - (int)(200 - shot.lifeTime), Color.Yellow)),
                   shot.pos.X - shot.size / 2f,
                   shot.pos.Y - shot.size / 2f,
                   shot.size,
                   shot.size
               );
                shot.pos.X += shot.acc.X;
                shot.pos.Y += shot.acc.Y;
                shot.lifeTime--;
                if (shot.lifeTime <= 0)
                {
                    shots.RemoveAt(i);
                    i--;
                }
            }
        }
        }
}

