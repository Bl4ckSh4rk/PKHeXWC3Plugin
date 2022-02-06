using System;
using System.IO;
using System.Windows.Forms;
using PKHeX.Core;

namespace WC3Plugin
{
    public partial class WN3Form : Form
    {
        private SAV3 sav;
        private int Offset;
        private int Length;

        private static readonly int Length_EU = 448;
        private static readonly int Length_JAP = 228;
        private static readonly int Offset_E = 0x3AC;
        private static readonly int Offset_FRLG = 0x2A0;

        public WN3Form(SAV3 sav)
        {
            this.sav = sav;

            switch (sav.Version)
            {
                case GameVersion.E:
                    Offset = Offset_E + 0x2E80;
                    break;
                case GameVersion.FR or GameVersion.LG or GameVersion.FRLG:
                    Offset = Offset_FRLG + 0x2E80;
                    break;
                default:
                    break;
            }

            InitializeComponent();

            if (sav.Language == 0)
                LangJAPButton.Checked = true;
            else
                LangEUButton.Checked = true;
        }

        private void WN3ImportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "WN3 (*.wn3)|*.wn3|All files (*.*)|*.*";
                ofd.Title = "Open Wonder News file";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    long fileSize = new FileInfo(ofd.FileName).Length;

                    if (fileSize == Length)
                    {
                        try
                        {
                            Checksums.FixWN3Checksum(File.ReadAllBytes(ofd.FileName)).CopyTo(sav.Large, Offset);

                            success = true;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unable to read Wonder News file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Wonder News imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void WN3ExportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "WN3 (*.wn3)|*.wn3|All files (*.*)|*.*";
                sfd.Title = "Save Wonder News file";
                sfd.FilterIndex = 1;

                byte[] data = sav.Large.Slice(Offset, Length);

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
                            MessageBox.Show("Unable to write Wonder News file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //else
                //{
                //    MessageBox.Show("There is no Wonder News in this save file.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                if (success)
                {
                    Close();
                    MessageBox.Show($"Wonder News exported to {sfd.FileName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LangEUButton_CheckedChanged(object sender, EventArgs e)
        {
            Length = Length_EU;
        }

        private void LangJAPButton_CheckedChanged(object sender, EventArgs e)
        {
            Length = Length_JAP;
        }
    }
}
