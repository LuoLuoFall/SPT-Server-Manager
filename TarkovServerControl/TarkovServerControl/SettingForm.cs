using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace TarkovServerControl
{
    public partial class SettingForm : Form
    {
        private Config config;


        string configFile = "config.json";

        public SettingForm()
        {
            InitializeComponent();
            LoadConfig();
        }

        //加载配置文件
        private void LoadConfig()
        {
            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);

                config = JsonSerializer.Deserialize<Config>(json);

                if (config != null)
                {
                    txtServerPath.Text = config.ServerPath;
                    txtHeadlessPath.Text = config.HeadlessPath;
                    CPU.Checked = config.EnableCpuAffinity;
                    Min.Checked = config.MinimizeToTray;
                }
            }
        }
        
        private void ChooseServerButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtServerPath.Text = dialog.SelectedPath;
            }
        }

        private void ChooseHeadlessButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtHeadlessPath.Text = dialog.SelectedPath;
            }
        }

        private void SettingSave_Click(object sender, EventArgs e)
        {
            try
            {
                config = new Config();

                config.ServerPath = txtServerPath.Text;
                config.HeadlessPath = txtHeadlessPath.Text;
                config.EnableCpuAffinity = CPU.Checked;
                config.MinimizeToTray = Min.Checked;


                string json = JsonSerializer.Serialize(
                    config,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }
                );


                File.WriteAllText(
                    "config.json",
                    json
                );


                MessageBox.Show(
                    "保存成功",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                //关闭设置窗口
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "保存失败:\n" + ex.Message
                );
            }
        }

        private void CPU_CheckedChanged(object sender, EventArgs e)
        {
        }
    }

}