namespace WC3Plugin
{
    partial class WC3Form
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
            this.WC3ImportButton = new System.Windows.Forms.Button();
            this.WC3ExportButton = new System.Windows.Forms.Button();
            this.LangJAPButton = new System.Windows.Forms.RadioButton();
            this.LangEUButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WC3ImportButton
            // 
            this.WC3ImportButton.Location = new System.Drawing.Point(12, 59);
            this.WC3ImportButton.Name = "WC3ImportButton";
            this.WC3ImportButton.Size = new System.Drawing.Size(75, 23);
            this.WC3ImportButton.TabIndex = 0;
            this.WC3ImportButton.Text = "Import";
            this.WC3ImportButton.UseVisualStyleBackColor = true;
            this.WC3ImportButton.Click += new System.EventHandler(this.WC3ImportButton_Click);
            // 
            // WC3ExportButton
            // 
            this.WC3ExportButton.Location = new System.Drawing.Point(94, 59);
            this.WC3ExportButton.Name = "WC3ExportButton";
            this.WC3ExportButton.Size = new System.Drawing.Size(75, 23);
            this.WC3ExportButton.TabIndex = 1;
            this.WC3ExportButton.Text = "Export";
            this.WC3ExportButton.UseVisualStyleBackColor = true;
            this.WC3ExportButton.Click += new System.EventHandler(this.WC3ExportButton_Click);
            // 
            // LangJAPButton
            // 
            this.LangJAPButton.AutoSize = true;
            this.LangJAPButton.Location = new System.Drawing.Point(90, 18);
            this.LangJAPButton.Name = "LangJAPButton";
            this.LangJAPButton.Size = new System.Drawing.Size(44, 17);
            this.LangJAPButton.TabIndex = 2;
            this.LangJAPButton.Text = "JAP";
            this.LangJAPButton.UseVisualStyleBackColor = true;
            this.LangJAPButton.CheckedChanged += new System.EventHandler(this.LangJAPButton_CheckedChanged);
            // 
            // LangEUButton
            // 
            this.LangEUButton.AutoSize = true;
            this.LangEUButton.Location = new System.Drawing.Point(24, 18);
            this.LangEUButton.Name = "LangEUButton";
            this.LangEUButton.Size = new System.Drawing.Size(60, 17);
            this.LangEUButton.TabIndex = 3;
            this.LangEUButton.TabStop = true;
            this.LangEUButton.Text = "EU/US";
            this.LangEUButton.UseVisualStyleBackColor = true;
            this.LangEUButton.CheckedChanged += new System.EventHandler(this.LangEUButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LangEUButton);
            this.groupBox1.Controls.Add(this.LangJAPButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 41);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detected save file region";
            // 
            // WC3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 94);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WC3ExportButton);
            this.Controls.Add(this.WC3ImportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WC3Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mystery Gift";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WC3ImportButton;
        private System.Windows.Forms.Button WC3ExportButton;
        private System.Windows.Forms.RadioButton LangJAPButton;
        private System.Windows.Forms.RadioButton LangEUButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}