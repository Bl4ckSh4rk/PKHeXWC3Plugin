using System;
using System.IO;
using System.Windows.Forms;
using PKHeX.Core;

namespace WC3Plugin
{
    public partial class WC3Form : Form
    {
        private SAV3 sav;
        private int Offset_WC;
        private int Offset_Script;
        private int Offset_Script_WC3;
        private int Length;
        private int Length_WC;
        private GameVersion Version;

        private static readonly int Length_WC_EU = 0x15C;
        private static readonly int Length_WC_JAP = 0xB4;
        private static readonly int Length_Script = 0x3EC;
        private static readonly int Offset_WC_E_EU = 0x56C;
        private static readonly int Offset_WC_FRLG_EU = 0x460;
        private static readonly int Offset_WC_E_JAP = 0x490;
        private static readonly int Offset_WC_FRLG_JAP = 0x384;
        private static readonly int Offset_Script_E = 0x8A8;
        private static readonly int Offset_Script_FRLG = 0x79C;

        private static readonly int Length_WC3_EU = 0x58C;
        private static readonly int Length_WC3_JAP = 0x4E4;
        private static readonly int Offset_Script_WC3_EU = 0x1A0;
        private static readonly int Offset_Script_WC3_JAP = 0xF8;

        public WC3Form(SAV3 sav)
        {
            this.sav = sav;
            Version = sav.Version;

            InitializeComponent();

            if (sav.Language == (int)LanguageID.Japanese)
                LangJAPButton.Checked = true;
            else
                LangEUButton.Checked = true;
        }

        private void WC3ImportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "WC3 (*.wc3)|*.wc3|All files (*.*)|*.*";
                ofd.Title = "Open Mystery Gift file";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    long fileSize = new FileInfo(ofd.FileName).Length;

                    if (fileSize == Length)
                    {
                        try
                        {
                            byte[] data = Checksums.FixWC3Checksum(File.ReadAllBytes(ofd.FileName));
                            byte[] wc = new byte[Length_WC];
                            byte[] script = new byte[Length_Script];

                            Array.Copy(data, 0, wc, 0, Length_WC);
                            Array.Copy(data, Offset_Script_WC3, script, 0, Length_Script);

                            File.ReadAllBytes(ofd.FileName).CopyTo(sav.Large, Offset_WC);
                            File.ReadAllBytes(ofd.FileName).CopyTo(sav.Large, Offset_Script);

                            success = true;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unable to read Mystery Gift file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid file size ({fileSize} bytes). Expected {Length} bytes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (success)
                {
                    Close();
                    MessageBox.Show("Mystery Gift imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void WC3ExportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "WC3 (*.wc3)|*.wc3|All files (*.*)|*.*";
                sfd.Title = "Save Mystery Gift file";
                sfd.FilterIndex = 1;

                byte[] data = new byte[Length];
                byte[] wc = sav.Large.Slice(Offset_WC, Length_WC);
                byte[] script = sav.Large.Slice(Offset_Script, Length_Script);

                Array.Copy(wc, 0, data, 0, Length_WC);
                Array.Copy(script, 0, data, Offset_Script_WC3, Length_Script);

                //if (!data.IsRangeAll((byte)0, 0, data.Length))
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            File.WriteAllBytes(sfd.FileName, data);

                            success = true;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unable to write Mystery Gift file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //else
                //{
                //    MessageBox.Show("There is no Mystery Gift in this save file.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                if (success)
                {
                    Close();
                    MessageBox.Show($"Mystery Gift exported to {sfd.FileName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LangEUButton_CheckedChanged(object sender, EventArgs e)
        {
            Length = Length_WC3_EU;
            Length_WC = Length_WC_EU;
            Offset_Script_WC3 = Offset_Script_WC3_EU;

            if (Version == GameVersion.E)
            {
                Offset_WC = Offset_WC_E_EU + 0x2E80;
                Offset_Script = Offset_Script_E + 0x2E80;
            }
            else if (Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
            {
                Offset_WC = Offset_WC_FRLG_EU + 0x2E80;
                Offset_Script = Offset_Script_FRLG + 0x2E80;
            }
        }

        private void LangJAPButton_CheckedChanged(object sender, EventArgs e)
        {
            Length = Length_WC3_JAP;
            Length_WC = Length_WC_JAP;
            Offset_Script_WC3 = Offset_Script_WC3_JAP;

            if (Version == GameVersion.E)
            {
                Offset_WC = Offset_WC_E_JAP + 0x2E80;
                Offset_Script = Offset_Script_E + 0x2E80;
            }
            else if (Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
            {
                Offset_WC = Offset_WC_FRLG_JAP + 0x2E80;
                Offset_Script = Offset_Script_FRLG + 0x2E80;
            }
        }
    }
}
