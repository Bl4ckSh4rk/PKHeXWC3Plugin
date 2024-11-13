using Xunit;
using PKHeX.Core;
using WC3Plugin;

namespace Test;

public class WC3Test
{
    [Fact]
    public void ImportEmeraldEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Mysticticket_EM_EN}");

        SAV3E sav = new(clean);
        sav.ImportWC3(wc3);

        Assert.True(sav.HasWC3());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportEmeraldJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Mysticticket_EM_JP}");

        SAV3E sav = new(clean);
        sav.ImportWC3(wc3);

        Assert.True(sav.HasWC3());
        Assert.Equal(sav.Write(), expected);
    }

    [Fact]
    public void ImportFRLGEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Auroraticket_FRLG_EN}");

        SAV3FRLG sav = new(clean);
        sav.ImportWC3(wc3);

        Assert.True(sav.HasWC3());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportFRLGJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Auroraticket_FRLG_JP}");

        SAV3FRLG sav = new(clean);
        sav.ImportWC3(wc3);

        Assert.True(sav.HasWC3());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ExportEmeraldEnglish()
    {
        byte[] sav_wc3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Mysticticket_EM_EN}");

        SAV3E sav = new(sav_wc3);

        Assert.Equal(wc3, sav.ExportWC3());
    }
    [Fact]
    public void ExportEmeraldJapanese()
    {
        byte[] sav_wc3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Mysticticket_EM_JP}");

        SAV3E sav = new(sav_wc3);

        Assert.Equal(wc3, sav.ExportWC3());
    }
    [Fact]
    public void ExportFRLGEnglish()
    {
        byte[] sav_wc3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Auroraticket_FRLG_EN}");

        SAV3FRLG sav = new(sav_wc3);

        Assert.Equal(wc3, sav.ExportWC3());
    }
    [Fact]
    public void ExportFRLGJapanese()
    {
        byte[] sav_wc3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_WC3}");
        byte[] wc3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Auroraticket_FRLG_JP}");

        SAV3FRLG sav = new(sav_wc3);

        Assert.Equal(wc3, sav.ExportWC3());
    }
}