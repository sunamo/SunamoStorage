namespace SunamoStorage.Storage;

/// <summary>
/// Represents the date time file index t storage folder storage file type.
/// </summary>
public class DateTimeFileIndexT<StorageFolder, StorageFile>
{
    /// <summary>
    /// Gets or sets the catalog.
    /// </summary>
    public AbstractCatalogShared<StorageFolder, StorageFile> Catalog { get; set; } = null!;

    /// <summary>
    /// The init complete.
    /// </summary>
    public event Action<List<FileNameWithDateTimeTU<StorageFolder, StorageFile>>>? InitComplete;

    private string? extension = null;
    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    public List<FileNameWithDateTimeTU<StorageFolder, StorageFile>> Files { get; set; } = new List<FileNameWithDateTimeTU<StorageFolder, StorageFile>>();
    private FileEntriesDuplicitiesStrategy duplicityStrategy = FileEntriesDuplicitiesStrategy.Time;
    private LangsShared lang = LangsShared.cs;

#pragma warning disable
    public string GetFullPath(FileNameWithDateTimeTU<StorageFolder, StorageFile> fileEntry)
    {
        return null;
    }
#pragma warning restore

    /// <summary>
    /// Date time file index t.
    /// </summary>
    /// <param name="fileEntry">The file entry.</param>
    /// <returns>The date time file index t result.</returns>
    public DateTimeFileIndexT()
    {
    }

    // A4 was nowhere used, deleted
    /// <summary>
    /// Initialize.
    /// </summary>
    /// <returns>The initialize result.</returns>
    public void Initialize(string ext, FileEntriesDuplicitiesStrategy duplicitiesStrategy, AbstractCatalogShared<StorageFolder, StorageFile> catalog)
    {
        this.Catalog = catalog;
        duplicityStrategy = duplicitiesStrategy;
        extension = ext;
        string mask = "????_??_??_";
        if (duplicitiesStrategy == FileEntriesDuplicitiesStrategy.Serie)
        {
            mask += "S_?*_";
        }
        else if (duplicitiesStrategy == FileEntriesDuplicitiesStrategy.Time)
        {
            mask += "??_??_";
        }
        else
        {
            throw new Exception("Not supported strategy of saving files" + ".");
        }
        mask += "*" + ext;
        List<StorageFile>? storageFiles = null;
        foreach (var item in storageFiles!)
        {
        }
        if (duplicitiesStrategy == FileEntriesDuplicitiesStrategy.Serie)
        {
            Files.Sort(new CompareFileNameWithDateTimeBySerie<StorageFolder, StorageFile>().Desc);
        }
        Files.Sort(new CompareFileNameWithDateTimeByDateTime<StorageFolder, StorageFile>().Desc);
        if (InitComplete != null)
        {
            InitComplete(Files);
        }
    }

    private FileEntriesDuplicitiesStrategy GetFileEntriesDuplicitiesStrategy(string fileNameWithoutExtension, out int? serie, out int hour, out int minute, out string postfix)
    {
        serie = null;
        minute = hour = 0;
        if (fileNameWithoutExtension[11] == 'S')
        {
            var parts = SHSplit.Split(fileNameWithoutExtension, "_");
            serie = int.Parse(parts[4]);
            postfix = SHJoin.JoinFromIndex(5, "_", parts);
            return FileEntriesDuplicitiesStrategy.Serie;
        }
        else
        {
            string filePath = fileNameWithoutExtension.Substring(11, 5);
            var parts = SHSplit.Split(filePath, "_");
            hour = int.Parse(parts[0]);
            minute = int.Parse(parts[1]);
            postfix = SHJoin.JoinFromIndex(5, "_", parts);
            return FileEntriesDuplicitiesStrategy.Time;
        }
    }

    /// <summary>
    /// Create object file name with date time.
    /// </summary>
    /// <param name="11">The 11.</param>
    /// <param name="5">The 5.</param>
    /// <returns>The create object file name with date time result.</returns>
    public FileNameWithDateTimeTU<StorageFolder, StorageFile> CreateObjectFileNameWithDateTime(string row1, string row2, AbstractCatalogShared<StorageFolder, StorageFile> catalog)
    {
        var entry = new FileNameWithDateTimeTU<StorageFolder, StorageFile>(row1, row2, catalog);
        string? fileNameWithoutExtension = null;
        string dateS = fileNameWithoutExtension!.Substring(0, 10);
        entry.DateTime = DateTime.ParseExact(dateS, "yyyy_MM_dd", null);
        var strategy = GetFileEntriesDuplicitiesStrategy(fileNameWithoutExtension, out int? serie, out int hour, out int minute, out string postfix);
        entry.Serie = serie;
        entry.DateTime.AddMinutes(minute);
        entry.DateTime.AddHours(hour);
        entry.Name = postfix;
        entry.FileNameWithoutExtension = DeleteWrongCharsInFileName(fileNameWithoutExtension);
        entry.Row1 = postfix;
        entry.Row2 = entry.DateTime.ToShortDateString();
        return entry;
    }

    private static string GetDisplayText(DateTime date, int? serie, LangsShared lang)
    {
        string displayText;
        if (serie == null)
        {
            displayText = DTHelper.DateTimeToString(date, lang, new(1900, 1, 1));
        }
        else
        {
            int serieValue = serie.Value;
            string serieSuffix = "";
            if (serieValue != 0)
            {
                serieSuffix = " (" + serieValue + ")";
            }
            displayText = DTHelper.DateToString(date, lang) + serieSuffix;
        }
        return displayText;
    }

    private FileNameWithDateTimeTU<StorageFolder, StorageFile> CreateObjectFileNameWithDateTime(string row1, string row2, DateTime date, int? serie, string postfix, string fileNameWithoutExtension)
    {
        var entry = new FileNameWithDateTimeTU<StorageFolder, StorageFile>(row1, row2, Catalog);
        entry.DateTime = date;
        entry.Serie = serie;
        entry.Name = postfix;
        entry.FileNameWithoutExtension = DeleteWrongCharsInFileName(fileNameWithoutExtension);
        return entry;
    }

    private string DeleteWrongCharsInFileName(string fileNameWithoutExtension)
    {
        return SHReplace.ReplaceAll(FS.DeleteWrongCharsInFileName(fileNameWithoutExtension, false), "_", "");
    }

    /// <summary>
    /// Delete file.
    /// </summary>
    /// <param name="fileNameWithoutExtension">The file name without extension.</param>
    /// <returns>The delete file result.</returns>
    public void DeleteFile(FileNameWithDateTimeTU<StorageFolder, StorageFile> fileEntry)
    {
        try
        {
            string filePath = GetStorageFile(fileEntry);
            FS.TryDeleteFile(filePath);
            Files.Remove(fileEntry);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

#pragma warning disable
    public string GetStorageFile(FileNameWithDateTimeTU<StorageFolder, StorageFile> fileEntry)
    {
        return null;
    }
#pragma warning restore

    /// <summary>
    /// Save file with date.
    /// </summary>
    /// <param name="fileEntry">The file entry.</param>
    /// <returns>The save file with date result.</returns>
    public async Task<FileNameWithDateTimeTU<StorageFolder, StorageFile>> SaveFileWithDate(string name, string content)
    {
        var dateTime = DateTime.Now;
        var today = DateTime.Today;
        string fileNameWithoutExtension = "";
        int? max = null;
        if (duplicityStrategy == FileEntriesDuplicitiesStrategy.Time)
        {
            fileNameWithoutExtension = ConvertDateTimeToFileNamePostfix.ToConvention(name, dateTime, true);
        }
        else if (duplicityStrategy == FileEntriesDuplicitiesStrategy.Serie)
        {
            IList<int?> serieValues = Files.Where(fileEntry => fileEntry.DateTime == today).Select(fileEntry => fileEntry.Serie).ToList();
            max = serieValues.Count();
            if (max != 0)
            {
                max = serieValues.Max() + 1;
            }
            if (!max.HasValue)
            {
                max = 1;
            }
            fileNameWithoutExtension = DTHelper.DateTimeToFileName(dateTime, false) + "_S_" + max.Value + "_" + name;
        }
        else
        {
            // Unnecessary, already checked in constructor
        }
        var fileEntry = CreateObjectFileNameWithDateTime(GetDisplayText(dateTime, max, lang), name, dateTime, max, name, fileNameWithoutExtension);
        Files.Add(fileEntry);
        return fileEntry;
    }
}
