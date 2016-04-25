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
			public class FunctionTests
			{
						[TestMethod()]
						public void FunctionTest()
						{
									Function f = new Function(1, 2, 3, 4, 5);
									Assert.AreEqual(5, f.MULTIPLY_BY.Length);
						}

						[TestMethod()]
						public void CallTest()
						{
									Function f = new Function(2, 3, 4);
									float res = f.Call(1, 1, 1);
									Assert.AreEqual(9, res);
						}

						[TestMethod()]
						public void ParseTest()
						{
									Function f;
									f = Function.Parse("[1 2 3 4]");
									CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4 }, f.MULTIPLY_BY);
									f = Function.Parse(" [1 2 3 4] ");
									CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4 }, f.MULTIPLY_BY);
						}
			}
}