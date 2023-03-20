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
            TitleBox.Text = ((IGen3Wonder)sav).WonderCard.Title;
            WC3ExportButton.Enabled = true;
        }
    }

    private void WC3ImportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.MysteryGift} (*.wc3)|*.wc3|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.MysteryGift);
        ofd.FilterIndex = 1;

        WonderCard3 wc3 = new(new byte[CardSize]);

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            long fileSize = new FileInfo(ofd.FileName).Length;

            if (fileSize == WC3FileSize)
            {
                try
                {
                    byte[] data = File.ReadAllBytes(ofd.FileName);

                    wc3 = new(data[0..CardSize]);
                    wc3.FixChecksum();

                    MysteryEvent3 me3 = new(data[WC3ScriptOffset..]);
                    me3.FixChecksum();

                    ((IGen3Wonder)sav).WonderCard = wc3;
                    sav.MysteryData = me3;

                    success = true;
                }
                catch (Exception)
                {
                    _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.MysteryGift), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, WC3FileSize), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.MysteryGift)}\n\n\"{wc3.Title}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void WC3ExportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.MysteryGift} (*.wc3)|*.wc3|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.MysteryGift);
        sfd.FilterIndex = 1;

        byte[] data = new byte[WC3FileSize];

        ((IGen3Wonder)sav).WonderCard.Data.CopyTo(data, 0);
        sav.MysteryData.Data.CopyTo(data, WC3ScriptOffset);

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                File.WriteAllBytes(sfd.FileName, data);

                success = true;
            }
            catch
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.MysteryGift), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.MysteryGift, sfd.FileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
