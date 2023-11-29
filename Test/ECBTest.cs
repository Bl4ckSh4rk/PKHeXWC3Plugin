using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class ECBTest
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
        private const string EM_EN_ECB = "em_en_ecb.sav";
        private const string RS_EN_ECB = "rs_en_ecb.sav";
        private const string FRLG_EN_ECB = "frlg_en_ecb.sav";
        private const string EM_JP_ECB = "em_jp_ecb.sav";
        private const string RS_JP_ECB = "rs_jp_ecb.sav";
        private const string FRLG_JP_ECB = "frlg_jp_ecb.sav";
        private const string Berry_RS_EN = "berry_rs_en.ecb";
        private const string Berry_EM_EN = "berry_em_en.ecb";

        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3E sav = new(clean);
            sav.ImportECB(ecb);

            Assert.That(sav.HasECB(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{EM_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3E sav = new(clean);
            sav.ImportECB(ecb);

            Assert.That(sav.HasECB(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportRSEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{RS_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{RS_EN_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_RS_EN}");

            SAV3RS sav = new(clean);
            sav.ImportECB(ecb);

            Assert.That(sav.HasECB(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportRSJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{RS_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{RS_JP_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_RS_EN}");

            SAV3RS sav = new(clean);
            sav.ImportECB(ecb);

            Assert.That(sav.HasECB(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportFRLGEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_EN}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportECB(ecb);

            Assert.That(sav.HasECB(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportFRLGJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{CleanSavesDir}{FRLG_JP}");
            byte[] expected = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportECB(ecb);

            Assert.That(sav.HasECB(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }


        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_ecb = File.ReadAllBytes($"{ExpectedSavesDir}{EM_EN_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3E sav = new(sav_ecb);

            Assert.That(ecb, Is.EqualTo(sav.ExportECB()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_ecb = File.ReadAllBytes($"{ExpectedSavesDir}{EM_JP_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3E sav = new(sav_ecb);

            Assert.That(ecb, Is.EqualTo(sav.ExportECB()));
        }
        [Test]
        public void ExportRSEnglish()
        {
            byte[] sav_ecb = File.ReadAllBytes($"{ExpectedSavesDir}{RS_EN_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_RS_EN}");

            SAV3RS sav = new(sav_ecb);

            Assert.That(ecb, Is.EqualTo(sav.ExportECB()));
        }
        [Test]
        public void ExportRSJapanese()
        {
            byte[] sav_ecb = File.ReadAllBytes($"{ExpectedSavesDir}{RS_JP_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_RS_EN}");

            SAV3RS sav = new(sav_ecb);

            Assert.That(ecb, Is.EqualTo(sav.ExportECB()));
        }
        [Test]
        public void ExportFRLGEnglish()
        {
            byte[] sav_ecb = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_EN_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3FRLG sav = new(sav_ecb);

            Assert.That(ecb, Is.EqualTo(sav.ExportECB()));
        }
        [Test]
        public void ExportFRLGJapanese()
        {
            byte[] sav_ecb = File.ReadAllBytes($"{ExpectedSavesDir}{FRLG_JP_ECB}");
            byte[] ecb = File.ReadAllBytes($"{MysteryDataDir}{Berry_EM_EN}");

            SAV3FRLG sav = new(sav_ecb);

            Assert.That(ecb, Is.EqualTo(sav.ExportECB()));
        }
    }
}