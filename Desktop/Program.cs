using Desktop.DependencyInjection;
using SisGUAPA.Forms;
using System;
using System.Windows.Forms;

namespace SisGUAPA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //NHibernateHelper.GeraSchema();
            Console.Read();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Starts dependecy injection
            IocKernel.Initialize(new IocConfigurations());

            Application.Run(new FormLoginNovo());
        }

    }
}