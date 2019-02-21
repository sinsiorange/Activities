using System;
using System.Linq;

public class Hello
{
    public static void Main()
    {
        // Your code here!

        int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int N = a[0]; //コマの数
        int M = a[1]; //区間の数
        int[] array = Console.ReadLine().Split(' ').Select(y => int.Parse(y)).ToArray();
        Array.Sort(array);
        int[] d = new int[100010];

        for (int i = 0; i < M - 1; i++)
        {
            d[i] = array[i + 1] - array[i];
        }

        Array.Sort(d);
        Array.Reverse(d);
        int sum = 0;
        for (int i = 0; i < N - 1; i++)//区切りの数(コマの数 - 1)分まわす
        {
            sum += d[i];
        }

        Console.WriteLine((array[array.Length - 1] - array[0]) - sum);

    }
}