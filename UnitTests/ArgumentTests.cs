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
				public class ArgumentTests
				{
								Argument arg;
								[TestInitialize]
								public void TestInitialize()
								{
												arg = new Argument("x1", -123);
								}
								[TestMethod()]
								public void ArgumentTest()
								{
												Assert.AreEqual("x1", arg.NAME);
												Assert.AreEqual(-123, arg.VALUE);
								}

								[TestMethod()]
								public void EqualsTest()
								{
												Argument arg1 = new Argument("x1", -123);
												Argument arg2 = new Argument("x1", -123);
												Argument arg3 = new Argument("x1", 123);
												Argument arg4 = new Argument("x2", 123);
												Argument arg5 = new Argument("x2", -123);
												Assert.AreEqual(true, arg1.Equals(arg2));
												Assert.AreNotEqual(true, arg1.Equals(arg3));
												Assert.AreNotEqual(true, arg1.Equals(arg4));
												Assert.AreNotEqual(true, arg1.Equals(arg5));
								}

								[TestMethod()]
								public void ParseTest()
								{
												Argument res = Argument.Parse("-2x1");
												Assert.AreEqual("x1", res.NAME);
												Assert.AreEqual(-2, res.VALUE);
								}

								[TestMethod()]
								public void EvalTest()
								{
												float score = arg.Eval(-2);
												Assert.AreEqual(246, score);
								}
				}
}