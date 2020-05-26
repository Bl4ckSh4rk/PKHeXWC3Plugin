using System;
using System.IO;
using System.Windows.Forms;
using PKHeX.Core;

namespace WC3Plugin
{
    public partial class ECTForm : Form
    {
        private SAV3 sav;
        private int Offset;
        private GameVersion Version;

        private static readonly int Block = 4;
        private static readonly int Length = 188;
        private static readonly int Offset_RS = 0x498;
        private static readonly int Offset_E = 0xBEC;
        private static readonly int Offset_FRLG = 0x4A0;

        public ECTForm(SAV3 sav)
        {
            this.sav = sav;
            Version = sav.Version;

            if (Version == GameVersion.R || Version == GameVersion.S || Version == GameVersion.RS)
                Offset = Offset_RS;
            else if (Version == GameVersion.E)
                Offset = Offset_E;
            else if (Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
                Offset = Offset_FRLG;

            InitializeComponent();
        }

        private void ECTImportButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "ECT (*.ect)|*.ect|All files (*.*)|*.*";
                ofd.Title = "Open e-Card Trainer file";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    long fileSize = new FileInfo(ofd.FileName).Length;

                    if (fileSize == Length)
                    {
                        sav.SetData(Checksums.FixECTChecksum(File.ReadAllBytes(ofd.FileName)), sav.GetBlockOffset(Block) + Offset);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid file size ({fileSize} bytes)! Expected {Length} bytes.");
                    }

                    Close();
                }
            }
        }

        private void ECTExportButton_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "ECT (*.ect)|*.ect|All files (*.*)|*.*";
                sfd.Title = "Save e-Card Trainer file";
                sfd.FilterIndex = 1;

                byte[] data = sav.GetData(sav.GetBlockOffset(Block) + Offset, Length);

                if (!data.IsRangeAll((byte)0, 0, data.Length))
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName, data);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("There is no ECT data in this save file.");
                }
            }
        }
    }
}
