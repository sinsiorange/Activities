using System;
using System.Linq;

public class Hello
{
    public static void Main()
    {
        // Your code here!

        int[] t = new int[100010];
        int[] x = new int[100010];
        int[] y = new int[100010];
        t[0] = 0;
        x[0] = 0;
        y[0] = 0;
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            int[] s = Console.ReadLine().Split(' ').Select(v => int.Parse(v)).ToArray();
            t[i + 1] = s[0];
            x[i + 1] = s[1];
            y[i + 1] = s[2];
        }

        bool can = true;
        for (int i = 0; i < N; i++)
        {
            int dt = t[i + 1] - t[i];
            int dist = Math.Abs(x[i + 1] - x[i]) + Math.Abs(y[i + 1] - y[i]);
            if (dt < dist)
            {
                can = false;

            }
            else
            {
                if (dt % 2 != dist % 2)
                {

                    can = false;

                }
            }
        }

        if (can == true) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}
