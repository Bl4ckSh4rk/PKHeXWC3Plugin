using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace WC3Plugin
{
    public class WC3Plugin : IPlugin
    {
        public string Name => "WC3 Plugin";
        public int Priority => 1; // Loading order, lowest is first.
        public ISaveFileProvider SaveFileEditor { get; private set; }
        public IPKMView PKMEditor { get; private set; }

        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            if (args == null)
                return;
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);

            LoadMenuStrip(menu);
        }

        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            var tools = items.Find("Menu_Tools", false)[0] as ToolStripDropDownItem;
            AddPluginControl(tools);
        }

        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name);
            tools.DropDownItems.Add(ctrl);

            var c2 = new ToolStripMenuItem($"Mystery Gift (WC3)");
            c2.Click += (s, e) => OpenWC3Form();
            ctrl.DropDownItems.Add(c2);

            var c3 = new ToolStripMenuItem($"Mystery Event (ME3)");
            c3.Click += (s, e) => OpenME3Form();
            ctrl.DropDownItems.Add(c3);

            var c4 = new ToolStripMenuItem($"e-Card Trainer (ECT)");
            c4.Click += (s, e) => OpenECTForm();
            ctrl.DropDownItems.Add(c4);

            var c5 = new ToolStripMenuItem($"e-Card Berries (ECB)");
            c5.Click += (s, e) => OpenECBForm();
            ctrl.DropDownItems.Add(c5);

            var c6 = new ToolStripMenuItem($"Wonder News (WN3)");
            c6.Click += (s, e) => OpenWN3Form();
            ctrl.DropDownItems.Add(c6);
        }

        private void OpenWC3Form()
        {
            GameVersion Version = ((SAV3)SaveFileEditor.SAV).Version;
            if (Version == GameVersion.E || Version == GameVersion.FR || Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
                new WC3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
            else
                MessageBox.Show("Mystery Gifts (MC3) are only available for Emerald, FireRed and LeafGreen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OpenME3Form()
        {
            GameVersion Version = ((SAV3)SaveFileEditor.SAV).Version;
            if (Version == GameVersion.R || Version == GameVersion.S || Version == GameVersion.E || Version == GameVersion.RS || Version == GameVersion.RSE)
                new ME3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
            else
                MessageBox.Show("Mystery Events (ME3) are only available for Ruby, Sapphire and Emerald!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OpenECBForm()
        {
            GameVersion Version = ((SAV3)SaveFileEditor.SAV).Version;
            if (Version == GameVersion.R || Version == GameVersion.S || Version == GameVersion.E || Version == GameVersion.RS || Version == GameVersion.RSE
                || Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
                new ECBForm((SAV3)SaveFileEditor.SAV).ShowDialog();
            else
                MessageBox.Show("e-Card Berries (ECB) are only available for Ruby, Sapphire, Emerald, FireRed and LeafGreen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OpenECTForm()
        {
            GameVersion Version = ((SAV3)SaveFileEditor.SAV).Version;
            if (Version == GameVersion.R || Version == GameVersion.S || Version == GameVersion.E || Version == GameVersion.RS || Version == GameVersion.RSE
                || Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
                new ECTForm((SAV3)SaveFileEditor.SAV).ShowDialog();
            else
                MessageBox.Show("e-Card Trainers (ECT) are only available for Ruby, Sapphire, Emerald, FireRed and LeafGreen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OpenWN3Form()
        {
            GameVersion Version = ((SAV3)SaveFileEditor.SAV).Version;
            if (Version == GameVersion.E || Version == GameVersion.FR || Version == GameVersion.FR || Version == GameVersion.LG || Version == GameVersion.FRLG)
                new WN3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
            else
                MessageBox.Show("Wonder News (WN3) are only available for Emerald, FireRed and LeafGreen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void NotifySaveLoaded()
        {
            Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
        }

        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }
    }
}
