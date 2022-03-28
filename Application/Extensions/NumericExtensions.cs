namespace Common.Application;

public static class NumericExtensions
{
    public static double ToDouble(this decimal original)
    {
        return decimal.ToDouble(original);
    }
}
