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
        private GameVersion Version;

        private static readonly int Block = 4;
        private static readonly int Length_EU = 228;
        private static readonly int Length_JAP = 448;
        private static readonly int Offset_E = 0x2A0;
        private static readonly int Offset_FRLG = 0x3AC;

        public WN3Form(SAV3 sav)
        {
            this.sav = sav;
            Version = sav.Version;

            if (Version == GameVersion.E)
                Offset = Offset_E;
            else if (Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
                Offset = Offset_FRLG;

            InitializeComponent();

            if (sav.Language == 0)
                LangJAPButton.Checked = true;
            else
                LangEUButton.Checked = true;
        }

        private void WN3ImportButton_Click(object sender, EventArgs e)
        {
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
                        sav.SetData(Checksums.FixWN3Checksum(File.ReadAllBytes(ofd.FileName)), sav.GetBlockOffset(Block) + Offset);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid file size ({fileSize} bytes)! Expected {Length} bytes.");
                    }

                    Close();
                }
            }
        }

        private void WN3ExportButton_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "WN3 (*.wn3)|*.wn3|All files (*.*)|*.*";
                sfd.Title = "Save Wonder News file";
                sfd.FilterIndex = 1;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, sav.GetData(sav.GetBlockOffset(Block) + Offset, Length));

                    Close();
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
