using System;
using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    static class ConsoleHandler
    {
        static void WriteXOBoard(){
            XOBoard xoboard = XOBoard.Instance;
            for (int wiersz = 0; wiersz < 3; wiersz++) // w tym miejscu będziemy przeglądać pierwszy wymiar tablicy (wiersze)
            {
                for (int kolumna = 0; kolumna < 3; kolumna++) // ta pętla przegląda elementy w danym wierszu
                {
                    Console.Write(xoboard.Board[wiersz, kolumna].FieldStatus == FieldStatus.Empty
                        ? "- "
                        : xoboard.Board[wiersz, kolumna].FieldStatus + " ");
                }
                Console.WriteLine();
            }

        }
        static void WriteInstructions()
        {
            Console.WriteLine("Instructions:");
            Console.WriteLine("X - Player");
            Console.WriteLine("O - Computer");
            Console.WriteLine("- - Empty field");
            
        }
        public static Location HandleCommunications()
        {
            Console.WriteLine("Write X coordinate 1 - 3");
            string msgX = Console.ReadLine();
            Console.WriteLine("Write Y coordinate 1 - 3");
            string msgY = Console.ReadLine();
            int x,y;
            int.TryParse(msgX, out x);
            int.TryParse(msgY, out y);
            return new Location(x - 1,y - 1);
        }
        public static void RedrawConsole()
        {
            Console.Clear();
            WriteXOBoard();
            Console.WriteLine();
            WriteInstructions();
            Console.WriteLine();
        }
    }
}
