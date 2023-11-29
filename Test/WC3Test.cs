using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class WC3Test
    {
        private const string CleanSavesDir = "../../../data/saves/clean/";
        private const string ExpectedSavesDir = "../../../data/saves/expected/";
        private const string MysteryDataDir = "../../../data/mysterydata/";
        private const string EM_EN = "em_en.sav";
        private const string FRLG_EN = "frlg_en.sav";
        private const string EM_JP = "em_jp.sav";
        private const string FRLG_JP = "frlg_jp.sav";
        private const string EM_EN_WC3 = "em_en_WC3.sav";
        private const string FRLG_EN_WC3 = "frlg_en_WC3.sav";
        private const string EM_JP_WC3 = "em_jp_WC3.sav";
        private const string FRLG_JP_WC3 = "frlg_jp_WC3.sav";
        private const string Auroraticket_FRLG_EN = "auroraticket_frlg_en.wc3";
        private const string Auroraticket_FRLG_JP = "auroraticket_frlg_jp.wc3";
        private const string Mysticticket_EM_EN = "mysticticket_em_en.wc3";
        private const string Mysticticket_EM_JP = "mysticticket_em_jp.wc3";

        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Mysticticket_EM_EN}");

            SAV3E sav = new(clean);
            sav.ImportWC3(wc3);

            Assert.That(sav.HasWC3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Mysticticket_EM_JP}");

            SAV3E sav = new(clean);
            sav.ImportWC3(wc3);

            Assert.That(sav.HasWC3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportFRLGEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Auroraticket_FRLG_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportWC3(wc3);

            Assert.That(sav.HasWC3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportFRLGJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Auroraticket_FRLG_JP}");

            SAV3FRLG sav = new(clean);
            sav.ImportWC3(wc3);

            Assert.That(sav.HasWC3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_wc3 = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Mysticticket_EM_EN}");

            SAV3E sav = new(sav_wc3);

            Assert.That(wc3, Is.EqualTo(sav.ExportWC3()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_wc3 = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Mysticticket_EM_JP}");

            SAV3E sav = new(sav_wc3);

            Assert.That(wc3, Is.EqualTo(sav.ExportWC3()));
        }
        [Test]
        public void ExportFRLGEnglish()
        {
            byte[] sav_wc3 = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Auroraticket_FRLG_EN}");

            SAV3FRLG sav = new(sav_wc3);

            Assert.That(wc3, Is.EqualTo(sav.ExportWC3()));
        }
        [Test]
        public void ExportFRLGJapanese()
        {
            byte[] sav_wc3 = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_WC3}");
            byte[] wc3 = File.ReadAllBytes($"{MysteryDataDir}{Auroraticket_FRLG_JP}");

            SAV3FRLG sav = new(sav_wc3);

            Assert.That(wc3, Is.EqualTo(sav.ExportWC3()));
        }
    }
}