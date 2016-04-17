using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solver
{
		static class Program
		{
				/// <summary>
				/// The main entry point for the application.
				/// </summary>
				[STAThread]
				static void Main()
				{
						//Application.EnableVisualStyles();
						//Application.SetCompatibleTextRenderingDefault(false);
						//Application.Run(new Form1());

						//Equation eq1 = new Equation(1, 2, 3, 4, 5, 6, 7);
						//Equation eq2 = new Equation(1, 2, 3, 4, 5, 6, 7);
						//Equation eq3 = new Equation(1, 2, 3, 4, 5, 6, 7);
						//Equation eq4 = new Equation(1, 2, 3, 4, 5, 6, 7);
						//Equation eq5 = new Equation(1, 2, 3, 4, 5, 6, 7);
						//Equation eq6 = new Equation(1, 2, 3, 4, 5, 6, 7);

						Equation eq1 = new Equation(-2, 3, 1, 1);
						Equation eq2 = new Equation(8, 2, 2, 3);
						Equation eq3 = new Equation(6, 1, 3, 2);

						Console.WriteLine(eq1.ToString());

						//LinearSolver solver = new LinearSolver(eq1,eq2,eq3,eq4,eq5,eq6);
						LinearSolver solver = new LinearSolver(eq1,eq2,eq3);

						Console.WriteLine(solver.ToString());

						solver.LUP_Solve();


						Console.Write("X:\t");
						foreach (float item in solver.x)
								Console.Write(item.ToString() + "\t");
						Console.WriteLine();
						foreach (float item in solver.y)
								Console.Write(item.ToString() + "\t");
						Console.WriteLine();

						Console.WriteLine();

						printMatrix(solver.LU_L);
						printMatrix(solver.LU_U);

				}
				public static void printMatrix(float[,] arr)
				{
						for(int i = 0; i < arr.GetLength(0); i++)
						{
								for(int j = 0; j<arr.GetLength(1); j++)
								{
										Console.Write(arr[i, j].ToString() + "\t");
								}
								Console.Write("\n");
						}
						Console.WriteLine();
				}
				public static void printMatrix(float[] arr)
				{
						for (int i = 0; i < arr.GetLength(0); i++)
						{
										Console.Write(arr[i].ToString() + "\t");
						}
						Console.WriteLine();
						Console.WriteLine();
				}
		}
}
