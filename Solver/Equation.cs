using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
			public class Equation
			{
						public LinkedList<float> parameters
						{
									get;
									private set;
						}
						public float B
						{
									get;
									private set;
						}
						public Equation(float b, params float[] prms)
						{
									B = b;
									parameters = new LinkedList<float>();
									foreach (float prm in prms)
									{
												parameters.AddLast(prm);
									}
						}
						public override string ToString()
						{
									string ret = B + " \t=";
									int index = 0;
									foreach (float prm in parameters)
									{
												index++;
												if (prm.CompareTo(0) > 0)
												{
															//+
															ret += " +";
												}
												ret += prm.ToString() + "x" + index;
									}
									return ret;
						}
						public float[] ToArray()
						{
									float[] ret = new float[parameters.Count];
									for (int i = 0; i < parameters.Count; ret[i] = parameters.ElementAt(i++)) ;
									return ret;
						}
			}
}
