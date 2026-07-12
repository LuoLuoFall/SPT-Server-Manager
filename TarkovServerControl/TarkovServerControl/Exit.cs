using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarkovServerControl
{
    public partial class Exit : Form
    {

        public enum ExitResult
        {
            KeepRunning,
            Cancel,
            CloseServices
        }


        public ExitResult Result { get; private set; }



        public Exit(string message)
        {
            InitializeComponent();

            labelMessage.Text = message;

            Result = ExitResult.Cancel;
        }



        private void buttonKeep_Click(object sender, EventArgs e)
        {
            Result = ExitResult.KeepRunning;

            DialogResult = DialogResult.OK;

            Close();
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Result = ExitResult.Cancel;

            DialogResult = DialogResult.Cancel;

            Close();
        }



        private void buttonCloseService_Click(object sender, EventArgs e)
        {
            Result = ExitResult.CloseServices;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}