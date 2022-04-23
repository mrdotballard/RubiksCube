# RubiksCube

Code to represent rotations to the faces of a Rubiks cube, as visualised on www.rubiks-cube-solver.com.

To Run:
1) Clone repository into Visual Studio and build and run for an output to the console
2) You can change the rotation moves in the Program.cs, Main method by editing the *rotationMoves* array

Notes to reviewing devs:

After first hour it was about at the stage of doing a rotation to the front face only, including transforming the rotated face. Additional face rotations and testing were done using additional time. A super fun challenge and would be great to finish with more time!

Going forward, after coding remaining 4 rotations I would probably look at where the refactoring could be done to reduce duplicate code, i.e. there's likely an algorithm to reduce common 'brute force' instructions for certain rotations. In turn that may mean changing the data structures for the sides/rows/columns, but at first pass the 2D array seemed sufficient.
