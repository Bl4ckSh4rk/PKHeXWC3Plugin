using PKHeX.Core;

namespace WC3Plugin;

public partial class WC3Form : Form
{
    private readonly SAV3 sav;

    private static readonly string FileFilter = $"{TranslationStrings.MysteryGift} (*.wc3)|*.wc3|{TranslationStrings.AllFiles} (*.*)|*.*";

    public WC3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        if (sav.HasWC3())
        {
            TitleBox.Text = ((IGen3Wonder)sav).WonderCard.Title.Trim();
            WC3ExportButton.Enabled = true;
        }
    }

    private void WC3ImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = FileFilter;
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.MysteryGift);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportWC3(ofd.FileName);
    }

    private void WC3ExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = FileFilter;
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.MysteryGift);
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportWC3(sfd.FileName);
    }

    private void ImportWC3(string fileName)
    {
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize == sav.GetWC3FileSize())
        {
            try
            {
                byte[] wc3 = File.ReadAllBytes(fileName);
                sav.ImportWC3(wc3);

                Close();
                Message.ShowFileImported(TranslationStrings.MysteryGift, ((IGen3Wonder)sav).WonderCard.Title.Trim());
            }
            catch
            {
                Message.ShowFileReadError(TranslationStrings.MysteryGift);
            }
        }
        else
        {
            Message.ShowInvalidFileSize(fileSize, sav.GetWC3FileSize());
        }
    }

    private void ExportWC3(string fileName)
    {
        try
        {
            File.WriteAllBytes(fileName, sav.ExportWC3());

            Close();
            Message.ShowFileExported(TranslationStrings.MysteryGift, fileName);
        }
        catch
        {
            Message.ShowFileWriteError(TranslationStrings.MysteryGift);
        }
    }

    private void WC3Form_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    private void WC3Form_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportWC3(files[0]);
    }
}
