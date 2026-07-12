namespace TarkovServerControl
{
    partial class Exit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exit));
            buttonCloseService = new Button();
            buttonCancel = new Button();
            buttonKeep = new Button();
            labelMessage = new Label();
            labelExitTips = new Label();
            SuspendLayout();
            // 
            // buttonCloseService
            // 
            buttonCloseService.Location = new Point(38, 231);
            buttonCloseService.Name = "buttonCloseService";
            buttonCloseService.Size = new Size(105, 32);
            buttonCloseService.TabIndex = 0;
            buttonCloseService.Text = "关闭并退出";
            buttonCloseService.UseVisualStyleBackColor = true;
            buttonCloseService.Click += buttonCloseService_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(163, 231);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(105, 32);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "取消退出";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonKeep
            // 
            buttonKeep.Location = new Point(287, 231);
            buttonKeep.Name = "buttonKeep";
            buttonKeep.Size = new Size(154, 32);
            buttonKeep.TabIndex = 2;
            buttonKeep.Text = "保持运行并退出";
            buttonKeep.UseVisualStyleBackColor = true;
            buttonKeep.Click += buttonKeep_Click;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(38, 28);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(60, 23);
            labelMessage.TabIndex = 3;
            labelMessage.Text = "label1";
            labelMessage.Click += labelMessage_Click;
            // 
            // labelExitTips
            // 
            labelExitTips.AutoSize = true;
            labelExitTips.Location = new Point(23, 168);
            labelExitTips.Name = "labelExitTips";
            labelExitTips.Size = new Size(418, 46);
            labelExitTips.TabIndex = 4;
            labelExitTips.Text = "请你选择退出方式\r\n如果保持运行并退出需要自行前往任务管理器退出进程";
            labelExitTips.Click += label1_Click;
            // 
            // Exit
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 292);
            Controls.Add(labelExitTips);
            Controls.Add(labelMessage);
            Controls.Add(buttonKeep);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCloseService);
            Cursor = Cursors.No;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Exit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "有进程仍在运行！";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCloseService;
        private Button buttonCancel;
        private Button buttonKeep;
        private Label labelMessage;
        private Label labelExitTips;
    }
}