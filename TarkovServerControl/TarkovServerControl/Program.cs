using System.Threading;

namespace TarkovServerControl
{
    internal static class Program
    {

        private static Mutex mutex;


        [STAThread]
        static void Main()
        {

            bool createdNew;


            mutex = new Mutex(
                true,
                "TarkovServerControl",
                out createdNew
            );


            //已经存在实例
            if (!createdNew)
            {
                MessageBox.Show(
                    "Tarkov Server Control 已经运行",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }



            ApplicationConfiguration.Initialize();


            Application.Run(new Form1());


            mutex.ReleaseMutex();

        }
    }
}