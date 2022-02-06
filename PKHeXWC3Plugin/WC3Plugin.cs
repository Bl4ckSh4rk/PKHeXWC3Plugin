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

        private ToolStripMenuItem ctrl;
        private ToolStripMenuItem wc3;
        private ToolStripMenuItem me3;
        private ToolStripMenuItem ect;
        private ToolStripMenuItem ecb;
        private ToolStripMenuItem wn3;

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
            ctrl = new(Name);
            ctrl.Enabled = false;
            tools.DropDownItems.Add(ctrl);

            wc3 = new($"Mystery Gift (WC3)");
            wc3.Enabled = false;
            wc3.Click += (s, e) => OpenWC3Form();
            ctrl.DropDownItems.Add(wc3);

            me3 = new($"Mystery Event (ME3)");
            me3.Enabled = false;
            me3.Click += (s, e) => OpenME3Form();
            ctrl.DropDownItems.Add(me3);

            ect = new($"e-Card Trainer (ECT)");
            ect.Click += (s, e) => OpenECTForm();
            ctrl.DropDownItems.Add(ect);

            ecb = new($"e-Card Berries (ECB)");
            ecb.Click += (s, e) => OpenECBForm();
            ctrl.DropDownItems.Add(ecb);

            wn3 = new($"Wonder News (WN3)");
            wn3.Enabled = false;
            wn3.Click += (s, e) => OpenWN3Form();
            ctrl.DropDownItems.Add(wn3);
        }

        private void OpenWC3Form()
        {
            new WC3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
        }

        private void OpenME3Form()
        {
            new ME3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
        }

        private void OpenECBForm()
        {
            new ECBForm((SAV3)SaveFileEditor.SAV).ShowDialog();
        }

        private void OpenECTForm()
        {
            new ECTForm((SAV3)SaveFileEditor.SAV).ShowDialog();
        }

        private void OpenWN3Form()
        {
            new WN3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
        }

        public void NotifySaveLoaded()
        {
            ctrl.Enabled = SaveFileEditor.SAV is SAV3;
            wc3.Enabled = wn3.Enabled = SaveFileEditor.SAV is SAV3E or SAV3FRLG;
            me3.Enabled = SaveFileEditor.SAV is SAV3RS or SAV3E;
        }

        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }
    }
}
