using System;
using System.Threading;
using System.Threading.Tasks;
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
            Logic.Algorithm = Algorithms.RandomAvailable;
            Task csForm = new Task(RunCsForm);
            csForm.Start();
            Thread.Sleep(1000);
            RunConsole();
        }
        static void RunCsForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            xoForm1 = new Form1();
            Task xoTask = new Task(() => Application.Run(xoForm1));
            xoTask.Start();
        }

        private static Form1 xoForm1;
        static void RunConsole()
        {
            Player.Instance.Changed += player => ConsoleHandler.PrepareConsole();
            ConsoleHandler.PrepareConsole();
            while (true)
            {
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
                    catch (Exception e)
                    {
                        Console.WriteLine(Resources.Program_RunConsole_Error);
                        Console.WriteLine(e.ToString());
                        Console.ReadKey();
                    }
                }
            }
        }

        public static bool IsConsole { get; private set; }
    }
}
