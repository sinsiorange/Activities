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

        S = string.Join("", S.Reverse());



        for (int i = 0; i < divide.Length; i++)
        {
            divide[i] = string.Join("", divide[i].Reverse());
        }
        bool can = true;

        for (int i = 0; i < S.Length;)
        {

            bool can2 = false;
            for (int j = 0; j < divide.Length; j++)
            {
                string d = divide[j];
                if (S.Length - i < d.Length)
                {
                    continue;
                }
                else if (S.Substring(i, d.Length) == d) //divide[i]‚Å•ªŠ„‚Å‚«‚½‚ç
                {
                    can2 = true;
                    i += d.Length;
                }

            }

            if (can2 == false)
            {

                can = false;
                break;
            }
        }

        if (can) Console.WriteLine("YES");
        else Console.WriteLine("NO");

    }
}
