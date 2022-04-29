# RubiksCube

Code to represent rotations to the faces of a Rubiks cube, as visualised on www.rubiks-cube-solver.com.

To Run:
1) Clone repository into Visual Studio and build and run for an output to the console
2) You can change the rotation moves in the Program.cs, Main method by editing the *rotationMoves* array

Notes to reviewing devs:

Spent a few more hours to get solution solved, and then another couple refactoring it (couldn't help myself!). 

The file named Cube.cs is my original 'brute force' solution for my 2D array approach, having a function for each L, R, F, B rotation with both directions using a bool for anti-clockwise/clockwise.

The file named CubeRefactored.cs mainly removes the need for each L, R, F, B face to have its own rotating function with both directions and instead uses the relation opposite faces have with each other to use one function to rotate two faces, e.g. the (L)eft face anti-clockwise (ACW) turn is the same direction as the (R)ight face clockwise (CW) turn.

I also abstracted out some print functions to a utility class name Printable.

In Programe.cs, change the variable "cube" type back to Cube for original solution.

If I were to refactor one more step it would be the switch statement, i.e. the case of (L) and (R') rotations could be in the same catch and pass in the rotation name to the function instead of using a bool to indicate which face.

Further, for testing purposes I would create some hard coded solution arrays that have the correct configuration, and then compare the program solution and notify the user if correct or not; somewhat like a unit test for certain rotations.
