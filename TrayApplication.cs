using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace TarkovServerControl
{
    public class TrayApplication : ApplicationContext
    {
        NotifyIcon tray;
        Process server;


        public TrayApplication()
        {
            StartServer();


            tray = new NotifyIcon();

            tray.Icon = SystemIcons.Application;

            tray.Text = "SPT Server";


            ContextMenuStrip menu = new ContextMenuStrip();


            menu.Items.Add(
                "显示窗口",
                null,
                ShowServer
            );


            menu.Items.Add(
                "退出",
                null,
                CloseServer
            );


            tray.ContextMenuStrip = menu;

            tray.Visible = true;
        }

        private Config LoadConfig()
        {
            string configFile = "config.json";

            if (!File.Exists(configFile))
            {
                MessageBox.Show("没有找到config.json");
                return null;
            }

            string json = File.ReadAllText(configFile);

            return JsonSerializer.Deserialize<Config>(json);
        }

        void StartServer()
        {
            void StartServer()
            {
                Config config = LoadConfig();

                if (config == null)
                    return;


                string serverExe = Path.Combine(
                    config.ServerPath,
                    "SPT.Server.exe"
                );


                if (!File.Exists(serverExe))
                {
                    MessageBox.Show("找不到SPT.Server.exe:\n" + serverExe);
                    return;
                }


                server = Process.Start(new ProcessStartInfo
                {
                    FileName = serverExe,
                    WorkingDirectory = config.ServerPath
                });
            }
        }



        void ShowServer(
            object sender,
            EventArgs e)
        {

            if (server != null)
            {
                server.Refresh();

                ShowWindow(
                    server.MainWindowHandle,
                    5
                );
            }

        }



        void CloseServer(
            object sender,
            EventArgs e)
        {

            if (server != null &&
               !server.HasExited)
            {
                server.Kill();
            }


            tray.Dispose();

            Application.Exit();

        }



        [System.Runtime.InteropServices.DllImport(
        "user32.dll")]
        static extern bool ShowWindow(
            IntPtr hwnd,
            int command);


    }
}