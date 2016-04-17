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
	public class LinearSolverTests
	{
		[TestMethod()]
		public void LinearSolverTest()
		{
			Solver.LinearSolver ls = new Solver.LinearSolver();
		}

		[TestMethod()]
		public void LinearSolverTest1()
		{
			Equation eq1 = new Equation(-2, 3, 1, 1);
			Equation eq2 = new Equation(8, 2, 2, 3);
			Equation eq3 = new Equation(6, 1, 3, 2);
			LinearSolver ls = new LinearSolver(eq1,eq2,eq3);
			Assert.Fail();
		}

		[TestMethod()]
		public void AddEquationTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void UpdateMatrixTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ResolveTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void LUP_Decomposition_1Test()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void LUP_DecompositionTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void LUP_SolveTest()
		{
			Assert.Fail();
		}
	}
}