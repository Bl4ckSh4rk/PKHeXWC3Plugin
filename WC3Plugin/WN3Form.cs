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
            TitleBox.Text = ((IGen3Wonder)sav).WonderNews.Title.Trim();
            WN3ExportButton.Enabled = true;
        }
    }

    private void WN3ImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.WonderNews} (*.wn3)|*.wn3|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.WonderNews);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportWN3(ofd.FileName);
    }

    private void WN3ExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.WonderNews} (*.wn3)|*.wn3|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.WonderNews);
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportWN3(sfd.FileName);
    }

    private void ImportWN3(string fileName)
    {
        bool success = false;
        WonderNews3 wn3 = new(new byte[NewsSize]);
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize == NewsSize)
        {
            try
            {
                wn3 = new(File.ReadAllBytes(fileName));
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

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.WonderNews)}\n\n\"{wn3.Title.Trim()}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ExportWN3(string fileName)
    {
        bool success = false;

        byte[] data = new byte[NewsSize];
        ((IGen3Wonder)sav).WonderNews.Data.CopyTo(data, 0);

        try
        {
            File.WriteAllBytes(fileName, data);

            success = true;
        }
        catch
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.WonderNews), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.WonderNews, fileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    void WN3Form_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    void WN3Form_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportWN3(files[0]);
    }
}
