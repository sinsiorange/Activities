using System;
using System.Linq;
public class Hello
{

    public static int[] dx = { 1, 0 };
    public static int[] dy = { 0, 1 };
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] board = new int[2, N];
        int[,] boardMax = new int[2, N]; //�ݐϘa�̍ő�l��ۑ�

        for (int i = 0; i < 2; i++)
        {
            int[] line = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            for (int j = 0; j < N; j++)
            {
                board[i, j] = line[j];
            }

        }

        boardMax[0, 0] = board[0, 0];
        dfs(board, boardMax, 0, 0, ref N);
        Console.WriteLine(boardMax[1, N - 1]);
    }

    public static void dfs(int[,] board, int[,] boardMax, int x, int y, ref int N)
    {
        for (int j = 0; j < 2; j++)
        {
            int next_y = y + dy[j];
            int next_x = x + dx[j];
            if (next_y >= 2 || next_x >= N)
            {
                continue;
            }
            //���̈ړ����boardMax�Ɍ��݂���}�X�̐���������
            int nextSum = boardMax[y, x] + board[next_y, next_x];
            if (nextSum > boardMax[next_y, next_x]) //���݂̗ݐϘa��max���傫����΍X�V
            {
                boardMax[next_y, next_x] = nextSum;
            }

            dfs(board, boardMax, next_x, next_y, ref N);
        }
        return;
    }
}
