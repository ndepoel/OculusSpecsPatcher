namespace OculusSpecsPatcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtOculusHomeDir = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnPatch = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblSelectDir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOculusHomeDir
            // 
            this.txtOculusHomeDir.Location = new System.Drawing.Point(12, 25);
            this.txtOculusHomeDir.Name = "txtOculusHomeDir";
            this.txtOculusHomeDir.Size = new System.Drawing.Size(327, 20);
            this.txtOculusHomeDir.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(345, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnPatch
            // 
            this.btnPatch.Location = new System.Drawing.Point(12, 385);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(75, 23);
            this.btnPatch.TabIndex = 2;
            this.btnPatch.Text = "Patch!";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 81);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(408, 298);
            this.txtOutput.TabIndex = 3;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 65);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(61, 13);
            this.lblLog.TabIndex = 4;
            this.lblLog.Text = "Log output:";
            // 
            // lblSelectDir
            // 
            this.lblSelectDir.AutoSize = true;
            this.lblSelectDir.Location = new System.Drawing.Point(12, 9);
            this.lblSelectDir.Name = "lblSelectDir";
            this.lblSelectDir.Size = new System.Drawing.Size(150, 13);
            this.lblSelectDir.TabIndex = 5;
            this.lblSelectDir.Text = "Select Oculus Home directory:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 420);
            this.Controls.Add(this.lblSelectDir);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnPatch);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtOculusHomeDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Oculus Hardware Specs Patcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOculusHomeDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnPatch;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblSelectDir;
    }
}