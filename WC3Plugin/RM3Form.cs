using PKHeX.Core;

namespace WC3Plugin;

public partial class RM3Form : Form
{
    private readonly SAV3 sav;

    public RM3Form(SAV3 sav)
    {
        this.sav = sav;

        InitializeComponent();

        List<ComboItem> items = sav.GetRecordMixingItemDataSource();
        ItemComboBox.DataSource = new BindingSource(items, null);
        ItemComboBox.DisplayMember = "Text";
        ItemComboBox.ValueMember = "Value";

        ItemComboBox.SelectedValue = sav.IsValidForRecordMixing(((IGen3Hoenn)sav).RecordMixingGift.Item) ? ((IGen3Hoenn)sav).RecordMixingGift.Item : 0;
        CountBox.Value = ((IGen3Hoenn)sav).RecordMixingGift.Count;
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        sav.SetRecordMixing((ushort)((ushort)ItemComboBox.SelectedValue! & 0xFFFF), (byte)CountBox.Value);
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
}
