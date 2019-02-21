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
        bool[] dp = new bool[100010];


        dp[0] = true;
        for (int i = 0; i <= S.Length; i++)
        {
            if (dp[i] == false)
            {
                continue;
            }

            for (int j = 0; j < divide.Length; j++)
            {
                string d = divide[j];

                if (S.Length - i < d.Length)
                {
                    continue;
                }

                else if (S.Substring(i, d.Length) == d) //divide[i]‚Å•ªŠ„‚Å‚«‚½‚ç
                {
                    dp[i + d.Length] = true;

                }

            }


        }



        if (dp[S.Length] == true) Console.WriteLine("YES");
        else Console.WriteLine("NO");

    }
}