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
        int[] dp = new int[50010]; //dp[i] i�~���x�������߂ɕK�v�ȍŏ��̖���
        for (int i = 0; i < dp.Length; i++)�@//dp��������
        {
            dp[i] = 100000;
        }

        dp[0] = 0;
        for (int i = 0; i < dp.Length; i++)
        {
            for (int j = 0; j < c.Length; j++)
            {
                if (i + c[j] <= n) // i + c[j]��dp�͈̔͂���͂ݏo���̂�h�����߂̏���
                {
                    dp[i + c[j]] = Math.Min(dp[i + c[j]], dp[i] + 1);
                }

            }
        }

        Console.WriteLine(dp[n]);
    }
}