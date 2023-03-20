namespace WC3Plugin;

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
        this.TitleBox = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // WC3ImportButton
        // 
        this.WC3ImportButton.Location = new System.Drawing.Point(14, 45);
        this.WC3ImportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.WC3ImportButton.Name = "WC3ImportButton";
        this.WC3ImportButton.Size = new System.Drawing.Size(88, 27);
        this.WC3ImportButton.TabIndex = 0;
        this.WC3ImportButton.Text = TranslationStrings.Import;
        this.WC3ImportButton.UseVisualStyleBackColor = true;
        this.WC3ImportButton.Click += new System.EventHandler(this.WC3ImportButton_Click);
        // 
        // WC3ExportButton
        // 
        this.WC3ExportButton.Enabled = false;
        this.WC3ExportButton.Location = new System.Drawing.Point(112, 45);
        this.WC3ExportButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.WC3ExportButton.Name = "WC3ExportButton";
        this.WC3ExportButton.Size = new System.Drawing.Size(88, 27);
        this.WC3ExportButton.TabIndex = 1;
        this.WC3ExportButton.Text = TranslationStrings.Export;
        this.WC3ExportButton.UseVisualStyleBackColor = true;
        this.WC3ExportButton.Click += new System.EventHandler(this.WC3ExportButton_Click);
        // 
        // TitleBox
        // 
        this.TitleBox.Location = new System.Drawing.Point(12, 12);
        this.TitleBox.Name = "TitleBox";
        this.TitleBox.ReadOnly = true;
        this.TitleBox.Size = new System.Drawing.Size(190, 23);
        this.TitleBox.TabIndex = 2;
        this.TitleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // WC3Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(214, 86);
        this.Controls.Add(this.TitleBox);
        this.Controls.Add(this.WC3ExportButton);
        this.Controls.Add(this.WC3ImportButton);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        this.Name = "WC3Form";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = TranslationStrings.MysteryGift;
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button WC3ImportButton;
    private System.Windows.Forms.Button WC3ExportButton;
    private TextBox TitleBox;
}