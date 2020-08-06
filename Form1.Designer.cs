namespace DllRegistrar
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox_regasmPaths = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_dllPaths = new System.Windows.Forms.Label();
            this.button_Register = new System.Windows.Forms.Button();
            this.button_Unregister = new System.Windows.Forms.Button();
            this.textBox_regasmOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_regasmPaths
            // 
            this.comboBox_regasmPaths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_regasmPaths.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_regasmPaths.FormattingEnabled = true;
            this.comboBox_regasmPaths.Location = new System.Drawing.Point(69, 27);
            this.comboBox_regasmPaths.Name = "comboBox_regasmPaths";
            this.comboBox_regasmPaths.Size = new System.Drawing.Size(437, 21);
            this.comboBox_regasmPaths.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RegAsm:";
            // 
            // label_dllPaths
            // 
            this.label_dllPaths.AllowDrop = true;
            this.label_dllPaths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_dllPaths.Location = new System.Drawing.Point(16, 61);
            this.label_dllPaths.Name = "label_dllPaths";
            this.label_dllPaths.Size = new System.Drawing.Size(490, 120);
            this.label_dllPaths.TabIndex = 2;
            this.label_dllPaths.Text = "Click here to select dll\'s.\r\n(You can drag dll\'s if you dragging from application" +
    " with admin permissions).";
            this.label_dllPaths.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_dllPaths.Click += new System.EventHandler(this.label_dllPaths_Click);
            this.label_dllPaths.DragDrop += new System.Windows.Forms.DragEventHandler(this.label_dllPaths_DragDrop);
            this.label_dllPaths.DragEnter += new System.Windows.Forms.DragEventHandler(this.label_dllPaths_DragEnter);
            // 
            // button_Register
            // 
            this.button_Register.Location = new System.Drawing.Point(168, 184);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(75, 23);
            this.button_Register.TabIndex = 3;
            this.button_Register.Text = "Register";
            this.button_Register.UseVisualStyleBackColor = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // button_Unregister
            // 
            this.button_Unregister.Location = new System.Drawing.Point(249, 184);
            this.button_Unregister.Name = "button_Unregister";
            this.button_Unregister.Size = new System.Drawing.Size(75, 23);
            this.button_Unregister.TabIndex = 4;
            this.button_Unregister.Text = "Unregister";
            this.button_Unregister.UseVisualStyleBackColor = true;
            this.button_Unregister.Click += new System.EventHandler(this.button_Unregister_Click);
            // 
            // textBox_regasmOutput
            // 
            this.textBox_regasmOutput.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.textBox_regasmOutput.Location = new System.Drawing.Point(16, 215);
            this.textBox_regasmOutput.Multiline = true;
            this.textBox_regasmOutput.Name = "textBox_regasmOutput";
            this.textBox_regasmOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_regasmOutput.Size = new System.Drawing.Size(490, 130);
            this.textBox_regasmOutput.TabIndex = 6;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 356);
            this.Controls.Add(this.textBox_regasmOutput);
            this.Controls.Add(this.button_Unregister);
            this.Controls.Add(this.button_Register);
            this.Controls.Add(this.label_dllPaths);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_regasmPaths);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DllRegistrar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_regasmPaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_dllPaths;
        private System.Windows.Forms.Button button_Register;
        private System.Windows.Forms.Button button_Unregister;
        private System.Windows.Forms.TextBox textBox_regasmOutput;
    }
}

