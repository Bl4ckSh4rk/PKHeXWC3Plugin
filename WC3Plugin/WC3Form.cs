using PKHeX.Core;

namespace WC3Plugin;

public partial class WC3Form : Form
{
    private readonly SAV3 sav;

    private readonly int CardSize;
    private readonly int WC3FileSize;
    private readonly int WC3ScriptOffset;

    public WC3Form(SAV3 sav)
    {
        this.sav = sav;

        CardSize = sav.Japanese ? WonderCard3.SIZE_JAP : WonderCard3.SIZE;
        WC3ScriptOffset = CardSize + 0x50;
        WC3FileSize = WC3ScriptOffset + MysteryEvent3.SIZE;

        InitializeComponent();

        if (!((IGen3Wonder)sav).WonderCard.Data.IsEmpty())
        {
            TitleBox.Text = ((IGen3Wonder)sav).WonderCard.Title.Trim();
            WC3ExportButton.Enabled = true;
        }
    }

    private void WC3ImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.MysteryGift} (*.wc3)|*.wc3|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.MysteryGift);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportWC3(ofd.FileName);
    }

    private void WC3ExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.MysteryGift} (*.wc3)|*.wc3|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.MysteryGift);
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportWC3(sfd.FileName);
    }

    private void ImportWC3(string fileName)
    {
        bool success = false;
        WonderCard3 wc3 = new(new byte[CardSize]);
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize == WC3FileSize)
        {
            try
            {
                byte[] data = File.ReadAllBytes(fileName);

                wc3 = new(data[0..CardSize]);
                wc3.FixChecksum();

                MysteryEvent3 me3 = new(data[WC3ScriptOffset..]);
                me3.FixChecksum();

                ((IGen3Wonder)sav).WonderCard = wc3;
                sav.MysteryData = me3;

                success = true;
            }
            catch
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.MysteryGift), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, WC3FileSize), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.MysteryGift)}\n\n\"{wc3.Title.Trim()}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ExportWC3(string fileName)
    {
        bool success = false;

        byte[] data = new byte[WC3FileSize];
        ((IGen3Wonder)sav).WonderCard.Data.CopyTo(data, 0);
        sav.MysteryData.Data.CopyTo(data, WC3ScriptOffset);

        try
        {
            File.WriteAllBytes(fileName, data);

            success = true;
        }
        catch
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.MysteryGift), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.MysteryGift, fileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    void WC3Form_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    void WC3Form_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportWC3(files[0]);
    }
}
