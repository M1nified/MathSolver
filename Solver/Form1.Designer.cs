namespace Solver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
									this.panel1 = new System.Windows.Forms.Panel();
									this.label1 = new System.Windows.Forms.Label();
									this.txt_in_matrix = new System.Windows.Forms.TextBox();
									this.lb_solution_x = new System.Windows.Forms.Label();
									this.panel2 = new System.Windows.Forms.Panel();
									this.label2 = new System.Windows.Forms.Label();
									this.panel3 = new System.Windows.Forms.Panel();
									this.button1 = new System.Windows.Forms.Button();
									this.label3 = new System.Windows.Forms.Label();
									this.txt_target = new System.Windows.Forms.TextBox();
									this.panel1.SuspendLayout();
									this.panel2.SuspendLayout();
									this.panel3.SuspendLayout();
									this.SuspendLayout();
									// 
									// panel1
									// 
									this.panel1.Controls.Add(this.txt_target);
									this.panel1.Controls.Add(this.label3);
									this.panel1.Controls.Add(this.label1);
									this.panel1.Controls.Add(this.txt_in_matrix);
									this.panel1.Location = new System.Drawing.Point(12, 12);
									this.panel1.Name = "panel1";
									this.panel1.Size = new System.Drawing.Size(377, 195);
									this.panel1.TabIndex = 0;
									// 
									// label1
									// 
									this.label1.AutoSize = true;
									this.label1.Location = new System.Drawing.Point(3, 0);
									this.label1.Name = "label1";
									this.label1.Size = new System.Drawing.Size(205, 13);
									this.label1.TabIndex = 1;
									this.label1.Text = "Conditions:, one each line: x1 + 2x2 <= 90";
									// 
									// txt_in_matrix
									// 
									this.txt_in_matrix.Location = new System.Drawing.Point(3, 16);
									this.txt_in_matrix.Multiline = true;
									this.txt_in_matrix.Name = "txt_in_matrix";
									this.txt_in_matrix.Size = new System.Drawing.Size(371, 137);
									this.txt_in_matrix.TabIndex = 0;
									// 
									// lb_solution_x
									// 
									this.lb_solution_x.Location = new System.Drawing.Point(3, 13);
									this.lb_solution_x.Name = "lb_solution_x";
									this.lb_solution_x.Size = new System.Drawing.Size(368, 33);
									this.lb_solution_x.TabIndex = 1;
									// 
									// panel2
									// 
									this.panel2.Controls.Add(this.label2);
									this.panel2.Controls.Add(this.lb_solution_x);
									this.panel2.Location = new System.Drawing.Point(12, 246);
									this.panel2.Name = "panel2";
									this.panel2.Size = new System.Drawing.Size(380, 55);
									this.panel2.TabIndex = 2;
									// 
									// label2
									// 
									this.label2.AutoSize = true;
									this.label2.Location = new System.Drawing.Point(3, 0);
									this.label2.Name = "label2";
									this.label2.Size = new System.Drawing.Size(48, 13);
									this.label2.TabIndex = 2;
									this.label2.Text = "Solution:";
									// 
									// panel3
									// 
									this.panel3.Controls.Add(this.button1);
									this.panel3.Location = new System.Drawing.Point(12, 210);
									this.panel3.Name = "panel3";
									this.panel3.Size = new System.Drawing.Size(377, 30);
									this.panel3.TabIndex = 3;
									// 
									// button1
									// 
									this.button1.Location = new System.Drawing.Point(299, 3);
									this.button1.Name = "button1";
									this.button1.Size = new System.Drawing.Size(75, 23);
									this.button1.TabIndex = 0;
									this.button1.Text = "Solve!";
									this.button1.UseVisualStyleBackColor = true;
									this.button1.Click += new System.EventHandler(this.button1_Click);
									// 
									// label3
									// 
									this.label3.AutoSize = true;
									this.label3.Location = new System.Drawing.Point(3, 156);
									this.label3.Name = "label3";
									this.label3.Size = new System.Drawing.Size(282, 13);
									this.label3.TabIndex = 2;
									this.label3.Text = "Goal: [1 2 3 4] -> MAX (means: 1x1+2x2+3x3+4x4 -> MAX)";
									// 
									// txt_target
									// 
									this.txt_target.Location = new System.Drawing.Point(3, 172);
									this.txt_target.Name = "txt_target";
									this.txt_target.Size = new System.Drawing.Size(371, 20);
									this.txt_target.TabIndex = 3;
									// 
									// Form1
									// 
									this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
									this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
									this.ClientSize = new System.Drawing.Size(401, 310);
									this.Controls.Add(this.panel3);
									this.Controls.Add(this.panel2);
									this.Controls.Add(this.panel1);
									this.Name = "Form1";
									this.Text = "[BOiTZO] Michal Gora";
									this.panel1.ResumeLayout(false);
									this.panel1.PerformLayout();
									this.panel2.ResumeLayout(false);
									this.panel2.PerformLayout();
									this.panel3.ResumeLayout(false);
									this.ResumeLayout(false);

        }

						#endregion

						private System.Windows.Forms.Panel panel1;
						private System.Windows.Forms.Label label1;
						private System.Windows.Forms.TextBox txt_in_matrix;
						private System.Windows.Forms.Label lb_solution_x;
						private System.Windows.Forms.Panel panel2;
						private System.Windows.Forms.Label label2;
						private System.Windows.Forms.Panel panel3;
						private System.Windows.Forms.Button button1;
						private System.Windows.Forms.TextBox txt_target;
						private System.Windows.Forms.Label label3;
			}
}

