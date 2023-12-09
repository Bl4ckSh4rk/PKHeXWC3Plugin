using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class ECTTest
    {
        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3E sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3E sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportRSEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3RS sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportRSJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3RS sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportFRLGEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportFRLGJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.FRLG_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3FRLG sav = new(clean);
            sav.ImportECT(ect);

            Assert.That(sav.HasECT(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }


        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3E sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3E sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportRSEnglish()
        {
            byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3RS sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportRSJapanese()
        {
            byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3RS sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportFRLGEnglish()
        {
            byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_EN_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3FRLG sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
        [Test]
        public void ExportFRLGJapanese()
        {
            byte[] sav_ect = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.FRLG_JP_ECT}");
            byte[] ect = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Trainer_EN}");

            SAV3FRLG sav = new(sav_ect);

            Assert.That(ect, Is.EqualTo(sav.ExportECT()));
        }
    }
}