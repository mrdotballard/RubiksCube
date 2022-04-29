using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube
{
    class Cube
    {
        string[,] frontFace = new string[3, 3]; //green
        string[,] rightFace = new string[3, 3]; //red
        string[,] upFace = new string[3, 3]; //white
        string[,] downFace = new string[3, 3]; //yellow
        string[,] leftFace = new string[3, 3]; //orange
        string[,] backFace = new string[3, 3]; //blue

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
                    case "B":
                        BackRotation(rightFace, upFace, leftFace, downFace, true);
                        TransformFace(backFace, true);
                        break;
                    case "B'":
                        BackRotation(rightFace, upFace, leftFace, downFace, false);
                        TransformFace(backFace, false);
                        break;
                    case "R":
                        RightRotation(upFace, backFace, downFace, frontFace, true);
                        TransformFace(rightFace, true);
                        break;
                    case "R'":
                        RightRotation(upFace, backFace, downFace, frontFace, false);
                        TransformFace(rightFace, false);
                        break;
                    case "L":
                        LeftRotation(upFace, frontFace, downFace, backFace, true);
                        TransformFace(leftFace, true);
                        break;
                    case "L'":
                        LeftRotation(upFace, frontFace, downFace, backFace, false);
                        TransformFace(leftFace, false);
                        break;
                    case "U":
                        UpCW_DownACW_Rotation(frontFace, backFace, leftFace, rightFace, true);
                        TransformFace(upFace, true);
                        break;
                    case "U'":
                        UpACW_DownCW_Rotation(frontFace, backFace, leftFace, rightFace, true);
                        TransformFace(upFace, false);
                        break;
                    case "D":
                        UpACW_DownCW_Rotation(frontFace, backFace, leftFace, rightFace, false);
                        TransformFace(downFace, true);
                        break;
                    case "D'":
                        UpCW_DownACW_Rotation(frontFace, backFace, leftFace, rightFace, false);
                        TransformFace(downFace, false);
                        break;
                }
            }
        }

        static void LeftRotation(string[,] upFace, string[,] frontFace, string[,] downFace, string[,] backFace, bool clockwise)
        {
            string[] upBuffer = new string[3] { upFace[0, 0], upFace[1, 0], upFace[2, 0] };
            if (clockwise)
            {
                // back -> up
                int c = 2;
                for (var i = 0; i < 3; i++)
                {
                    upFace[i, 0] = backFace[c, 2];
                    c--;
                }

                //down -> back
                int d = 2;
                for (var i = 0; i < 3; i++)
                {
                    backFace[i, 2] = downFace[d, 0];
                    d--;
                }
                //front -> down
                //up->front
                for (var i = 0; i < 3; i++)
                {
                    downFace[i, 0] = frontFace[i, 0];
                    frontFace[i, 0] = upBuffer[i];
                }
            }
            else
            {
                //front -> up
                //down -> front
                for (int i = 0; i < 3; i++)
                {
                    upFace[i, 0] = frontFace[i, 0];
                    frontFace[i, 0] = downFace[i, 0];
                }

                //back -> down
                int c = 2;
                for (int i = 0; i < 3; i++)
                {
                    downFace[i, 0] = backFace[c, 2];
                    c--;
                }

                //up -> back
                int d = 2;
                for (int i = 0; i < 3; i++)
                {
                    backFace[i, 2] = upBuffer[d];
                    d--;
                }
            }
        }

        static void RightRotation(string[,] upFace, string[,] backFace, string[,] downFace, string[,] frontFace, bool clockwise)
        {
            string[] upBuffer = new string[3] { upFace[0, 2], upFace[1, 2], upFace[2, 2] };

            if (clockwise)
            {
                //front -> up
                //down -> front
                for(var i = 0; i < 3; i++)
                {
                    upFace[i, 2] = frontFace[i, 2];
                    frontFace[i, 2] = downFace[i, 2];
                }

                //back -> down
                int c = 2;
                for (var i = 0; i < 3; i++)
                {
                    downFace[i, 2] = backFace[c, 0];
                    c--;
                }

                //up -> back
                int d = 2;
                for (var i = 0; i < 3; i++)
                {
                    backFace[i, 0] = upBuffer[d];
                    d--;
                }
            }
            else
            {
                //back -> up
                int c = 2;
                for(var i = 0; i < 3; i++)
                {
                    upFace[i, 2] = backFace[c, 0];
                    c--;
                }

                // down->back
                int d = 2;
                for (var i = 0; i < 3; i++)
                {
                    backFace[i, 0] = downFace[d, 2];
                    d--;
                }

                //front -> down
                for (var i = 0; i < 3; i++)
                {
                    downFace[i, 2] = frontFace[i, 2];
                }
                //up -> front
                for (var i = 0; i < 3; i++)
                {
                    frontFace[i, 2] = upBuffer[i];
                }
            }
        }

        static void FrontRotation(string[,] rightFace, string[,] upFace, string[,] leftFace, string[,] downFace, bool clockwise)
        {
                string[] upBuffer = new string[3] { upFace[2, 2], upFace[2, 1], upFace[2, 0] };
            if (clockwise)
            {
                //left  -> up
                int c = 2;
                for (var i = 0; i < 3; i++)
                {
                    upFace[2, i] = leftFace[c, 2];
                    c--;
                }
                //down -> left
                for (var i = 0; i < 3; i++)
                {
                    leftFace[i, 2] = downFace[0, i];
                }
                //right -> down
                int d = 2;
                for (var i = 0; i < 3; i++)
                {
                    downFace[0, i] = rightFace[d, 0];
                    d--;
                }
                //up -> right
                int e = 2;
                for (var i = 0; i < 3; i++)
                {
                    rightFace[i, 0] = upBuffer[e];
                    e--;
                }
            }
            else
            {
                //right -> up
                for (var i = 0; i < 3; i++)
                {
                    upFace[2,i] = rightFace[i,0];
                }

                //down -> right
                int c = 2;
                for (var i = 0; i < 3; i++)
                {
                    rightFace[i, 0] = downFace[0, c];
                    c--;
                }
                //left -> down
                for (var i = 0; i < 3; i++)
                {
                    downFace[0, i] = leftFace[i, 2];
                }
                //up -> left
                for (var i = 0; i < 3; i++)
                {
                    leftFace[i, 2] = upBuffer[i];
                }
            }
        }

        static void BackRotation(string[,] rightFace, string[,] upFace, string[,] leftFace, string[,] downFace, bool clockwise)
        {
            string[] upBuffer = new string[3] { upFace[0, 2], upFace[0, 1], upFace[0, 0] };

            if (clockwise)
            {
                //right -> up
                for (var i = 0; i < 3; i++)
                {
                    upFace[0, i] = rightFace[i, 2];
                }

                //down -> right
                int c = 2;
                for (var i = 0; i < 3; i++)
                {
                    rightFace[i, 2] = downFace[2, c];
                    c--;
                }
                //left -> down
                for (var i = 0; i < 3; i++)
                {
                    downFace[2, i] = leftFace[i, 0];
                }
                //up -> left
                for (var i = 0; i < 3; i++)
                {
                    leftFace[i, 0] = upBuffer[i];
                }
            }
            else
            {
                //left  -> up
                int c = 2;
                for (var i = 0; i < 3; i++)
                {
                    upFace[0, i] = leftFace[c, 0];
                    c--;
                }
                //down -> left
                for (var i = 0; i < 3; i++)
                {
                    leftFace[i, 0] = downFace[2, i];
                }
                //right -> down
                int d = 2;
                for (var i = 0; i < 3; i++)
                {
                    downFace[2, i] = rightFace[d, 2];
                    d--;
                }
                //up -> right
                int e = 2;
                for (var i = 0; i < 3; i++)
                {
                    rightFace[i, 2] = upBuffer[e];
                    e--;
                }
            }

        }

        static void UpCW_DownACW_Rotation(string[,] frontFace, string[,] backFace, string[,] leftFace, string[,] rightFace, bool up)
        {
            int row = up ? 0 : 2; //if upFace is rotating then row is 0, else 2 for downFace
            string[] frontBuffer = new string[3] { frontFace[row, 0], frontFace[row, 1], frontFace[row, 2] };
            //int row = 0;

             // UP CLOCKWISE
            // DOWN ANTI-CLOCKWISE
            //right -> front
            //back -> right
            //left -> back
            //front - left
            for (int i = 0; i < 3; i++)
            {
                frontFace[row, i] = rightFace[row, i];
                rightFace[row, i] = backFace[row, i];
                backFace[row, i] = leftFace[row, i];
                leftFace[row, i] = frontBuffer[i];
            }
        }


        static void UpACW_DownCW_Rotation(string[,] frontFace, string[,] backFace, string[,] leftFace, string[,] rightFace, bool up)
        {
            int row = up ? 0 : 2; //if upFace is rotating then row is 0, else 2 for downFace
            string[] frontBuffer = new string[3] { frontFace[row, 0], frontFace[row, 1], frontFace[row, 2] };

            // UP ANTI-CLOCKWISE
            // DOWN CLOCKWISE
            //left -> front
            //back -> left
            //right -> back
            //front -> right
            for (int i = 0; i < 3; i++)
            {
                frontFace[row, i] = leftFace[row, i];
                leftFace[row, i] = backFace[row, i];
                backFace[row, i] = rightFace[row, i];
                rightFace[row, i] = frontBuffer[i];
            }
        }

        // Re-do transform by splitting face into rows?
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

                face[0,1] = copyArray[1, 0];
            }
            else
            {
                face[0, 2] = copyArray[2, 2];
                face[1, 2] = copyArray[2, 1];
                face[2,2] = copyArray[2,0];

                face[2, 1] = copyArray[1, 0];
                face[2, 0] = copyArray[0, 0];

                face[1,0] = copyArray[0, 1];
                face[0, 0] = copyArray[0,2];
                face[0, 1] = copyArray[1, 2];
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

        public void PrintCube()
        {
            PrintCubeFace(upFace, nameof(upFace));
            //PrintCubeFace(leftFace, nameof(leftFace));
            //PrintCubeFace(frontFace, nameof(frontFace));
            //PrintCubeFace(rightFace, nameof(rightFace));
            //PrintCubeFace(backFace, nameof(backFace));
            PrintFourFaces(leftFace, frontFace, rightFace, backFace);
            PrintCubeFace(downFace, nameof(downFace));

        }

        private void PrintCubeFace(string[,] face, string name = "")
        {
            int count = 0;
            string row = "";

            string tab = (name.Equals("upFace") || name.Equals("downFace") ? "\t\t\t".PadRight(4) : "");

            if(name.Equals("downFace"))
                Console.WriteLine(tab + "-----------------------");


            foreach (var item in face)
            {
                row += item + "\t";
                count++;
                 
                if (count % 3 == 0)
                {
                    Console.WriteLine(tab + row +  Environment.NewLine);
                    row = "";
                }
            }
            if(name.Equals("upFace"))
                Console.WriteLine(tab + "-----------------------");
        }

        private void PrintFourFaces(string[,] leftFace, string[,] frontFace, string[,] rightFace, string[,] backFace)
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
