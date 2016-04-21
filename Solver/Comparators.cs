using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
			public class ConditionComparator : IEqualityComparer<Condition>
			{
						public int Compare(object x, object y)
						{
									Condition cond1 = (Condition)x;
									Condition cond2 = (Condition)y;
									return cond1.Equals(cond2) ? 0 : 1;
						}

						public bool Equals(Condition x, Condition y)
						{
									return x.Equals(y);
						}

						public int GetHashCode(Condition obj)
						{
									return obj.ToString().ToLower().GetHashCode();
						}
			}
}
