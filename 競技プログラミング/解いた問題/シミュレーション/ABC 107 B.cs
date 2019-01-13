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
        int[] goodX = new int[101]; //�s
        int[] goodY = new int[101]; //��
        char[,] matrix = new char[H, W];

        for (int h = 0; h < H; h++)
        {
            string line = Console.ReadLine();

            for (int w = 0; w < W; w++)
            {
                matrix[h, w] = line[w];
            }
        }

        //���ׂẴ}�X���݂�#������s�Ɨ���L��
        for (int h = 0; h < H; h++)
        {
            for (int w = 0; w < W; w++)
            {
                if (matrix[h, w] == '#')//������������
                {
                    //�s�Ɨ���L��
                    goodX[h] = 1;
                    goodY[w] = 1;
                }
            }

        }

        for (int h = 0; h < H; h++) //�s�Ɨ�ɍ�������}�X�����o��
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