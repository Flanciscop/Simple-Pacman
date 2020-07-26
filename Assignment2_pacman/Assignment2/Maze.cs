using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment2
{
    public class Maze
    {
        PictureBox[] boxes;
        const int boxSize = 20;

        public Maze()
        {

        }
        // this method sets all the pictureboxes for the maze, calling two other methods to determine what kind of picturebox they are
        public void MakeMaze(Form form)
        {
            boxes = new PictureBox[400];
            int a = 0;
            int left = 0;
            int top = 0;
            for(int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new PictureBox();
                boxes[i].Width = boxSize;
                boxes[i].Height = boxSize;
                boxes[i].BackColor = Color.Black;
                boxes[i].Tag = "Pellet";
                if (a == 20)
                {
                    top += boxSize;
                    left = 0;
                    a = 0;
                }
                if (a < 20)
                {
                    boxes[i].Left = left;
                    boxes[i].Top = top;
                    form.Controls.Add(boxes[i]);
                    a++;                    
                    left += boxSize;
                }
            }
            MakeWalls();
            PlacePellets();
        }
        // this method sets the walls of the maze
        // *note: its efficiency could be increased by setting the numbers as multiple of the variable "boxSize"
        public void MakeWalls()
        {
            // now we establish the walls
            for (int i = 0; i < boxes.Length; i++)
            {
                // first the walls on the outside
                if (boxes[i].Top == 0)
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 0)
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 380)
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 380)
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                //now the smaller blocks in the middle
                else if (boxes[i].Top == 40 && (boxes[i].Left > 20 && boxes[i].Left < 160))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 40 && (boxes[i].Left > 220 && boxes[i].Left < 360))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 340 && (boxes[i].Left > 20 && boxes[i].Left < 160))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 340 && (boxes[i].Left > 220 && boxes[i].Left < 360))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }           
                else if (boxes[i].Left == 180 && (boxes[i].Top > 20 && boxes[i].Top < 120))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 200 && (boxes[i].Top > 20 && boxes[i].Top < 120))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                // here they touch the outside wall
                else if (boxes[i].Left == 180 && (boxes[i].Top > 260 && boxes[i].Top < 380))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 200 && (boxes[i].Top > 260 && boxes[i].Top < 380))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 40 && (boxes[i].Top > 60 && boxes[i].Top < 200))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 40 && (boxes[i].Top > 200 && boxes[i].Top < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 340 && (boxes[i].Top > 60 && boxes[i].Top < 200))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 340 && (boxes[i].Top > 200 && boxes[i].Top < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 240 && (boxes[i].Left > 60 && boxes[i].Left < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 300 && (boxes[i].Left > 60 && boxes[i].Left < 160))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 300 && (boxes[i].Left > 220 && boxes[i].Left < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 280 && (boxes[i].Left == 240))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 280 && (boxes[i].Left == 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 260 && (boxes[i].Left > 260 && boxes[i].Left < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 260 && (boxes[i].Left > 60 && boxes[i].Left < 120))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 200 && (boxes[i].Left > 240 && boxes[i].Left < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 200 && (boxes[i].Left > 60 && boxes[i].Left < 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 160 && (boxes[i].Left > 240 && boxes[i].Left < 320))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 160 && (boxes[i].Left > 60 && boxes[i].Left < 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 80 && (boxes[i].Top > 60 && boxes[i].Top < 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 120 && (boxes[i].Top > 60 && boxes[i].Top < 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 140 && (boxes[i].Top > 60 && boxes[i].Top < 120))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 300 && (boxes[i].Top > 60 && boxes[i].Top < 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 260 && (boxes[i].Top > 60 && boxes[i].Top < 140))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 240 && (boxes[i].Top > 60 && boxes[i].Top < 120))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                // now make the ghost box
                else if (boxes[i].Left == 160 && (boxes[i].Top > 120 && boxes[i].Top < 220))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Left == 220 && (boxes[i].Top > 120 && boxes[i].Top < 220))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
                else if (boxes[i].Top == 200 && (boxes[i].Left > 160 && boxes[i].Left < 220))
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.wall;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Tag = "Wall";
                }
            }
        }
        // this determines which pictureboxes are pellets and which ones are empty
        public void PlacePellets()
        {
            for(int i=0; i < boxes.Length; i++)
            {
                if((string)boxes[i].Tag == "Pellet")
                {
                    boxes[i].Image = (Bitmap)Properties.Resources.pellet;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if(boxes[i].Left > 160 && boxes[i].Left < 220)
                {
                    // where the ghosts will go
                    if(boxes[i].Top < 200 && boxes[i].Top > 120)
                    {
                        boxes[i].Image = null;
                        boxes[i].Tag = "";
                    }
                    // where pacman will go
                    else if(boxes[i].Left == 200 && boxes[i].Top == 260)
                    {
                        boxes[i].Image = null;
                        boxes[i].Tag = "";
                    }
                }
            }
        }
    }
}
