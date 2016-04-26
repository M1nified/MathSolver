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
						public void GetTypeStringTest()
						{
									string sign;
									sign = Condition.GetTypeString("x1 = 2");
									Assert.AreEqual("=", sign);
									sign = Condition.GetTypeString("x1 <= 2");
									Assert.AreEqual("<=", sign);
						}

						[TestMethod()]
						public void ParseConditionTest()
						{
						}

						[TestMethod()]
						public void ParseConditionsToListTest()
						{
									List<Condition> expected1 = new List<Condition>();
									expected1.Add(Condition.Parse("3x1 + x2 + x3 = -2"));
									expected1.Add(Condition.Parse("2x1 + 2x2 + 3x3 = 8"));
									expected1.Add(Condition.Parse("x1 + 3x2 + 2x3 = 6"));
									List<Condition> res = cp.ParseConditionsToList(conditions1);
									CollectionAssert.AreEqual(expected1, res);
									//AreConditionListEqual(expected1, res);

						}

						[TestMethod()]
						public void ParseConditionsToArrayTest()
						{
									List<Condition> expected1 = new List<Condition>();
									expected1.Add(Condition.Parse("3x1 + x2 + x3 = -2"));
									expected1.Add(Condition.Parse("2x1 + 2x2 + 3x3 = 8"));
									expected1.Add(Condition.Parse("x1 + 3x2 + 2x3 = 6"));
									float[,] expectedMatrixOfA = new float[,] {
												{3,1,1 }, {2,2,3 }, {1,3,2 }
												};
									float[] expectedMatrixOfB = new float[] { -2, 8, 6 };
									ConditionsMatrix res = cp.ParseConditionsToArrayOfEquations(conditions1);
									CollectionAssert.AreEqual(expectedMatrixOfA, res.A);
									CollectionAssert.AreEqual(expectedMatrixOfB, res.B);
						}

			}
}