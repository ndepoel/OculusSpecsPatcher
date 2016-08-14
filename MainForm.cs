using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OculusSpecsPatcher
{
    public partial class MainForm : Form
    {
        private readonly Patcher _patcher = new Patcher();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _patcher.OnLogInfo += msg => txtOutput.AppendText(msg + Environment.NewLine);
            _patcher.OnLogError += msg => txtOutput.AppendText("ERROR - " + msg + Environment.NewLine);

            txtOculusHomeDir.Text = OculusUtil.GetOculusHomeDir()?.FullName;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                SelectedPath = txtOculusHomeDir.Text,
                Description = @"Select Oculus Home directory",
                ShowNewFolderButton = false,
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            txtOculusHomeDir.Text = dialog.SelectedPath;
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            _patcher.Patch(txtOculusHomeDir.Text);
        }
    }
}
