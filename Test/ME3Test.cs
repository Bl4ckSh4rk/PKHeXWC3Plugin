using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class ME3Test
    {
        private const string CleanSavesDir = "../../../data/saves/clean/";
        private const string ExpectedSavesDir = "../../../data/saves/expected/";
        private const string MysteryDataDir = "../../../data/mysterydata/";
        private const string EM_EN = "em_en.sav";
        private const string RS_EN = "rs_en.sav";
        private const string EM_JP = "em_jp.sav";
        private const string RS_JP = "rs_jp.sav";
        private const string EM_EN_ME3 = "em_en_me3.sav";
        private const string RS_EN_ME3 = "rs_en_me3.sav";
        private const string EM_JP_ME3 = "em_jp_me3.sav";
        private const string RS_JP_ME3 = "rs_jp_me3.sav";
        private const string Eonticket_RS_EN = "eonticket_rs_en.me3";
        private const string Eonticket_RS_JP = "eonticket_rs_jp.me3";
        private const string Eonticket_EM_EN = "eonticket_em_en.me3";
        private const string Eonticket_EM_JP = "eonticket_em_jp.me3";

        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_EM_EN}");

            SAV3E sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_EM_JP}");

            SAV3E sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportRSEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{RS_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{RS_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_RS_EN}");

            SAV3RS sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportRSJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{RS_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{RS_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_RS_JP}");

            SAV3RS sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_EM_EN}");

            SAV3E sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_EM_JP}");

            SAV3E sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
        [Test]
        public void ExportRSEnglish()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{ExpectedSavesDir}{RS_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_RS_EN}");

            SAV3RS sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
        [Test]
        public void ExportRSJapanese()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{ExpectedSavesDir}{RS_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{MysteryDataDir}{Eonticket_RS_JP}");

            SAV3RS sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
    }
}