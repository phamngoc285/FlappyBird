using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Serializing.Helpers;
using test1.Models;


namespace test1
{
    public partial class Form1 : Form
    {
        private int Score =0;

        private int HighestScore = 0;

        private int WaitingTime = 500;
    
        //private int y1, y2, y3;
        private Random random;
        private int showsuggest = 200;



        #region Background & BackgroundSound

        private Bitmap background = new Bitmap(@"Resources/BackgroundDay.png");


        private Media BackgroundSound;

        #endregion

        #region character & pipe

        private Bird bird;

        private Pipe toppipe1;
        private Pipe toppipe2;
        private Pipe toppipe3;

        private Pipe bottompipe1;
        private Pipe bottompipe2;
        private Pipe bottompipe3;

        private List<Pipe> listtoppipe;
        private List<Pipe> listbottompipe;

        private const int Space = 120;
        #endregion

        public static int WidthClient, HeightClient;
        public Form1(int highestScore)
        {
            InitializeComponent();
            Init();

            HighestScore = highestScore;
        }

        private void Init()
        {
            #region Client Size

            Form1.WidthClient = this.ClientSize.Width;
            Form1.HeightClient = this.ClientSize.Height;

            #endregion


            #region SetGraphic

            graphics = this.CreateGraphics();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            backBuffer = new Bitmap(WidthClient, HeightClient);

            #endregion
            
            random = new Random();

            #region init bird and pipe

            

            bird = new Bird(new Point(115, 162));

            toppipe1 = new Pipe(new Point(WaitingTime + 359, 0));
            toppipe1.Height = random.Next(4, 20) * 10;

            toppipe2 = new Pipe(new Point(WaitingTime + 559, 0));
            toppipe2.Height = random.Next(4, 20) * 10;

            toppipe3 = new Pipe(new Point(WaitingTime + 759, 0));
            toppipe3.Height = random.Next(4, 20) * 10;

            
            bottompipe1 = new Pipe();
            bottompipe1.Height = 613 - 200 - toppipe1.Height;
            bottompipe1.Location = new Point(WaitingTime + 359, 613 - bottompipe1.Height);

            bottompipe2 = new Pipe();
            bottompipe2.Height = 613 - 200 - toppipe2.Height;
            bottompipe2.Location = new Point(WaitingTime + 559, 613 - bottompipe2.Height);

            bottompipe3 = new Pipe();
            bottompipe3.Height = 613 - 200 - toppipe3.Height;
            bottompipe3.Location = new Point(WaitingTime + 759, 613 - bottompipe3.Height);

            listtoppipe = new List<Pipe>();
            listtoppipe.Add(toppipe1);
            listtoppipe.Add(toppipe2);
            listtoppipe.Add(toppipe3);

            listbottompipe = new List<Pipe>();
            listbottompipe.Add(bottompipe1);
            listbottompipe.Add(bottompipe2);
            listbottompipe.Add(bottompipe3);


            #endregion
        }

        #region Sprite


        private Bitmap backBuffer;
        
        public Graphics graphics;

        
        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && timer1.Enabled == true)
            {
                bird.Up();
               
                //SoundPlayer sound = new SoundPlayer(test1.Properties.Resources.tap);
                //sound.Play();
            }
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            if (showsuggest <= 0)
            {
                this.labelSuggestion.Visible = false;
            }
            else
            {
                showsuggest -= 10;
            }
            
            Render();

            bird.Down();
            
            if (bird.Index < 3)
            {
                bird.Index++;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        
       
      

        private void Render()
        {
            if (bird.IsDied) return;
            #region Setup Graphic

            Graphics g = Graphics.FromImage(backBuffer);
            g.Clear(Color.White);
            g.DrawImage(background, 0, 0);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            #endregion

            // create bird
            if (bird == null)
            {
                bird = new Bird(new Point(115,162));
            }

           
            
            // set impact
            foreach (var pipe in listtoppipe)
            {
                if (IsImpact(new Rectangle(bird.Location.X, bird.Location.Y, bird.Width, bird.Height),
                    new Rectangle(pipe.Location.X, pipe.Location.Y, pipe.Width, pipe.Height)))
                {
                    this.timer1.Enabled = false;

                    if (Score > HighestScore)
                    {
                        SaveHighestScore(Score);
                    }
                    

                    bird.Die();

                    StartForm startform = new StartForm(true, Score);
                    startform.Show();
                    this.Hide();
                }
            }

            foreach (var pipe in listbottompipe)
            {
                if (IsImpact(new Rectangle(bird.Location.X, bird.Location.Y, bird.Width, bird.Height),
                    new Rectangle(pipe.Location.X, pipe.Location.Y, pipe.Width, pipe.Height)))
                {
                    this.timer1.Enabled = false;

                    if (Score > HighestScore)
                    {
                        SaveHighestScore(Score);
                    }

                    bird.Die();

                    StartForm startform = new StartForm(true, Score);
                    startform.Show();
                    this.Hide();
                }
            }

        
            // create pipe
            for (int i = 0; i < 3; i++)
            {
                listtoppipe[i].MoveToLeft();
                if (listtoppipe[i].Location.X + 80 <=0)
                {
                    this.labelScore.Text = ++Score + "";

                    listtoppipe[i].Height = random.Next(4, 20) * 10;
                    listtoppipe[i].Location = new Point(510, 0);

                    listbottompipe[i].Height = 613 - 200 - listtoppipe[i].Height;
                    listbottompipe[i].Location = new Point(510, 613 - listbottompipe[i].Height);
                }

                listbottompipe[i].MoveToLeft();
                if (listbottompipe[i].Location.X + 80 <= 0)
                {
                    listtoppipe[i].Height = random.Next(4, 20) * 10;
                    listtoppipe[i].Location = new Point(510, 0);

                    listbottompipe[i].Height = 613 - 200 - listtoppipe[i].Height;
                    listbottompipe[i].Location = new Point(510, 613 - listbottompipe[i].Height);
                }
            }

            // draw bird
            g.DrawImage(bird.bm,bird.Location.X,bird.Location.Y, new Rectangle(bird.Width*bird.Index,0,bird.Width,bird.Height), GraphicsUnit.Pixel);

          
            // draw top pipe 

            foreach (var pipe in listtoppipe)
            {
                g.DrawImage(new Bitmap(@"Resources/pipedown.png"),pipe.Location.X,pipe.Location.Y,new Rectangle(0, 500 - pipe.Height, pipe.Width,pipe.Height), GraphicsUnit.Pixel);

            }

            foreach (var pipe in listbottompipe)
            {
                g.DrawImage(new Bitmap(@"Resources/pipe.png"), pipe.Location.X, pipe.Location.Y, new Rectangle(0, 0, pipe.Width, pipe.Height), GraphicsUnit.Pixel);

            }



            Graphics gr = backBufferPanel.CreateGraphics();
            gr.DrawImage(
                backBuffer, new Point(0, 0));
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backBufferPanel_Paint(object sender, PaintEventArgs e)
        {

        }



        #region Impact

        private bool IsImpact(Rectangle a, Rectangle b)
        {
            Rectangle c = Rectangle.Intersect(a, b);
            return !c.IsEmpty;
        }

        #endregion

        #region Save highest score


        private void SaveHighestScore(int score)
        {
            try
            {
                StreamWriter stream = new StreamWriter("Files/BestScore.txt");

                stream.Flush();
                stream.Write(score.ToString());
                stream.Close();
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Can not save highest score");
            }
        }

        #endregion
    }
}
