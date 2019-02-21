using System;
using System.Linq;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] a = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int N = a[0];
        int Y = a[1];
        for (int x = 0; x <= N; x++)
        {
            for (int y = 0; y <= N - x; y++)
            {
                int z = N - x - y;
                if (10000 * x + 5000 * y + 1000 * z == Y)
                {
                    Console.WriteLine(x + " " + y + " " + z);
                    return;
                }
            }
        }
        Console.WriteLine("-1 -1 -1");
    }
}
