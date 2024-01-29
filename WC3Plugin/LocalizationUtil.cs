namespace WC3Plugin;

public static class LocalizationUtil
{
    private const string TranslationSplitter = " = ";
    private const string LineSplitter = "\n";

    public static void SetLocalization(string currentCultureCode)
    {
        var txt = Properties.Resources.ResourceManager.GetObject($"lang_{currentCultureCode}")?.ToString();
        SetLocalization(txt == null ? [] : txt.Split(LineSplitter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
    }

    private static void SetLocalization(IReadOnlyCollection<string> lines)
    {
        if (lines.Count == 0)
            return;

        Dictionary<string, string> dict = [];
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
        TranslationStrings.RecordMixing = dict[nameof(TranslationStrings.RecordMixing)];
        TranslationStrings.Item = dict[nameof(TranslationStrings.Item)];
        TranslationStrings.Count = dict[nameof(TranslationStrings.Count)];
        TranslationStrings.Save = dict[nameof(TranslationStrings.Save)];
    }
}
