using PKHeX.Core;

namespace WC3Plugin;

// Partially based on PKHeX's LocalizationUtil, thanks Kaphotics!
// https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/ResourceUtil.cs
// https://github.com/kwsch/PKHeX/blob/master/PKHeX.Core/Util/Localization/LocalizationUtil.cs
public static class LocalizationUtil
{
    private const string TranslationSplitter = " = ";
    private const string StringCachePrefix = nameof(WC3Plugin); // to distinguish from cashed PKHeX resources

    public static void SetLocalization(string currentCultureCode)
    {
        SetLocalization(GetStringList($"lang_{currentCultureCode}"));
    }

    private static string[] GetStringList(string fileName)
    {
        if (Util.IsStringListCached($"{StringCachePrefix}_{fileName}", out var result))
            return result;
        var txt = Properties.Resources.ResourceManager.GetObject(fileName)?.ToString();
        return Util.LoadStringList($"{StringCachePrefix}_{fileName}", txt);
    }

    private static void SetLocalization(IReadOnlyCollection<string> lines)
    {
        if (lines.Count == 0)
            return;

        Dictionary<string, string> dict = new();
        foreach (var line in lines)
        {
            var index = line.IndexOf(TranslationSplitter, StringComparison.Ordinal);
            if (index < 0)
                continue;

            dict.Add(line[..index], line[(index + TranslationSplitter.Length)..]);
        }

        TranslationStrings.PluginName = dict[nameof(TranslationStrings.PluginName)];
        TranslationStrings.MysteryGift = dict[nameof(TranslationStrings.MysteryGift)];
        TranslationStrings.MysteryEvent = dict[nameof(TranslationStrings.MysteryEvent)];
        TranslationStrings.ECardTrainer = dict[nameof(TranslationStrings.ECardTrainer)];
        TranslationStrings.ECardBerry = dict[nameof(TranslationStrings.ECardBerry)];
        TranslationStrings.WonderNews = dict[nameof(TranslationStrings.WonderNews)];
        TranslationStrings.Import = dict[nameof(TranslationStrings.Import)];
        TranslationStrings.Export = dict[nameof(TranslationStrings.Export)];
        TranslationStrings.AllFiles = dict[nameof(TranslationStrings.AllFiles)];
        TranslationStrings.Error = dict[nameof(TranslationStrings.Error)];
        TranslationStrings.Success = dict[nameof(TranslationStrings.Success)];
        TranslationStrings.InvalidFileSize = dict[nameof(TranslationStrings.InvalidFileSize)];
        TranslationStrings.OpenFile = dict[nameof(TranslationStrings.OpenFile)];
        TranslationStrings.SaveFile = dict[nameof(TranslationStrings.SaveFile)];
        TranslationStrings.ReadFileError = dict[nameof(TranslationStrings.ReadFileError)];
        TranslationStrings.WriteFileError = dict[nameof(TranslationStrings.WriteFileError)];
        TranslationStrings.FileImported = dict[nameof(TranslationStrings.FileImported)];
        TranslationStrings.FileExported = dict[nameof(TranslationStrings.FileExported)];
    }
}
