using System;

namespace RubiksCube
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rotationMoves = new string[] { "F", "R'", "U", "B'", "L", "D'" };
            //string[] rotationMoves = new string[] { "L", "D'" };
            //string[] rotationMoves = new string[] { "F", "R'", "U'", "F", "B", "U'", "B", "U"};

            foreach (string item in rotationMoves)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n");

            Cube cube = new Cube();

            cube.SeedCube();
            cube.Rotate(rotationMoves);
            cube.PrintCube();
        }
    }
}
