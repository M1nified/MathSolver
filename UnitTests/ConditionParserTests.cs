using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.Tests
{
			[TestClass()]
			public class ConditionParserTests
			{
						string conditions1 = "3x1 + x2 + x3 = -2 \n 2x1 + 2x2 + 3x3 = 8 \n x1 + 3x2 + 2x3 = 6";
						ConditionParser cp;
						[TestMethod()]
						public void ConditionParserTest()
						{
						}
						[TestInitialize]
						public void TestInitialize()
						{
									cp = new ConditionParser();
						}

						[TestMethod()]
						public void GetEqualityTest()
						{
									string sign;
									sign = cp.GetEquality("x1 = 2");
									Assert.AreEqual("=", sign);
									sign = cp.GetEquality("x1 <= 2");
									Assert.AreEqual("<=", sign);
						}

						[TestMethod()]
						public void ParseConditionTest()
						{
									Condition res, shouldbe = new Condition();
									res = cp.ParseCondition("2x1 - 3x2 + 4x2 - x3= 1");
									shouldbe.ARGUMENTS["x1"] = 2;
									shouldbe.ARGUMENTS["x2"] = 1;
									shouldbe.ARGUMENTS["x3"] = -1;
									shouldbe.ARGUMENTS["FREE"] = -1;
									shouldbe.COND = Condition.CONDITION_EQUAL;
									CollectionAssert.AreEqual(shouldbe.ARGUMENTS, res.ARGUMENTS);
									Assert.AreEqual(shouldbe.COND, res.COND);
						}

						[TestMethod()]
						public void ParseArgumentTest()
						{
									Argument res = cp.ParseArgument("-2x1");
									Argument shouldbe = new Argument("x1", -2);
									Assert.AreEqual(shouldbe.NAME, res.NAME);
									Assert.AreEqual(shouldbe.VALUE, res.VALUE);
						}

						[TestMethod()]
						public void ParseConditionsToListTest()
						{
									List<Condition> expected1 = new List<Condition>();
									expected1.Add(cp.ParseCondition("3x1 + x2 + x3 = -2"));
									expected1.Add(cp.ParseCondition("2x1 + 2x2 + 3x3 = 8"));
									expected1.Add(cp.ParseCondition("x1 + 3x2 + 2x3 = 6"));
									List<Condition> res = cp.ParseConditionsToList(conditions1);
									CollectionAssert.AreEqual(expected1, res);
									//AreConditionListEqual(expected1, res);

						}

						[TestMethod()]
						public void ParseConditionsToArrayTest()
						{
									List<Condition> expected1 = new List<Condition>();
									expected1.Add(cp.ParseCondition("3x1 + x2 + x3 = -2"));
									expected1.Add(cp.ParseCondition("2x1 + 2x2 + 3x3 = 8"));
									expected1.Add(cp.ParseCondition("x1 + 3x2 + 2x3 = 6"));
									float[,] expectedMatrixOfA = new float[,] {
												{3,1,1 }, {2,2,3 }, {1,3,2 }
												};
									float[] expectedMatrixOfB = new float[] { -2, 8, 6 };
									ConditionsMatrix res = cp.ParseConditionsToArrayOfEquations(conditions1);
									CollectionAssert.AreEqual(expectedMatrixOfA,res.A);
									CollectionAssert.AreEqual(expectedMatrixOfB,res.B);
						}

			}
}