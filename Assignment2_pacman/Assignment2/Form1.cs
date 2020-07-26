using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Program name: 	    Pacman
   Project file name:   Assignment 2
   Author:		        Francisco Salazar
   Date:	            21/07/2020
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2019
   Purpose:		        This program runs a basic pacman game
   Description:		    This program allows a user to move a pacman around a maze collecting all the little pellets or kibble while avoiding the ghosts
                        If the player is eaten by the ghosts then they loses, if they eat all the kibble first they win
   Known Bugs:		    Sometimes the pacman gets a bit stuck in the walls but a few presses of the directional keys will get him out. 
                        A rarer bug that im not sure how it happens but sometimes one of the ghosts disappears
   Additional Features: 
*/
namespace Assignment2
{
    public partial class Form1 : Form
    {
        bool goLeft;
        bool goRight;
        bool goUp;
        bool goDown;
        bool gameOver;

        Maze maze;
        Pacman pacman;
        Ghost ghost1;
        Ghost ghost2;
        Ghost ghost3;

        public Form1()
        {
            InitializeComponent();
            maze = new Maze();
            pacman = new Pacman(4,4,2);
            ghost1 = new Ghost(180, 140, (Bitmap)Properties.Resources.green_ghost);
            ghost2 = new Ghost(180, 160, (Bitmap)Properties.Resources.red_ghost);
            ghost3 = new Ghost(180, 180, (Bitmap)Properties.Resources.yellow_ghost);
            SetUp();
        }
        // this method sets up all the pieces 
        public void SetUp()
        {
            gameOver = false;
            ghost1.SetGhost(this);
            ghost2.SetGhost(this);
            ghost3.SetGhost(this);
            pacman.SetPacman(this);
            maze.MakeMaze(this);
            
        }
        // here the game's timer dictates the play
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Score: " + pacman.Score;
            label2.Text = "Lives: " + pacman.Lives;
            pacman.MovePacman(this, goLeft, goRight, goUp, goDown);
            ghost1.MoveGhost(this);
            ghost2.MoveGhost(this);
            ghost3.MoveGhost(this);
            // check if game is over
            if (pacman.Score==189)
            {
                gameOver = true;
                EndGame("You win! Score: " + pacman.Score);
            }
            else if (pacman.Lives == 0)
            {
                gameOver = true;
                EndGame("You lose. Score: " + pacman.Score);
            }
            // check if pacman hits ghost
            foreach (Control x in this.Controls)
            {
                if ((string)x.Tag == "Ghost")
                {
                    if (pacman.PacmanBox.Bounds.IntersectsWith(ghost1.GhostBox.Bounds))
                    {
                        pacman.Lives--;
                        pacman.PacmanBox.Left = 200;
                        pacman.PacmanBox.Top = 260;
                    }
                    else if (pacman.PacmanBox.Bounds.IntersectsWith(ghost2.GhostBox.Bounds))
                    {
                        pacman.Lives--;
                        pacman.PacmanBox.Left = 200;
                        pacman.PacmanBox.Top = 260;
                    }
                    else if (pacman.PacmanBox.Bounds.IntersectsWith(ghost3.GhostBox.Bounds))
                    {
                        pacman.Lives--;
                        pacman.PacmanBox.Left = 200;
                        pacman.PacmanBox.Top = 260;
                    }
                }
            }
            
        }
        // this method activates when the game is over
        public void EndGame(string message)
        {
            if (gameOver == true)
            {
                timer1.Stop();
                MessageBox.Show(message);
            }
        }
        // this allows the movement of pacman
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && pacman.PacmanBox.Left>20)
            {
                goLeft = true;
            }            
            if (e.KeyCode == Keys.Right && pacman.PacmanBox.Left<this.Width-40)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && pacman.PacmanBox.Top>20)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && pacman.PacmanBox.Top<380)
            {
                goDown = true;
            }
            
        }
        // this stops the movement of pacman
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }
    }
}
