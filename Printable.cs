using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube
{
    public class Printable
    {
        public void PrintCubeFace(string[,] face, string name = "")
        {
            int count = 0;
            string row = "";

            string tab = (name.Equals("upFace") || name.Equals("downFace") ? "\t\t\t".PadRight(4) : "");

            if (name.Equals("downFace"))
                Console.WriteLine(tab + "-----------------------");


            foreach (var item in face)
            {
                row += item + "\t";
                count++;

                if (count % 3 == 0)
                {
                    Console.WriteLine(tab + row + Environment.NewLine);
                    row = "";
                }
            }
            if (name.Equals("upFace"))
                Console.WriteLine(tab + "-----------------------");
        }

        public void PrintFourFaces(string[,] leftFace, string[,] frontFace, string[,] rightFace, string[,] backFace)
        {
            int count = 0;
            string row = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    row += leftFace[i, j] + "\t";
                    count++;
                    if (count % 3 == 0)
                    {
                        row += "|";
                        count = 0;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    row += frontFace[i, j] + "\t";
                    count++;
                    if (count % 3 == 0)
                    {
                        row += "|";
                        count = 0;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    row += rightFace[i, j] + "\t";
                    count++;
                    if (count % 3 == 0)
                    {
                        row += "|";
                        count = 0;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    row += backFace[i, j] + "\t";

                    count++;
                    if (count % 3 == 0)
                        row += Environment.NewLine;
                }

                if (i < 2)
                    Console.WriteLine(row + Environment.NewLine);
                else
                    Console.WriteLine(row);

                row = "";
            }
        }
    }
}
