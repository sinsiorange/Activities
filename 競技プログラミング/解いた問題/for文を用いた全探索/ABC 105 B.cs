using System;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int N = int.Parse(Console.ReadLine());
        int CMAX = 100 / 4;
        int DMAX = 100 / 7;
        for (int i = 0; i < CMAX; i++) //ケーキの個数
        {
            for (int j = 0; j < DMAX; j++) //ドーナツの個数
            {
                if (4 * i + 7 * j == N)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
        }
        Console.WriteLine("No");
    }
}