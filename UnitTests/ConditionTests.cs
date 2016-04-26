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
				public class ConditionTests
				{
								Condition c1 = null;
								[TestMethod()]
								public void ConditionTest()
								{
												c1 = new Condition();
												Assert.AreNotEqual(null, c1);
								}

								[TestMethod()]
								public void ConditionTest1()
								{
												c1 = new Condition(Condition.ConditionType.EQUAL, new Dictionary<string, float> { });
								}

								[TestMethod()]
								public void ConditionTest2()
								{

								}

								[TestMethod()]
								public void AddArgumentTest()
								{

								}

								[TestMethod()]
								public void SetConditionTest()
								{

								}

								[TestMethod()]
								public void EqualsTest()
								{

								}

								[TestMethod()]
								public void GetHashCodeTest()
								{

								}

								[TestMethod()]
								public void CloneTest()
								{

								}

								[TestMethod()]
								public void GetEqualityTest()
								{

								}

								[TestMethod()]
								public void ParseTest()
								{
												Condition res, shouldbe = new Condition();
												res = Condition.Parse("2x1 - 3x2 + 4x2 - x3= 1");
												shouldbe.ARGUMENTS["x1"] = 2;
												shouldbe.ARGUMENTS["x2"] = 1;
												shouldbe.ARGUMENTS["x3"] = -1;
												shouldbe.ARGUMENTS[Argument.FREE_KEY] = -1;
												shouldbe.TYPE = Condition.ConditionType.EQUAL;
												CollectionAssert.AreEqual(shouldbe.ARGUMENTS, res.ARGUMENTS);
												Assert.AreEqual(shouldbe.TYPE, res.TYPE);
								}

				}
}