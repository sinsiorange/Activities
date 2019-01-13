using System;
using System.Linq;

public class Hello
{
    public static void Main()
    {
        // Your code here!

        int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int H = a[0];
        int W = a[1];
        int[] goodX = new int[101]; //行
        int[] goodY = new int[101]; //列
        char[,] matrix = new char[H, W];

        for (int h = 0; h < H; h++)
        {
            string line = Console.ReadLine();

            for (int w = 0; w < W; w++)
            {
                matrix[h, w] = line[w];
            }
        }

        //すべてのマスをみて#がある行と列を記憶
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (matrix[h, w] == '#')//黒があったら
                {
                    //行と列を記憶
                    goodX[h] = 1;
                    goodY[w] = 1;
                }
            }

        }

        for (int h = 0; h < H; h++) //行と列に黒があるマスだけ出力
        {
            if (goodX[h] == 1)
            {
                for (int w = 0; w < W; w++)
                {
                    if (goodY[w] == 1)
                    {
                        Console.Write(matrix[h, w]);
                    }
                }
                Console.WriteLine();
            }

        }


    }
}