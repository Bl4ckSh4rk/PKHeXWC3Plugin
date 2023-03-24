using PKHeX.Core;
using static System.Buffers.Binary.BinaryPrimitives;

namespace WC3Plugin;

public partial class ECBForm : Form
{
    private readonly SAV3 sav;

    private readonly int BerrySize;
    private const int SIZE_RS = 1328;
    private const int SIZE_FRLGE = 52;
    private const int VAR_ENIGMA_BERRY_AVAILABLE_RSE = 0x402D;
    private const int VAR_ENIGMA_BERRY_AVAILABLE_FRLG = 0x4033; // unused but set by script command

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
            TitleBox.Text = sav.EBerryName.Trim();
            ECBExportButton.Enabled = true;
        }
    }

    private void ECBImportButton_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.ECardBerry} (*.ecb)|*.ecb|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.ECardBerry);
        ofd.FilterIndex = 1;

        if (ofd.ShowDialog() == DialogResult.OK)
            ImportECB(ofd.FileName);
    }

    private void ECBExportButton_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.ECardBerry} (*.ecb)|*.ecb|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.ECardBerry); ;
        sfd.FilterIndex = 1;

        if (sfd.ShowDialog() == DialogResult.OK)
            ExportECB(sfd.FileName);
    }

    private void ImportECB(string fileName)
    {
        bool success = false;
        string BerryName = string.Empty;
        long fileSize = new FileInfo(fileName).Length;

        if (fileSize == BerrySize)
        {
            try
            {
                sav.SetEReaderBerry(FixECBChecksum(File.ReadAllBytes(fileName)));
                BerryName = sav.EBerryName.Trim();
                sav.SetWork((sav is SAV3RS or SAV3E) ? VAR_ENIGMA_BERRY_AVAILABLE_RSE : VAR_ENIGMA_BERRY_AVAILABLE_FRLG, 1);

                success = true;
            }
            catch
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.ECardBerry), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, BerrySize), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.ECardBerry)}\n\n\"{BerryName}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ExportECB(string fileName)
    {
        bool success = false;

        try
        {
            File.WriteAllBytes(fileName, sav.GetEReaderBerry());

            success = true;
        }
        catch
        {
            _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.ECardBerry), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.ECardBerry, fileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    void ECBForm_DragEnter(object sender, DragEventArgs e)
    {
        if (e is null)
            return;
        if (e.AllowedEffect == (DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move))
            e.Effect = DragDropEffects.Copy;
    }

    void ECBForm_DragDrop(object sender, DragEventArgs e)
    {
        if (e?.Data?.GetData(DataFormats.FileDrop) is not string[] { Length: not 0 } files)
            return;
        ImportECB(files[0]);
    }

    private static byte[] FixECBChecksum(byte[] data)
    {
        ushort chk = GetECBChecksum(data);

        WriteUInt16LittleEndian(data.AsSpan(data.Length - 4), chk);

        return data;
    }

    private static ushort GetECBChecksum(byte[] data)
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
