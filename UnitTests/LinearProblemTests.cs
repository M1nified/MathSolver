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
			public class LinearProblemTests
			{
						List<Condition> lofconds1, lofconds2;
						LinearProblem lp;
						[TestInitialize]
						public void TestInitialize()
						{
									ConditionParser cp = new ConditionParser();
									lofconds1 = cp.ParseConditionsToList("-x1+x2+3x3>=15\n-x1+x2+x3<=6");
									lofconds2 = cp.ParseConditionsToList("x1+x2<=10\n -2x1+x2<=4");
									Target t2 = new Target("MAX", new Function(1, 2));
									lp = new LinearProblem(lofconds2, t2);
						}
						[TestMethod()]
						public void SolveTest()
						{
									float[] res = lp.Solve();
									float[] exp1 = new float[] { 2, 8 };
									CollectionAssert.AreEqual(exp1, res);
						}

						[TestMethod()]
						public void StandarizeConditionsTest()
						{

						}

						[TestMethod()]
						public void StandarizeTargetTest()
						{

						}

						[TestMethod()]
						public void GetEnumeratorTest()
						{

						}

						[TestMethod()]
						public void MultiplyMatrixBybTest()
						{

						}
			}
}