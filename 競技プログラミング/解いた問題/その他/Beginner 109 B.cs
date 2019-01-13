using System;
using System.Linq;
using System.Collections.Generic;

public class Hello
{
    public static void Main()
    {

        // Your code here!
        int N = int.Parse(Console.ReadLine());
        string[] array = new string[N];
        bool ans = true;

        for (int i = 0; i < N; i++)
        {
            array[i] = Console.ReadLine();
        }

        for (int i = 0; i < N - 1; i++) //最後の文字と最初の文字が一致するかチェック
        {
            if (array[i][array[i].Length - 1] != array[i + 1][0])
            {
                ans = false;
            }

        }

        for (int i = 0; i < N; i++)　//重複チェック
        {
            for (int j = 0; j < i; j++)
            {
                if (array[i] == array[j])
                {
                    ans = false;
                }
            }
        }

        if (ans == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }

    }
}
