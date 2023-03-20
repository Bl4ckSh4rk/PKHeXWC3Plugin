using PKHeX.Core;

namespace WC3Plugin;

public class WC3Plugin : IPlugin
{
    public string Name => TranslationStrings.PluginName;
    public int Priority => 1; // Loading order, lowest is first.
    public ISaveFileProvider SaveFileEditor { get; private set; } = null!;

    private ToolStripMenuItem ctrl = new();
    private ToolStripMenuItem wc3 = new();
    private ToolStripMenuItem me3 = new();
    private ToolStripMenuItem ect = new();
    private ToolStripMenuItem ecb = new();
    private ToolStripMenuItem wn3 = new();

    public void Initialize(params object[] args)
    {
        LocalizationUtil.SetLocalization(GameInfo.CurrentLanguage);

        Console.WriteLine($"Loading {Name}...");
        if (args != null)
        {
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider)!;

            LoadMenuStrip((ToolStrip)Array.Find(args, z => z is ToolStrip)!);
        }
    }

    private void LoadMenuStrip(ToolStrip menuStrip)
    {
        if (menuStrip.Items.Find("Menu_Tools", false)[0] is not ToolStripDropDownItem tools)
            throw new ArgumentException(null, nameof(menuStrip));

        AddPluginControl(tools);
    }

    private void AddPluginControl(ToolStripDropDownItem tools)
    {
        ctrl = new(Name)
        {
            Visible = false,
            Image = Properties.Resources.icon
        };
        tools?.DropDownItems.Add(ctrl);

        wc3 = new($"{TranslationStrings.MysteryGift} (WC3)");
        wc3.Visible = false;
        wc3.Click += (s, e) => OpenWC3Form();
        ctrl.DropDownItems.Add(wc3);

        me3 = new($"{TranslationStrings.MysteryEvent} (ME3)");
        me3.Visible = false;
        me3.Click += (s, e) => OpenME3Form();
        ctrl.DropDownItems.Add(me3);

        ect = new($"{TranslationStrings.ECardTrainer} (ECT)");
        ect.Click += (s, e) => OpenECTForm();
        ctrl.DropDownItems.Add(ect);

        ecb = new($"{TranslationStrings.ECardBerry} (ECB)");
        ecb.Click += (s, e) => OpenECBForm();
        ctrl.DropDownItems.Add(ecb);

        wn3 = new($"{TranslationStrings.WonderNews} (WN3)");
        wn3.Visible = false;
        wn3.Click += (s, e) => OpenWN3Form();
        ctrl.DropDownItems.Add(wn3);
    }

    private void OpenWC3Form()
    {
        _ = new WC3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
    }

    private void OpenME3Form()
    {
        _ = new ME3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
    }

    private void OpenECBForm()
    {
        _ = new ECBForm((SAV3)SaveFileEditor.SAV).ShowDialog();
    }

    private void OpenECTForm()
    {
        _ = new ECTForm((SAV3)SaveFileEditor.SAV).ShowDialog();
    }

    private void OpenWN3Form()
    {
        _ = new WN3Form((SAV3)SaveFileEditor.SAV).ShowDialog();
    }

    public void NotifySaveLoaded()
    {
        if (ctrl != null)
            ctrl.Visible = SaveFileEditor.SAV is SAV3;

        wc3.Visible = wn3.Visible = SaveFileEditor.SAV is SAV3E or SAV3FRLG;
        me3.Visible = SaveFileEditor.SAV is SAV3RS or SAV3E;
    }

    public bool TryLoadFile(string filePath) => false;
}
