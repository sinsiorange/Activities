using System;
using System.Linq;
public class Hello
{
    public static int n;
    public static int[] A;
    public static int[,] dp; //trueならば1,falseならば-1
    public static void Main()
    {
        //入力受け取り
        n = int.Parse(Console.ReadLine());
        A = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int q = int.Parse(Console.ReadLine());
        int[] m = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        
        //メモ用の二重配列
        dp = new int[21, 4000];

        for(int j = 0; j < q; j++)
        {
            if(solve(0,m[j]) == 1) Console.WriteLine("yes");
            else if(solve(0,m[j]) == -1) Console.WriteLine("no");
        }
    }
    
    public static int solve(int i, int m)
    {
        //まずメモリを参照
        if(dp[i, m + 2000] != 0)
        {
            return dp[i, m + 2000];
        }
        //再帰の終了条件
        else if(m == 0) dp[i, m + 2000] = 1;
        else if(i >= n) dp[i, m + 2000] = -1;

        //部分問題に分割
        else if(solve(i + 1, m) == 1) dp[i, m + 2000] = 1;
        else if(solve(i + 1, m - A[i]) == 1) dp[i, m + 2000] = 1;
        else dp[i, m + 2000] = -1;
        
        return dp[i, m + 2000];
    }


}