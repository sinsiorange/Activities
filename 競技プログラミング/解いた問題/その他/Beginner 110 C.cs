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
        int[] start = new int[26]; //�ϊ��̕\
        int[] goal = new int[26]; //�t�ϊ��̕\
        for (int i = 0; i < 26; i++) //�ϊ��\��������
        {
            start[i] = -1;
            goal[i] = -1;
        }

        for (int i = 0; i < S.Length; i++)
        {
            if (start[S[i] - 'a'] != -1 || goal[T[i] - 'a'] != -1) //���łɕϊ��܂��͋t�ϊ��������Ȃ��Ă���ꍇ
            {
                if (start[S[i] - 'a'] != T[i] - 'a' || goal[T[i] - 'a'] != S[i] - 'a')//����̕ϊ��Ƃ͈Ⴄ or ����̋t�ϊ��Ƃ͈Ⴄ�ꍇ
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            else
            {
                start[S[i] - 'a'] = T[i] - 'a'; //�ϊ�
                goal[T[i] - 'a'] = S[i] - 'a';�@//�t�ϊ�
            }

        }
        Console.WriteLine("Yes");

    }

}
