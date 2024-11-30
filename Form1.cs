using MY_Tac_Toe_Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public enum enTurn { enPlayer1,  enPlayer2 };
        private enTurn _Turn = enTurn.enPlayer1;
        private byte _PlayCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private bool CheckValues(Button butt1, Button butt2, Button butt3)
        {
            if((butt1.Tag.ToString() != "?") && (butt1.Tag.ToString() == butt2.Tag.ToString()) && (butt1.Tag.ToString() == butt3.Tag.ToString()))
            {
                butt1.BackColor = Color.YellowGreen;
                butt2.BackColor = Color.YellowGreen;
                butt3.BackColor = Color.YellowGreen;
                lblTurn.Text = "Game Over";
                lblStates.Text = (butt1.Tag.ToString() == "O") ? "Player2" : "Player1";
                return true;
            }
            return false;
        }
        private bool CheckWinner()
        {
            if (CheckValues(button1, button2, button3)) return true;
            if (CheckValues(button4, button5, button6)) return true;
            if (CheckValues(button7, button8, button9)) return true;
            if (CheckValues(button1, button4, button7)) return true;
            if (CheckValues(button2, button5, button8)) return true;
            if (CheckValues(button3, button6, button9)) return true;
            if (CheckValues(button1, button5, button9)) return true;
            if (CheckValues(button3, button5, button7)) return true;

            return false;
        }
        private void RestButtonImage (Button butt)
        {
            if(butt.Tag.ToString() == "?")
            {
                _PlayCount++;
                if (_Turn == enTurn.enPlayer1)
                {
                    butt.Image = Resources.X;
                    butt.Tag = "X";
                    _Turn = enTurn.enPlayer2;
                    lblTurn.Text = "Player2";
                }
                else if (_Turn == enTurn.enPlayer2)
                {
                    butt.Image = Resources.O;
                    butt.Tag = "O";
                    _Turn = enTurn.enPlayer1;
                    lblTurn.Text = "Player1";
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (CheckWinner()) return;
            if (_PlayCount == 9)
            {
                lblTurn.Text = "Game Over";
                lblStates.Text = "Draw";
            }
        }
        private void RestButton(Button butt)
        {
            butt.Image = Resources.question_mark_96;
            butt.Tag = "?";
            butt.BackColor = Color.White;
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (_PlayCount == 9) return;
            RestButtonImage((Button)sender);
        }
        private void btRestart_Click(object sender, EventArgs e)
        {
            _Turn = enTurn.enPlayer1;
            _PlayCount = 0;
            lblTurn.Text = "Player1";
            lblStates.Text = "Game In Progress";
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);
        }
    }
}
