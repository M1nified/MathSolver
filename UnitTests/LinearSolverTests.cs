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
								Equation eq1 = new Equation(-2, 3, 1, 1);
								Equation eq2 = new Equation(8, 2, 2, 3);
								Equation eq3 = new Equation(6, 1, 3, 2);
								int expected_equations_len = 3;
								float[,] expected_matrixOfA = new float[3, 3] { { 3, 1, 1 }, { 2, 2, 3 }, { 1, 3, 2 } };
								float[] expected_matrixOfB = new float[3] { -2, 8, 6 };

								float[] expected_solutionX = new float[3] { -2, 0, 4 };
								LinearSolver ls;

								[TestInitialize]
								public void TestInitialize()
								{
												ls = new LinearSolver(eq1, eq2, eq3);
								}
								[TestMethod()]
								public void LinearSolverTest()
								{
												LinearSolver ls = new LinearSolver();
								}

								[TestMethod()]
								public void LinearSolverTest1()
								{
												Assert.AreEqual(expected_equations_len, ls.equations.Count);
												CollectionAssert.AreEqual(expected_matrixOfA, ls.matrixOfA);
												CollectionAssert.AreEqual(expected_matrixOfB, ls.matrixOfB);
								}

								[TestMethod()]
								public void AddEquationTest()
								{
												ls.AddEquation(eq1);
												Assert.AreEqual(4, ls.equations.Count);
								}

								//[TestMethod()]
								//public void UpdateMatrixTest()
								//{
								//				Assert.Fail();
								//}

								//[TestMethod()]
								//public void ResolveTest()
								//{
								//}

								//[TestMethod()]
								//public void ToStringTest()
								//{
								//}

								//[TestMethod()]
								//public void LUP_Decomposition_1Test()
								//{
								//}

								//[TestMethod()]
								//public void LUP_DecompositionTest()
								//{
								//}

								[TestMethod()]
								public void LUP_SolveTest()
								{
												ls.LUP_Solve();
												CollectionAssert.AreEqual(expected_solutionX, ls.x);
								}
				}
}