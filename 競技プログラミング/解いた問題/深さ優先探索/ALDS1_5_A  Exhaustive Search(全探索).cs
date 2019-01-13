using System;
using System.Linq;
public class Hello
{
    public static int n;
    public static int[] A;
    public static void Main()
    {
        n = int.Parse(Console.ReadLine());
        A = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int q = int.Parse(Console.ReadLine());
        int[] m = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        for(int j = 0; j < q; j++)
        {
            if(solve(0,m[j]) == 1) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }
    }
    
    public static int solve(int i, int m)
    {
        //再帰の終了条件
        if(m == 0) return 1;
        if(i >= n) return 0;

        //部分問題に分割
        int res = solve(i + 1, m) + solve(i + 1, m - A[i]); //どちらかが1であればよい
        if(res >= 1) return 1;
        else return 0;
    }


}
