using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Solver
{
			public class Argument<T>
			{
						public string NAME;
						public T VALUE;
						public Argument(string name, T value)
						{
									NAME = name;
									VALUE = value;
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
						public Argument<float> ParseArgument(string arg)
						{
									Match match = Regex.Match(arg, PATT_ARG);
									string val = match.Groups[1].Value;
									val = val == "" ? "1" : val;
									val = val == "-" || val == "+" ? val + "1" : val;
									float fval = float.Parse(val);
									string name = match.Groups[2].Value;
									name = name == "" ? "FREE" : name;
									return new Argument<float>(name, fval);
						}
						public Dictionary<string, float> ParseCondition(string cond)
						{
									cond = Regex.Replace(cond, @"\s+", "");
									Dictionary<string, float> dict = new Dictionary<string, float>();
									Regex twoside = new Regex(PATT_COMP);
									Regex argpatt = new Regex(PATT_ARG);
									string[] sides = twoside.Split(cond);
									foreach (Match arg in argpatt.Matches(sides[0]))
									{
												Argument<float> parsedArg = ParseArgument(arg.Value);
												dict[parsedArg.NAME] = dict.ContainsKey(parsedArg.NAME) ? dict[parsedArg.NAME] + parsedArg.VALUE : parsedArg.VALUE;

									}
									foreach (Match arg in argpatt.Matches(sides[2]))
									{
												string val = arg.Groups[1].Value;
												val = val == "" ? "1" : val;
												float fval = float.Parse(val);
												fval *= -1;
												string name = arg.Groups[2].Value;
												name = name == "" ? "FREE" : name;
												dict[name] = dict.ContainsKey(name) ? dict[name] + fval : fval;

									}
									return dict;
						}
						#endregion
			}
}
