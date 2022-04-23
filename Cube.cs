using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube
{
    class Cube
    {
        string[,] frontFace = new string[3, 3];
        string[,] rightFace = new string[3, 3];
        string[,] upFace = new string[3, 3];
        string[,] downFace = new string[3, 3];
        string[,] leftFace = new string[3, 3];
        string[,] backFace = new string[3, 3];

        //{ "F", "R'", "U", "B'", "L", "D'" };

    public Cube()
        {



        }

        public void Rotate(string [] rotations)
        {
            // Six possible face rotations in two direction
            // Direction bool: true for clockwise, false for anti-clockwise

            foreach (string item in rotations)
            {
                switch (item)
                {
                    case "F":
                        FrontRotation(rightFace, upFace, leftFace, downFace, true);
                        TransformFace(frontFace, true);
                        break;
                    case "F'":
                        FrontRotation(rightFace, upFace, leftFace, downFace, false);
                        TransformFace(frontFace, false);
                        break;
                    case "R":
                        RightRotation(upFace, backFace, downFace, frontFace, true);
                        TransformFace(rightFace, true);
                        break;
                    case "R'":
                        RightRotation(upFace, backFace, downFace, frontFace, false);
                        TransformFace(rightFace, false);
                        break;
                }
            }
        }

        public void RightRotation(string[,] upFace, string[,] backFace, string[,] downFace, string[,] frontFace, bool clockwise)
        {
            string[] backBuffer = new string[3] { backFace[2, 0], backFace[1, 0], backFace[0, 0] };
            string[] upBuffer = new string[3] { upFace[2, 2], upFace[1, 2], upFace[0, 2] };
            if (clockwise)
            {

                for (var i = 0; i <= 2; i++)
                {
                    upFace[i, 2] = frontFace[i, 2];
                    frontFace[i, 2] = downFace[i, 2];
                }
                for (var i = 2; i >= 0; i--)
                {
                    downFace[i, 2] = backBuffer[i];
                    backFace[i, 0] = upBuffer[i];
                }
            }
            else
            {
                string[] downBuffer = new string[3] { downFace[2, 2], downFace[1, 2], downFace[0, 2] };

                for (var i = 0; i <= 2; i++)
                {
                    backFace[i, 0] = downBuffer[i];
                    downFace[i, 2] = frontFace[i, 2];
                }
                for(var i = 2; i >= 0; i--)
                {
                    frontFace[i, 2] = upBuffer[i];
                    upFace[i, 2] = backBuffer[i];
                }
            }
        }

        static void FrontRotation(string[,] rightFace, string[,] upFace, string[,] leftFace, string[,] downFace, bool clockwise)
        {
            if (clockwise)
            {
                string[] rightBuffer = new string[3] { rightFace[2, 0], rightFace[1, 0], rightFace[0, 0] };
                string[] leftBuffer = new string[3] { leftFace[2, 0], leftFace[1, 0], leftFace[0, 0] };

                for (var i = 0; i <= 2; i++)
                {
                    rightFace[i, 0] = upFace[2, i];
                    leftFace[i, 2] = downFace[0, i]; 
                }
                for (var i = 2; i >= 0; i--)
                {
                    upFace[2, i] = leftBuffer[i]; 
                    downFace[0, i] = rightBuffer[i]; 
                }
            }
            else
            {
                string[] bufferRow = new string[3] { upFace[2, 0], upFace[2, 1], upFace[2, 2] };
                for (var i = 2; i >= 0; i--)
                {
                    upFace[2, i] = rightFace[i, 0];
                    rightFace[i, 0] = downFace[0, i];
                    downFace[0, i] = leftFace[i, 2];
                    leftFace[i, 2] = bufferRow[i];

                }
            }
        }

        // Re-do transform by using splitting face into rows?
        private void TransformFace(string[,] face, bool clockwise)
        {
            string[,] copyArray = new string[3,3];

            for (var i = 0; i <= 2; i++)
            {
                for (var j = 0; j <= 2; j++)
                {
                    copyArray[i, j] = face[i,j];
                }
            }

            if(clockwise)
            {
                face[0, 2] = copyArray[0, 0];
                face[1, 2] = copyArray[0, 1];
                face[2, 2] = copyArray[0, 2];

                
                face[2, 1] = copyArray[1, 2];
                face[2, 0] = copyArray[2, 2];

                face[1, 0] = copyArray[2, 1];
                face[0, 0] = copyArray[2, 0];

                face[0, 1] = copyArray[1, 0];
            }
            else
            {
                face[0, 1] = copyArray[1, 2];

                face[1, 0] = copyArray[0, 1];
                face[0, 0] = copyArray[0, 2];

                face[2, 1] = copyArray[1, 0];
                face[2, 0] = copyArray[0, 0];

                face[0, 2] = copyArray[2, 2];
                face[1, 2] = copyArray[2, 1];
                face[2, 2] = copyArray[2, 0];
            }
        }

        public void SeedCube()
        {
            SeedCubeFace(frontFace, "green");
            SeedCubeFace(rightFace, "red");
            SeedCubeFace(upFace, "white");
            SeedCubeFace(downFace, "yellow");
            SeedCubeFace(leftFace, "orange");
            SeedCubeFace(backFace, "blue");
        }

        public void PrintCube()
        {
            PrintCubeFace(frontFace);
            PrintCubeFace(rightFace);
            PrintCubeFace(upFace);
            PrintCubeFace(downFace);
            PrintCubeFace(leftFace);
            PrintCubeFace(backFace);
        }

        private void SeedCubeFace(string[,] face, string color)
        {
            for (var i = 0; i <= 2; i++)
            {
                for (var j = 0; j <= 2; j++)
                {
                    face[i, j] = color;
                }
            }
        }

        private void PrintCubeFace(string[,] face)
        {
            int count = 0;
            string row = "";

            foreach (var item in face)
            {
                row += item + "\t";
                count++;

                if (count % 3 == 0)
                {
                    Console.WriteLine(row + Environment.NewLine);
                    row = "";
                }
            }

            Console.WriteLine("--------------------");
        }
    }
}
