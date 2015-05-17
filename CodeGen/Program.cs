using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Willowsoft.WillowLib.CodeGen;

namespace CodeGen
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
            CodeViewer window = new CodeViewer();
            window.DefinitionsPath = Path.Combine(Application.StartupPath,
                "..\\..\\..\\Core\\Entities\\Definitions.xml");
            Application.Run(window);
        }
    }
}
