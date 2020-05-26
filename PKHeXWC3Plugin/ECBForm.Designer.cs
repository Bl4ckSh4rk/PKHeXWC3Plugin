namespace WC3Plugin
{
    partial class ECBForm
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
            this.ECBExportButton = new System.Windows.Forms.Button();
            this.ECBImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ECBExportButton
            // 
            this.ECBExportButton.Location = new System.Drawing.Point(94, 36);
            this.ECBExportButton.Name = "ECBExportButton";
            this.ECBExportButton.Size = new System.Drawing.Size(75, 23);
            this.ECBExportButton.TabIndex = 3;
            this.ECBExportButton.Text = "Export";
            this.ECBExportButton.UseVisualStyleBackColor = true;
            this.ECBExportButton.Click += new System.EventHandler(this.ECBExportButton_Click);
            // 
            // ECBImportButton
            // 
            this.ECBImportButton.Location = new System.Drawing.Point(12, 36);
            this.ECBImportButton.Name = "ECBImportButton";
            this.ECBImportButton.Size = new System.Drawing.Size(75, 23);
            this.ECBImportButton.TabIndex = 2;
            this.ECBImportButton.Text = "Import";
            this.ECBImportButton.UseVisualStyleBackColor = true;
            this.ECBImportButton.Click += new System.EventHandler(this.ECBImportButton_Click);
            // 
            // ECBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 94);
            this.Controls.Add(this.ECBExportButton);
            this.Controls.Add(this.ECBImportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ECBForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "e-Card Berry";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ECBExportButton;
        private System.Windows.Forms.Button ECBImportButton;
    }
}