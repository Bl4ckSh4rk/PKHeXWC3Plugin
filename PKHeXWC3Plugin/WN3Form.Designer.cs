namespace WC3Plugin
{
    partial class WN3Form
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
            this.WN3ExportButton = new System.Windows.Forms.Button();
            this.WN3ImportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LangEUButton = new System.Windows.Forms.RadioButton();
            this.LangJAPButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WN3ExportButton
            // 
            this.WN3ExportButton.Location = new System.Drawing.Point(94, 59);
            this.WN3ExportButton.Name = "WN3ExportButton";
            this.WN3ExportButton.Size = new System.Drawing.Size(75, 23);
            this.WN3ExportButton.TabIndex = 3;
            this.WN3ExportButton.Text = "Export";
            this.WN3ExportButton.UseVisualStyleBackColor = true;
            this.WN3ExportButton.Click += new System.EventHandler(this.WN3ExportButton_Click);
            // 
            // WN3ImportButton
            // 
            this.WN3ImportButton.Location = new System.Drawing.Point(12, 59);
            this.WN3ImportButton.Name = "WN3ImportButton";
            this.WN3ImportButton.Size = new System.Drawing.Size(75, 23);
            this.WN3ImportButton.TabIndex = 2;
            this.WN3ImportButton.Text = "Import";
            this.WN3ImportButton.UseVisualStyleBackColor = true;
            this.WN3ImportButton.Click += new System.EventHandler(this.WN3ImportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LangEUButton);
            this.groupBox1.Controls.Add(this.LangJAPButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 41);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detected save file region";
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
            // 
            // WN3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 94);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WN3ExportButton);
            this.Controls.Add(this.WN3ImportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WN3Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wondernews";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WN3ExportButton;
        private System.Windows.Forms.Button WN3ImportButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LangEUButton;
        private System.Windows.Forms.RadioButton LangJAPButton;
    }
}