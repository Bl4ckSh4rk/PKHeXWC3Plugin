using PKHeX.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WC3Plugin;

public partial class ECTForm : Form
{
    private readonly SAV3 sav;

    private const int SIZE = 188;

    public ECTForm(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        if (!sav.GetEReaderTrainer().IsEmpty())
        {
            TitleBox.Text = StringConverter3.GetString(sav.GetEReaderTrainer().AsSpan(8, sav.Japanese ? 5 : 7), sav.Japanese);
            ECTExportButton.Enabled= true;
        }
    }

    private void ECTImportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var ofd = new OpenFileDialog();
        ofd.Filter = $"{TranslationStrings.ECardTrainer} (*.ect)|*.ect|{TranslationStrings.AllFiles} (*.*)|*.*";
        ofd.Title = string.Format(TranslationStrings.OpenFile, TranslationStrings.ECardTrainer);
        ofd.FilterIndex = 1;

        string TrainerName = string.Empty;

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            long fileSize = new FileInfo(ofd.FileName).Length;

            if (fileSize == SIZE)
            {
                try
                {
                    sav.SetEReaderTrainer(FixECTChecksum(File.ReadAllBytes(ofd.FileName)));
                    TrainerName = StringConverter3.GetString(sav.GetEReaderTrainer().AsSpan(8, sav.Japanese ? 5 : 7), sav.Japanese);

                    success = true;
                }
                catch (Exception)
                {
                    _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, TranslationStrings.ECardTrainer), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, fileSize, SIZE), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, TranslationStrings.ECardTrainer)}\n\n\"{TrainerName}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void ECTExportButton_Click(object sender, EventArgs e)
    {
        bool success = false;
        using var sfd = new SaveFileDialog();
        sfd.Filter = $"{TranslationStrings.ECardTrainer} (*.ect)|*.ect|{TranslationStrings.AllFiles} (*.*)|*.*";
        sfd.Title = string.Format(TranslationStrings.SaveFile, TranslationStrings.ECardTrainer); ;
        sfd.FilterIndex = 1;

        byte[] data = sav.GetEReaderTrainer();

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                File.WriteAllBytes(sfd.FileName, data);

                success = true;
            }
            catch (Exception)
            {
                _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, TranslationStrings.ECardTrainer), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (success)
        {
            Close();
            _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, TranslationStrings.ECardTrainer, sfd.FileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


    public static byte[] FixECTChecksum(byte[] data)
    {
        uint chk = GetECTChecksum(data);

        data[^4] = (byte)(chk & 0xFF);
        data[^3] = (byte)(chk >> 8);
        data[^2] = (byte)(chk >> 16);
        data[^1] = (byte)(chk >> 24);

        return data;
    }

    private static uint GetECTChecksum(byte[] data)
    {
        uint chk = 0;

        for (int i = 0; i < SIZE - 4; i += 4)
        {
            chk += data[i] + (uint)(data[i + 1] << 8) + (uint)(data[i + 2] << 16) + (uint)(data[i + 3] << 24);
        }

        return chk & 0xFFFFFFFF;
    }
}
