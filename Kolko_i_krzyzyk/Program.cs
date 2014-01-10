using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
            Task xoTask = new Task(() => Application.Run(xoForm1));
            xoTask.Start();

            FormController formController = new FormController();
            Task formTask = new Task(() => Application.Run(formController));
            formTask.Start();
        }
        static void RunConsole()
        {
            Player.Instance.Changed += actualPlayer => ConsoleHandler.RedrawConsole();
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
                            ConsoleHandler.RedrawConsole();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(Resources.Program_RunConsole_Error);
                    }
                }
            }
        }
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
