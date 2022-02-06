using System;
using System.IO;
using System.Windows.Forms;
using PKHeX.Core;

namespace WC3Plugin
{
    public partial class ECBForm : Form
    {
        private SAV3 sav;
        private int Offset;
        private int Length;

        private static readonly int Length_RS = 1328;
        private static readonly int Length_FRLGE = 52;
        private static readonly int Offset_RS = 0x2E0;
        private static readonly int Offset_E = 0x378;
        private static readonly int Offset_FRLG = 0x26C;

        public ECBForm(SAV3 sav)
        {
            this.sav = sav;

            switch (sav.Version)
            {
                case GameVersion.R or GameVersion.S or GameVersion.RS:
                    Length = Length_RS + 0x2E80;
                    Offset = Offset_RS + 0x2E80;
                    break;
                case GameVersion.E:
                    Length = Length_FRLGE + 0x2E80;
                    Offset = Offset_E + 0x2E80;
                    break;
                case GameVersion.FR or GameVersion.LG or GameVersion.FRLG:
                    Length = Length_FRLGE + 0x2E80;
                    Offset = Offset_FRLG + 0x2E80;
                    break;
                default:
                    break;
            }

            InitializeComponent();
        }

        private void ECBImportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "ECB (*.ecb)|*.ecb|All files (*.*)|*.*";
                ofd.Title = "Open e-Card Berry file";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    long fileSize = new FileInfo(ofd.FileName).Length;

                    if (fileSize == Length)
                    {
                        try
                        {
                            Checksums.FixECBChecksum(File.ReadAllBytes(ofd.FileName)).CopyTo(sav.Large, Offset);

                            success = true;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unable to read e-Card Berry file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("e-Card Berry imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ECBExportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "ECB (*.ecb)|*.ecb|All files (*.*)|*.*";
                sfd.Title = "Save e-Card Berry file";
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
                            MessageBox.Show("Unable to write e-Card Berry file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //else
                //{
                //    MessageBox.Show("There is no e-Card Berry in this save file.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                if (success)
                {
                    Close();
                    MessageBox.Show($"e-Card Trainer exported to {sfd.FileName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
