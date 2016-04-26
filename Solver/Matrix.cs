using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
			public class Matrix
			{
						public static void PrintMatrix(float[,] matrix)
						{
									for (int i = 0; i < matrix.GetLength(0); i++)
									{
												for (int j = 0; j < matrix.GetLength(1); j++)
												{
															Console.Write(matrix[i, j] + "\t");
												}
												Console.WriteLine();
									}
									Console.WriteLine();
						}
						public static void PrintMatrix(float[] matrix)
						{
									for (int i = 0; i < matrix.GetLength(0); i++)
									{
												Console.Write(matrix[i] + "\t");
									}
									Console.WriteLine();
									Console.WriteLine();
						}
						public static float[,] InverseMatrix(float[,] matrix)
						{
									if (matrix.GetLength(0) != matrix.GetLength(1))
									{
												throw new Exception("Inversed cannot be evaluated, no NxN matrix given.");
									}
									int size = matrix.GetLength(0);
									float det = DetMatrix(matrix);
									float[,] res = new float[size, size];
									for (int i = 0; i < size; i++)
									{
												for (int j = 0; j < size; j++)
												{
															float[,] sub = SubMatrixAt(matrix, i, j);
															res[i, j] = DetMatrix(sub);
															if ((i + j) % 2 != 0)
															{
																		res[i, j] *= -1;
															}
												}
									}
									res = MultiplyMatrix(res, 1 / det);
									return res;
						}
						public static float[,] SubMatrixAt(float[,] matrix, int x, int y)
						{
									if (matrix.GetLength(0) != matrix.GetLength(1))
									{
												throw new Exception("SubMatrix cannot be evaluated, no NxN matrix given.");
									}
									int size = matrix.GetLength(0);
									if (size == 1)
									{
												return matrix;
									}
									float[,] res = new float[size - 1, size - 1];
									int nx = 0, ny = 0;
									for (int i = 0; i < size; i++)
									{
												if (i == x) continue;
												for (int j = 0; j < size; j++)
												{
															if (j == y) continue;
															res[nx, ny] = matrix[i, j];
															ny++;
												}
												nx++;
									}
									return res;
						}
						public static float DetMatrix(float[,] matrix)
						{
									if (matrix.GetLength(0) != matrix.GetLength(1))
									{
												throw new Exception("Determinant cannot be evaluated, no NxN matrix given.");
									}
									int size = matrix.GetLength(0);
									if (size == 1)
									{
												return matrix[0, 0];
									}
									else if (size == 2)
									{
												return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
									}
									else
									{
												float det = 0;
												throw new NotImplementedException();
									}
						}
						public static float[,] MultiplyMatrix(float[,] matrix, float by)
						{
									float[,] res = new float[matrix.GetLength(0), matrix.GetLength(1)];
									for (int i = 0; i < matrix.GetLength(0); i++)
									{
												for (int j = 0; j < matrix.GetLength(1); j++)
												{
															res[i, j] = matrix[i, j] * by;
												}
									}
									return res;
						}
			}
}
