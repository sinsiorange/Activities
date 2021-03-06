using System;
using System.Linq;
using System.Collections.Generic;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        string S = Console.ReadLine();
        string T = Console.ReadLine();
        int[] start = new int[26]; //変換の表
        int[] goal = new int[26]; //逆変換の表
        for (int i = 0; i < 26; i++) //変換表を初期化
        {
            start[i] = -1;
            goal[i] = -1;
        }

        for (int i = 0; i < S.Length; i++)
        {
            if (start[S[i] - 'a'] != -1 || goal[T[i] - 'a'] != -1) //すでに変換または逆変換がおこなわれている場合
            {
                if (start[S[i] - 'a'] != T[i] - 'a' || goal[T[i] - 'a'] != S[i] - 'a')//今回の変換とは違う or 今回の逆変換とは違う場合
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            else
            {
                start[S[i] - 'a'] = T[i] - 'a'; //変換
                goal[T[i] - 'a'] = S[i] - 'a';　//逆変換
            }

        }
        Console.WriteLine("Yes");

    }

}
