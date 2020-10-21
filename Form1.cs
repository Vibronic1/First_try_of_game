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
        
        public Player(PointF pos)
        {

        }
    }
   
    public partial class Form1 : Form
    {
        //создание переменных
        Bitmap scene;
        int gametimer = 0;
        Graphics game;
        Player player;
        Brush blackbrush;


        public Form1()
        {
            InitializeComponent();
            //инициализация

            player = new Player(new PointF(player.size,scene.Height/2 + player.size));
            scene = new Bitmap(canvas.Width, canvas.Height);
            game = Graphics.FromImage(scene);
            gameTimer.Start();
            blackbrush = new SolidBrush(Color.Black);


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
            game.Clear(Color.White);
            canvas.Image = scene;
            gametimer++;
            
        }
    }
}
