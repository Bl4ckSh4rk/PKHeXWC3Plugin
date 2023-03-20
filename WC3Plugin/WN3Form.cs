using PKHeX.Core;

namespace WC3Plugin;

public partial class WN3Form : Form
{
    private readonly SAV3 sav;

    private readonly int NewsSize;

    public WN3Form(SAV3 sav)
    {
        this.sav = sav;

        NewsSize = sav.Japanese ? WonderNews3.SIZE_JAP : WonderNews3.SIZE;

        InitializeComponent();

        if (!((IGen3Wonder)sav).WonderNews.Data.IsEmpty())
        {
            TitleBox.Text = ((IGen3Wonder)sav).WonderNews.Title;
            WN3ExportButton.Enabled = true;
        }
    }

    private void WN3ImportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.WonderNews} (*.wn3)|*.wn3|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.WonderNews);
        ofd.FilterIndex = 1;

        WonderNews3 wn3 = new(new byte[NewsSize]);

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            long fileSize = new FileInfo(ofd.FileName).Length;

            if (fileSize == NewsSize)
            {
                try
                {
                    wn3 = new(File.ReadAllBytes(ofd.FileName));
                    wn3.FixChecksum();

                    ((IGen3Wonder)sav).WonderNews = wn3;

                    success = true;
                }
                catch
                {
                    _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.WonderNews), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, NewsSize), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.WonderNews)}\n\n\"{wn3.Title}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void WN3ExportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.WonderNews} (*.wn3)|*.wn3|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.WonderNews);
        sfd.FilterIndex = 1;

        byte[] data = new byte[NewsSize];

        ((IGen3Wonder)sav).WonderNews.Data.CopyTo(data, 0);

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                File.WriteAllBytes(sfd.FileName, data);

                success = true;
            }
            catch (Exception)
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.WonderNews), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.WonderNews, sfd.FileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
