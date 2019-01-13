using System;
using System.Linq;
public class Hello
{
    public static int n;
    public static int[] A;
    public static int[,] dp; //true�Ȃ��1,false�Ȃ��-1
    public static void Main()
    {
        //���͎󂯎��
        n = int.Parse(Console.ReadLine());
        A = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int q = int.Parse(Console.ReadLine());
        int[] m = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        
        //�����p�̓�d�z��
        dp = new int[21, 4000];

        for(int j = 0; j < q; j++)
        {
            if(solve(0,m[j]) == 1) Console.WriteLine("yes");
            else if(solve(0,m[j]) == -1) Console.WriteLine("no");
        }
    }
    
    public static int solve(int i, int m)
    {
        //�܂����������Q��
        if(dp[i, m + 2000] != 0)
        {
            return dp[i, m + 2000];
        }
        //�ċA�̏I������
        else if(m == 0) dp[i, m + 2000] = 1;
        else if(i >= n) dp[i, m + 2000] = -1;

        //�������ɕ���
        else if(solve(i + 1, m) == 1) dp[i, m + 2000] = 1;
        else if(solve(i + 1, m - A[i]) == 1) dp[i, m + 2000] = 1;
        else dp[i, m + 2000] = -1;
        
        return dp[i, m + 2000];
    }


}