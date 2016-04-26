using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solver
{
			public class LinearProblem : IEnumerable
			{
						public float[,] matrixOfA;
						public float[] matrixOfB;
						public Dictionary<string, int> matrixColumns;
						public List<Condition> conditions;
						public List<Condition> standarizedConditions;
						public Target targetFunction;

						public LinearProblem(List<Condition> conds, Target target)
						{
									conditions = conds;
									targetFunction = target;
						}
						public float[] Solve()
						{
									StandarizeConditions();
									StandarizeTarget();
									ConditionParser cp = new ConditionParser();
									ConditionsMatrix cm = cp.ParseConditionsToArrayOfEquations(standarizedConditions);
									matrixOfA = cm.A;
									matrixOfB = cm.B;
									matrixColumns = cm.COLUMNS;
									float best = 0;
									int j = 0;
									float[] param = new float[targetFunction.FUNCTION.MULTIPLY_BY.Length];
									float[] best_param = null;
									foreach (float[] sol in this)
									{
												Matrix.PrintMatrix(sol);
												for (int i = 0; i < targetFunction.FUNCTION.MULTIPLY_BY.Length; i++)
												{
															param[i] = sol[i];
												}
												float score = targetFunction.FUNCTION.Call(param);
												if (j == 0 || (targetFunction.DESIRE == Target.DESIRE_MINIMUM && best.CompareTo(score) > 0) || (targetFunction.DESIRE == Target.DESIRE_MAXIMUM && best.CompareTo(score) < 0))
												{
															best = score;
															best_param = (float[])param.Clone();
												}
												j++;
									}
									return best_param;
						}
						public void StandarizeConditions()
						{
									standarizedConditions = new List<Condition>();
									int i = 0;
									foreach (Condition cond in conditions)
									{
												Condition standarized = (Condition)cond.Clone();
												if ((int)standarized.TYPE < (int)Condition.ConditionType.EQUAL)
												{
															standarized.ARGUMENTS["SPECIAL" + i] = 1;
												}
												else if ((int)standarized.TYPE > (int)Condition.ConditionType.EQUAL)
												{
															standarized.ARGUMENTS["SPECIAL" + i] = -1;
												}
												standarized.TYPE = Condition.ConditionType.EQUAL;
												i++;
												standarizedConditions.Add(standarized);
									}
						}
						public void StandarizeTarget()
						{
									if (targetFunction.DESIRE == Target.DESIRE_MAXIMUM)
									{
												for (int i = 0; i < targetFunction.FUNCTION.MULTIPLY_BY.Length; i++)
												{
															targetFunction.FUNCTION.MULTIPLY_BY[i] *= -1;
												}
												targetFunction.DESIRE = Target.DESIRE_MINIMUM;
									}
						}
						public IEnumerator GetEnumerator()
						{
									int numOfConds = matrixOfA.GetLength(0);
									KeyValuePair<string, int>[] mcols = matrixColumns.ToArray();
									for (int i = 0; i < mcols.Length; i++)
									{
												if (Regex.Match(mcols[i].Key, @"SPECIAL").Length > 0)
												{
															continue;
												}
												for (int j = i + 1; j < matrixOfA.GetLength(1); j++)
												{
															float[,] B = new float[numOfConds, numOfConds];
															B[0, 0] = matrixOfA[0, i];
															B[0, 1] = matrixOfA[1, i];
															B[1, 0] = matrixOfA[0, 1];
															B[1, 1] = matrixOfA[1, j];
															B = Matrix.InverseMatrix(B);
															float[] possible = MultiplyMatrixByb(B);
															float[] res = new float[matrixColumns.Count];
															bool isallowed = true;
															foreach (float p in possible)
																		if (p < 0 || float.IsNaN(p))
																					isallowed = false;
															if (!isallowed) continue;

															for (int a = 0; a < res.Length; a++)
															{
																		res[a] = 0;
															}
															res[i] = possible[0];
															for (int a = 0; a < numOfConds - 1; a++)
															{
																		res[j + a] = possible[a + 1];
															}
															yield return res;
												}
									}
						}
						public float[] MultiplyMatrixByb(float[,] matrix)
						{
									if (matrix.GetLength(1) != matrixOfB.Length)
									{
												throw new Exception("MultiplyMatrixByb failed due to size mismatch.");
									}
									float[] res = new float[matrix.GetLength(0)];
									for (int i = 0; i < matrix.GetLength(0); i++)
									{
												res[i] = 0;
												for (int j = 0; j < matrixOfB.Length; j++)
												{
															res[i] += matrix[i, j] * matrixOfB[j];
												}
									}
									return res;
						}
			}
}
