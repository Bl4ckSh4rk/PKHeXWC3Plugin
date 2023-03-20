namespace WC3Plugin;

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
        this.TitleBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // ECTExportButton
        // 
        this.ECTExportButton.Location = new System.Drawing.Point(112, 45);
        this.ECTExportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.ECTExportButton.Name = "ECTExportButton";
        this.ECTExportButton.Size = new System.Drawing.Size(88, 27);
        this.ECTExportButton.TabIndex = 3;
        this.ECTExportButton.Text = TranslationStrings.Export;
        this.ECTExportButton.UseVisualStyleBackColor = true;
        this.ECTExportButton.Click += new System.EventHandler(this.ECTExportButton_Click);
        // 
        // ECTImportButton
        // 
        this.ECTImportButton.Location = new System.Drawing.Point(14, 45);
        this.ECTImportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.ECTImportButton.Name = "ECTImportButton";
        this.ECTImportButton.Size = new System.Drawing.Size(88, 27);
        this.ECTImportButton.TabIndex = 2;
        this.ECTImportButton.Text = TranslationStrings.Import;
        this.ECTImportButton.UseVisualStyleBackColor = true;
        this.ECTImportButton.Click += new System.EventHandler(this.ECTImportButton_Click);
        // 
        // TitleBox
        // 
        this.TitleBox.Location = new System.Drawing.Point(12, 12);
        this.TitleBox.Name = "TitleBox";
        this.TitleBox.ReadOnly = true;
        this.TitleBox.Size = new System.Drawing.Size(190, 23);
        this.TitleBox.TabIndex = 4;
        this.TitleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // ECTForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(214, 86);
        this.Controls.Add(this.TitleBox);
        this.Controls.Add(this.ECTExportButton);
        this.Controls.Add(this.ECTImportButton);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.Name = "ECTForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = TranslationStrings.ECardTrainer;
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button ECTExportButton;
    private System.Windows.Forms.Button ECTImportButton;
    private TextBox TitleBox;
}