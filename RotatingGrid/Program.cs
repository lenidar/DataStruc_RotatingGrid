using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatingGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare
            // multidimensional array
            int[,] face = new int[5, 5];
            int[,] tempArr = new int[5, 5];
            int[] temptemp = new int[5];
            Random rnd = new Random();
            string uInput = "";
            char command = ' ';

            // initialize
            for(int x = 0; x < face.GetLength(0); x++)
                for(int y = 0; y < face.GetLength(1); y++)
                    face[x, y] = rnd.Next(0,5);

            while (true)
            {
                Console.Clear();
                // processing
                switch(command)
                {
                    case 'L':
                        Console.WriteLine("Turning Left");
                        for (int x = 0; x < face.GetLength(0); x++)
                        {
                            for (int y = 0; y < face.GetLength(1); y++)
                            {
                                temptemp[y] = face[x, y];
                            }
                            for (int y = 0; y < face.GetLength(1); y++)
                            {
                                tempArr[y,x] = temptemp[temptemp.Length - 1 - y];
                            }
                        }

                        face = tempArr;
                        break;
                    case 'R':
                        Console.WriteLine("Turning Right");
                        for (int x = 0; x < face.GetLength(0); x++)
                        {
                            for (int y = 0; y < face.GetLength(1); y++)
                            {
                                temptemp[y] = face[x, y];
                            }
                            for (int y = 0; y < face.GetLength(1); y++)
                            {
                                tempArr[y, temptemp.Length - 1 - x] = temptemp[y];
                            }
                        }

                        face = tempArr;
                        break;
                }

                // display
                for (int x = 0; x < face.GetLength(0); x++)
                {
                    for (int y = 0; y < face.GetLength(1); y++)
                    {
                        switch (face[x, y])
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                        }
                        Console.Write(face[x, y]);
                    }
                    Console.WriteLine();
                }

                // get user input
                Console.ResetColor();
                Console.Write("Input L or R: ");
                uInput = Console.ReadLine().ToUpper();
                if (uInput.Length <= 0)
                    uInput = " ";
                command = uInput[0];
            }
        }
    }
}
