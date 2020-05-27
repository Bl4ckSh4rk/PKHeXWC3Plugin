using System;
using System.IO;
using System.Windows.Forms;
using PKHeX.Core;

namespace WC3Plugin
{
    public partial class ME3Form : Form
    {
        private SAV3 sav;
        private int Offset;
        private GameVersion Version;

        private static readonly int Block = 4;
        private static readonly int Length = 1012;
        private static readonly int Offset_RS = 0x810;
        private static readonly int Offset_E = 0x8A8;

        public ME3Form(SAV3 sav)
        {
            this.sav = sav;
            Version = sav.Version;

            if (Version == GameVersion.R || Version == GameVersion.S || Version == GameVersion.RS)
                Offset = Offset_RS;
            else if (Version == GameVersion.E)
                Offset = Offset_E;

            InitializeComponent();
        }

        private void ME3ImportButton_Click(object sender, EventArgs e)
        {
            bool success = true;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "ME3 (*.me3)|*.me3|All files (*.*)|*.*";
                ofd.Title = "Open Mystery Event file";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    long fileSize = new FileInfo(ofd.FileName).Length;

                    if (fileSize == Length || fileSize == Length - 8)
                    {
                        try
                        {
                            sav.SetData(Checksums.FixME3Checksum(File.ReadAllBytes(ofd.FileName)), sav.GetBlockOffset(Block) + Offset);

                            success = true;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unable to read Mystery Event file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Mystery Event imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ME3ExportButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "ME3 (*.me3)|*.me3|All files (*.*)|*.*";
                sfd.Title = "Save Mystery Event file";
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
                            MessageBox.Show("Unable to write Mystery Event file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is no Mystery Event in this save file.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success)
                {
                    Close();
                    MessageBox.Show($"Mystery Event exported to {sfd.FileName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
