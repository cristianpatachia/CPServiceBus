namespace CPShared.Extensions
{
    public static class PrimitiveExtensions
    {
        public static bool IsGreaterThanZero(this decimal value)
        {
            return value > 0;
        }

        public static string F(this string input, params object?[] args)
        {
            return string.Format(input, args);
        }
    }
}
