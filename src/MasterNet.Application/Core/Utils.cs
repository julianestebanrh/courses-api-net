using System.Globalization;

namespace MasterNet.Application.Core;


public static class Utils
{
    public static string ToTitleCase(this string source, CultureInfo culture)
    {
        culture = culture ?? CultureInfo.CurrentUICulture;
        return culture.TextInfo.ToTitleCase(source.ToLower());
    }
}