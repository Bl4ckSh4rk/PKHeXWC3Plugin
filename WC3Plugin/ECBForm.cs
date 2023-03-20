using PKHeX.Core;

namespace WC3Plugin;

public partial class ECBForm : Form
{
    private readonly SAV3 sav;

    private readonly int BerrySize;
    private const int SIZE_RS = 1328;
    private const int SIZE_FRLGE = 52;

    public ECBForm(SAV3 sav)
    {
        this.sav = sav;

        if (sav is SAV3RS)
            BerrySize = SIZE_RS;
        else
            BerrySize = SIZE_FRLGE;

        InitializeComponent();

        if (!sav.GetEReaderBerry().IsEmpty())
        {
            TitleBox.Text = sav.EBerryName;
            ECBExportButton.Enabled = true;
        }
    }

    private void ECBImportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.ECardBerry} (*.ecb)|*.ecb|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.ECardBerry);
        ofd.FilterIndex = 1;

        string BerryName = string.Empty;

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            long fileSize = new FileInfo(ofd.FileName).Length;

            if (fileSize == BerrySize)
            {
                try
                {
                    sav.SetEReaderBerry(FixECBChecksum(File.ReadAllBytes(ofd.FileName)));
                    BerryName = sav.EBerryName;

                    success = true;
                }
                catch (Exception)
                {
                    _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.ECardBerry), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, BerrySize), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.ECardBerry)}\n\n\"{BerryName}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ECBExportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.ECardBerry} (*.ecb)|*.ecb|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.ECardBerry); ;
        sfd.FilterIndex = 1;

        byte[] data = sav.GetEReaderBerry();

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                File.WriteAllBytes(sfd.FileName, data);

                success = true;
            }
            catch (Exception)
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.ECardBerry), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.ECardBerry, sfd.FileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static byte[] FixECBChecksum(byte[] data)
    {
        uint chk = GetECBChecksum(data);

        data[data.Length - 4] = (byte)(chk & 0xFF);
        data[data.Length - 3] = (byte)(chk >> 8);

        return data;
    }

    public static ushort GetECBChecksum(byte[] data)
    {
        ushort chk = 0;

        if (data.Length == SIZE_RS)
        {
            for (int i = 0; i < SIZE_RS - 4; i++)
            {
                if (i < 0xC || i >= 0x14)
                    chk += (ushort)(data[i] & 0xFF);
            }
        }
        else
        {
            for (int i = 0; i < SIZE_FRLGE - 4; i++)
            {
                chk += (ushort)(data[i] & 0xFF);
            }
        }

        return chk;
    }
}
