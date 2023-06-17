using System;
using System.Linq;

public static class Tools
{
    public static T Get<T>(ref T a_value, T a_fallback)
    {
        if (a_value != null) return a_value;
        return a_fallback;
    }

    private static Random s_random = new Random();

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[s_random.Next(s.Length)]).ToArray());
    }
}