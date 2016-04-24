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
			public class LineLimiterTests
			{
						[TestMethod()]
						public void LineLimiterTest()
						{
						}

						[TestMethod()]
						public void FindSharedPointTest()
						{
									//wypada jeszcze dopisac
									LineLimiter ll1 = new LineLimiter(0, 1, 1);
									LineLimiter ll2 = new LineLimiter(0, 1, 2);
									LineLimiter ll3 = new LineLimiter(0, 0, 1);
									LineLimiter ll4 = new LineLimiter(0, 0, is_vertical: true);

									Point p;
									p = ll1.FindSharedPoint(ll2);
									Assert.AreEqual(null, p);
									p = ll1.FindSharedPoint(ll3);
									Assert.AreEqual(new Point(0, 1), p);
									p = ll1.FindSharedPoint(ll4);
									Assert.AreEqual(new Point(0,1), p);
						}
			}
}