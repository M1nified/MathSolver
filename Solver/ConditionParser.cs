using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solver
{
			public class Argument
			{
						public static string FREE_KEY = "FREE";
						public string NAME;
						public float VALUE;
						public Argument(string name, float value)
						{
									NAME = name;
									VALUE = value;
						}

						public override bool Equals(object obj)
						{
									Argument arg = (Argument)obj;
									return (NAME.Equals(arg.NAME) && VALUE.Equals(arg.VALUE));
						}
						public override int GetHashCode()
						{
									return base.GetHashCode();
						}
			}
			public class Condition
			{
						public static int CONDITION_LESS = -2;
						public static int CONDITION_LESS_EQUAL = -1;
						public static int CONDITION_EQUAL = 0;
						public static int CONDITION_GREATER_EQUAL = 1;
						public static int CONDITION_GREATER = 2;

						public Dictionary<string, float> ARGUMENTS;
						public int COND;
						public Condition()
						{
									ARGUMENTS = new Dictionary<string, float>();
						}
						public Condition(int condition, Dictionary<string, float> arguments)
						{
									COND = condition;
									ARGUMENTS = arguments;
						}
						public void AddArgument(Argument arg)
						{
									ARGUMENTS[arg.NAME] = arg.VALUE;
						}
						public void SetCondition(string cond)
						{
									switch (cond)
									{
												case "<":
															COND = CONDITION_LESS;
															break;
												case "<=":
												case "=<":
															COND = CONDITION_LESS_EQUAL;
															break;
												case ">=":
												case "=>":
															COND = CONDITION_GREATER_EQUAL;
															break;
												case ">":
															COND = CONDITION_GREATER;
															break;
												default:
															COND = CONDITION_EQUAL;
															break;
									}
						}

						public override bool Equals(object obj)
						{
									Condition a = (Condition)obj;
									if(a.COND == COND || ARGUMENTS.Equals(a.ARGUMENTS))
												return true;
									return false;
						}
						public override int GetHashCode()
						{
									return base.GetHashCode();
						}
			}
			public class ConditionsMatrix
			{
						public float[,] A;
						public float[] B;
						public ConditionsMatrix(float[,] matrixOfA, float[] matrixOfB)
						{
									A = matrixOfA;
									B = matrixOfB;
						}
			}
			public class ConditionParser
			{
						public static string PATT_COMP = @"(<=|>=|[<>=])";
						public static string PATT_SUM = @"[-+]";
						private static string PATT_ARG = @"([-+]?\d?)(\w\d?)?";

						public ConditionParser()
						{

						}
						#region Single condition parsing
						public string GetEquality(string cond)
						{
									string sign = Regex.Match(cond, PATT_COMP).ToString();
									return sign;
						}
						public Argument ParseArgument(string arg)
						{
									Match match = Regex.Match(arg, PATT_ARG);
									string val = match.Groups[1].Value;
									val = val == "" ? "1" : val;
									val = val == "-" || val == "+" ? val + "1" : val;
									float fval = float.Parse(val);
									string name = match.Groups[2].Value;
									name = name == "" ? Argument.FREE_KEY : name;
									return new Argument(name, fval);
						}
						public Condition ParseCondition(string cond)
						{
									Condition condition = new Condition();
									cond = Regex.Replace(cond, @"\s+", "");
									Dictionary<string, float> dict = new Dictionary<string, float>();
									Regex twoside = new Regex(PATT_COMP);
									Regex argpatt = new Regex(PATT_ARG);
									string[] sides = twoside.Split(cond);
									foreach (Match arg in argpatt.Matches(sides[0]))//left side
									{
												Argument parsedArg = ParseArgument(arg.Value);
												dict[parsedArg.NAME] = dict.ContainsKey(parsedArg.NAME) ? dict[parsedArg.NAME] + parsedArg.VALUE : parsedArg.VALUE;
									}
									foreach (Match arg in argpatt.Matches(sides[2]))//right side
									{
												Argument parsedArg = ParseArgument(arg.Value);
												dict[parsedArg.NAME] = dict.ContainsKey(parsedArg.NAME) ? dict[parsedArg.NAME] - parsedArg.VALUE : -parsedArg.VALUE;//transfer to the left side
									}
									condition.ARGUMENTS = dict;
									condition.SetCondition(GetEquality(cond));
									return condition;
						}
						#endregion
						#region Multiple conditions parsing
						public List<Condition> ParseConditionsToList(string conds)
						{
									List<Condition> list = new List<Condition>();

									Regex linebreak = new Regex(@"\n|\r\n");
									string[] conditions = linebreak.Split(conds);

									foreach (string cond in conditions)
									{
												Condition condition = ParseCondition(cond);
												list.Add(condition);
									}

									return list;
						}
						public ConditionsMatrix ParseConditionsToArrayOfEquations(string conds)
						{
									List<Condition> list = ParseConditionsToList(conds);
									int numofargs = 0;
									Dictionary<string, int> column = new Dictionary<string, int>();
									foreach (Condition cond in list)
									{
												foreach (KeyValuePair<string, float> arg in cond.ARGUMENTS)
												{
															if (!arg.Key.Equals(Argument.FREE_KEY) && !column.ContainsKey(arg.Key))
															{
																		column[arg.Key] = numofargs++;
															}
												}
									}
									float[,] matrixOfA = new float[list.Count, numofargs];
									float[] matrixOfB = new float[list.Count];
									int index = 0;
									foreach (Condition cond in list)
									{
												matrixOfB[index] = 0;
												foreach (KeyValuePair<string, float> arg in cond.ARGUMENTS)
												{
															if (arg.Key.Equals(Argument.FREE_KEY))
															{
																		matrixOfB[index] = -arg.Value;
															}
															else
															{
																		matrixOfA[index, column[arg.Key]] = arg.Value;
															}
												}
												index++;
									}
									ConditionsMatrix cm = new ConditionsMatrix(matrixOfA, matrixOfB);
									return cm;
						}
						#endregion
			}
}
