using System;
using System.Linq;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int n = int.Parse(Console.ReadLine());
        int[] S = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(findMaximam(S, 0 ,n - 1));
    }
    public static int findMaximam(int[] A, int l, int r)
    {
        int m = (l + r) / 2;
        if(l == r - 1) //要素数が2つのとき
        {
            return Math.Max(A[l], A[r]);
        }
        else
        {
            int u = findMaximam(A, l, m);　　　//部分問題を解決
            int v = findMaximam(A, m + 1, r);　//部分問題を解決
            int x = Math.Max(u, v);
            return x;
        }

    }
}
