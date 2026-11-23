namespace SunamoStorage.Storage;

/// <summary>
/// Represents the compare file name with date time by serie storage folder storage file type.
/// </summary>
public class CompareFileNameWithDateTimeBySerie<StorageFolder, StorageFile> : ISunamoComparer<FileNameWithDateTimeTU<StorageFolder, StorageFile>>
{
    /// <summary>
    /// Desc.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The desc result.</returns>
    public int Desc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.SerieValue.CompareTo(second.SerieValue) * -1;

    /// <summary>
    /// Asc.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The asc result.</returns>
    public int Asc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.SerieValue.CompareTo(second.SerieValue);
}
