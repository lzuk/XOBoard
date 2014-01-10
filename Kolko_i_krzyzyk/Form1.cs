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
                if (label1.InvokeRequired)
                {
                    label1.Invoke(new Action(() => label1.Text = Resources.Form1_Form1_Aktualny_gracz__ + actualPlayer));
                    for (int wiersz = 0; wiersz < 3; wiersz++) // w tym miejscu będziemy przeglądać pierwszy wymiar tablicy (wiersze)
                    {
                        for (int kolumna = 0; kolumna < 3; kolumna++) // ta pętla przegląda elementy w danym wierszu
                        {
                            if (Board.Board[wiersz, kolumna].FieldStatus != FieldStatus.Empty)
                            {
                                Board.Board[wiersz, kolumna].Button.Invoke(
                                    new Action(() => Board.Board[wiersz, kolumna].Button.Text 
                                        = Board.Board[wiersz, kolumna].FieldStatus.ToString()));
                            }
                        }
                    }

                }

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
