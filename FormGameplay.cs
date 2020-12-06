using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Checkers_Game.Properties;
using LogicCheckers;

namespace Checkers_Game
{
    public partial class FormGameplay : Form
    {
        private readonly ButtonBoard[,] r_Board;

        private Game m_Game;        
        private Image m_BlackSoldierIcon;
        private Image m_WhiteSoldierIcon;
        private Image m_BlackKingIcon;
        private Image m_WhiteKingIcon;
        private Player m_Player1;
        private Player m_Player2;
        private ButtonBoard m_PreviousClickedButton;

        public FormGameplay(int i_BoardSize, Player i_Player1, Player i_Player2)
        {
            InitializeComponent();

            m_WhiteSoldierIcon = Resources.white;
            m_BlackSoldierIcon = Resources.black;
            m_BlackKingIcon = Resources.blackking;
            m_WhiteKingIcon = Resources.whiteking;
                        
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;

            m_Game = new Game(i_BoardSize, m_Player1, m_Player2);       // initializing board in Logic level
            m_Player1 = m_Game.Player1;
            m_Player2 = m_Game.Player2;

            r_Board = new ButtonBoard[i_BoardSize, i_BoardSize];
            m_PreviousClickedButton = null;

            initializeBoardButtons();

            m_Game.m_reportEndOfRound += game_endRound;

            if (m_Player2.Type == Player.ePlayerType.Computer && m_Player2.Color == m_Game.CurrentTurn && m_Game.BlacksCounter > 0 && m_Game.WhitesCounter > 0)
            {
                generateComputerMove();
            }
        }

        private void initializeBoardButtons()
        {
            for (int i = 0; i < m_Game.Board.GetLength(0); i++)
            {
                initializeLineButtons(i);
            }

            m_LabelPlayer1.Text = string.Format(@"{0} : {1}", m_Player1.Name + " (" + m_Player1.Color + ")", m_Player1.Score);
            m_LabelPlayer2.Text = string.Format(@"{0} : {1}", m_Player2.Name + " (" + m_Player2.Color + ")", m_Player2.Score);
            m_LabelPlayer1.Left = this.Left + 20;
            m_LabelPlayer1.Top = this.Top + 30;
            m_LabelPlayer2.Left = this.Right - m_LabelPlayer2.Width - 40; 
            m_LabelPlayer2.Top = this.Top + 30;

            Controls.Add(m_LabelPlayer1);
            Controls.Add(m_LabelPlayer2);
        }

        private void initializeLineButtons(int i_LineIndex)
        {
            int i = i_LineIndex;
            Point location = new Point(50, 100);
            Size cellSize = new Size(50, 50);

            for (int j = 0; j < m_Game.Board.GetLength(0); j++)
            {
                r_Board[i, j] = new ButtonBoard(m_Game.Board[i, j], new Point(j, i));
                r_Board[i, j].MouseClick += boardButton_ButtonClicked;

                Point currentCell = new Point(location.X + (50 * j), location.Y + (50 * i));

                r_Board[i, j].Location = currentCell;
                r_Board[i, j].Size = cellSize;                               

                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                {
                    r_Board[i, j].BackColor = Color.LightGray;
                    r_Board[i, j].Enabled = false;
                }
                else
                {
                    r_Board[i, j].BackColor = Color.FloralWhite;

                    if (m_Game.Board[i, j] != null && m_Game.Board[i, j].Color == ePlayerColor.White)
                    {
                        if (m_Game.Board[i, j].Type == Checker.eCheckerType.Soldier)
                        {
                            r_Board[i, j].BackgroundImage = m_WhiteSoldierIcon;
                        }
                        else
                        {
                            r_Board[i, j].BackgroundImage = m_WhiteKingIcon;
                        }

                        r_Board[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (m_Game.Board[i, j] != null && m_Game.Board[i, j].Color == ePlayerColor.Black)
                    {
                        if (m_Game.Board[i, j].Type == Checker.eCheckerType.Soldier)
                        {
                            r_Board[i, j].BackgroundImage = m_BlackSoldierIcon;
                        }
                        else
                        {
                            r_Board[i, j].BackgroundImage = m_BlackKingIcon;
                        }

                        r_Board[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }

                Controls.Add(r_Board[i, j]);               
            }
        }

        private bool askIfAnotherRound(string i_Result)
        {
            string output = string.Format(
@"      {0}

        Do you want another round?",
i_Result);
            bool anotherRound = false;
            DialogResult result = MessageBox.Show(output, "End of Round", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                anotherRound = true;
            }
            else
            {
                this.Dispose();
                this.Close();
            }

            return anotherRound;
        }

        private void makeMove(Move i_CurrentMove)
        {
            ButtonBoard currentButton = null;

            foreach (ButtonBoard button in r_Board)
            {
                if (button.Position == i_CurrentMove.End)
                {
                    currentButton = button;
                    break;
                }
            }

            if (i_CurrentMove.CheckIfEatingMove())
            {
                currentButton.Checker = m_PreviousClickedButton.Checker;
                m_PreviousClickedButton.Checker = null;
                currentButton.BackgroundImage = m_PreviousClickedButton.BackgroundImage;
                currentButton.BackgroundImageLayout = ImageLayout.Stretch;
                m_PreviousClickedButton.BackgroundImage = null;

                foreach (ButtonBoard button in r_Board)
                {
                    if (button.Position.X == (m_PreviousClickedButton.Position.X + currentButton.Position.X) / 2 &&
                       button.Position.Y == (m_PreviousClickedButton.Position.Y + currentButton.Position.Y) / 2)
                    {
                        button.BackgroundImage = null;
                        button.Checker = null;
                    }
                }
            }
            else
            {
                currentButton.Checker = m_PreviousClickedButton.Checker;
                m_PreviousClickedButton.Checker = null;
                currentButton.BackgroundImage = m_PreviousClickedButton.BackgroundImage;
                currentButton.BackgroundImageLayout = ImageLayout.Stretch;
                m_PreviousClickedButton.BackgroundImage = null;
            }

            if (i_CurrentMove.End.Y == 0 && currentButton.Checker != null && currentButton.Checker.Color == ePlayerColor.White)
            {
                currentButton.Checker.Type = Checker.eCheckerType.King;
                currentButton.BackgroundImage = Resources.whiteking;
            }
            else if (i_CurrentMove.End.Y == r_Board.GetLength(0) - 1 && currentButton.Checker != null && currentButton.Checker.Color == ePlayerColor.Black)
            {
                currentButton.Checker.Type = Checker.eCheckerType.King;
                currentButton.BackgroundImage = Resources.blackking;
            }            
        }

        private void generateComputerMove()
        {
            Move? generatedMove = m_Game.GenerateMove();            

            foreach (ButtonBoard button in r_Board)
            {
                if (button.Position == generatedMove.Value.Start)
                {
                    m_PreviousClickedButton = button;
                    break;
                }
            }
                        
            if (generatedMove != null)
            {
                // Make actual move on board
                makeMove(generatedMove.Value);

                // for making additional eating moves
                while (m_Game.CurrentPlayer().Type == Player.ePlayerType.Computer)
                {
                    generateComputerMove();
                } 
            }

            m_PreviousClickedButton = null;
        }

        private void boardButton_ButtonClicked(object sender, EventArgs e)
        {
            ButtonBoard currentClickedButton = sender as ButtonBoard;
            
            foreach (ButtonBoard button in r_Board)
            {
                if (button.Enabled == true)
                {
                    button.BackColor = Color.FloralWhite;
                }
            }                       

            if (m_PreviousClickedButton != null)
            {
                if (m_PreviousClickedButton == currentClickedButton)
                {
                    // return color to white 
                    m_PreviousClickedButton = null;
                }
                else if (currentClickedButton.Checker == null)
                {
                    Move currentMove = new Move(m_PreviousClickedButton.Position, currentClickedButton.Position);

                    if (m_Game.CheckIfMoveIsLegal(currentMove))
                    {
                        // Make actual move on Form board
                        makeMove(currentMove);
                        m_PreviousClickedButton = null;
                    }
                    else
                    {
                        MessageBox.Show("Move is Not Legal!", "Wrong Move!", MessageBoxButtons.OK);
                        m_PreviousClickedButton = null;
                    }
                }
                else
                {
                    MessageBox.Show("Move is Not Legal!", "Wrong Move!", MessageBoxButtons.OK);
                    m_PreviousClickedButton = null;
                }

                m_Game.CheckIfEndOfRound();
            }
            else
            {
                currentClickedButton.BackColor = Color.BlueViolet;
                m_PreviousClickedButton = currentClickedButton;
            }

            if (m_Player2.Type == Player.ePlayerType.Computer && m_Player2.Color == m_Game.CurrentTurn && m_Game.BlacksCounter > 0 && m_Game.WhitesCounter > 0)
            {
                generateComputerMove();
                m_Game.CheckIfEndOfRound();
            }            
        }

        private void game_endRound(int i_Score)
        {
            m_Game.CurrentPlayer().Score += i_Score;

            // tie option
            if (i_Score == 0)       
            {
                if (askIfAnotherRound("its a Tie!"))
                {
                    this.Dispose();
                    this.Close();

                    FormGameplay newRound = new FormGameplay(r_Board.GetLength(0), m_Player1, m_Player2);

                    newRound.ShowDialog();
                }
            }
            else if (askIfAnotherRound("Player: " + m_Game.CurrentPlayer().Name + " Won!"))
            {
                m_PreviousClickedButton = null;
                this.Dispose();
                this.Close();

                FormGameplay newRound = new FormGameplay(r_Board.GetLength(0), m_Player1, m_Player2);

                newRound.ShowDialog();
            }
        }        
    }
}
