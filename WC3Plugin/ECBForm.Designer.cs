namespace WC3Plugin;

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
        this.TitleBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // ECBExportButton
        // 
        this.ECBExportButton.Location = new System.Drawing.Point(112, 45);
        this.ECBExportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.ECBExportButton.Name = "ECBExportButton";
        this.ECBExportButton.Size = new System.Drawing.Size(88, 27);
        this.ECBExportButton.TabIndex = 3;
        this.ECBExportButton.Text = TranslationStrings.Export;
        this.ECBExportButton.UseVisualStyleBackColor = true;
        this.ECBExportButton.Click += new System.EventHandler(this.ECBExportButton_Click);
        // 
        // ECBImportButton
        // 
        this.ECBImportButton.Location = new System.Drawing.Point(14, 45);
        this.ECBImportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.ECBImportButton.Name = "ECBImportButton";
        this.ECBImportButton.Size = new System.Drawing.Size(88, 27);
        this.ECBImportButton.TabIndex = 2;
        this.ECBImportButton.Text = TranslationStrings.Import;
        this.ECBImportButton.UseVisualStyleBackColor = true;
        this.ECBImportButton.Click += new System.EventHandler(this.ECBImportButton_Click);
        // 
        // TitleBox
        // 
        this.TitleBox.Location = new System.Drawing.Point(12, 12);
        this.TitleBox.Name = "TitleBox";
        this.TitleBox.ReadOnly = true;
        this.TitleBox.Size = new System.Drawing.Size(190, 23);
        this.TitleBox.TabIndex = 5;
        this.TitleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // ECBForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(214, 86);
        this.Controls.Add(this.TitleBox);
        this.Controls.Add(this.ECBExportButton);
        this.Controls.Add(this.ECBImportButton);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.Name = "ECBForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = TranslationStrings.ECardBerry;
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button ECBExportButton;
    private System.Windows.Forms.Button ECBImportButton;
    private TextBox TitleBox;
}