namespace PairFast.Logic;

public class Pair
{
    public string Left { get; init; }
    public string Right { get; init; }

    private Pair(string left, string right)
    {
        Left = left;
        Right = right;
    }

    public bool Equals(Pair? obj)
    {
        if (obj == null) return false;

        var samePair = obj.Left == Left && obj.Right == Right;
        var invertedPair = obj.Left == Right && obj.Right == Left;

        return samePair || invertedPair;
    }

    public static Pair? New(string left, string right)
    {
        if (left == right)
            return null;

        return new Pair(left, right);
    }
}
