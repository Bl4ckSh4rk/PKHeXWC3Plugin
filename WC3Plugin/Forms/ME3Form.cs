using PKHeX.Core;

namespace WC3Plugin;

public partial class ME3Form : Form
{
    private readonly SAV3 sav;

    private static readonly string FileFilter = $"{TranslationStrings.MysteryEvent} (*.me3)|*.me3|{TranslationStrings.AllFiles} (*.*)|*.*";

    public ME3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        ME3ExportButton.Enabled = sav.HasME3();
    }

    private void ME3ImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = FileFilter;
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.MysteryEvent);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportME3(ofd.FileName);
    }

    private void ME3ExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = FileFilter;
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.MysteryEvent); ;
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportME3(sfd.FileName);
    }

    private void ImportME3(string fileName)
    {
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize is MysteryEvent3.SIZE or (MysteryEvent3.SIZE + RecordMixing3Gift.SIZE))
        {
            try
            {
                sav.ImportME3(File.ReadAllBytes(fileName));
                sav.State.Edited = true;

                Close();
                Message.ShowFileImported(TranslationStrings.MysteryEvent);
            }
            catch
            {
                Message.ShowFileReadError(TranslationStrings.MysteryEvent);
            }
        }
        else
        {
            Message.ShowInvalidFileSize(fileSize, MysteryEvent3.SIZE);
        }
    }

    private void ExportME3(string fileName)
    {
        try
        {
            File.WriteAllBytes(fileName, sav.ExportME3());

            Close();
            Message.ShowFileExported(TranslationStrings.MysteryEvent, fileName);
        }
        catch
        {
            Message.ShowFileWriteError(TranslationStrings.MysteryEvent);
        }
    }

    private void ME3Form_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    private void ME3Form_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportME3(files[0]);
    }
}
