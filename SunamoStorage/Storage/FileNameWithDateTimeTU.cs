namespace SunamoStorage.Storage;

/// <summary>
/// Represents the file name with date time TU storage folder storage file type.
/// </summary>
public class FileNameWithDateTimeTU<StorageFolder, StorageFile>
{
    private AbstractCatalogShared<StorageFolder, StorageFile> catalog;

    /// <summary>
    /// Gets or sets the date time.
    /// </summary>
    public DateTime DateTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Gets or sets the serie.
    /// </summary>
    public int? Serie { get; set; } = null;

    /// <summary>
    /// Gets or sets the file name without extension.
    /// </summary>
    public string FileNameWithoutExtension { get; set; } = "";

    // Gets the serie value (throws if null).
    /// <summary>
    /// Gets the serie value.
    /// </summary>
    public int SerieValue => Serie!.Value;

    private string? displayText = null;
    private string row1 = string.Empty;
    private string row2 = string.Empty;

    /// <summary>
    /// File name with date time TU.
    /// </summary>
    /// <param name="null">The null.</param>
    /// <returns>The file name with date time TU result.</returns>
    public FileNameWithDateTimeTU(string row1, string row2, AbstractCatalogShared<StorageFolder, StorageFile> catalog)
    {
        displayText = $"{row1} {row2}";
        this.row1 = row1;
        this.row2 = row2;
        this.catalog = catalog;
    }

    // First row in SelectorHelperListViewUC.
    /// <summary>
    /// Gets or sets the row 1.
    /// </summary>
    public string Row1 { get { return row1; } set { row1 = value; } }

    // Second row in SelectorHelperListViewUC.
    /// <summary>
    /// Gets or sets the row 2.
    /// </summary>
    public string Row2 { get { return row2; } set { row2 = value; } }

    /// <summary>
    /// Initializes a new instance of the to string class.
    /// </summary>
    /// <param name="row1">The row 1.</param>
    /// <param name="row2">The row 2.</param>
    /// <param name="catalog">The catalog.</param>
    public override string ToString() => displayText!;
}
