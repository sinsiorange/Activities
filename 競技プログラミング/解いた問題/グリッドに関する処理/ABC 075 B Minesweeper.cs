using System;
using System.Linq;
using System.Collections.Generic;
public class Hello
{
    public static void Main()
    {
        // Your code here!
        int[] array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int H = array[0];
        int W = array[1];
        //C#はstringの文字は書き換えられず，char型配列の要素は書き換えられるのでchar型の二重配列にしたほうがよい．
        char[,] board = new char[50, 50];

        //最初にあらかじめ各方向への移動を表す配列を用意しておくと便利
        int[] dx = { 1, -1, 0, 0, 1, 1, -1, -1 };
        int[] dy = { 0, 0, 1, -1, 1, -1, -1, 1 };

        for (int i = 0; i < H; i++) //読み込み
        {
            string line = Console.ReadLine();
            for (int j = 0; j < W; j++)
            {
                board[i, j] = line[j];
            }
        }

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                if (board[i, j] == '#')
                {
                    continue;
                }
                int num = 0;

                for (int k = 0; k < 8; k++)
                {

                    if (i + dy[k] < 0 || H <= i + dy[k]) continue;
                    if (j + dx[k] < 0 || W <= j + dx[k]) continue;

                    if (board[i + dy[k], j + dx[k]] == '#')
                    {
                        num++;
                    }
                }

                //int型をchar型に変換
                board[i, j] = num.ToString()[0];
            }
        }

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.WriteLine();
        }
    }
}
