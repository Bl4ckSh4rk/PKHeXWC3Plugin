using PKHeX.Core;

namespace WC3Plugin;

public partial class ME3Form : Form
{
    private readonly SAV3 sav;

    public ME3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        ME3ExportButton.Enabled = !sav.MysteryData.Data.IsEmpty() && ((IGen3Wonder)sav).WonderCard.Data.IsEmpty();
    }

    private void ME3ImportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.MysteryEvent} (*.me3)|*.me3|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.MysteryEvent);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            long fileSize = new FileInfo(ofd.FileName).Length;

            if (fileSize is MysteryEvent3.SIZE or (MysteryEvent3.SIZE + RecordMixing3Gift.SIZE))
            {
                try
                {
                    byte[] data = File.ReadAllBytes(ofd.FileName);

                    Gen3MysteryData mystery;

                    if (sav is SAV3RS)
                        mystery = new MysteryEvent3RS(data[..MysteryEvent3.SIZE]);
                    else
                        mystery = new MysteryEvent3(data[..MysteryEvent3.SIZE]);

                    mystery.FixChecksum();
                    sav.MysteryData = mystery;

                    ((IGen3Wonder)sav).WonderCard = new(new byte[sav.Japanese ? WonderCard3.SIZE_JAP : WonderCard3.SIZE]);

                    if (data.Length > MysteryEvent3.SIZE)
                    {
                        RecordMixing3Gift rm3 = new(data[MysteryEvent3.SIZE..]);
                        rm3.FixChecksum();
                        ((IGen3Hoenn)sav).RecordMixingGift = rm3;
                    }

                    success = true;
                }
                catch
                {
                    _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.MysteryEvent), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, MysteryEvent3.SIZE), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileImported, TranslationStrings.MysteryEvent), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ME3ExportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.MysteryEvent} (*.me3)|*.me3|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.MysteryEvent); ;
        sfd.FilterIndex = 1;

        byte[] data = sav.MysteryData.Data;

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                File.WriteAllBytes(sfd.FileName, data);

                success = true;
            }
            catch
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.MysteryEvent), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.MysteryEvent, sfd.FileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
