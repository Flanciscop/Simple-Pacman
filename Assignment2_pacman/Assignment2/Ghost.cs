using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public class Ghost
    {
        private PictureBox pictureBox;
        private int left;
        private int top;
        private Image image;
        private int xMove = 0;
        private int yMove = -5;
        private Random random;
        public Ghost(int left, int top, Image image)
        {
            this.left = left;
            this.top = top;
            this.image = image;
            random = new Random();
        }

        // the ghost's initial characteristics are set
        public void SetGhost(Form form)
        {
            pictureBox = new PictureBox();
            pictureBox.Width = 15;
            pictureBox.Height = 15;
            pictureBox.Left = left;
            pictureBox.Top = top;
            pictureBox.BackColor = Color.Black;
            pictureBox.Tag = "Ghost";
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            form.Controls.Add(pictureBox);
        }
        // this method determines the ghost's movement
        public void MoveGhost(Form form)
        {            
            int rnd = random.Next(4);
            pictureBox.Left += xMove;
            pictureBox.Top += yMove;

            foreach(Control x in form.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "Wall")
                {
                    if (yMove != 0 && pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox.Top += yMove*-1;
                        yMove = 0;
                        if(rnd == 0)
                        {
                            xMove = 5;
                        }
                        else if (rnd==2)
                        {
                            xMove = -5;
                        }
                        else if (rnd == 3)
                        {
                            yMove = 5;
                        }
                        else
                        {
                            yMove = 5;
                        }
                    }
                    else if (xMove != 0 && pictureBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBox.Left += xMove*-1;
                        xMove = 0;
                        if (rnd == 0)
                        {
                            yMove = 5;
                        }
                        else if(rnd == 2)
                        {
                            yMove = -5;
                        }
                        else if (rnd == 3 )
                        {
                            xMove = 5;
                        }
                        else
                        {
                            xMove = -5;
                        }
                    }
                }
            }

        }
        public PictureBox GhostBox { get => pictureBox; set => pictureBox = value; }

    }
}
