namespace SunamoStorage.Storage;

/// <summary>
/// Represents the file name with date time type.
/// </summary>
public class FileNameWithDateTime : FileNameWithDateTimeTU<string, string>
{
    /// <summary>
    /// Initializes a new instance of the file name with date time class.
    /// </summary>
    /// <param name="row1">The row 1.</param>
    /// <param name="row2">The row 2.</param>
    public FileNameWithDateTime(string row1, string row2) : base(row1, row2, null!)
    {
    }
}
