namespace WC3Plugin
{
    partial class ME3Form
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
            this.ME3ExportButton = new System.Windows.Forms.Button();
            this.ME3ImportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ME3ExportButton
            // 
            this.ME3ExportButton.Location = new System.Drawing.Point(94, 36);
            this.ME3ExportButton.Name = "ME3ExportButton";
            this.ME3ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ME3ExportButton.TabIndex = 3;
            this.ME3ExportButton.Text = "Export";
            this.ME3ExportButton.UseVisualStyleBackColor = true;
            this.ME3ExportButton.Click += new System.EventHandler(this.ME3ExportButton_Click);
            // 
            // ME3ImportButton
            // 
            this.ME3ImportButton.Location = new System.Drawing.Point(12, 36);
            this.ME3ImportButton.Name = "ME3ImportButton";
            this.ME3ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ME3ImportButton.TabIndex = 2;
            this.ME3ImportButton.Text = "Import";
            this.ME3ImportButton.UseVisualStyleBackColor = true;
            this.ME3ImportButton.Click += new System.EventHandler(this.ME3ImportButton_Click);
            // 
            // ME3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 94);
            this.Controls.Add(this.ME3ExportButton);
            this.Controls.Add(this.ME3ImportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ME3Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mystery Event";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ME3ExportButton;
        private System.Windows.Forms.Button ME3ImportButton;
    }
}