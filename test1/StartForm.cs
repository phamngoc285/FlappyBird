using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile(@"Resources/StartBackground.jpg");

            GetHighestScore();
        }

        public StartForm(bool isGameOver, int score)
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile(@"Resources/StartBackground.jpg");
            this.IsGamveOver = isGameOver;
            this.Score = score;

            GetHighestScore();

            ShowScore();
        }

        #region Property

        private int HighestScore = 0;

        #endregion

        #region Get Highest Score

        private void GetHighestScore()
        {
            try
            {
                StreamReader stream = new StreamReader("Files/BestScore.txt");

                HighestScore = int.Parse(stream.ReadLine());

                Debug.WriteLine("Highest score: " + HighestScore.ToString());

                labelBestScore.Text = "Highest Score: " + HighestScore;

                stream.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Can not read the highest score");
            }
        }

        #endregion

        #region is gameover

        private bool IsGamveOver = false;
        private int Score;

        private void ShowScore()
        {
            this.LabelScore.Visible = true;
            LabelScore.Text = "Your score: " + Score.ToString();
        }

        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                Form1 playform = new Form1(HighestScore);
                playform.Show();
                this.Hide();
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
