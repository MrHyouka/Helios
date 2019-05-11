using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helios
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            if (LoginFlag == true)
            {
                Application.Run(new FormMain());
            }
        }

        private static bool LoginFlag = false;

        public static bool SetLoginFlag { set => LoginFlag = value; }

        public static bool GetLoginFlag { get => LoginFlag; }

        static ResourceManager LocRM = new ResourceManager("Helios.lang", typeof(FormLogin).Assembly);
        //MessageBox.Show(LocRM.GetString("STR_KEY"));
    }
}
