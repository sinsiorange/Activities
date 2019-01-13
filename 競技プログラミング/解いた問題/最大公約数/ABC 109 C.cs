using System;
using System.Linq;


public class Hello
{
    public static void Main()
    {
        // Your code here!

        int[] a = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int[] x = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int N = a[0];
        int X = a[1];
        int ans = Math.Abs(X - x[0]);

        for (int i = 1; i < N; i++)
        {
            // gcd(a, b, c) = gcd(gcd(a, b), c)
            ans = gcd(ans, Math.Abs(X - x[i]));
        }
        Console.WriteLine(ans);

    }

    public static int gcd(int a, int b) //ユークリッドの互除法でaとbの最大公約数を求める
    {
        if (a < b) //a < bのとき，aとbを入れ替える．
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        if (b < 1) //aとbは自然数でないとだめ．bが自然数でないならば-1を返す．
        {
            return -1;
        }

        int r = a % b;

        //終了条件
        if (r == 0)
        {
            return b;
        }

        return gcd(b, r);
    }
}
