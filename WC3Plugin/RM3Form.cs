using PKHeX.Core;

namespace WC3Plugin;

public partial class RM3Form : Form
{
    private readonly SAV3 sav;

    private const ushort MAX_ITEM = 0x178;

    public RM3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        ItemComboBox.DataSource = GameInfo.Strings.GetItemStrings(sav.Context, sav.Version).ToArray();
        ItemComboBox.DisplayMember = "Text";

        ItemComboBox.SelectedIndex = ((IGen3Hoenn)sav).RecordMixingGift.Item > MAX_ITEM ? 0 : ((IGen3Hoenn)sav).RecordMixingGift.Item;
        CountBox.Value = ((IGen3Hoenn)sav).RecordMixingGift.Count;
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        RecordMixing3Gift rm3 = new(((IGen3Hoenn)sav).RecordMixingGift.Data)
        {
            Item = (ushort)ItemComboBox.SelectedIndex,
            Count = (byte)(ItemComboBox.SelectedIndex < 1 ? 0 : CountBox.Value),
            Max = 1 // unused
        };
        rm3.FixChecksum();
        ((IGen3Hoenn)sav).RecordMixingGift = rm3;
        Close();
    }

    private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ItemComboBox.SelectedIndex <= 0)
        {
            CountBox.Value = 0;
        }
        else if (ItemComboBox.SelectedIndex > 0 && CountBox.Value == 0)
        {
            CountBox.Value = 1;
        }
    }
}
