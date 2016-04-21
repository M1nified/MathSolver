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
									ConditionsMatrix cm = cp.ParseConditionsToArrayOfEquations(txt_in_matrix.Text);
									LinearSolver ls = new LinearSolver(cm);
									ls.LUP_Solve();

									string solX = "X = [";
									foreach(float a in ls.x)
									{
												solX += " " + a.ToString();
									}
									solX += " ]";

									lb_solution_x.Text = solX;
						}
			}
}
