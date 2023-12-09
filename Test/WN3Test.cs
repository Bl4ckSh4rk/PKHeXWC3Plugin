using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class WN3Test
    {
        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_EN}");

            SAV3E sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_JP}");

            SAV3E sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportFRLGEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportFRLGJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_JP}");

            SAV3FRLG sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_EN}");

            SAV3E sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_JP}");

            SAV3E sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
        [Test]
        public void ExportFRLGEnglish()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_EN}");

            SAV3FRLG sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
        [Test]
        public void ExportFRLGJapanese()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.NEWS_JP}");

            SAV3FRLG sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
    }
}