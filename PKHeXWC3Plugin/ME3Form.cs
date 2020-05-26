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
                        sav.SetData(Checksums.FixME3Checksum(File.ReadAllBytes(ofd.FileName)), sav.GetBlockOffset(Block) + Offset);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid file size ({fileSize} bytes)! Expected {Length} bytes.");
                    }

                    Close();
                }
            }
        }

        private void ME3ExportButton_Click(object sender, EventArgs e)
        {
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
                        File.WriteAllBytes(sfd.FileName, data);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("There is no ME3 data in this save file.");
                }
            }
        }
    }
}
