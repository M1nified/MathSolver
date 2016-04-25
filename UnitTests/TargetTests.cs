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
						[TestMethod()]
						public void ParseTest()
						{
									Target t = Target.Parse("[1 2 3 4] -> MAX");
									Assert.AreEqual(Target.DESIRE_MAXIMUM, t.DESIRE);
									CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4 }, t.FUNCTION.MULTIPLY_BY);
						}
			}
}