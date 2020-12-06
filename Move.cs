using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LogicCheckers
{
    public struct Move
    {
        private Point m_Start;
        private Point m_End;
        
        public Move(Point i_Start, Point i_End)
        {
            m_Start = i_Start;
            m_End = i_End;
        }

        public Point Start
        {
            get { return m_Start; }
            set { m_Start = value; }
        }

        public Point End
        {
            get { return m_End; }
            set { m_End = value; }
        }

        public bool QuitRoundOrConvertStringToMove(string i_Move)
        {
            bool isQuit = false;

            if (i_Move != null)
            {
                m_Start.X = i_Move[0] - 'A';
                m_Start.Y = i_Move[1] - 'a';
                m_End.X = i_Move[3] - 'A';
                m_End.Y = i_Move[4] - 'a';
            }
            else
            {
                isQuit = true;
            }

            return isQuit;
        }

        public bool CheckIfEatingMove()
        {
            bool isEatingMove = false;

            if (m_End.X - m_Start.X == 2 || m_End.X - m_Start.X == -2)
            {
                isEatingMove = true;
            }

            return isEatingMove;
        }
    }
}
