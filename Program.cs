using System;

namespace RubiksCube
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] rotationMoves = new string[] { "F", "R'", "U", "B'", "L", "D'" };
            string[] rotationMoves = new string[] { "R'", "F", "R", "F'" };
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
