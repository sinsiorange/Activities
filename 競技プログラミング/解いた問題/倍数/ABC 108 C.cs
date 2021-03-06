using System;
using System.Linq;

public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int N = input[0];
        int K = input[1];
        int count1 = 0;
        int count2 = 0;
        long sum = 0;

        // Kの倍数である数値の個数を数える

        for (int i = 1; i <= N; i++)
        {
            if (i % K == 0)
            {
                count1 += 1;
            }
        }



        // 余りがKの半分となる数値の個数を数える
        for (int i = 1; i <= N; i++)
        {
            if (i % K == K / 2)
            {
                count2 += 1;
            }
        }

        sum += (long)count1 * count1 * count1;

        if (K % 2 == 0)//Kが偶数のとき
        {
            sum += (long)count2 * count2 * count2;
        }


        Console.WriteLine(sum);
    }
}