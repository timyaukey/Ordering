using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.WillowLib.Data.Sql;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(ExceptionHandler);
            Ambient.Configure(new StaticAmbientDataProvider());
            SqlDbSession session = new SqlDbSession("OrderingDev");
            Ambient.DbSession = session;
            OrderingRepositories.Configure(new SqlOrderingRepositories(session));
            Application.Run(new MDIMain());
        }

        private static void ExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + Environment.NewLine +
                e.Exception.StackTrace.ToString(), "Unhandled Exception");
            Application.Exit();
        }

    }
}
