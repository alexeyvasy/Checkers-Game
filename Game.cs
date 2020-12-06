using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LogicCheckers
{
    public enum ePlayerColor
    {
        White = 1,
        Black = -1
    }

    public class Game
    {
        public const int k_SinglePlayer = 1;
        public const int k_MultiPlayer = 2;

        private readonly Checker[,] r_Board;
        private readonly List<Move> r_CurrentPossibleMoves;
        
        private ePlayerColor m_CurrentTurn;
        private int m_WhitesCounter;
        private int m_BlacksCounter;
        private Player m_Player1;
        private Player m_Player2;

        public event Action<int> m_reportEndOfRound;

        public Game(int i_BoardSize, Player i_Player1, Player i_Player2)
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            r_CurrentPossibleMoves = new List<Move>();
            r_Board = new Checker[i_BoardSize, i_BoardSize];
            initializeBoard(i_BoardSize);
        }

        public ePlayerColor CurrentTurn
        {
            get { return m_CurrentTurn; }
        }

        public Checker[,] Board
        {
            get { return r_Board; }
        }

        public int WhitesCounter
        {
            get { return m_WhitesCounter; }
            set { m_WhitesCounter = value; }
        }

        public int BlacksCounter
        {
            get { return m_BlacksCounter; }
            set { m_BlacksCounter = value; }
        }

        public Player Player1
        {
            get { return m_Player1; }
        }

        public Player Player2
        {
            get { return m_Player2; }
        }

        public List<Move> CurrentPossibleMoves
        {
            get { return r_CurrentPossibleMoves; }
        }

        private void initializeBoard(int i_BoardSize)
        {
            m_CurrentTurn = ePlayerColor.White;            
            m_BlacksCounter = 0;
            m_WhitesCounter = 0;
            colorToss();

            // initialize the black checkers on the board
            for (int i = 0; i < (i_BoardSize / 2) - 1; i++)           
            {
                for (int j = (i + 1) % 2; j < i_BoardSize; j += 2)
                {
                    r_Board[i, j] = new Checker(ePlayerColor.Black, new Point(j, i));
                    m_BlacksCounter++;
                }
            }

            // initialize the white checkers on the board
            for (int i = i_BoardSize - 1; i > i_BoardSize / 2; i--)       
            {
                for (int j = (i + 1) % 2; j < i_BoardSize; j += 2)
                {
                    r_Board[i, j] = new Checker(ePlayerColor.White, new Point(j, i));
                    m_WhitesCounter++;
                }
            }
        }

        private void colorToss()
        {
            Random number = new Random();

            // deciding who is going first as whites.
            if (number.Next() % 2 == 0)             
            {
                m_Player1.Color = ePlayerColor.White;
                m_Player2.Color = ePlayerColor.Black;
            }
            else
            {
                m_Player1.Color = ePlayerColor.Black;
                m_Player2.Color = ePlayerColor.White;
            }
        }

        public Move? GenerateMove()
        {
            Move? computerMove = new Move();

            if (r_CurrentPossibleMoves.Count == 0)
            {
                UpdateCurrentPossibleMovesInCheckers();
            }

            int number;
            Random random = new Random();

            number = random.Next(0, r_CurrentPossibleMoves.Count);

            if (r_CurrentPossibleMoves.Count > 0)
            {
                computerMove = r_CurrentPossibleMoves[number];
                CheckIfCurrentMoveExistsInList(computerMove.Value);
            }
            else
            {
                computerMove = null;
            }

            return computerMove.Value;
        }

        public bool CheckIfMoveIsLegal(Move i_CurrentMove)
        {
            bool isLegalMove = true;

            UpdateCurrentPossibleMovesInCheckers();
            isLegalMove = CheckIfCurrentMoveExistsInList(i_CurrentMove);

            return isLegalMove;
        }

        private void checkAdditionalEatingMoves(Checker i_Checker)
        {
            i_Checker.EatingMovesInsertToList(r_Board);

            foreach (Move move in i_Checker.PossibleMoves)
            {
                r_CurrentPossibleMoves.Add(move);
            }
        }

        private void updateBoard(Move i_CurrentMove)
        {
            r_Board[i_CurrentMove.End.Y, i_CurrentMove.End.X] = new Checker(m_CurrentTurn, i_CurrentMove.End, r_Board[i_CurrentMove.Start.Y, i_CurrentMove.Start.X].Type);
            r_Board[i_CurrentMove.Start.Y, i_CurrentMove.Start.X] = null;

            if (i_CurrentMove.End.Y == 0 || i_CurrentMove.End.Y == (r_Board.GetLength(0) - 1))
            {
                r_Board[i_CurrentMove.End.Y, i_CurrentMove.End.X].Type = Checker.eCheckerType.King;
            }

            updateCurrentTurn();

            if (i_CurrentMove.CheckIfEatingMove())
            {
                int i = (i_CurrentMove.End.Y + i_CurrentMove.Start.Y) / 2;
                int j = (i_CurrentMove.End.X + i_CurrentMove.Start.X) / 2;

                r_Board[i, j] = null;       // eaten checker becomes empty square on the board

                if (m_CurrentTurn == ePlayerColor.White)
                {
                    m_WhitesCounter--;
                }
                else
                {
                    m_BlacksCounter--;
                }
            }
        }

        private void updateCurrentTurn()
        {
            m_CurrentTurn = (ePlayerColor)((int)m_CurrentTurn * -1);
        }

        public void UpdateCurrentPossibleMovesInCheckers()
        {
            if (r_CurrentPossibleMoves.Count == 0)
            {
                foreach (Checker checker in r_Board)
                {
                    if (checker != null && checker.Color == m_CurrentTurn)
                    {
                        checker.EatingMovesInsertToList(r_Board);
                    }
                }

                foreach (Checker checker in r_Board)
                {
                    if (checker != null && checker.Color == m_CurrentTurn)
                    {
                        r_CurrentPossibleMoves.AddRange(checker.PossibleMoves);
                    }
                }

                if (r_CurrentPossibleMoves.Count == 0)
                {
                    foreach (Checker checker in r_Board)
                    {
                        if (checker != null && checker.Color == m_CurrentTurn)
                        {
                            checker.RegularMovesInsertToList(r_Board);
                        }
                    }

                    foreach (Checker checker in r_Board)
                    {
                        if (checker != null && checker.Color == m_CurrentTurn)
                        {
                            r_CurrentPossibleMoves.AddRange(checker.PossibleMoves);
                        }
                    }
                }
            }
        }

        public void CheckIfEndOfRound()
        {
            UpdateCurrentPossibleMovesInCheckers();

            // check if a tie (draw) if both sides remaining with 1 king only
            if (r_CurrentPossibleMoves.Count == 0)
            {
                endRound();
            }
            else if (WhitesCounter == 1 && BlacksCounter == 1)      
            {
                foreach (Checker checker1 in r_Board)
                {
                    if (checker1 != null && checker1.Type == Checker.eCheckerType.King && checker1.Color == ePlayerColor.White)
                    {
                        foreach (Checker checker2 in r_Board)
                        {
                            if (checker2 != null && checker2.Type == Checker.eCheckerType.King && checker2.Color == ePlayerColor.Black)
                            {
                                endRound();
                            }
                        }
                    }
                }
            }

            r_CurrentPossibleMoves.Clear();
        }

        public bool CheckIfCurrentMoveExistsInList(Move i_CurrentMove)
        {
            bool isPossible = false;

            foreach (Move move in r_CurrentPossibleMoves)
            {
                if (move.Equals(i_CurrentMove))
                {
                    isPossible = true;

                    if (move.CheckIfEatingMove())
                    {
                        updateBoard(move);
                        r_CurrentPossibleMoves.Clear();
                        checkAdditionalEatingMoves(r_Board[move.End.Y, move.End.X]);    // insert possible additional eating moves of this current checker to list

                        if (r_CurrentPossibleMoves.Count != 0)
                        {
                            updateCurrentTurn();
                        }
                    }
                    else
                    {
                        updateBoard(move);
                        r_CurrentPossibleMoves.Clear(); // clear the possible moves list
                    }

                    break;
                }
            }      
            
            return isPossible;
        }

        public Player CurrentPlayer()
        {
            Player currentPlayer;

            if (m_CurrentTurn == m_Player1.Color)
            {
                currentPlayer = m_Player1;
            }
            else
            {
                currentPlayer = m_Player2;
            }

            return currentPlayer;
        }

        private int calculateScore()
        {
            int score = 0;

            foreach (Checker checker in r_Board)
            {
                if (checker != null && checker.Color != m_CurrentTurn)
                {
                    if (checker.Type == Checker.eCheckerType.Soldier)
                    {
                        score++;
                    }
                    else if (checker.Type == Checker.eCheckerType.King)
                    {
                        score += 4;
                    }
                }
                else if (checker != null)
                {
                    if (checker.Type == Checker.eCheckerType.Soldier)
                    {
                        score--;
                    }
                    else if (checker.Type == Checker.eCheckerType.King)
                    {
                        score -= 4;
                    }
                }
            }

            if (score < 0)
            {
                score = 0;
            }

            return score;
        }

        private void endRound()
        {   
            int score = calculateScore();
            updateCurrentTurn();            
            notifyEndOfGameObservers(score);           
        }

        protected virtual void notifyEndOfGameObservers(int i_Score)
        {
            if (m_reportEndOfRound != null)
            {
                m_reportEndOfRound.Invoke(i_Score);
            }
        }        
    }
}