public static class Tools
{
    public static T Get<T>(ref T a_value, T a_fallback)
    {
        if (a_value != null) return a_value;
        return a_fallback;
    }
}