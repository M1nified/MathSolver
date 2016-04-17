using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    class LinearSolver
    {
				#region Definitions
				private float[,] matrixOfA;
				private float[] matrixOfB;

				public float[,] LU_L
				{
						get;
						private set;
				}
				public float[,] LU_U
				{
						get;
						private set;
				}
				private int[] PI;

				public float[] x
				{
						get;
						private set;
				}
				public float[] y
				{
						get;
						private set;
				}

				public float[] solution
				{
						get;
						private set;
				} = null;

				public int numberOfXs
				{
						get;
						private set;
				} = 0;
				public List<Equation> equations
				{
						get;
						private set;
				} = new List<Equation>();
				public LinearSolver()
				{

				}
				#endregion

				#region Constructors
				public LinearSolver(params Equation[] prms)
				{
						foreach(Equation eq in prms)
						{
								AddEquation(eq);
						}
						UpdateMatrix();
				}
				#endregion

				#region Management
				public void AddEquation(Equation eq)
				{
						numberOfXs = eq.parameters.Count > numberOfXs ? eq.parameters.Count : numberOfXs;
						equations.Add(eq);
				}
				public void UpdateMatrix()
				{
						matrixOfA = new float[equations.Count,numberOfXs];
						matrixOfB = new float[equations.Count];
						for(int i = 0; i<equations.Count; i++)
						{
								Equation elem = equations.ElementAt(i);
								matrixOfB[i] = elem.B;
								for (int j = 0; j<elem.parameters.Count; j++)
								{
										matrixOfA[i, j] = elem.parameters.ElementAt(j);
								}
						}
				}
				#endregion

				#region Solving
				public float[] Resolve()
				{
						return null;
				}
				public override string ToString()
				{
						string ret = "";
						foreach(Equation eq in equations)
						{
								ret += eq.ToString() + "\n";
						}
						return ret;
				}
				public void LUP_Decomposition_1()
				{

						PI = new int[equations.Count];
						for (int i = 0; i < PI.Length; i++)
								PI[i] = i;
						//inicjowanie macierzy U i L
						LU_L = new float[equations.Count, numberOfXs];
						LU_U = new float[equations.Count, numberOfXs];
						for(int i = 0;i<equations.Count;i++)
								for(int j = 0; j < equations.Count; j++)
								{
										if (i < j)//jestem ponizej przekatnej
										{
												LU_U[i, j] = 0;
										}
										else
										{
												LU_L[i, j] = (i == j) ? 1 : 0;
										}
								}

						for(int k = 0; k < equations.Count; k++)
						{
								LU_U[k, k] = matrixOfA[k, k];
								for(int i = k+1; i < equations.Count; i++)
								{
										LU_L[i, k] = matrixOfA[i, k] / matrixOfA[k, k];
										LU_U[k, i] = matrixOfA[k, i];
								}
								for(int i=k+1; i<equations.Count; i++)
								{
										for(int j = k + 1; j<equations.Count; j++)
										{
												matrixOfA[i, j] = matrixOfA[i, j] - LU_L[i, k] * LU_U[k, j];
										}
								}
						}
				}
				public void LUP_Decomposition()
				{
						//Inicjowanie macierzy U i L
						LU_L = new float[equations.Count, numberOfXs];
						LU_U = new float[equations.Count, numberOfXs];
						for (int i = 0; i < equations.Count; i++)
								for (int j = 0; j < equations.Count; j++)
								{
										if (i < j)//jestem ponizej przekatnej
										{
												LU_U[i, j] = 0;
										}
										else
										{
												LU_L[i, j] = (i == j) ? 1 : 0;
										}
								}
						PI = new int[equations.Count];
						for(int i = 0; i<PI.Length; i++)
								PI[i] = i;
						int kprim = 0;

						//Obliczanie
						for (int k = 0; k < equations.Count; k++)
						{
								float p = 0;
								for(int i = k; i<equations.Count; i++)
								{
										if (Math.Abs(matrixOfA[i, k]) > p)
										{
												p = Math.Abs(matrixOfA[i, k]);
												kprim = i;
										}
								}
								if (p.Equals(0))
								{
										Console.WriteLine("Maciez osobliwa");
								}

								{
										int tmp = PI[k];
										PI[k] = PI[kprim];
										PI[kprim] = tmp;
								}

								for(int i = 0; i < equations.Count; i++)
								{
										float tmp = matrixOfA[k, i];
										matrixOfA[k, i] = matrixOfA[kprim, i];
										matrixOfA[kprim, i] = tmp;
								}
								for(int i = k + 1; i < equations.Count; i++)
								{
										matrixOfA[i, k] = matrixOfA[i, k] / matrixOfA[k, k];
										for(int j = k+1; j<equations.Count; j++)
										{
												matrixOfA[i, j] -= matrixOfA[i, k] * matrixOfA[k, j];
										}
								}
						}
				}
				public void LUP_Solve()
				{
						UpdateMatrix();
						Console.WriteLine("Po aktualizacji macierzy:-----------------");
						Program.printMatrix(matrixOfA);
						Program.printMatrix(matrixOfB);

						LUP_Decomposition_1();

						Console.WriteLine("Po rozkladzie:-----------------");
						Program.printMatrix(LU_L);
						Program.printMatrix(LU_U);

						//Inicjowanie macierzy wynikowych
						x = new float[equations.Count];
						y = new float[equations.Count];
						for(int i = 0; i < equations.Count; i++)
						{
								x[i] = 0;
								y[i] = 0;
						}

						for(int i = 0; i < equations.Count; i++)
						{
								y[i] = matrixOfB[PI[i]];
								for(int j = 0; j < i; j++)
								{
										y[i] -= LU_L[i, j] * y[j];
								}
						}
						for(int i = equations.Count-1;i>=0; i--)
						{
								float sum = 0;
								for(int j = i + 1; j< equations.Count; j++)
								{
										sum += LU_U[i, j] * x[j];
								}
								x[i] = !LU_U[i, i].Equals(0) ? (y[i] - sum) / LU_U[i, i] : 0;
								Console.WriteLine(x[i]);
						}
				}
				#endregion
		}
}
