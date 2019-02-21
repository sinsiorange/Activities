using System;
using System.Linq;
using System.Collections.Generic;

public class Hello
{
    public static void Main()
    {
        // Your code here!

        string S = Console.ReadLine();
        string[] divide = new string[] { "dream", "dreamer", "erase", "eraser" };

        Queue<int> q = new Queue<int>();
        q.Enqueue(0);
        bool can = false;
        while (q.Count != 0)
        {
            int now = q.Dequeue();
            if (now == S.Length)
            {
                can = true;
                break;
            }
            for (int j = 0; j < divide.Length; j++)
            {
                string d = divide[j];
                int next = now + d.Length;
                if (S.Length - now < d.Length)
                {
                    continue;
                }
                else if (S.Substring(now, d.Length) == d)
                {
                    q.Enqueue(next);
                }
            }

        }

        if (can) Console.WriteLine("YES");
        else Console.WriteLine("NO");



    }
}
