using System;
using System.Linq;

public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int N = input[0];
        int K = input[1];
        int count1 = 0;
        int count2 = 0;
        long sum = 0;

        // K‚Ì”{”‚Å‚ ‚é”’l‚ÌŒÂ”‚ğ”‚¦‚é

        for (int i = 1; i <= N; i++)
        {
            if (i % K == 0)
            {
                count1 += 1;
            }
        }



        // —]‚è‚ªK‚Ì”¼•ª‚Æ‚È‚é”’l‚ÌŒÂ”‚ğ”‚¦‚é
        for (int i = 1; i <= N; i++)
        {
            if (i % K == K / 2)
            {
                count2 += 1;
            }
        }

        sum += (long)count1 * count1 * count1;

        if (K % 2 == 0)//K‚ª‹ô”‚Ì‚Æ‚«
        {
            sum += (long)count2 * count2 * count2;
        }


        Console.WriteLine(sum);
    }
}