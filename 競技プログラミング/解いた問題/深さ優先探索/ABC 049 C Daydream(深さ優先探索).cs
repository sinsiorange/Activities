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
        bool can = false;
        dfs(0, ref can, S, divide);
        if (can) Console.WriteLine("YES");
        else Console.WriteLine("NO");

    }

    public static void dfs(int now, ref bool can, string S, string[] divide)
    {
        if (now == S.Length)
        {
            can = true;
            return;
        }

        for (int i = 0; i < divide.Length; i++)
        {
            string d = divide[i];
            int next = now + d.Length;
            if (S.Length - now < d.Length)
            {
                continue;
            }
            else if (S.Substring(now, d.Length) == d)
            {
                dfs(next, ref can, S, divide);
            }

        }

        //‚Ç‚¤‚â‚Á‚Ä‚àØ‚ê‚È‚©‚Á‚½‚çreturn
        return;
    }


}
