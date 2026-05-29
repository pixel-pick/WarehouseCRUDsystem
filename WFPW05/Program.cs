using WFPW05.Services;

namespace WFPW05
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DBInitialize.DBInit();
            Application.Run(new LoginForm());
        }
    }
}