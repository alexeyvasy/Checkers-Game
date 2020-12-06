using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogicCheckers;

namespace Checkers_Game
{
    public partial class Form1 : Form
    {
        private Player m_Player1;
        private Player m_Player2;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            int Boardsize = 8;

            if (m_RadioButtonSize6.Checked == true)
            {
                Boardsize = 6;
            }
            else if (m_RadioButtonSize8.Checked == true)
            {
                Boardsize = 8;
            }
            else if (m_RadioButtonSize10.Checked == true)
            {
                Boardsize = 10;
            }
            
            m_Player1 = new Player(Player.ePlayerType.Human);
            m_Player1.Name = m_TextBoxPlayer1Name.Text;

            if (m_CheckBoxPlayer2.Checked)
            {
                m_Player2 = new Player(Player.ePlayerType.Human);
                m_Player2.Name = m_TextBoxPlayer2Name.Text;
            }
            else
            {
                m_Player2 = new Player();
                m_Player2.Name = m_TextBoxPlayer2Name.Text;
            }

            FormGameplay game = new FormGameplay(Boardsize, m_Player1, m_Player2);

            game.ShowDialog();
        }

        private void CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_CheckBoxPlayer2.Checked)
            {
                m_TextBoxPlayer2Name.Enabled = true;
                m_TextBoxPlayer2Name.Text = string.Empty;                
            }
            else
            {
                m_TextBoxPlayer2Name.Enabled = false;                
                m_TextBoxPlayer2Name.Text = "Computer";
            }
        }
    }
}
