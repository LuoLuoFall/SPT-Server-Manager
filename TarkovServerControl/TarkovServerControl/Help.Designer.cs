namespace TarkovServerControl
{
    partial class Help
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelHelp = new Label();
            buttonCloseHelp = new Button();
            SuspendLayout();
            // 
            // labelHelp
            // 
            labelHelp.AutoSize = true;
            labelHelp.Location = new Point(54, 54);
            labelHelp.Name = "labelHelp";
            labelHelp.Size = new Size(648, 69);
            labelHelp.TabIndex = 0;
            labelHelp.Text = "本软件仅用于无窗口启动SPT服务端和Headless客户端，同时提供状态监控和日志获\r\n取，对于双ccd的16核心amdcpu提供cpu亲和性分配来提供几乎翻倍的性能提升的功\r\n能，需要自行前往github或者oddba获取更新";
            // 
            // buttonCloseHelp
            // 
            buttonCloseHelp.Location = new Point(622, 145);
            buttonCloseHelp.Name = "buttonCloseHelp";
            buttonCloseHelp.Size = new Size(105, 32);
            buttonCloseHelp.TabIndex = 1;
            buttonCloseHelp.Text = "关闭";
            buttonCloseHelp.UseVisualStyleBackColor = true;
            buttonCloseHelp.Click += buttonCloseHelp_Click;
            // 
            // Help
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 189);
            Controls.Add(buttonCloseHelp);
            Controls.Add(labelHelp);
            Name = "Help";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "关于";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHelp;
        private Button buttonCloseHelp;
    }
}