using System;

public class Hello
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] R = new int[n];
        for(int a = 0; a < n; a++)
        {
            R[a] = int.Parse(Console.ReadLine());
        }
        int minV = R[0];
        int maxV = -1000000000;
        for(int j = 1; j < n; j++)
        {
           minV = Math.Min(minV, R[j - 1]);
           maxV = Math.Max(R[j] - minV, maxV);

        }
        Console.WriteLine(maxV);
    }
}
