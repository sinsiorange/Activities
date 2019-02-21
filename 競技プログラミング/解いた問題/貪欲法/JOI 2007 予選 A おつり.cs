using System;
using System.Linq;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] c = { 500, 100, 50, 10, 5, 1 };
        int input = int.Parse(Console.ReadLine());
        int A = 1000 - input;
        int num = 0;
        for (int i = 0; i < c.Length; i++)
        {
            int t = A / c[i];
            A -= t * c[i];
            num += t;
        }
        Console.WriteLine(num);
    }
}