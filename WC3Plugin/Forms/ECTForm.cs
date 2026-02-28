using PKHeX.Core;

namespace WC3Plugin;

public partial class ECTForm : Form
{
    private readonly SAV3 sav;

    private static readonly string FileFilter = $"{TranslationStrings.ECardTrainer} (*.ect)|*.ect|{TranslationStrings.AllFiles} (*.*)|*.*";

    public ECTForm(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        if (MysteryDataUtil.HasECT(sav))
        {
            TitleBox.Text = StringConverter3.GetString(sav.ExportECT()[4 .. (4 + (sav.Japanese ? 5 : 7))], sav.Japanese).Trim();
            ECTExportButton.Enabled = true;
        }
    }

    private void ECTImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = FileFilter;
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.ECardTrainer);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportECT(ofd.FileName);
    }

    private void ECTExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = FileFilter;
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.ECardTrainer); ;
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportECT(sfd.FileName);
    }

    private void ImportECT(string fileName)
    {
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize == sav.GetECTFileSize())
        {
            try
            {
                sav.ImportECT(File.ReadAllBytes(fileName));
                sav.State.Edited = true;
                string TrainerName = StringConverter3.GetString(sav.ExportECT()[4..(4 + (sav.Japanese ? 5 : 7))], sav.Japanese).Trim();

                Close();
                Message.ShowFileImported(TranslationStrings.ECardTrainer, TrainerName);
            }
            catch
            {
                Message.ShowFileReadError(TranslationStrings.ECardTrainer);
            }
        }
        else
        {
            Message.ShowInvalidFileSize(fileSize, sav.GetECTFileSize());
        }
    }

    private void ExportECT(string fileName)
    {
        try
        {
            File.WriteAllBytes(fileName, sav.ExportECT());

            Close();
            Message.ShowFileExported(TranslationStrings.ECardTrainer, fileName);
        }
        catch
        {
            Message.ShowFileWriteError(TranslationStrings.ECardTrainer);
        }
    }

    private void ECTForm_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    private void ECTForm_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportECT(files[0]);
    }
}
