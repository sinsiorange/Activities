using System;
using System.Linq;
public class Hello
{

    public static int[] dx = { 1, 0 };
    public static int[] dy = { 0, 1 };
    public static int max = 0;
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] board = new int[2, N];

        for (int i = 0; i < 2; i++)
        {
            int[] line = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int j = 0; j < N; j++)
            {
                board[i, j] = line[j];
            }

        }

        dfs(board, 0, 0, ref N, board[0, 0]);
        Console.WriteLine(max);
    }

    public static void dfs(int[,] board, int x, int y, ref int N, int sum)
    {

        if (y == 1 && x == N - 1)
        {
            max = Math.Max(sum, max);
            return;
        }

        for (int j = 0; j < 2; j++)
        {
            int next_y = y + dy[j];
            int next_x = x + dx[j];
            if (next_y >= 2 || next_x >= N)
            {
                continue;
            }
            else
            {
                //sum‚ÉŸ‚ÌˆÚ“®æ‚Ì’l‚ğ‰Á‚¦‚é
                sum += board[next_y, next_x];
                dfs(board, next_x, next_y, ref N, sum);

                //–Ø‚ğ–ß‚é‚Æ‚«‚Ésum‚à–ß‚·‚Ì‚ğ–Y‚ê‚È‚¢‚æ‚¤‚É
                sum -= board[next_y, next_x];
            }

        }

        return;
    }
}
