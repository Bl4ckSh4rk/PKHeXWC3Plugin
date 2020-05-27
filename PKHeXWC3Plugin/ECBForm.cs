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
        private GameVersion Version;

        private static readonly int Block = 4;
        private static readonly int Length_RS = 1328;
        private static readonly int Length_E = 52;
        private static readonly int Offset_RS = 0x2E0;
        private static readonly int Offset_E = 0x378;

        public ECBForm(SAV3 sav)
        {
            this.sav = sav;
            Version = sav.Version;

            if (Version == GameVersion.R || Version == GameVersion.S || Version == GameVersion.RS)
            {
                Length = Length_RS;
                Offset = Offset_RS;
            }
            else if (Version == GameVersion.E)
            {
                Length = Length_E;
                Offset = Offset_E;
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
                            sav.SetData(Checksums.FixECBChecksum(File.ReadAllBytes(ofd.FileName)), sav.GetBlockOffset(Block) + Offset);

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

                byte[] data = sav.GetData(sav.GetBlockOffset(Block) + Offset, Length);

                if (!data.IsRangeAll((byte)0, 0, data.Length))
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
                else
                {
                    MessageBox.Show("There is no e-Card Berry in this save file.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success)
                {
                    Close();
                    MessageBox.Show($"e-Card Trainer exported to {sfd.FileName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
