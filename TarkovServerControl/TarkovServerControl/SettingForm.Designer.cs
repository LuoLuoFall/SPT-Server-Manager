namespace TarkovServerControl
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            label1 = new Label();
            label2 = new Label();
            txtServerPath = new TextBox();
            txtHeadlessPath = new TextBox();
            ChooseServerButton = new Button();
            ChooseHeadlessButton = new Button();
            SettingSave = new Button();
            CPU = new CheckBox();
            Min = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 33);
            label1.Name = "label1";
            label1.Size = new Size(95, 23);
            label1.TabIndex = 0;
            label1.Text = "服务端路径";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 71);
            label2.Name = "label2";
            label2.Size = new Size(118, 23);
            label2.TabIndex = 1;
            label2.Text = "Headless路径";
            // 
            // txtServerPath
            // 
            txtServerPath.Location = new Point(138, 30);
            txtServerPath.Name = "txtServerPath";
            txtServerPath.Size = new Size(410, 29);
            txtServerPath.TabIndex = 2;
            // 
            // txtHeadlessPath
            // 
            txtHeadlessPath.Location = new Point(138, 68);
            txtHeadlessPath.Name = "txtHeadlessPath";
            txtHeadlessPath.Size = new Size(410, 29);
            txtHeadlessPath.TabIndex = 3;
            // 
            // ChooseServerButton
            // 
            ChooseServerButton.Location = new Point(554, 30);
            ChooseServerButton.Name = "ChooseServerButton";
            ChooseServerButton.Size = new Size(33, 29);
            ChooseServerButton.TabIndex = 4;
            ChooseServerButton.Text = "...";
            ChooseServerButton.UseVisualStyleBackColor = true;
            ChooseServerButton.Click += ChooseServerButton_Click;
            // 
            // ChooseHeadlessButton
            // 
            ChooseHeadlessButton.Location = new Point(554, 71);
            ChooseHeadlessButton.Name = "ChooseHeadlessButton";
            ChooseHeadlessButton.Size = new Size(33, 29);
            ChooseHeadlessButton.TabIndex = 5;
            ChooseHeadlessButton.Text = "...";
            ChooseHeadlessButton.UseVisualStyleBackColor = true;
            ChooseHeadlessButton.Click += ChooseHeadlessButton_Click;
            // 
            // SettingSave
            // 
            SettingSave.Location = new Point(482, 337);
            SettingSave.Name = "SettingSave";
            SettingSave.Size = new Size(105, 32);
            SettingSave.TabIndex = 6;
            SettingSave.Text = "保存";
            SettingSave.UseVisualStyleBackColor = true;
            SettingSave.Click += SettingSave_Click;
            // 
            // CPU
            // 
            CPU.AutoSize = true;
            CPU.Location = new Point(138, 119);
            CPU.Name = "CPU";
            CPU.Size = new Size(202, 27);
            CPU.TabIndex = 8;
            CPU.Text = "自动化CPU亲和性管理";
            CPU.UseVisualStyleBackColor = true;
            CPU.CheckedChanged += CPU_CheckedChanged;
            // 
            // Min
            // 
            Min.AutoSize = true;
            Min.Location = new Point(138, 152);
            Min.Name = "Min";
            Min.Size = new Size(202, 27);
            Min.TabIndex = 9;
            Min.Text = "点击关闭时到系统托盘";
            Min.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 384);
            Controls.Add(Min);
            Controls.Add(CPU);
            Controls.Add(SettingSave);
            Controls.Add(ChooseHeadlessButton);
            Controls.Add(ChooseServerButton);
            Controls.Add(txtHeadlessPath);
            Controls.Add(txtServerPath);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "设置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtServerPath;
        private TextBox txtHeadlessPath;
        private Button ChooseServerButton;
        private Button ChooseHeadlessButton;
        private Button SettingSave;
        private CheckBox CPU;
        private CheckBox Min;
    }
}