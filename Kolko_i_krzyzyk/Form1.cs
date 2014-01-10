using System;
using System.Windows.Forms;
using Kolko_i_krzyzyk.Properties;

namespace Kolko_i_krzyzyk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Board = XOBoard.Instance;
            ConnectButtonsWithTable();
            Player.Instance.Changed += actualPlayer =>
            {
                label1.Text = Resources.Form1_Form1_Aktualny_gracz__ + actualPlayer.ToString(); 
            };
            Instance = this;
        }

        public static Form1 Instance;

        private XOBoard Board;
        private void ConnectButtonsWithTable()
        {
            Board.Board[0, 0].Button = button00;
            Board.Board[0, 1].Button = button01;
            Board.Board[0, 2].Button = button02;

            Board.Board[1, 0].Button = button10;
            Board.Board[1, 1].Button = button11;
            Board.Board[1, 2].Button = button12;

            Board.Board[2, 0].Button = button20;
            Board.Board[2, 1].Button = button21;
            Board.Board[2, 2].Button = button22;

            Board.AssignEventsToButton();
            Board.RestartGame();
        }

        private void nowaGra_Click(object sender, EventArgs e)
        {
            Player.Instance.RestartGame();
            Board.RestartGame();
            ConnectButtonsWithTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
