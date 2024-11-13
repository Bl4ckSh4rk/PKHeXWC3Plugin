using Xunit;
using PKHeX.Core;
using WC3Plugin;

namespace Test;

public class ECBTest
{
    [Fact]
    public void ImportEmeraldEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3E sav = new(clean);
        sav.ImportECB(ecb);

        Assert.True(sav.HasECB());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportEmeraldJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3E sav = new(clean);
        sav.ImportECB(ecb);

        Assert.True(sav.HasECB());
        Assert.Equal(sav.Write(), expected);
    }

    [Fact]
    public void ImportRSEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_RS_EN}");

        SAV3RS sav = new(clean);
        sav.ImportECB(ecb);

        Assert.True(sav.HasECB());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportRSJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_RS_EN}");

        SAV3RS sav = new(clean);
        sav.ImportECB(ecb);

        Assert.True(sav.HasECB());
        Assert.Equal(sav.Write(), expected);
    }

    [Fact]
    public void ImportFRLGEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3FRLG sav = new(clean);
        sav.ImportECB(ecb);

        Assert.True(sav.HasECB());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportFRLGJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3FRLG sav = new(clean);
        sav.ImportECB(ecb);

        Assert.True(sav.HasECB());
        Assert.Equal(sav.Write(), expected);
    }


    [Fact]
    public void ExportEmeraldEnglish()
    {
        byte[] sav_ecb = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3E sav = new(sav_ecb);

        Assert.Equal(ecb, sav.ExportECB());
    }
    [Fact]
    public void ExportEmeraldJapanese()
    {
        byte[] sav_ecb = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3E sav = new(sav_ecb);

        Assert.Equal(ecb, sav.ExportECB());
    }
    [Fact]
    public void ExportRSEnglish()
    {
        byte[] sav_ecb = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_RS_EN}");

        SAV3RS sav = new(sav_ecb);

        Assert.Equal(ecb, sav.ExportECB());
    }
    [Fact]
    public void ExportRSJapanese()
    {
        byte[] sav_ecb = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_RS_EN}");

        SAV3RS sav = new(sav_ecb);

        Assert.Equal(ecb, sav.ExportECB());
    }
    [Fact]
    public void ExportFRLGEnglish()
    {
        byte[] sav_ecb = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3FRLG sav = new(sav_ecb);

        Assert.Equal(ecb, sav.ExportECB());
    }
    [Fact]
    public void ExportFRLGJapanese()
    {
        byte[] sav_ecb = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_ECB}");
        byte[] ecb = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Berry_EM_EN}");

        SAV3FRLG sav = new(sav_ecb);

        Assert.Equal(ecb, sav.ExportECB());
    }
}