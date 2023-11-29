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
    private ToolStripMenuItem rm3 = new();
    private readonly ToolStripSeparator rm3Separator = new() { Visible = false };

    public void Initialize(params object[] args)
    {
        Console.WriteLine($"Loading {nameof(WC3Plugin)}...");
        if (args != null)
        {
            LocalizationUtil.SetLocalization(GameInfo.CurrentLanguage);
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
        ctrl = new(Name) { Visible = false, Image = Properties.Resources.icon };
        _ = (tools?.DropDownItems.Add(ctrl));

        wc3 = new($"{TranslationStrings.MysteryGift} (WC3)") { Visible = false, Image = Properties.Resources.icon };
        wc3.Click += (s, e) => { _ = new WC3Form((SAV3)SaveFileEditor.SAV).ShowDialog(); };
        _ = ctrl.DropDownItems.Add(wc3);

        me3 = new($"{TranslationStrings.MysteryEvent} (ME3)") { Visible = false, Image = Properties.Resources.me3 };
        me3.Click += (s, e) => { _ = new ME3Form((SAV3)SaveFileEditor.SAV).ShowDialog(); };
        _ = ctrl.DropDownItems.Add(me3);

        ect = new($"{TranslationStrings.ECardTrainer} (ECT)") { Image = Properties.Resources.ect };
        ect.Click += (s, e) => { _ = new ECTForm((SAV3)SaveFileEditor.SAV).ShowDialog(); };
        _ = ctrl.DropDownItems.Add(ect);

        ecb = new($"{TranslationStrings.ECardBerry} (ECB)") { Image = Properties.Resources.ecb };
        ecb.Click += (s, e) => { _ = new ECBForm((SAV3)SaveFileEditor.SAV).ShowDialog(); };
        _ = ctrl.DropDownItems.Add(ecb);

        wn3 = new($"{TranslationStrings.WonderNews} (WN3)") { Visible = false, Image = Properties.Resources.wn3 };
        wn3.Click += (s, e) => { _ = new WN3Form((SAV3)SaveFileEditor.SAV).ShowDialog(); };
        _ = ctrl.DropDownItems.Add(wn3);

        _ = ctrl.DropDownItems.Add(rm3Separator);

        rm3 = new(TranslationStrings.RecordMixing) { Visible = false, Image = Properties.Resources.rm3 };
        rm3.Click += (s, e) => { _ = new RM3Form((SAV3)SaveFileEditor.SAV).ShowDialog(); };
        _ = ctrl.DropDownItems.Add(rm3);
    }

    public void NotifySaveLoaded()
    {
        if (ctrl != null)
        {
            ctrl.Visible = SaveFileEditor.SAV is SAV3 && SaveFileEditor.SAV.State.Exportable;

            wc3.Visible = wn3.Visible = SaveFileEditor.SAV is IGen3Wonder; // FRLGE
            me3.Visible = rm3.Visible = rm3Separator.Visible = SaveFileEditor.SAV is IGen3Hoenn; // RSE
        }
    }

    public bool TryLoadFile(string filePath) => false;
}
