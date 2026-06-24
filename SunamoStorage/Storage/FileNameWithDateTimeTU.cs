namespace SunamoStorage.Storage;

public class FileNameWithDateTimeTU<StorageFolder, StorageFile>
{
    private AbstractCatalogShared<StorageFolder, StorageFile> catalog;

    public DateTime DateTime { get; set; } = DateTime.MinValue;

    public string Name { get; set; } = "";

    public int? Serie { get; set; } = null;

    public string FileNameWithoutExtension { get; set; } = "";

    // Gets the serie value (throws if null).
    public int SerieValue => Serie!.Value;

    private string? displayText = null;
    private string row1 = string.Empty;
    private string row2 = string.Empty;

    public FileNameWithDateTimeTU(string row1, string row2, AbstractCatalogShared<StorageFolder, StorageFile> catalog)
    {
        displayText = $"{row1} {row2}";
        this.row1 = row1;
        this.row2 = row2;
        this.catalog = catalog;
    }

    // First row in SelectorHelperListViewUC.
    public string Row1 { get { return row1; } set { row1 = value; } }

    // Second row in SelectorHelperListViewUC.
    public string Row2 { get { return row2; } set { row2 = value; } }

    public override string ToString() => displayText!;
}
