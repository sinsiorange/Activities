using System;
using System.Linq;
public class Hello
{
    public static int D;
    public static int G;
    public static int[] S;
    public static int score = 0;
    public static int count = 0;
    public static void Main()
    {
        //入力受け取り
        int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        D = a[0];
        G = a[1];
        int[] p = new int[10];
        int[] c = new int[10];
        S = new int[D];
        int ans = 1000;

        for(int i = 0; i < D; i++)
        {
            int[] b = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            p[i] = b[0];
            c[i] = b[1];
        }

        //ビット全探索
        for(int mask = 0; mask < (1 << D); mask++)
        {
            int S = 0;
            int num = 0;
            int need = 0;
            int rest_max = -1;

            for(int i = 0; i < D; i++)
            {
                if((mask >> i & 1) == 1)
                {
                    S += 100 * (i + 1) * p[i] + c[i];
                    num += p[i];
                }
                else
                {
                    rest_max = i;
                }
            }

            if(S < G)//目標点に届かない場合
            {
                int S1 = 100 * (rest_max + 1);
                need = (G - S + S1 - 1) / S1; //中途半端に解かなければならない問題数
                if(need >= p[rest_max])
                {
                    continue;

                }
                else
                {
                    num += need;
                }
            }

            //最小値の更新
            ans = Math.Min(ans, num);
        }

        Console.WriteLine(ans);
    }

}
