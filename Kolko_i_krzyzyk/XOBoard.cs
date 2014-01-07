﻿using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    class XOBoard
    {
        public static XOBoard Instance
        {
            get { return instance ?? (instance = new XOBoard()); }
        }

        public Field[,] Board = new Field[3, 3];
        public void AssignEventsToButton()
        {
            for (int wiersz = 0; wiersz < 3; wiersz++) // w tym miejscu będziemy przeglądać pierwszy wymiar tablicy (wiersze)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++) // ta pętla przegląda elementy w danym wierszu
                {
                    Board[wiersz, kolumna].Button.Click += (sender, eventArgs) => {
                        Location location = findLocationInBoard(sender);
                        if (Board[location.wiersz, location.kolumna].FieldStatus == FieldStatus.Empty)
                        {
                            Board[location.wiersz, location.kolumna].FieldStatus = Player.Instance.ActualPlayer;
                            ((Button) sender).Text = Player.Instance.ActualPlayer.ToString();
                            Player.Instance.ChangePlayer();
                        }
                    };
                }
            }
        }

        public void RestartGame()
        {
            for (int wiersz = 0; wiersz < 3; wiersz++) // w tym miejscu będziemy przeglądać pierwszy wymiar tablicy (wiersze)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++) // ta pętla przegląda elementy w danym wierszu
                {
                    Board[wiersz, kolumna].Button.Text = "Click me!";
                    Board[wiersz, kolumna].FieldStatus = FieldStatus.Empty;
                }
            }
            ConsoleHandler.RedrawConsole();
        }

        private Location findLocationInBoard(object button)
        {
            for (int wiersz = 0; wiersz < 3; wiersz++) // w tym miejscu będziemy przeglądać pierwszy wymiar tablicy (wiersze)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++) // ta pętla przegląda elementy w danym wierszu
                {
                    if (Board[wiersz, kolumna].Button == button)
                    {
                        return new Location(wiersz, kolumna);
                    }
                }
            }
            return new Location(-1,-1);
        }

        private static XOBoard instance = null;
        private XOBoard()
        {
        }
    }
    class Location
    {
        public Location(int wiersz, int kolumna)
        {
            this.wiersz = wiersz;
            this.kolumna = kolumna;
        }
        public int wiersz {get; private set;}
        public int kolumna {get; private set;}
    }
}
