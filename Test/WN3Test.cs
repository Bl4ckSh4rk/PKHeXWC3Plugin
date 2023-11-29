using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class WN3Test
    {
        private const string CleanSavesDir = "../../../data/saves/clean/";
        private const string ExpectedSavesDir = "../../../data/saves/expected/";
        private const string MysteryDataDir = "../../../data/mysterydata/";
        private const string EM_EN = "em_en.sav";
        private const string FRLG_EN = "frlg_en.sav";
        private const string EM_JP = "em_jp.sav";
        private const string FRLG_JP = "frlg_jp.sav";
        private const string EM_EN_WN3 = "em_en_wn3.sav";
        private const string FRLG_EN_WN3 = "frlg_en_wn3.sav";
        private const string EM_JP_WN3 = "em_jp_wn3.sav";
        private const string FRLG_JP_WN3 = "frlg_jp_wn3.sav";
        private const string NEWS_EN = "news_en.wn3";
        private const string NEWS_JP = "news_jp.wn3";

        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_EN}");

            SAV3E sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_JP}");

            SAV3E sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportFRLGEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportFRLGJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_JP}");

            SAV3FRLG sav = new(clean);
            sav.ImportWN3(wn3);

            Assert.That(sav.HasWN3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_EN}");

            SAV3E sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_JP}");

            SAV3E sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
        [Test]
        public void ExportFRLGEnglish()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_EN}");

            SAV3FRLG sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
        [Test]
        public void ExportFRLGJapanese()
        {
            byte[] sav_wn3 = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_WN3}");
            byte[] wn3 = File.ReadAllBytes($"{MysteryDataDir}{NEWS_JP}");

            SAV3FRLG sav = new(sav_wn3);

            Assert.That(wn3, Is.EqualTo(sav.ExportWN3()));
        }
    }
}