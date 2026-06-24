namespace SunamoStorage.Storage;

public class CompareFileNameWithDateTimeByDateTime<StorageFolder, StorageFile> : ISunamoComparer<FileNameWithDateTimeTU<StorageFolder, StorageFile>>
{
    public int Desc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.DateTime.CompareTo(second.DateTime) * -1;

    public int Asc(FileNameWithDateTimeTU<StorageFolder, StorageFile> first, FileNameWithDateTimeTU<StorageFolder, StorageFile> second)
        => first.DateTime.CompareTo(second.DateTime);
}
