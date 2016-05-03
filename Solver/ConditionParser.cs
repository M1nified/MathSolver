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
								public static readonly string PATT_ARG = @"([-+]?\d*)(\w\d?)?";
								public static readonly string FREE_KEY = "FREE";

								public string NAME;
								public float VALUE;
								public Argument(string name, float value)
								{
												NAME = name;
												VALUE = value;
								}
								public Argument(string input)
								{
												Argument arg = Parse(input);
												NAME = arg.NAME;
												VALUE = arg.VALUE;
								}

								public float Eval(float x)
								{
												return x * VALUE;
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
								public static Argument Parse(string input)
								{
												Match match = Regex.Match(input, PATT_ARG);
												string val = match.Groups[1].Value;
												val = val == "" ? "1" : val;
												val = val == "-" || val == "+" ? val + "1" : val;
												float fval = float.Parse(val);
												string name = match.Groups[2].Value;
												name = name == "" ? Argument.FREE_KEY : name;
												return new Argument(name, fval);
								}
				}
				public class Function
				{
								public static readonly string PATT_ARG_NUM = @"[-+]?\d+";
								public static readonly string PATT_ARG_NAM = @"(\w\d?)+";
								public static readonly string PATT_ARG = @"(("+PATT_ARG_NUM+PATT_ARG_NAM+@")|(" + PATT_ARG_NUM+@")|("+PATT_ARG_NAM+@"))";
								public static readonly string PATT_MATR = @"^\[[\d,\s]+\]$";
								public static readonly string PATT_ARGS = @"^("+PATT_ARG+")*";
								public float[] MULTIPLY_BY;
								public Function(params float[] args)//Funkcje typu: -3x1 + 5x2 - 9x3
								{
												MULTIPLY_BY = args;
								}
								public float Call(params float[] args)
								{
												if (args.Length != MULTIPLY_BY.Length)
												{
																throw new Exception("Wrong number of arguments for specified function");
												}
												else
												{
																float result = 0;
																for (int i = 0; i < MULTIPLY_BY.Length; i++)
																{
																				result += MULTIPLY_BY[i] * args[i];
																}
																return result;
												}
								}
								public static Function Parse(string input)
								{
												input = input.Trim();
												if (Regex.IsMatch(input, PATT_MATR))//jesli zapisane jako tablica
												{
																MatchCollection matches = Regex.Matches(input, @"\d+");
																float[] multiple_by = new float[matches.Count];
																for (int i = 0; i < matches.Count; i++)
																{
																				multiple_by[i] = float.Parse(matches[i].ToString());
																}
																return new Function(multiple_by);
												}
												else if(Regex.IsMatch(Regex.Replace(input, @"\s+", ""),PATT_ARGS))
												{
																MatchCollection matches = Regex.Matches(Regex.Replace(input, @"\s+", ""), PATT_ARG);
																float[] multiple_by = new float[matches.Count];
																for(int i=0;i<matches.Count;i++)
																{
																				Argument arg = Argument.Parse(matches[i].ToString());
																				multiple_by[i] = arg.VALUE;
																}
																return new Function(multiple_by);
												}
												return null;
								}
				}
				public class Target
				{
								public static readonly byte DESIRE_MAXIMUM = 0;
								public static readonly byte DESIRE_MINIMUM = 1;

								public Function FUNCTION = null;
								public byte DESIRE;
								public Target(string desire, Function func)
								{
												SetDesire(desire);
												FUNCTION = func;
								}
								public void SetDesire(string desire)
								{
												desire = Regex.Replace(desire, @"\s+", "");
												if (desire == "MAX")
												{
																DESIRE = DESIRE_MAXIMUM;
												}
												else if (desire == "MIN")
												{
																DESIRE = DESIRE_MINIMUM;
												}
								}
								public static Target Parse(string input)
								{
												//Regex format1 = new Regex(@"\[[\d\s]+\]\s*->\s*(MAX|MIN)");
												//Regex format2 = new Regex(@"");
												Regex twoside = new Regex(@"->");
												string[] sides = twoside.Split(input);
												return new Target(sides[1], Function.Parse(sides[0]));
								}
				}
				public class Condition : ICloneable
				{
								public static string PATT_COMP = @"(<=|>=|[<>=])";

								public enum ConditionType
								{
												LESS = -2,
												LESS_EQUAL = -1,
												EQUAL = 0,
												GREATER_EQUAL = 1,
												GREATER = 2
								};

								//public static readonly int CONDITION_LESS = -2;
								//public static readonly int CONDITION_LESS_EQUAL = -1;
								//public static readonly int CONDITION_EQUAL = 0;
								//public static readonly int CONDITION_GREATER_EQUAL = 1;
								//public static readonly int CONDITION_GREATER = 2;

								public Dictionary<string, float> ARGUMENTS;
								public ConditionType TYPE;

								public Condition()
								{
												ARGUMENTS = new Dictionary<string, float>();
								}
								public Condition(ConditionType condition, Dictionary<string, float> arguments)
								{
												TYPE = condition;
												ARGUMENTS = arguments;
								}
								public Condition(string input)
								{
												Condition cond = Condition.Parse(input);
												ARGUMENTS = cond.ARGUMENTS;
												TYPE = cond.TYPE;
								}

								public void AddArgument(Argument arg)
								{
												ARGUMENTS[arg.NAME] = arg.VALUE;
								}
								public void SetCondition(string cond)
								{
												TYPE = ParseType(GetTypeString(cond));
								}

								public override bool Equals(object obj)
								{
												Condition a = (Condition)obj;
												if (a.TYPE == TYPE || ARGUMENTS.Equals(a.ARGUMENTS))
																return true;
												return false;
								}
								public override int GetHashCode()
								{
												return base.GetHashCode();
								}

								public object Clone()
								{
												return MemberwiseClone();
								}
								public static string GetTypeString(string condition_with_sign)
								{
												condition_with_sign = Regex.Match(condition_with_sign, PATT_COMP).ToString();
												return condition_with_sign;
								}
								public static ConditionType ParseType(string input)
								{
												switch (input)
												{
																case "<":
																				return ConditionType.LESS;
																//break;
																case "<=":
																case "=<":
																				return ConditionType.LESS_EQUAL;
																//break;
																case ">=":
																case "=>":
																				return ConditionType.GREATER_EQUAL;
																//break;
																case ">":
																				return ConditionType.GREATER;
																//break;
																default:
																				return ConditionType.EQUAL;
																				//break;
												}
								}
								public static Condition Parse(string input)
								{
												Condition condition = new Condition();
												input = Regex.Replace(input, @"\s+", "");
												Dictionary<string, float> dict = new Dictionary<string, float>();
												Regex twoside = new Regex(PATT_COMP);
												Regex argpatt = new Regex(Argument.PATT_ARG);
												string[] sides = twoside.Split(input);
												foreach (Match arg in argpatt.Matches(sides[0]))//left side
												{
																Argument parsedArg = Argument.Parse(arg.Value);
																dict[parsedArg.NAME] = dict.ContainsKey(parsedArg.NAME) ? dict[parsedArg.NAME] + parsedArg.VALUE : parsedArg.VALUE;
												}
												foreach (Match arg in argpatt.Matches(sides[2]))//right side
												{
																Argument parsedArg = Argument.Parse(arg.Value);
																dict[parsedArg.NAME] = dict.ContainsKey(parsedArg.NAME) ? dict[parsedArg.NAME] - parsedArg.VALUE : -parsedArg.VALUE;//transfer to the left side
												}
												condition.ARGUMENTS = dict;
												condition.SetCondition(input);
												return condition;
								}
				}
				public class ConditionsMatrix
				{
								public float[,] A;
								public float[] B;
								public Dictionary<string, int> COLUMNS = null;
								public ConditionsMatrix(float[,] matrixOfA, float[] matrixOfB)
								{
												A = matrixOfA;
												B = matrixOfB;
								}
								public ConditionsMatrix(float[,] matrixOfA, float[] matrixOfB, Dictionary<string, int> cols)
								{
												A = matrixOfA;
												B = matrixOfB;
												COLUMNS = cols;
								}
				}
				public class ConditionParser
				{
								public static string PATT_SUM = @"[-+]";

								public ConditionParser()
								{

								}
								#region Single condition parsing
								#endregion
								#region Multiple conditions parsing
								public List<Condition> ParseConditionsToList(string conds)
								{
												List<Condition> list = new List<Condition>();

												Regex linebreak = new Regex(@"\n|\r\n");
												string[] conditions = linebreak.Split(conds);

												foreach (string cond in conditions)
												{
																Condition condition = Condition.Parse(cond);
																list.Add(condition);
												}

												return list;
								}
								public ConditionsMatrix ParseConditionsToArrayOfEquations(string conds)
								{
												List<Condition> list = ParseConditionsToList(conds);
												return ParseConditionsToArrayOfEquations(list);
								}
								public ConditionsMatrix ParseConditionsToArrayOfEquations(List<Condition> list)
								{
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
												for (int i = 0; i < matrixOfA.GetLength(0); i++) for (int j = 0; j < matrixOfA.GetLength(1); j++) matrixOfA[i, j] = 0;//zerowanie macierzy A
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
												ConditionsMatrix cm = new ConditionsMatrix(matrixOfA, matrixOfB, column);
												return cm;
								}
								#endregion
				}
}
