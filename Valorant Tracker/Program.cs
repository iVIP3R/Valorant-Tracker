using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Valorant_Tracker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Auth session = null;
            using (var login = new frmLogin())
            {
                login.Authenticated += (_, auth) => session = auth;
                Application.Run(login);
            }

            if (session == null) return;

            using (var main = new frmMain(session))
            {
                Application.Run(main);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Debug.WriteLine("[Program] UI Thread Exception Caught");
            HandleException(e.Exception, "UI Thread");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine("[Program] Background Thread Exception Caught");
            if (e.ExceptionObject is Exception ex)
            {
                HandleException(ex, "Background Thread");
            }
        }

        private static void HandleException(Exception ex, string context)
        {
            Logger.Log(ex, context);

            string title = "Valorant Tracker";
            string message = "An unexpected error occurred. Please try restarting the application.\n\n" +
                             "If the problem persists, please contact the developer.";

            if (ex is System.Net.Http.HttpRequestException httpEx)
            {
                if (httpEx.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    message = "Your Riot session has expired or is invalid.\n\nPlease restart the application to log in again.";
                }
                else if (httpEx.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    message = "You are making too many requests to Riot's servers.\n\nPlease wait a few minutes and try again.";
                }
                else
                {
                    message = "Unable to connect to Riot's servers.\n\nPlease check your internet connection and try again.";
                }
            }
            else if (ex is System.Threading.Tasks.TaskCanceledException)
            {
                message = "The request to Riot's servers timed out.\n\nPlease check your internet connection or try again later.";
            }

            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}