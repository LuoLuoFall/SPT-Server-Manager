using System.Diagnostics;
using System.Text.Json;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace TarkovServerControl
{
    public partial class Form1 : Form
    {
        private Process? serverProcess;
        private Process? headlessManagerProcess;
        private Process? eftHeadlessProcess;
        private Process? normalEftProcess;

        private bool reallyExit = false;
        private bool headlessHidden = false;


        //退出选择
        private enum ExitChoice
        {
            Exit,
            Cancel,
            CloseServices
        }



        //生成默认配置文件
        private void CheckConfig()
        {
            if (!File.Exists("config.json"))
            {

                Config config = new Config();

                config.ServerPath = "";
                config.HeadlessPath = "";
                config.EnableCpuAffinity = false;
                config.MinimizeToTray = true;


                string json = JsonSerializer.Serialize(
                    config,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });


                File.WriteAllText(
                    "config.json",
                    json
                );

                MessageBox.Show(
                    "已生成默认配置文件，请在config.json中设置路径，当你启动服务端后请等待片刻，服务端完全启动后再启动headless即可",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
        }


        //隐藏窗口API
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(
            IntPtr hWnd,
            int nCmdShow
        );


        //隐藏窗口参数
        private const int SW_HIDE = 0;

        //隐藏指定进程窗口
        private bool HideProcessWindow(Process process)
        {
            try
            {
                //刷新进程信息
                process.Refresh();


                //获取窗口句柄
                IntPtr handle = process.MainWindowHandle;


                //没有窗口
                if (handle == IntPtr.Zero)
                {
                    return false;
                }


                //隐藏窗口
                ShowWindow(
                    handle,
                    SW_HIDE
                );


                return true;

            }
            catch
            {
                return false;
            }
        }



        //判断headless
        private bool IsHeadless(Process process)
        {
            try
            {
                return process.MainWindowTitle.Contains(
                    "BepInEx"
                );
            }
            catch
            {
                return false;
            }
        }

        //扫描headless进程
        private Process FindHeadlessProcess()
        {
            Process[] processes =
                Process.GetProcessesByName(
                    "EscapeFromTarkov"
                );


            foreach (Process p in processes)
            {
                if (IsHeadless(p))
                {
                    return p;
                }
            }


            return null;
        }

        //普通进程获取
        private Process FindNormalEftProcess()
        {
            Process[] processes =
                Process.GetProcessesByName(
                    "EscapeFromTarkov"
                );


            foreach (Process p in processes)
            {
                if (!IsHeadless(p))
                {
                    return p;
                }
            }


            return null;
        }


        //实时检测状态
        private void timerStatus_Tick(object sender, EventArgs e)
        {

            if (serverProcess != null && !serverProcess.HasExited)
            {
                labelStatus.Text = "运行中";
            }
            else
            {
                labelStatus.Text = "未启动\r\n（启动后等待数秒让服\r\n务器进程完成加载）";
                serverProcess = null;
            }



            //检测Headless EFT

            try
            {
                if (eftHeadlessProcess != null)
                {
                    if (eftHeadlessProcess.HasExited)
                    {
                        eftHeadlessProcess = null;

                        //允许下一次重新隐藏
                        headlessHidden = false;
                    }
                }
            }
            catch
            {
                eftHeadlessProcess = null;
                headlessHidden = false;
            }



            //没有绑定的时候尝试寻找
            if (eftHeadlessProcess == null)
            {
                eftHeadlessProcess = FindHeadlessProcess();


                //第一次发现Headless时设置CPU
                if (eftHeadlessProcess != null)
                {
                    SetCpuAffinity(
                        eftHeadlessProcess,
                        true
                    );
                }
            }



            //显示状态
            if (eftHeadlessProcess != null)
            {
                labelHStatus.Text = "运行中";


                //尝试隐藏Headless窗口
                if (!headlessHidden)
                {
                    bool result =
                        HideProcessWindow(
                            eftHeadlessProcess
                        );


                    //隐藏成功
                    if (result)
                    {
                        headlessHidden = true;
                    }
                }
            }
            else
            {
                labelHStatus.Text = "未启动";
            }





            //检测普通EFT

            if (normalEftProcess != null)
            {
                try
                {
                    if (normalEftProcess.HasExited)
                    {
                        normalEftProcess = null;
                    }
                }
                catch
                {
                    normalEftProcess = null;
                }
            }


            if (normalEftProcess == null)
            {
                normalEftProcess = FindNormalEftProcess();


                //第一次发现普通EFT时设置CPU
                if (normalEftProcess != null)
                {
                    SetCpuAffinity(
                        normalEftProcess,
                        false
                    );
                }
            }
        }

        //设置CPU亲和性
        private void SetCpuAffinity(Process process, bool headless)
        {
            try
            {

                if (!File.Exists("config.json"))
                {
                    return;
                }


                Config config =
                    JsonSerializer.Deserialize<Config>(
                        File.ReadAllText("config.json")
                    );


                if (config == null ||
                   !config.EnableCpuAffinity)
                {
                    return;
                }



                if (headless)
                {
                    //CPU 8-15
                    process.ProcessorAffinity =
                        (IntPtr)65280;
                }
                else
                {
                    //CPU 0-7
                    process.ProcessorAffinity =
                        (IntPtr)255;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "CPU亲和性设置失败:\n"
                    + ex.Message
                );
            }
        }

        //关闭所有服务
        private void StopAllServices()
        {

            //关闭SPT服务器
            try
            {
                if (serverProcess != null &&
                   !serverProcess.HasExited)
                {
                    serverProcess.Kill();
                    serverProcess.WaitForExit();
                }
            }
            catch
            {

            }



            //关闭Headless客户端
            try
            {
                if (eftHeadlessProcess != null &&
                   !eftHeadlessProcess.HasExited)
                {
                    eftHeadlessProcess.Kill();
                    eftHeadlessProcess.WaitForExit();
                }
            }
            catch
            {

            }



            //关闭Headless管理器
            try
            {
                if (headlessManagerProcess != null &&
                   !headlessManagerProcess.HasExited)
                {
                    headlessManagerProcess.Kill();
                    headlessManagerProcess.WaitForExit();
                }
            }
            catch
            {

            }



            //释放对象

            serverProcess?.Dispose();
            eftHeadlessProcess?.Dispose();
            headlessManagerProcess?.Dispose();


            serverProcess = null;
            eftHeadlessProcess = null;
            headlessManagerProcess = null;


            headlessHidden = false;

        }

        //窗口
        public Form1()
        {
            InitializeComponent();

            notifyIcon1.Visible = true;
            notifyIcon1.Text = "SPT服务端管理器";

            this.FormClosing += Form1_FormClosing;

            CheckConfig();

            // 固定窗口大小，禁止最大化和调整大小
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(375, 345);


            timerStatus.Interval = 1000;
            timerStatus.Start();

            toolTip1.SetToolTip(buttonStart, "启动SPT服务端");
            toolTip1.SetToolTip(buttonStop, "停止SPT服务端");
            toolTip1.SetToolTip(buttonHStart, "启动fika管理器并由管理器拉起Headless客户端");
            toolTip1.SetToolTip(buttonHStop, "停止Headless客户端和fika管理器");
            toolTip1.SetToolTip(buttonHRestart, "重启Headless客户端，不关闭fika管理器");
        }


        private void 设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingForm settings = new SettingForm();
            settings.ShowDialog();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //窗口管理
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            //真正退出
            if (reallyExit)
            {
                notifyIcon1.Visible = false;
                return;
            }

            Config? config =
                JsonSerializer.Deserialize<Config>(
                    File.ReadAllText("config.json")
                );

            //配置读取失败
            if (config == null)
            {
                return;
            }

            // 开启最小化到托盘
            if (config.MinimizeToTray)
            {
                e.Cancel = true;

                Hide();

                ShowInTaskbar = false;

                return;
            }

            // 执行退出检测
            ExitChoice choice =
                CheckRunningPrograms();

            //取消退出
            if (choice == ExitChoice.Cancel)
            {
                e.Cancel = true;
                return;
            }

            //关闭所有服务
            if (choice == ExitChoice.CloseServices)
            {
                StopAllServices();
            }

            //允许退出
            reallyExit = true;
            notifyIcon1.Visible = false;

        }


        //启动服务器
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                var config = JsonSerializer.Deserialize<Config>(
                    File.ReadAllText("config.json")
                );


                if (config == null)
                {
                    MessageBox.Show("配置文件错误");
                    return;
                }


                string exePath = Path.Combine(
                    config.ServerPath,
                    "SPT.Server.exe"
                );


                if (File.Exists(exePath))
                {
                    //防止重复启动
                    if (serverProcess != null && !serverProcess.HasExited)
                    {
                        MessageBox.Show("服务器已经运行");
                        return;
                    }


                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    startInfo.FileName = exePath;

                    //设置工作目录
                    startInfo.WorkingDirectory = Path.GetDirectoryName(exePath);


                    //隐藏窗口
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    //启动

                    serverProcess = Process.Start(startInfo);//启动
                }
                else
                {
                    MessageBox.Show(
                        "找不到服务器程序:\n" + exePath
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "启动失败:\n" + ex.Message
                );
            }
        }



        //停止服务器
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serverProcess == null || serverProcess.HasExited)
            {
                MessageBox.Show("服务器未启动");
                serverProcess = null;
                return;
            }


            try
            {
                if (!serverProcess.HasExited)
                {
                    serverProcess.Kill();
                    serverProcess.WaitForExit();
                }

                serverProcess.Dispose();
                serverProcess = null;

                labelStatus.Text = "已关闭";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "关闭失败:\n" + ex.Message
                );
            }
        }



        private void labelHStatus_Click(object sender, EventArgs e)
        {

        }
        //启动Headless服务器
        private void buttonHStart_Click(object sender, EventArgs e)
        {
            try
            {
                var config = JsonSerializer.Deserialize<Config>(
                    File.ReadAllText("config.json")
                );


                if (config == null)
                {
                    MessageBox.Show("配置文件错误");
                    return;
                }


                string exePath = Path.Combine(
                    config.HeadlessPath,
                    "FikaHeadlessManager.exe"
                );


                if (File.Exists(exePath))
                {
                    //防止重复启动
                    if (eftHeadlessProcess != null && !eftHeadlessProcess.HasExited)
                    {
                        MessageBox.Show("Headless已经运行");
                        return;
                    }


                    // 创建启动信息
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    // 要启动的程序
                    startInfo.FileName = exePath;

                    // 设置工作目录
                    startInfo.WorkingDirectory = Path.GetDirectoryName(exePath);

                    //后台启动
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;


                    //启动
                    headlessManagerProcess = Process.Start(startInfo);


                }
                else
                {
                    MessageBox.Show(
                        "找不到Headless服务器程序:\n" + exePath
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "启动失败:\n" + ex.Message
                );
            }
        }
        //停止Headless服务器
        //停止Headless
        private void buttonHStop_Click(object sender, EventArgs e)
        {

            try
            {

                //关闭无头客户端
                if (eftHeadlessProcess != null &&
                    !eftHeadlessProcess.HasExited)
                {
                    eftHeadlessProcess.Kill();
                    eftHeadlessProcess.WaitForExit();
                }


                //关闭Manager
                if (headlessManagerProcess != null &&
                    !headlessManagerProcess.HasExited)
                {
                    headlessManagerProcess.Kill();
                }


                eftHeadlessProcess = null;
                headlessManagerProcess = null;


                labelHStatus.Text = "已关闭";

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "关闭失败:\n" + ex.Message
                );
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help about = new Help();

            about.ShowDialog();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();

            this.WindowState =
                FormWindowState.Normal;


            this.Activate();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 显示窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();

            this.WindowState =
                FormWindowState.Normal;

            this.ShowInTaskbar = true;

            this.Activate();
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ExitChoice choice = CheckRunningPrograms();


            if (choice == ExitChoice.Cancel)
            {
                return;
            }


            if (choice == ExitChoice.CloseServices)
            {
                StopAllServices();
            }


            reallyExit = true;


            notifyIcon1.Visible = false;

            timerStatus.Stop();

            notifyIcon1.Dispose();

            Application.Exit();
        }


        private ExitChoice CheckRunningPrograms()
        {

            string warning = "";


            try
            {
                if (serverProcess != null &&
                   !serverProcess.HasExited)
                {
                    warning += "SPT服务器仍在运行\n";
                }
            }
            catch { }



            try
            {
                if (eftHeadlessProcess != null &&
                   !eftHeadlessProcess.HasExited)
                {
                    warning += "Headless客户端仍在运行\n";
                }
            }
            catch { }



            try
            {
                if (headlessManagerProcess != null &&
                   !headlessManagerProcess.HasExited)
                {
                    warning += "Headless管理器仍在运行\n";
                }
            }
            catch { }




            //没有运行程序
            if (warning == "")
            {
                return ExitChoice.Exit;
            }



            //打开自定义退出窗口

            Exit exitForm =
                new Exit(warning);


            exitForm.ShowDialog();



            //根据用户选择返回结果

            switch (exitForm.Result)
            {

                //保持服务运行退出
                case Exit.ExitResult.KeepRunning:

                    return ExitChoice.Exit;



                //取消退出
                case Exit.ExitResult.Cancel:

                    return ExitChoice.Cancel;



                //关闭服务并退出
                case Exit.ExitResult.CloseServices:

                    return ExitChoice.CloseServices;


                default:

                    return ExitChoice.Cancel;

            }

        }
    }
}
