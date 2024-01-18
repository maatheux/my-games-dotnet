using System.Text.RegularExpressions;

namespace MyGames.shared.utils;

public class DateRegex
{
    public static bool IsValidDate(string dateString)
    {
        Regex regex = new Regex(@"^\d{2}/\d{2}/\d{4}$");

        if (regex.IsMatch(dateString))
            return true;
        
        return false;

    }
}