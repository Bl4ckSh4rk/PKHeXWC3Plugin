using PKHeX.Core;

namespace WC3Plugin;

public partial class WN3Form : Form
{
    private readonly SAV3 sav;

    private static readonly string FileFilter = $"{TranslationStrings.WonderNews} (*.wn3)|*.wn3|{TranslationStrings.AllFiles} (*.*)|*.*";

    public WN3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        if (sav.HasWN3())
        {
            TitleBox.Text = ((IGen3Wonder)sav).WonderNews.Title.Trim();
            WN3ExportButton.Enabled = true;
        }
    }

    private void WN3ImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = FileFilter;
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.WonderNews);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportWN3(ofd.FileName);
    }

    private void WN3ExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = FileFilter;
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.WonderNews);
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportWN3(sfd.FileName);
    }

    private void ImportWN3(string fileName)
    {
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize == sav.GetWN3FileSize())
        {
            try
            {
                byte[] wn3 = File.ReadAllBytes(fileName);
                sav.ImportECB(wn3);

                Close();
                _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.WonderNews)}\n\n\"{((IGen3Wonder)sav).WonderNews.Title.Trim()}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.WonderNews), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, sav.GetWN3FileSize()), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ExportWN3(string fileName)
    {
        try
        {
            File.WriteAllBytes(fileName, sav.ExportWN3());

            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.WonderNews, fileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.WonderNews), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void WN3Form_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    private void WN3Form_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportWN3(files[0]);
    }
}
