using System;
using System.Windows.Forms;

namespace Valorant_Tracker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Auth session = null;
            using (var login = new frmLogin())
            {
                login.Authenticated += (_, auth) => session = auth;
                Application.Run(login);
            }

            if (session == null)
            {
                // User closed the login form without authenticating.
                return;
            }

            using (var main = new frmMain(session))
            {
                Application.Run(main);
            }
        }
    }
}