// *******************************************************************************
//
// Program.cs
//
// This example demonstrates how to use MATLAB .NET Assembly to build a simple 
// component returning a magic square and how to convert MWNumericArray types
// to native .NET types.
//
// Copyright 2001-2019 The MathWorks, Inc.
//
// *******************************************************************************

using System;

using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

using MyMagicModel;

namespace MyDotNetCoreApp
{
    /// <summary>
	/// The MagicSquareApp class computes a magic square of the user specified size.  
	/// </summary>
	/// <remarks>
	/// args[0] - a positive integer representing the size of the magic square.
	/// </remarks>
	class Program
	  {
      #region MAIN

		  /// <summary>
		  /// The main entry point for the application.
		  /// </summary>
		  [STAThread]
		  static void Main(string[] args)
		    {
          MWNumericArray arraySize= null; 
          MWNumericArray magicSquare= null;

          try
            {
              // Get user specified command line arguments or set default
              arraySize= (0 != args.Length) ? Double.Parse(args[0]) : 4;

              // Create the magic square object
              MyMagic magic= new MyMagic();

              // Compute the magic square and print the result
              magicSquare= (MWNumericArray)magic.mymagic(arraySize);

              Console.WriteLine("Magic square of order {0}\n\n{1}", arraySize, magicSquare);

              // Convert the magic square array to a two dimensional native double array
              double[,] nativeArray= (double[,])magicSquare.ToArray(MWArrayComponent.Real);

              Console.WriteLine("\nMagic square as native array:\n");

              // Display the array elements:
              for (int i= 0; i < (int)arraySize; i++) 
                for (int j= 0; j < (int)arraySize; j++)
                  Console.WriteLine("Element({0},{1})= {2}", i, j, nativeArray[i,j]);

              Console.ReadLine();  // Wait for user to exit application
            }

          catch(Exception exception)
            {
              Console.WriteLine("Error: {0}", exception);
            }
        }

      #endregion
	  }
}
