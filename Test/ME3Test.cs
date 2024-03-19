using NUnit.Framework;
using PKHeX.Core;
using WC3Plugin;

namespace Test
{
    public class ME3Test
    {
        [Test]
        public void ImportEmeraldEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_EM_EN}");

            SAV3E sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportEmeraldJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.EM_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_EM_JP}");

            SAV3E sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }

        [Test]
        public void ImportRSEnglish()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_EN}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_RS_EN}");

            SAV3RS sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ImportRSJapanese()
        {
            byte[] clean = File.ReadAllBytes($"{Data.CleanSavesDir}{Data.RS_JP}");
            byte[] expected = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_RS_JP}");

            SAV3RS sav = new(clean);
            sav.ImportME3(me3);

            Assert.That(sav.HasME3(), Is.True);
            Assert.That(sav.Write(), Is.EqualTo(expected));
        }
        [Test]
        public void ExportEmeraldEnglish()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_EM_EN}");

            SAV3E sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
        [Test]
        public void ExportEmeraldJapanese()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.EM_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_EM_JP}");

            SAV3E sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
        [Test]
        public void ExportRSEnglish()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_EN_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_RS_EN}");

            SAV3RS sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
        [Test]
        public void ExportRSJapanese()
        {
            byte[] sav_me3 = File.ReadAllBytes($"{Data.ExpectedSavesDir}{Data.RS_JP_ME3}");
            byte[] me3 = File.ReadAllBytes($"{Data.MysteryDataDir}{Data.Eonticket_RS_JP}");

            SAV3RS sav = new(sav_me3);

            Assert.That(me3, Is.EqualTo(sav.ExportME3()));
        }
    }
}