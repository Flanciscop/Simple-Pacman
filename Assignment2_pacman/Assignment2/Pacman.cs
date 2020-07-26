using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public class Pacman
    {
        PictureBox pictureBox;
        int xSpeed;
        int ySpeed;
        int score;
        int lives;

        public Pacman(int xSpeed, int ySpeed, int lives)
        {
            this.lives = lives;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;
            pictureBox = new PictureBox();
        }
        // this method determines the characteristecs of pacman 
        public void SetPacman(Form form)
        {            
            pictureBox.Width = 15;
            pictureBox.Height = 15;
            pictureBox.Left = 200;
            pictureBox.Top = 260;
            pictureBox.BackColor = Color.Black;
            pictureBox.Image = (Bitmap)Properties.Resources.left;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            form.Controls.Add(pictureBox);
        }
        //this method determines how pacman moves and interacts with his surroundings
        public void MovePacman(Form form, bool left, bool right, bool up, bool down)
        {
            // here his speed, direction and respective animation is set
            if(left == true)
            {
                pictureBox.Left -= xSpeed;
                pictureBox.Image = Properties.Resources.left;
            }
            if (right == true)
            {
                pictureBox.Left += xSpeed;
                pictureBox.Image = Properties.Resources.right;
            }
            if (up == true)
            {
                pictureBox.Top -= ySpeed;
                pictureBox.Image = Properties.Resources.Up;
            }
            if (down == true)
            {
                pictureBox.Top += ySpeed;
                pictureBox.Image = Properties.Resources.down;
            }
            // here his interaction with the pellets is determined
            foreach (Control x in form.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Pellet")
                {
                    if (pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        form.Controls.Remove(x);
                        score++;
                    }
                }
            }
            // checking if pacman hits the wall, stop movement
            foreach (Control x in form.Controls)
            {
                if (left == true && (string)x.Tag == "Wall")
                {
                    if (pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox.Left += xSpeed;
                    }
                }
                else if (right == true && (string)x.Tag == "Wall")
                {
                    if (pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox.Left -= xSpeed;
                    }
                }
                else if (up == true && (string)x.Tag == "Wall")
                {
                    if (pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox.Top += ySpeed;
                    }
                }
                else if (down == true && (string)x.Tag == "Wall")
                {
                    if (pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox.Top -= ySpeed;
                    }
                }
            }

        }

        public int Score { get => score; set => score = value; }
        public PictureBox PacmanBox { get => pictureBox; set => pictureBox = value; }
        public int Lives { get => lives; set => lives = value; }

    }
}
