using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class ECTTest
    {
        private const string CleanSavesDir = "../../../data/saves/clean/";
        private const string ExpectedSavesDir = "../../../data/saves/expected/";
        private const string MysteryDataDir = "../../../data/mysterydata/";
        private const string EM_EN = "em_en.sav";
        private const string RS_EN = "rs_en.sav";
        private const string FRLG_EN = "frlg_en.sav";
        private const string EM_JP = "em_jp.sav";
        private const string RS_JP = "rs_jp.sav";
        private const string FRLG_JP = "frlg_jp.sav";
        private const string EM_EN_ECT = "em_en_ect.sav";
        private const string RS_EN_ECT = "rs_en_ect.sav";
        private const string FRLG_EN_ECT = "frlg_en_ect.sav";
        private const string EM_JP_ECT = "em_jp_ect.sav";
        private const string RS_JP_ECT = "rs_jp_ect.sav";
        private const string FRLG_JP_ECT = "frlg_jp_ect.sav";
        private const string Trainer_EN = "trainer_en.ect";

        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3E sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3E sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportRSEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{RS_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{RS_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3RS sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportRSJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{RS_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{RS_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3RS sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportFRLGEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportFRLGJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }


        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_ect = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3E sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_ect = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3E sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportRSEnglish()
        {
            byte[] sav_ect = File.ReadAllBytes($"{ExpectedSavesDir}{RS_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3RS sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportRSJapanese()
        {
            byte[] sav_ect = File.ReadAllBytes($"{ExpectedSavesDir}{RS_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3RS sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportFRLGEnglish()
        {
            byte[] sav_ect = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3FRLG sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportFRLGJapanese()
        {
            byte[] sav_ect = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{MysteryDataDir}{Trainer_EN}");

            SAV3FRLG sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
    }
}