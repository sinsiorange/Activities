using System;
using System.Linq;
using System.Collections.Generic;

public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] a = Console.ReadLine().Split(' ').Select(d => int.Parse(d)).ToArray();
        int[] s = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
        int[] g = Console.ReadLine().Split(' ').Select(f => int.Parse(f)).ToArray();
        int R = a[0];
        int C = a[1];
        int sy = s[0];
        int sx = s[1];
        int gy = g[0];
        int gx = g[1];

        char[,] matrix = new char[R, C];
        int[,] board = new int[R, C]; //最小ステップ数を書き込む
        int[] moveRow = new int[] { 1, 0, -1, 0 }; //行を変える
        int[] moveCol = new int[] { 0, 1, 0, -1 }; //列を変える
        for (int r = 0; r < R; r++)//行
        {
            string line = Console.ReadLine();
            for (int c = 0; c < C; c++)//列
            {
                matrix[r, c] = line[c];

            }
        }

        //boardを初期化
        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                board[r, c] = -1;
            }
        }

        //boardのスタート地点のところを0にする
        board[sy - 1, sx - 1] = 0;

        //キューを宣言
        Queue<int> queueRow = new Queue<int>(); //行のキュー
        Queue<int> queueCol = new Queue<int>(); //列のキュー
        queueRow.Enqueue(sy - 1);
        queueCol.Enqueue(sx - 1);

        while (queueRow.Count > 0)
        {
            int y = queueRow.Dequeue();
            int x = queueCol.Dequeue();

            for (int i = 0; i < moveRow.Length; i++)
            {
                int nextY = y + moveRow[i];
                int nextX = x + moveCol[i];
                if (0 <= nextY && nextY < R
                && 0 <= nextX && nextX < C
                && board[nextY, nextX] == -1
                && matrix[nextY, nextX] == '.')
                {
                    board[nextY, nextX] = board[y, x] + 1; //キューに格納する前にboard[nextY, nextX]を更新してしまう．

                    queueRow.Enqueue(nextY);               //キューにnextX,nextYを格納
                    queueCol.Enqueue(nextX);


                }
            }

        }
        //デバッグ用
        /*
        for(int r = 0; r < R; r++)
        {
            for(int c = 0; c < C; c++)
            {
                Console.Write(board[r, c]);
            }
            Console.WriteLine();
        }
        */

        Console.WriteLine(board[gy - 1, gx - 1]);

    }
}
