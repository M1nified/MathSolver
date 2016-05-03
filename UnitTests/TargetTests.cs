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
				public class TargetTests
				{
								Target t;
								[TestMethod()]
								public void ParseTest()
								{
												t = Target.Parse("[1 2 3 4] -> MAX");
												Assert.AreEqual(Target.DESIRE_MAXIMUM, t.DESIRE);
												CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4 }, t.FUNCTION.MULTIPLY_BY);
								}
								[TestMethod()]
								public void ParseTest1()
								{
												t = Target.Parse("x1 + x2 - 3x3 -> MAX");
												Assert.AreEqual(Target.DESIRE_MAXIMUM, t.DESIRE);
												CollectionAssert.AreEqual(new float[] { 1, 1, -3 }, t.FUNCTION.MULTIPLY_BY);

								}
				}
}