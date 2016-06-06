using System.Globalization;
using System.Text;

public static class EditString
{
    //Transforms the culture of a letter to its equivalent representation in the 0-127 ascii table, such as the letter 'é' is substituted by an 'e'
    public static string RemoveDiacritics(string s)
    {
        string normalizedString = null;
        var stringBuilder = new StringBuilder();
        normalizedString = s.Normalize(NormalizationForm.FormD);
        int i = 0;
        char c = '\0';

        for (i = 0; i <= normalizedString.Length - 1; i++)
        {
            c = normalizedString[i];
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().ToLower();
    }
}
