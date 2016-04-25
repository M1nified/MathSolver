using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solver
{
			public partial class Form1 : Form
			{
						public Form1()
						{
									InitializeComponent();
						}

						private void button1_Click(object sender, EventArgs e)
						{
									ConditionParser cp = new ConditionParser();
									List<Condition> conds = cp.ParseConditionsToList(txt_in_matrix.Text);
									string targ_str = txt_target.Text;
									Target target = Target.Parse(targ_str);

									LinearProblem theProblem = new LinearProblem(conds, target);
									float[] solution = theProblem.Solve();
									string sol = "[ ";
									foreach(float s in solution)
									{
												sol += s.ToString()+" ";
									}
									sol += "]";
									lb_solution_x.Text = sol;
						}
			}
}
