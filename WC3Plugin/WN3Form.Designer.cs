namespace WC3Plugin;

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
        this.TitleBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // WN3ExportButton
        // 
        this.WN3ExportButton.Location = new System.Drawing.Point(112, 45);
        this.WN3ExportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.WN3ExportButton.Name = "WN3ExportButton";
        this.WN3ExportButton.Size = new System.Drawing.Size(88, 27);
        this.WN3ExportButton.TabIndex = 3;
        this.WN3ExportButton.Text = TranslationStrings.Export;
        this.WN3ExportButton.UseVisualStyleBackColor = true;
        this.WN3ExportButton.Click += new System.EventHandler(this.WN3ExportButton_Click);
        // 
        // WN3ImportButton
        // 
        this.WN3ImportButton.Location = new System.Drawing.Point(14, 45);
        this.WN3ImportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.WN3ImportButton.Name = "WN3ImportButton";
        this.WN3ImportButton.Size = new System.Drawing.Size(88, 27);
        this.WN3ImportButton.TabIndex = 2;
        this.WN3ImportButton.Text = TranslationStrings.Import;
        this.WN3ImportButton.UseVisualStyleBackColor = true;
        this.WN3ImportButton.Click += new System.EventHandler(this.WN3ImportButton_Click);
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
        // WN3Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(214, 86);
        this.Controls.Add(this.TitleBox);
        this.Controls.Add(this.WN3ExportButton);
        this.Controls.Add(this.WN3ImportButton);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.Name = "WN3Form";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = TranslationStrings.WonderNews;
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button WN3ExportButton;
    private System.Windows.Forms.Button WN3ImportButton;
    private TextBox TitleBox;
}