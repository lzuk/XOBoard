using System;
using System.Windows.Forms;
using Kolko_i_krzyzyk.Properties;

namespace Kolko_i_krzyzyk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logic.Algorithm = Algorithms.FirstAvailable;
            IsConsole = true;
            if (IsConsole)
            {
                RunConsole();
                Console.ReadKey();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        static void RunConsole()
        {
            while (true)
            {
                ConsoleHandler.RedrawConsole();
                ConsoleHandler.WriteXOBoard();
                ConsoleHandler.WriteInstructions();
                Location location = ConsoleHandler.HandleCommunications();
                {
                    try
                    {
                        if (XOBoard.Instance.Board[location.wiersz, location.kolumna].FieldStatus == FieldStatus.Empty)
                        {
                            XOBoard.Instance.Board[location.wiersz, location.kolumna].FieldStatus =
                                Player.Instance.ActualPlayer;
                            Player.Instance.ChangePlayer();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(Resources.Program_RunConsole_Error);
                        Console.ReadKey();
                    }
                }
            }
        }

        public static bool IsConsole { get; private set; }
    }
}
