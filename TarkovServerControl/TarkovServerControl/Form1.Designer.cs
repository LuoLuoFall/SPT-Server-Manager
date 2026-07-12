namespace TarkovServerControl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            设置ToolStripMenuItem1 = new ToolStripMenuItem();
            关于ToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tips = new Label();
            labelStatus = new Label();
            fuwuqizhuangtai = new Label();
            buttonStop = new Button();
            buttonStart = new Button();
            tabPage2 = new TabPage();
            buttonHRestart = new Button();
            labelHStatus = new Label();
            wutouzhuangtai = new Label();
            buttonHStop = new Button();
            buttonHStart = new Button();
            timerStatus = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            显示窗口ToolStripMenuItem = new ToolStripMenuItem();
            退出程序ToolStripMenuItem = new ToolStripMenuItem();
            toolTip1 = new ToolTip(components);
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(22, 22);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem, 关于ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(698, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem1 });
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(60, 27);
            设置ToolStripMenuItem.Text = "文件";
            设置ToolStripMenuItem.Click += 设置ToolStripMenuItem_Click;
            // 
            // 设置ToolStripMenuItem1
            // 
            设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            设置ToolStripMenuItem1.Size = new Size(138, 30);
            设置ToolStripMenuItem1.Text = "设置";
            设置ToolStripMenuItem1.Click += 设置ToolStripMenuItem1_Click;
            // 
            // 关于ToolStripMenuItem
            // 
            关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            关于ToolStripMenuItem.Size = new Size(60, 27);
            关于ToolStripMenuItem.Text = "关于";
            关于ToolStripMenuItem.Click += 关于ToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(698, 467);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tips);
            tabPage1.Controls.Add(labelStatus);
            tabPage1.Controls.Add(fuwuqizhuangtai);
            tabPage1.Controls.Add(buttonStop);
            tabPage1.Controls.Add(buttonStart);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(690, 431);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Server";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tips
            // 
            tips.AutoSize = true;
            tips.Location = new Point(57, 131);
            tips.Name = "tips";
            tips.Size = new Size(0, 23);
            tips.TabIndex = 4;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(157, 26);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(180, 69);
            labelStatus.TabIndex = 3;
            labelStatus.Text = "未启动\r\n（启动后等待数秒让服\r\n务器进程完成加载）";
            // 
            // fuwuqizhuangtai
            // 
            fuwuqizhuangtai.AutoSize = true;
            fuwuqizhuangtai.Location = new Point(52, 26);
            fuwuqizhuangtai.Name = "fuwuqizhuangtai";
            fuwuqizhuangtai.Size = new Size(112, 23);
            fuwuqizhuangtai.TabIndex = 2;
            fuwuqizhuangtai.Text = "服务器状态：";
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(152, 122);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(105, 32);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "终止";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(41, 122);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(105, 32);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "启动";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(buttonHRestart);
            tabPage2.Controls.Add(labelHStatus);
            tabPage2.Controls.Add(wutouzhuangtai);
            tabPage2.Controls.Add(buttonHStop);
            tabPage2.Controls.Add(buttonHStart);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(690, 431);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Headless";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonHRestart
            // 
            buttonHRestart.Location = new Point(152, 160);
            buttonHRestart.Name = "buttonHRestart";
            buttonHRestart.Size = new Size(105, 32);
            buttonHRestart.TabIndex = 5;
            buttonHRestart.Text = "重启";
            buttonHRestart.UseVisualStyleBackColor = true;
            // 
            // labelHStatus
            // 
            labelHStatus.AutoSize = true;
            labelHStatus.Location = new Point(193, 26);
            labelHStatus.Name = "labelHStatus";
            labelHStatus.Size = new Size(61, 23);
            labelHStatus.TabIndex = 4;
            labelHStatus.Text = "未启动";
            labelHStatus.Click += labelHStatus_Click;
            // 
            // wutouzhuangtai
            // 
            wutouzhuangtai.AutoSize = true;
            wutouzhuangtai.Location = new Point(52, 26);
            wutouzhuangtai.Name = "wutouzhuangtai";
            wutouzhuangtai.Size = new Size(135, 23);
            wutouzhuangtai.TabIndex = 3;
            wutouzhuangtai.Text = "Headless状态：";
            // 
            // buttonHStop
            // 
            buttonHStop.Location = new Point(152, 122);
            buttonHStop.Name = "buttonHStop";
            buttonHStop.Size = new Size(105, 32);
            buttonHStop.TabIndex = 2;
            buttonHStop.Text = "终止";
            buttonHStop.UseVisualStyleBackColor = true;
            buttonHStop.Click += buttonHStop_Click;
            // 
            // buttonHStart
            // 
            buttonHStart.Location = new Point(41, 122);
            buttonHStart.Name = "buttonHStart";
            buttonHStart.Size = new Size(105, 32);
            buttonHStart.TabIndex = 1;
            buttonHStart.Text = "启动";
            buttonHStart.UseVisualStyleBackColor = true;
            buttonHStart.Click += buttonHStart_Click;
            // 
            // timerStatus
            // 
            timerStatus.Enabled = true;
            timerStatus.Interval = 1000;
            timerStatus.Tick += timerStatus_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(22, 22);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 显示窗口ToolStripMenuItem, 退出程序ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(149, 60);
            // 
            // 显示窗口ToolStripMenuItem
            // 
            显示窗口ToolStripMenuItem.Name = "显示窗口ToolStripMenuItem";
            显示窗口ToolStripMenuItem.Size = new Size(148, 28);
            显示窗口ToolStripMenuItem.Text = "显示窗口";
            显示窗口ToolStripMenuItem.Click += 显示窗口ToolStripMenuItem_Click;
            // 
            // 退出程序ToolStripMenuItem
            // 
            退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            退出程序ToolStripMenuItem.Size = new Size(148, 28);
            退出程序ToolStripMenuItem.Text = "退出程序";
            退出程序ToolStripMenuItem.Click += 退出程序ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 498);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SPT服务端管理器";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem1;
        private ToolStripMenuItem 关于ToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button buttonStop;
        private Button buttonStart;
        private Button buttonHStop;
        private Button buttonHStart;
        private Label labelStatus;
        private Label fuwuqizhuangtai;
        private System.Windows.Forms.Timer timerStatus;
        private Label labelHStatus;
        private Label wutouzhuangtai;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 显示窗口ToolStripMenuItem;
        private ToolStripMenuItem 退出程序ToolStripMenuItem;
        private Button buttonHRestart;
        private ToolTip toolTip1;
        private Label tips;
    }
}
