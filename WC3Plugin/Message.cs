namespace WC3Plugin;

public static class Message
{
    public static void ShowFileImported(string mysteryType, string internalName) => _ = MessageBox.Show($"{string.Format(TranslationStrings.FileImported, mysteryType)}\n\n\"{internalName}\"", TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
    public static void ShowFileImported(string mysteryType) => _ = MessageBox.Show(string.Format(TranslationStrings.FileImported, mysteryType), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
    public static void ShowFileReadError(string mysteryType) => _ = MessageBox.Show(string.Format(TranslationStrings.ReadFileError, mysteryType), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    public static void ShowInvalidFileSize(long actualSize, int expectedSize) => _ = MessageBox.Show(string.Format(TranslationStrings.InvalidFileSize, actualSize, expectedSize), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    public static void ShowFileExported(string mysteryType, string fileName) => _ = MessageBox.Show(string.Format(TranslationStrings.FileExported, mysteryType, fileName), TranslationStrings.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
    public static void ShowFileWriteError(string mysteryType) => _ = MessageBox.Show(string.Format(TranslationStrings.WriteFileError, mysteryType), TranslationStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
}
