using System;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int N = int.Parse(Console.ReadLine());
        int CMAX = 100 / 4;
        int DMAX = 100 / 7;
        for (int i = 0; i < CMAX; i++) //�P�[�L�̌�
        {
            for (int j = 0; j < DMAX; j++) //�h�[�i�c�̌�
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