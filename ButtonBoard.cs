using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogicCheckers;

namespace Checkers_Game
{
    public class ButtonBoard : Button
    {
        private bool m_IsPressed;
        private Checker m_Checker;
        private Point m_Position;

        public Checker Checker
        {
            get { return m_Checker; }
            set { m_Checker = value; }
        }

        public Point Position
        {
            get { return m_Position; }
        }

        public bool IsPressed
        {
            get { return m_IsPressed; }
            set { m_IsPressed = value; }
        }

        public ButtonBoard(Checker i_Checker, Point i_Position)
        {
            m_IsPressed = false;
            m_Checker = i_Checker;
            m_Position = i_Position;
        }
    }
}
