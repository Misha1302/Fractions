var first = new Fraction(2, 3);
var second = new Fraction(4, 7);

Console.WriteLine(first + second);
Console.WriteLine(first - second);
Console.WriteLine(first * second);
Console.WriteLine(first / second);

public record Fraction
{
    public readonly int A;
    public readonly int B;

    public Fraction(int A, int B)
    {
        var nod = Nod.GetNod(A, B);
        this.A = A / nod;
        this.B = B / nod;
    }

    public static Fraction operator +(Fraction first, Fraction second) =>
        new(first.A * second.B + second.A * first.B, first.B * second.B);

    public static Fraction operator -(Fraction first, Fraction second) =>
        first + -second;

    public static Fraction operator -(Fraction frac) =>
        new(-frac.A, frac.B);


    public static Fraction operator *(Fraction first, Fraction second) =>
        new(first.A * second.A, first.B * second.B);

    public static Fraction operator /(Fraction first, Fraction second) =>
        first * Reverse(second);

    public static Fraction Reverse(Fraction frac) =>
        new(frac.B, frac.A);

    public override string ToString() => $"{A}/{B}";

    public void Deconstruct(out float A, out float B)
    {
        A = this.A;
        B = this.B;
    }
}

public static class Nod
{
    public static int GetNod(int a, int b)
    {
        a = Math.Abs(a);
        
        while (a != b)
            if (a > b)
                a -= b;
            else b -= a;

        return a;
    }
}