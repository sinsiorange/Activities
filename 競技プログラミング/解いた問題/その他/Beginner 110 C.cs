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
        int[] start = new int[26]; //•ÏŠ·‚Ì•\
        int[] goal = new int[26]; //‹t•ÏŠ·‚Ì•\
        for (int i = 0; i < 26; i++) //•ÏŠ·•\‚ð‰Šú‰»
        {
            start[i] = -1;
            goal[i] = -1;
        }

        for (int i = 0; i < S.Length; i++)
        {
            if (start[S[i] - 'a'] != -1 || goal[T[i] - 'a'] != -1) //‚·‚Å‚É•ÏŠ·‚Ü‚½‚Í‹t•ÏŠ·‚ª‚¨‚±‚È‚í‚ê‚Ä‚¢‚éê‡
            {
                if (start[S[i] - 'a'] != T[i] - 'a' || goal[T[i] - 'a'] != S[i] - 'a')//¡‰ñ‚Ì•ÏŠ·‚Æ‚Íˆá‚¤ or ¡‰ñ‚Ì‹t•ÏŠ·‚Æ‚Íˆá‚¤ê‡
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            else
            {
                start[S[i] - 'a'] = T[i] - 'a'; //•ÏŠ·
                goal[T[i] - 'a'] = S[i] - 'a';@//‹t•ÏŠ·
            }

        }
        Console.WriteLine("Yes");

    }

}
