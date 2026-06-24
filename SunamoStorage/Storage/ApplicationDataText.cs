namespace SunamoStorage.Storage;

public class ApplicationDataText
{
    public static
async Task<Dictionary<string, List<string>>>
Parse(string file, List<string> sections)
    {
        var result = new Dictionary<string, List<string>>();

        var lines = (
            await FileAsync.ReadAllLinesAsync(file)
            ).ToList();
        CA.Trim(lines);
        var currentLines = new List<string>();

        string? currentSection = null;

        foreach (var item in lines)
        {
            string? previousSection = currentSection;
            if (CA.IsSomethingTheSame(item, sections, ref currentSection!))
            {
                CA.RemoveStringsEmpty(currentLines);
                if (previousSection != null)
                {
                    result.Add(previousSection, currentLines);
                }

                currentLines = new List<string>();

                continue;
            }

            currentLines.Add(item);
        }
        CA.RemoveStringsEmpty(currentLines);
        result.Add(currentSection!, currentLines);

        ThrowEx.DifferentCountInLists("sections", sections.Count, "result", result.Count);
        return result;
    }
}
