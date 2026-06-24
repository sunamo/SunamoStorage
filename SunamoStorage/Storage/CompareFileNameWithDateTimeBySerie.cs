namespace SunamoStorage.Storage;

public class CompareFileNameWithDateTimeBySerie<StorageFolder, StorageFile> : ISunamoComparer<FileNameWithDateTimeTU<StorageFolder, StorageFile>>
{
    public int Desc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.SerieValue.CompareTo(second.SerieValue) * -1;

    public int Asc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.SerieValue.CompareTo(second.SerieValue);
}
