namespace WC3Plugin
{
    partial class ECTForm
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
            this.ECTExportButton = new System.Windows.Forms.Button();
            this.ECTImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ECTExportButton
            // 
            this.ECTExportButton.Location = new System.Drawing.Point(94, 36);
            this.ECTExportButton.Name = "ECTExportButton";
            this.ECTExportButton.Size = new System.Drawing.Size(75, 23);
            this.ECTExportButton.TabIndex = 3;
            this.ECTExportButton.Text = "Export";
            this.ECTExportButton.UseVisualStyleBackColor = true;
            this.ECTExportButton.Click += new System.EventHandler(this.ECTExportButton_Click);
            // 
            // ECTImportButton
            // 
            this.ECTImportButton.Location = new System.Drawing.Point(12, 36);
            this.ECTImportButton.Name = "ECTImportButton";
            this.ECTImportButton.Size = new System.Drawing.Size(75, 23);
            this.ECTImportButton.TabIndex = 2;
            this.ECTImportButton.Text = "Import";
            this.ECTImportButton.UseVisualStyleBackColor = true;
            this.ECTImportButton.Click += new System.EventHandler(this.ECTImportButton_Click);
            // 
            // ECTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 94);
            this.Controls.Add(this.ECTExportButton);
            this.Controls.Add(this.ECTImportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ECTForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "e-Card Trainer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ECTExportButton;
        private System.Windows.Forms.Button ECTImportButton;
    }
}