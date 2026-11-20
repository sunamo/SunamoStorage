namespace SunamoStorage.Storage;

/// <summary>
/// Represents the compare file name with date time by date time storage folder storage file type.
/// </summary>
public class CompareFileNameWithDateTimeByDateTime<StorageFolder, StorageFile> : ISunamoComparer<FileNameWithDateTimeTU<StorageFolder, StorageFile>>
{
    /// <summary>
    /// Desc.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The desc result.</returns>
    public int Desc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.DateTime.CompareTo(second.DateTime) * -1;

    /// <summary>
    /// Asc.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The asc result.</returns>
    public int Asc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.DateTime.CompareTo(second.DateTime);
}
