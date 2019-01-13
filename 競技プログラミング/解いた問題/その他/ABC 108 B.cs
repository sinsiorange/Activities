using System;
using System.Linq;

public class Hello
{
    public static void Main()
    {
        // Your code here!

        int[] a = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int x1 = a[0];
        int y1 = a[1];
        int x2 = a[2];
        int y2 = a[3];

        int dx = x2 - x1;
        int dy = y2 - y1;
        int x = x2;
        int y = y2;


        for (int i = 0; i < 2; i++)
        {
            Swap<int>(ref dx, ref dy);
            dx = -dx;
            x += dx;
            y += dy;
            Console.Write(x + " " + y + " ");
        }


    }

    static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

}