using Xunit;
using PKHeX.Core;
using WC3Plugin;

namespace Test;

public class ECTTest
{
    [Fact]
    public void ImportEmeraldEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3E sav = new(clean);
        sav.ImportECT(ect);

        Assert.True(sav.HasECT());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportEmeraldJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3E sav = new(clean);
        sav.ImportECT(ect);

        Assert.True(sav.HasECT());
        Assert.Equal(sav.Write(), expected);
    }

    [Fact]
    public void ImportRSEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3RS sav = new(clean);
        sav.ImportECT(ect);

        Assert.True(sav.HasECT());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportRSJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3RS sav = new(clean);
        sav.ImportECT(ect);

        Assert.True(sav.HasECT());
        Assert.Equal(sav.Write(), expected);
    }

    [Fact]
    public void ImportFRLGEnglish()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_EN}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3FRLG sav = new(clean);
        sav.ImportECT(ect);

        Assert.True(sav.HasECT());
        Assert.Equal(sav.Write(), expected);
    }
    [Fact]
    public void ImportFRLGJapanese()
    {
        byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_JP}");
        byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3FRLG sav = new(clean);
        sav.ImportECT(ect);

        Assert.True(sav.HasECT());
        Assert.Equal(sav.Write(), expected);
    }


    [Fact]
    public void ExportEmeraldEnglish()
    {
        byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3E sav = new(sav_ect);

        Assert.Equal(ect, sav.ExportECT());
    }
    [Fact]
    public void ExportEmeraldJapanese()
    {
        byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3E sav = new(sav_ect);

        Assert.Equal(ect, sav.ExportECT());
    }
    [Fact]
    public void ExportRSEnglish()
    {
        byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3RS sav = new(sav_ect);

        Assert.Equal(ect, sav.ExportECT());
    }
    [Fact]
    public void ExportRSJapanese()
    {
        byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3RS sav = new(sav_ect);

        Assert.Equal(ect, sav.ExportECT());
    }
    [Fact]
    public void ExportFRLGEnglish()
    {
        byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3FRLG sav = new(sav_ect);

        Assert.Equal(ect,sav.ExportECT());
    }
    [Fact]
    public void ExportFRLGJapanese()
    {
        byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_ECT}");
        byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

        SAV3FRLG sav = new(sav_ect);

        Assert.Equal(ect, sav.ExportECT());
    }
}