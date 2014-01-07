using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Task csForm = new Task(RunCsForm);
            csForm.Start();
            Thread.Sleep(1000);

            RunConsole();
            Console.ReadKey();
        }

        private static Form1 xoForm1;
        static void RunCsForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            xoForm1 = new Form1();
            Application.Run(xoForm1);
        }
        static void RunConsole()
        {
            Player.Instance.Changed += actualPlayer => ConsoleHandler.RedrawConsole();
            while (true)
            {
                Location location = ConsoleHandler.HandleCommunications();
                {
                    if (XOBoard.Instance.Board[location.wiersz, location.kolumna].FieldStatus == FieldStatus.Empty)
                    {
                        XOBoard.Instance.Board[location.wiersz, location.kolumna].FieldStatus = Player.Instance.ActualPlayer;
                        Player.Instance.ChangePlayer();
                        ConsoleHandler.RedrawConsole();
                    }
                }
            }
        }
    }
}
