using PKHeX.Core;

namespace WC3Plugin;

public partial class RM3Form : Form
{
    private readonly SAV3 sav;

    private const ushort EONTICKET = 0x113;

    public RM3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        List<ComboItem> items = new();
        items.AddRange(GameInfo.FilteredSources.Items);
        items.Add(new(GameInfo.Strings.GetItemStrings(sav.Context, sav.Version)[EONTICKET], EONTICKET));
        ItemComboBox.DataSource = new BindingSource(items, null);
        ItemComboBox.DisplayMember = "Text";
        ItemComboBox.ValueMember = "Value";

        ItemComboBox.SelectedValue = IsValidItem(((IGen3Hoenn)sav).RecordMixingGift.Item) ? ((IGen3Hoenn)sav).RecordMixingGift.Item : 0;
        CountBox.Value = ((IGen3Hoenn)sav).RecordMixingGift.Count;
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        ushort selected = (ushort)((int)ItemComboBox.SelectedValue! & 0xFFFF);
        RecordMixing3Gift rm3 = new(((IGen3Hoenn)sav).RecordMixingGift.Data)
        {
            Item = selected,
            Count = (byte)(selected == 0 ? 0 : CountBox.Value)
        };
        rm3.FixChecksum();
        ((IGen3Hoenn)sav).RecordMixingGift = rm3;
        Close();
    }

    private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ushort selected = (ushort)((int)ItemComboBox.SelectedValue! & 0xFFFF);
        if (selected == 0)
        {
            CountBox.Value = 0;
        }
        else if (selected != 0 && CountBox.Value == 0)
        {
            CountBox.Value = 1;
        }
    }

    private bool IsValidItem(ushort item)
    {
        if (item is 0 or EONTICKET)
            return true;

        IItemStorage storage;
        if (sav is SAV3E)
            storage = new ItemStorage3E();
        else
            storage = new ItemStorage3RS();

        return storage.GetItems(InventoryType.PCItems).Contains(item);
    }
}
