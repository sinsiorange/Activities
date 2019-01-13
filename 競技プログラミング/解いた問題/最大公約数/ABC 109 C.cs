using System;
using System.Linq;


public class Hello
{
    public static void Main()
    {
        // Your code here!

        int[] a = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int[] x = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int N = a[0];
        int X = a[1];
        int ans = Math.Abs(X - x[0]);

        for (int i = 1; i < N; i++)
        {
            // gcd(a, b, c) = gcd(gcd(a, b), c)
            ans = gcd(ans, Math.Abs(X - x[i]));
        }
        Console.WriteLine(ans);

    }

    public static int gcd(int a, int b) //���[�N���b�h�̌ݏ��@��a��b�̍ő���񐔂����߂�
    {
        if (a < b) //a < b�̂Ƃ��Ca��b�����ւ���D
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        if (b < 1) //a��b�͎��R���łȂ��Ƃ��߁Db�����R���łȂ��Ȃ��-1��Ԃ��D
        {
            return -1;
        }

        int r = a % b;

        //�I������
        if (r == 0)
        {
            return b;
        }

        return gcd(b, r);
    }
}
