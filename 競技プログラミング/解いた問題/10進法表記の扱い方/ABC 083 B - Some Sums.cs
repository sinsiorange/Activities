using System;
using System.Linq;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int N = a[0];
        int A = a[1];
        int B = a[2];
        int total = 0;
        for (int i = 1; i <= N; i++)
        {
            int sum = findSumOfDigits(i);
            if (A <= sum && sum <= B)
            {
                total += i;
            }
        }

        Console.WriteLine(total);
    }

    public static int findSumOfDigits(int n)//ŠeŒ…‚Ì˜a‚ğ•Ô‚·ŠÖ”
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum;
    }




}