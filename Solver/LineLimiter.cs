using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
			public class LineLimiter
			{
						public static readonly int LESS = -2;
						public static readonly int EQUAL = 0;
						public static readonly int GRETER = 2;
						public int EQUALITY = 0;
						public float A = 0;
						public float B = 0;
						public bool IS_VERTICAL = false;
						public LineLimiter(int eq, float a, float b = 0, bool is_vertical = false)
						{
									EQUALITY = eq;
									A = a;
									B = b;
									IS_VERTICAL = is_vertical;
						}
						public Point FindSharedPoint(LineLimiter ll)
						{
									float x, y;
									if ((ll.IS_VERTICAL && IS_VERTICAL && A != ll.A) || (A == 0 && ll.A == 0 && B != ll.B))
									{
												return null;
									}
									else if (IS_VERTICAL)
									{
												x = A;
												y = x * ll.A + ll.B;
									}
									else if (ll.IS_VERTICAL)
									{
												x = ll.A;
												y = x * A + B;
									}
									//both are y=Ax+B functions
									else if (A == ll.A && B != ll.B)
									{
												return null;
									}
									else if (A == 0)
									{
												y = B;
												x = (B - ll.B) / ll.A;
									}
									else if (ll.A == 0)
									{
												y = ll.B;
												x = (ll.B - B) / A;
									}
									//both are not horizontal
									else
									{
												float equalizer = A / ll.A;
												y = B - equalizer * ll.B;
												x = (y - B) / A;
									}
									return new Point(x, y);
						}
			}
			public class Point
			{
						public float X = 0;
						public float Y = 0;
						public Point(float x, float y)
						{
									X = x;
									Y = y;
						}
						public override bool Equals(object obj)
						{
									Point p = (Point)obj;
									return p.X == X && p.Y == Y;
						}
						public override int GetHashCode()
						{
									return base.GetHashCode();
						}
			}
}
