using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube
{
    class CubeRefactored : Printable
    {
        string[,] frontFace = new string[3, 3]; //green
        string[,] rightFace = new string[3, 3]; //red
        string[,] upFace = new string[3, 3]; //white
        string[,] downFace = new string[3, 3]; //yellow
        string[,] leftFace = new string[3, 3]; //orange
        string[,] backFace = new string[3, 3]; //blue

        //{ "F", "R'", "U", "B'", "L", "D'" };

    public CubeRefactored()
        {
        }

        public void Rotate(string [] rotations)
        {
            // Six possible face rotations in two direction
            // Face bool for rotation functions: true for back, right and up sides to determin which side is being rotated
            // Direction bool for transform runction: true for clockwise, false for anti-clockwise

            foreach (string item in rotations)
            {
                switch (item)
                {
                    case "F":
                        BackACW_FrontCW_Rotation(rightFace, upFace, leftFace, downFace, false);
                        TransformFace(frontFace, true);
                        break;
                    case "F'":
                        BackCW_FrontACW_Rotation(rightFace, upFace, leftFace, downFace, false);
                        TransformFace(frontFace, false);
                        break;
                    case "B":
                        BackCW_FrontACW_Rotation(rightFace, upFace, leftFace, downFace, true);
                        TransformFace(backFace, true);
                        break;
                    case "B'":
                        BackACW_FrontCW_Rotation(rightFace, upFace, leftFace, downFace, true);
                        TransformFace(backFace, false);
                        break;
                    case "R":
                        RightCW_LeftACW_Rotation(upFace, backFace, downFace, frontFace, true);
                        TransformFace(rightFace, true);
                        break;
                    case "R'":
                        RightACW_LeftCW_Rotation(upFace, backFace, downFace, frontFace, true);
                        TransformFace(rightFace, false);
                        break;
                    case "L":
                        RightACW_LeftCW_Rotation(upFace, backFace, downFace, frontFace, false);
                        TransformFace(leftFace, true);
                        break;
                    case "L'":
                        RightCW_LeftACW_Rotation(upFace, backFace, downFace, frontFace, false);
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

        static void RightCW_LeftACW_Rotation(string[,] upFace, string[,] backFace, string[,] downFace, string[,] frontFace, bool rightRotation)
        {
            int ref0 = rightRotation ? 0 : 2;
            int ref2 = rightRotation ? 2 : 0;
            string[] upBuffer = new string[3] { upFace[0, ref2], upFace[1, ref2], upFace[2, ref2] };

            //front -> up
            //down -> front
            for (var i = 0; i < 3; i++)
            {
                upFace[i, ref2] = frontFace[i, ref2];
                frontFace[i, ref2] = downFace[i, ref2];
            }

            //back -> down
            int c = 2;
            for (var i = 0; i < 3; i++)
            {
                downFace[i, ref2] = backFace[c, ref0];
                c--;
            }

            //up -> back
            int d = 2;
            for (var i = 0; i < 3; i++)
            {
                backFace[i, ref0] = upBuffer[d];
                d--;
            }
        }

        static void RightACW_LeftCW_Rotation(string[,] upFace, string[,] backFace, string[,] downFace, string[,] frontFace, bool rightRotation)
        {
            int ref0 = rightRotation ? 0 : 2;
            int ref2 = rightRotation ? 2 : 0;
            string[] upBuffer = new string[3] { upFace[0, ref2], upFace[1, ref2], upFace[2, ref2] };

            //back -> up
            int c = 2;
            for (var i = 0; i < 3; i++)
            {
                upFace[i, ref2] = backFace[c, ref0];
                c--;
            }

            // down->back
            int d = 2;
            for (var i = 0; i < 3; i++)
            {
                backFace[i, ref0] = downFace[d, ref2];
                d--;
            }

            //front -> down
            //up -> front
            for (var i = 0; i < 3; i++)
            {
                downFace[i, ref2] = frontFace[i, ref2];
                frontFace[i, ref2] = upBuffer[i];
            }
        }

        static void BackACW_FrontCW_Rotation(string[,] rightFace, string[,] upFace, string[,] leftFace, string[,] downFace, bool backRotation)
        {
            int ref0 = backRotation ? 0 : 2;
            int ref2 = backRotation ? 2 : 0;
            string[] upBuffer = new string[3] { upFace[ref0, 2], upFace[ref0, 1], upFace[ref0, 0] };

            //left  -> up
            int c = 2;
            for (var i = 0; i < 3; i++)
            {
                upFace[ref0, i] = leftFace[c, ref0];
                c--;
            }
            //down -> left
            for (var i = 0; i < 3; i++)
            {
                leftFace[i, ref0] = downFace[ref2, i];
            }
            //right -> down
            int d = 2;
            for (var i = 0; i < 3; i++)
            {
                downFace[ref2, i] = rightFace[d, ref2];
                d--;
            }
            //up -> right
            int e = 2;
            for (var i = 0; i < 3; i++)
            {
                rightFace[i, ref2] = upBuffer[e];
                e--;
            }
        }

        static void BackCW_FrontACW_Rotation(string[,] rightFace, string[,] upFace, string[,] leftFace, string[,] downFace, bool backRotation)
        {
            int ref0 = backRotation ? 0 : 2;
            int ref2 = backRotation ? 2 : 0;
            string[] upBuffer = new string[3] { upFace[ref0, 2], upFace[ref0, 1], upFace[ref0, 0] };

            //right -> up
            for (var i = 0; i < 3; i++)
            {
                upFace[ref0, i] = rightFace[i, ref2];
            }

            //down -> right
            int c = 2;
            for (var i = 0; i < 3; i++)
            {
                rightFace[i, ref2] = downFace[ref2, c];
                c--;
            }
            //left -> down
            for (var i = 0; i < 3; i++)
            {
                downFace[ref2, i] = leftFace[i, ref0];
            }
            //up -> left
            for (var i = 0; i < 3; i++)
            {
                leftFace[i, ref0] = upBuffer[i];
            }
        }

        static void UpCW_DownACW_Rotation(string[,] frontFace, string[,] backFace, string[,] leftFace, string[,] rightFace, bool upRotation)
        {
            int row = upRotation ? 0 : 2; //if upFace is rotating then row is 0, else 2 for downFace
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


        static void UpACW_DownCW_Rotation(string[,] frontFace, string[,] backFace, string[,] leftFace, string[,] rightFace, bool upRotation)
        {
            int row = upRotation ? 0 : 2; //if upFace is rotating then row is 0, else 2 for downFace
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

        private void TransformFace(string[,] face, bool clockwise)
        {
            string[,] copyArray = (string[,])face.Clone();

            if (clockwise)
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
            PrintFourFaces(leftFace, frontFace, rightFace, backFace);
            PrintCubeFace(downFace, nameof(downFace));
        }
    }
}
