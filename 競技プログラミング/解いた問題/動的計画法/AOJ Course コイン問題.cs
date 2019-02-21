using System;
using System.Linq;
public class Hello
{
    public static void Main()
    {
        int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int n = a[0];
        int m = a[1];
        int[] c = Console.ReadLine().Split(' ').Select(y => int.Parse(y)).ToArray();
        int[] dp = new int[50010]; //dp[i] i円を支払うために必要な最小の枚数
        for (int i = 0; i < dp.Length; i++)　//dpを初期化
        {
            dp[i] = 100000;
        }

        dp[0] = 0;
        for (int i = 0; i < dp.Length; i++)
        {
            for (int j = 0; j < c.Length; j++)
            {
                if (i + c[j] <= n) // i + c[j]がdpの範囲からはみ出すのを防ぐための条件
                {
                    dp[i + c[j]] = Math.Min(dp[i + c[j]], dp[i] + 1);
                }

            }
        }

        Console.WriteLine(dp[n]);
    }
}