using static System.Buffers.Binary.BinaryPrimitives;
using PKHeX.Core;

namespace WC3Plugin;

public static class MysteryDataUtil
{
    #region WC3
    /*
     * File Size:       INT 0x58C,         JP 0x4E4
     * Offsets:
     * WonderCard:      INT 0     - 0x14F, JP 0     - 0x0A7
     * WonderCardExtra: INT 0x150 - 0x177, JP 0x0A8 - 0x0CF
     * Trainer IDs:     INT 0x178 - 0x19F, JP 0x0D0 - 0x0F7 // not handled
     * MysteryData:     INT 0x1A0 - 0x58B, JP 0x0F8 - 0x4E3
     */
    public static void ImportWC3(this SAV3 sav, byte[] data)
    {
        if (sav is not IGen3Wonder wonder)
            return;

        int CardSize = GetWC3CardSize(sav);
        int WC3ScriptOffset = GetWC3ScriptOffset(sav);

        WonderCard3 wc3 = new(data[..CardSize]);
        wc3.FixChecksum();

        WonderCard3Extra wc3Extra = new(data[CardSize..(CardSize + WonderCard3Extra.SIZE)]);
        // wc3Extra.FixChecksum(); checksum is unused in the games

        MysteryEvent3 me3 = new(data[WC3ScriptOffset..]);
        me3.FixChecksum();

        wonder.WonderCard = wc3;
        wonder.WonderCardExtra = wc3Extra;
        sav.MysteryData = me3;
    }
    
    public static byte[] ExportWC3(this SAV3 sav)
    {
        if (sav is not IGen3Wonder wonder)
            return [];

        byte[] data = new byte[GetWC3FileSize(sav)];
        wonder.WonderCard.Data.CopyTo(data, 0);
        wonder.WonderCardExtra.Data.CopyTo(data, GetWC3CardSize(sav));
        sav.MysteryData.Data.CopyTo(data, GetWC3ScriptOffset(sav));
        return data;
    }
    
    public static bool HasWC3(this SAV3 sav)
    {
        return sav is IGen3Wonder wonder && !IsEmpty(wonder.WonderCard.Data);
    }
    
    public static int GetWC3FileSize(this SAV3 sav) => GetWC3ScriptOffset(sav) + MysteryEvent3.SIZE;
    
    private static int GetWC3CardSize(this SAV3 sav) => sav.Japanese ? WonderCard3.SIZE_JAP : WonderCard3.SIZE;
    private static int GetWC3ScriptOffset(this SAV3 sav) => GetWC3CardSize(sav) + (WonderCard3Extra.SIZE * 2);
    #endregion WC3

    #region ME3
    public static void ImportME3(this SAV3 sav, byte[] data)
    {
        Gen3MysteryData mystery;
        if (sav is IGen3Wonder wonder) // FRLGE
        {
            wonder.WonderCard = new(new byte[sav.Japanese ? WonderCard3.SIZE_JAP : WonderCard3.SIZE]);

            mystery = new MysteryEvent3(data[..MysteryEvent3.SIZE]);
            ((MysteryEvent3)mystery).FixChecksum();
        }
        else // RS
        {
            mystery = new MysteryEvent3RS(data[..MysteryEvent3.SIZE]);
            ((MysteryEvent3RS)mystery).FixChecksum();
        }
        sav.MysteryData = mystery;

        if (sav is IGen3Hoenn hoenn && data.Length == MysteryEvent3.SIZE + RecordMixing3Gift.SIZE)
        {
            RecordMixing3Gift rm3 = new(data[MysteryEvent3.SIZE..]);
            rm3.FixChecksum();
            hoenn.RecordMixingGift = rm3;
        }
    }
    
    public static byte[] ExportME3(this SAV3 sav)
    {
        return sav.MysteryData.Data;
    }
    
    public static bool HasME3(this SAV3 sav)
    {
        return sav is SAV3RS
            ? !IsEmpty(sav.MysteryData.Data)
            : sav is IGen3Wonder wonder && !IsEmpty(sav.MysteryData.Data) && IsEmpty(wonder.WonderCard.Data);
    }
    #endregion ME3

    #region WN3
    public static void ImportWN3(this SAV3 sav, byte[] data)
    {
        if (sav is not IGen3Wonder wonder)
            return;

        WonderNews3 wn3 = new(data);
        wn3.FixChecksum();

        wonder.WonderNews = wn3;
    }
    
    public static byte[] ExportWN3(this SAV3 sav)
    {
        if (sav is not IGen3Wonder wonder)
            return [];

        byte[] data = new byte[GetWN3FileSize(sav)];
        wonder.WonderNews.Data.CopyTo(data, 0);
        return data;
    }
    
    public static bool HasWN3(this SAV3 sav)
    {
        return sav is IGen3Wonder wonder && !IsEmpty(wonder.WonderNews.Data);
    }
    
    public static int GetWN3FileSize(this SAV3 sav) => sav.Japanese ? WonderNews3.SIZE_JAP : WonderNews3.SIZE;
    #endregion WN3

    #region ECT
    public static void ImportECT(this SAV3 sav, byte[] data)
    {
        FixECTChecksum(data).CopyTo(sav.EReaderTrainer());
    }
    
    public static byte[] ExportECT(this SAV3 sav)
    {
        return sav.EReaderTrainer().ToArray();
    }
    
    public static bool HasECT(this SAV3 sav)
    {
        return !IsEmpty(sav.EReaderTrainer());
    }
    
    public static int GetECTFileSize(this SAV3 _) => ECT_SIZE;
    
    private static byte[] FixECTChecksum(byte[] data)
    {
        WriteUInt32LittleEndian(data.AsSpan(ECT_SIZE - 4), GetECTChecksum(data));
        return data;
    }
    
    private static uint GetECTChecksum(byte[] data)
    {
        uint chk = 0;

        for (int i = 0; i < ECT_SIZE - 4; i += 4)
        {
            chk += ReadUInt32LittleEndian(data.AsSpan(i));
        }

        return chk;
    }
    
    private const int ECT_SIZE = 188;
    #endregion ECT

    #region ECB
    public static void ImportECB(this SAV3 sav, byte[] data)
    {
        FixECBChecksum(data).CopyTo(sav.EReaderBerry());
        sav.SetWork((sav is IGen3Hoenn) ? VAR_ENIGMA_BERRY_AVAILABLE_RSE : VAR_ENIGMA_BERRY_AVAILABLE_FRLG, 1);
    }
    
    public static byte[] ExportECB(this SAV3 sav)
    {
        return sav.EReaderBerry().ToArray();
    }
    
    public static bool HasECB(this SAV3 sav)
    {
        return !IsEmpty(sav.EReaderBerry());
    }
    
    public static int GetECBFileSize(this SAV3 sav) => sav is SAV3RS ? ECB_SIZE_RS : ECB_SIZE_FRLGE;
    
    private static byte[] FixECBChecksum(byte[] data)
    {
        WriteUInt16LittleEndian(data.AsSpan(data.Length - 4), GetECBChecksum(data));
        return data;
    }

    private static ushort GetECBChecksum(byte[] data)
    {
        ushort chk = 0;

        if (data.Length == ECB_SIZE_RS)
        {
            for (int i = 0; i < ECB_SIZE_RS - 4; i++)
            {
                if (i < 0xC || i >= 0x14)
                    chk += (ushort)(data[i] & 0xFF);
            }
        }
        else
        {
            for (int i = 0; i < ECB_SIZE_FRLGE - 4; i++)
            {
                chk += (ushort)(data[i] & 0xFF);
            }
        }

        return chk;
    }

    private const int ECB_SIZE_RS = 1328;
    private const int ECB_SIZE_FRLGE = 52;
    private const int VAR_ENIGMA_BERRY_AVAILABLE_RSE = 0x2D;  // 0x402D
    private const int VAR_ENIGMA_BERRY_AVAILABLE_FRLG = 0x33; // 0x4033; unused but set by script command
    #endregion ECB

    #region RM3
    public static void SetRecordMixing(this SAV3 sav, ushort item, byte count)
    {
        if (sav is not IGen3Hoenn hoenn)
            return;

        RecordMixing3Gift rm3 = new(hoenn.RecordMixingGift.Data)
        {
            Item = item,
            Count = (byte)(item == 0 ? 0 : count)
        };
        rm3.FixChecksum();
        hoenn.RecordMixingGift = rm3;
    }

    public static bool IsValidForRecordMixing(this SAV3 sav, ushort item)
    {
        if (sav is not IGen3Hoenn)
            return false;

        if (item is 0 or EONTICKET)
            return true;

        IItemStorage storage = sav is SAV3E ? new ItemStorage3E() : new ItemStorage3RS();
        return storage.GetItems(InventoryType.PCItems).Contains(item);
    }

    public static IReadOnlyList<ComboItem> GetRecordMixingItemDataSource(this SAV3 sav) =>
    [
        .. GameInfo.FilteredSources.Items,
        new(GameInfo.Strings.GetItemStrings(sav.Context, sav.Version)[EONTICKET], EONTICKET),
    ];
    private const ushort EONTICKET = 0x113;
    #endregion RM3

    #region Utility
    internal static bool IsEmpty(Span<byte> data)
    {
        foreach (byte b in data)
        {
            if (b is not (0 or 0xFF))
                return false;
        }
        return true;
    }
    #endregion Utility
}
