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
									Dictionary<string, float> res, shouldbe = new Dictionary<string, float>();
									res = cp.ParseCondition("2x1 - 3x2 + 4x2 - x3= 1");
									shouldbe["x1"] = 2;
									shouldbe["x2"] = 1;
									shouldbe["x3"] = -1;
									shouldbe["FREE"] = -1;
									CollectionAssert.AreEqual(shouldbe,res);
						}
			}
}