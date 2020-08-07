using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DllRegistrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Regasm.OutputDataReceiverEvent += UpdateLabel;

            foreach (string path in Regasm.GetPaths(false))
                comboBox_regasmPaths.Items.Add(path);
            foreach (string path in Regasm.GetPaths(true))
                comboBox_regasmPaths.Items.Add(path);

            List<string> regasmPaths = new List<string>();
            foreach (var path in comboBox_regasmPaths.Items)
                regasmPaths.Add(path.ToString());

            string bestRgsm = Regasm.FindBestRegasm(regasmPaths);
            if(!string.IsNullOrEmpty(bestRgsm))
            {
                comboBox_regasmPaths.SelectedItem = bestRgsm;
            }
            
        }
        


        private void UpdateLabel(string text)
        {
            textBox_regasmOutput.BeginInvoke((MethodInvoker)delegate () { textBox_regasmOutput.Text += text; });
        }

        #region DRAG DROP
        private void label_dllPaths_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            label_dllPaths.Text = "";
            label_dllPaths.TextAlign = ContentAlignment.TopLeft;

            foreach (var file in files)
            {
                label_dllPaths.Text += file + Environment.NewLine;
            }

        }

        private void label_dllPaths_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; ;
            bool isValid = files.All(f => Path.GetExtension(f) == ".dll");

            if (isValid)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion

        private void button_Register_Click(object sender, EventArgs e)
        {
            if (dllPathsAreOk())
            {
                textBox_regasmOutput.Clear();

                var paths = label_dllPaths.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var path in paths)
                    Regasm.Register(comboBox_regasmPaths.SelectedItem.ToString(), path);
            }
            else
            {
                MessageBox.Show(this, "Path to dll is not correct.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_Unregister_Click(object sender, EventArgs e)
        {
            if (dllPathsAreOk())
            {
                textBox_regasmOutput.Clear();

                var paths = label_dllPaths.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var path in paths)
                    Regasm.Unregister(comboBox_regasmPaths.SelectedItem.ToString(), path);
            }
            else
            {
                MessageBox.Show(this, "Path to dll is not correct.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool dllPathsAreOk()
        {
            var paths = label_dllPaths.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var path in paths)
            {
                if (!File.Exists(path))
                    return false;
            }

            return true;
        }


        private void label_dllPaths_Click(object sender, EventArgs e)
        {
            selectDllsDialog();
        }

        private void selectDllsDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "dll|*.dll";
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var paths = fileDialog.FileNames;
                label_dllPaths.Text = "";
                label_dllPaths.TextAlign = ContentAlignment.TopLeft;

                foreach (var path in paths)
                {
                    label_dllPaths.Text += path + Environment.NewLine;
                }
            }
        }


    }
}
