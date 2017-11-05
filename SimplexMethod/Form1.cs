using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int constraintsCount = 0;
        int variablesCount = 0;

        int defaultIndex = 0;

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                constraintsCount = Convert.ToInt32(nOfContraintsTextBox.Text);
                variablesCount = Convert.ToInt32(nOfVariablesTextBox.Text);
                fillConstraintsGrid();
                fillFunctionGrid();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        void fillConstraintsGrid()
        {
            constraintsGridView.Rows.Clear();
            constraintsGridView.ColumnCount = variablesCount + 2;
            constraintsGridView.RowHeadersVisible = false;
            for (int i = 0; i < variablesCount + 2; i++)
            {
                constraintsGridView.Columns[i].Width = 50;
                constraintsGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i < variablesCount)
                {
                    constraintsGridView.Columns[i].Name = "x" + (i + 1).ToString();
                } else if (i == variablesCount)
                {
                    constraintsGridView.Columns[i].Name = "Sign";
                }
                
            }

            for (int i = 0; i < constraintsCount; i++)
            {
                string[] row = new string[variablesCount + 2];
                constraintsGridView.Rows.Add(row);
                constraintsGridView.Rows[i].Height = 20;
            }
        }
        void fillFunctionGrid()
        {
            functionGridView.Rows.Clear();
            functionGridView.ColumnCount = variablesCount + 1;
            functionGridView.RowHeadersVisible = false;
            for (int i = 0; i < variablesCount + 1; i++)
            {
                functionGridView.Columns[i].Width = 50;
                functionGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i < variablesCount)
                {
                    functionGridView.Columns[i].Name = "x" + (i + 1).ToString();
                }
                else
                {
                    functionGridView.Columns[i].Name = "C";
                }

            }
            string[] row = new string[variablesCount + 2];
            constraintsGridView.Rows.Add(row);
            constraintsGridView.Rows[0].Height = 20;
            
        }

        void Proceed()
        {
            Constraint[] constraints = new Constraint[constraintsCount];
            for (int i = 0; i < constraintsCount; i++)
            {
                double[] variables = new double[variablesCount];
                double b = Convert.ToDouble(constraintsGridView.Rows[i].Cells[variablesCount + 1].Value);
                string sign = Convert.ToString(constraintsGridView.Rows[i].Cells[variablesCount].Value);
                for (int j = 0; j < variablesCount; j++)
                {
                    variables[j] = Convert.ToDouble(constraintsGridView.Rows[i].Cells[j].Value);
                }
                constraints[i] = new Constraint(variables, b, sign);
            }
            double[] functionVariables = new double[variablesCount];
            for (int i = 0; i < variablesCount; i++)
            {
                functionVariables[i] = Convert.ToDouble(functionGridView.Rows[0].Cells[i].Value);
            }
            double c = Convert.ToDouble(functionGridView.Rows[0].Cells[variablesCount].Value);

            bool isExtrMax = extrComboBox.SelectedIndex == 0;

            Function function = new Function(functionVariables, c, isExtrMax);

            Simplex simplex = new Simplex(function, constraints);

            Tuple<List<SimplexSnap>, SimplexResult> result = simplex.GetResult();

            switch (result.Item2)
            {
                case SimplexResult.Found:
                    string extrStr = isExtrMax ? "max" : "min";
                    resultsLbl.Text = "The optimal solution is found: F" + extrStr + $" = {result.Item1.Last().fValue}";
                    break;
                case SimplexResult.Unbounded:
                    resultsLbl.Text = "The domain of admissible solutions is unbounded";
                    break;
                case SimplexResult.NotYetFound:
                    resultsLbl.Text = "Algorithm has made 100 cycles and hasn't found any optimal solution.";
                    break;
            }

            ShowResultsGrid(result.Item1);
            
        }

        void ShowResultsGrid(List<SimplexSnap> snaps)
        {
            resultsGridView.Rows.Clear();
            resultsGridView.ColumnCount = snaps.First().matrix.Length + 4;
            resultsGridView.RowHeadersVisible = false;
            resultsGridView.ColumnHeadersVisible = false;

            for (int i = 0; i < snaps.First().matrix.Length + 4; i++)
            {
                resultsGridView.Columns[i].Width = 50;
                resultsGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            foreach (SimplexSnap snap in snaps)
            {
                string[] firstRow = new string[snaps.First().matrix.Length + 4];

                firstRow[0] = "i";
                firstRow[1] = "Basis";
                firstRow[2] = "C";
                firstRow[3] = "B";

                for (int i = 4; i < snaps.First().matrix.Length + 4; i++)
                {
                    firstRow[i] = $"A{i - 3}";
                }

                resultsGridView.Rows.Add(firstRow);

                for (int i = 0; i < snaps.First().C.Length; i++)
                {
                    string[] row = new string[snaps.First().matrix.Length + 4];
                    for (int j = 0; j < snaps.First().matrix.Length + 4; j++)
                    {
                        if (j == 0)
                        {
                            row[j] = (i + 1).ToString();
                        }
                        else if (j == 1)
                        {
                            row[j] = $"A{snap.C[i] + 1}";
                        }
                        else if (j == 2)
                        {
                            row[j] = snap.m[snap.C[i]] ? "-M" : $"{snap.fVars[snap.C[i]]}";
                        }
                        else if (j == 3)
                        {
                            row[j] = Round(snap.b[i]).ToString();
                        }
                        else
                        {
                            row[j] = Round(snap.matrix[j - 4][i]).ToString();
                        }
                    }
                    resultsGridView.Rows.Add(row);
                }
                string[] fRow = new string[snaps.First().matrix.Length + 4];
                fRow[0] = "m+1";
                fRow[1] = "F";
                fRow[2] = "Δj";
                fRow[3] = Round(snap.fValue).ToString();
                for (int i = 4; i < snaps.First().matrix.Length + 4; i++)
                {
                    fRow[i] = Round(snap.F[i - 4]).ToString();
                }
                resultsGridView.Rows.Add(fRow);

                if (!snap.isMDone)
                {
                    string[] mRow = new string[snaps.First().matrix.Length + 4];
                    mRow[0] = "m+2";
                    mRow[1] = "M";
                    mRow[2] = "Δj";
                    mRow[3] = "";
                    for (int i = 4; i < snaps.First().matrix.Length + 4; i++)
                    {
                        mRow[i] = Round(snap.M[i - 4]).ToString();
                    }
                    resultsGridView.Rows.Add(mRow);
                }
                string[] emptyRow = new string[snaps.First().matrix.Length + 4];
                resultsGridView.Rows.Add(emptyRow);
            }
        }

        double Round(double a)
        {
            return Math.Round(a, 2);
        }

        void fillDefaultsConstraints(double[][] consMatrx, string[] signs, double[] freeVars)
        {

            constraintsCount = signs.Length;
            variablesCount = consMatrx.First().Length;
            fillConstraintsGrid();

            for (int i = 0; i < constraintsCount; i++)
            {
                for (int j = 0; j < variablesCount + 2; j++)
                {
                    if (j < variablesCount)
                    {
                        constraintsGridView.Rows[i].Cells[j].Value = consMatrx[i][j];
                    }
                    else if (j < variablesCount + 1)
                    {
                        constraintsGridView.Rows[i].Cells[j].Value = signs[i];
                    }
                    else if (j < variablesCount + 2)
                    {
                        constraintsGridView.Rows[i].Cells[j].Value = freeVars[i];
                    }

                }
            }
        }

        void fillDefaultsFunction(double[] funcVars, double c, bool isExtrMax)
        {
            fillFunctionGrid();
            for (int i = 0; i < variablesCount + 1; i++)
            {
                if (i < variablesCount)
                {
                    functionGridView.Rows[0].Cells[i].Value = funcVars[i];
                }
                else
                {
                    functionGridView.Rows[0].Cells[i].Value = c;
                }
            }

            extrComboBox.SelectedIndex = isExtrMax ? 0 : 1;
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            Proceed();
        }

        void simplex4()
        {
            Constraint[] constraints = new Constraint[2];
            double[] c1Vars = { 3, 2, 1};
            Constraint c1 = new Constraint(c1Vars, 10, "<=");
            constraints[0] = c1;
            double[] c2Vars = { 2, 5, 3 };
            Constraint c2 = new Constraint(c2Vars, 26, "<=");
            constraints[1] = c2;
            double[] funcVars = { -2, -3, -4 };
            Function function = new Function(funcVars, 0, false);
            Simplex s = new Simplex(function, constraints);
        }

        void simplex2()
        {
            Constraint[] constraints = new Constraint[2];
            double[] c1Vars = { 2, 5, 1, 8 };
            Constraint c1 = new Constraint(c1Vars, 12, "=");
            constraints[0] = c1;
            double[] c2Vars = { -3, 6, 2, -2 };
            Constraint c2 = new Constraint(c2Vars, 5, "<=");
            constraints[1] = c2;

            double[] funcVars = { 2, -1, 7, 11, 5 };
            Function function = new Function(funcVars, 0, true);
            Simplex s = new Simplex(function, constraints);
        }

        void simplex3()
        {
            Constraint[] constraints = new Constraint[4];
            double[] c1Vars = { 8,6,1 };
            Constraint c1 = new Constraint(c1Vars, 48, "<=");
            constraints[0] = c1;
            double[] c2Vars = { 2,1.5,0.5 };
            Constraint c2 = new Constraint(c2Vars, 8, "<=");
            constraints[1] = c2;
            double[] c3Vars = { 4, 2, 1.5 };
            Constraint c3 = new Constraint(c3Vars, 20, "<=");
            constraints[2] = c3;
            double[] c4Vars = { 0,1,0 };
            Constraint c4 = new Constraint(c4Vars, 5, "<=");
            constraints[3] = c4;
            double[] funcVars = { 60, 30, 20 };
            Function function = new Function(funcVars, 0, true);
            Simplex s = new Simplex(function, constraints);
        }

        void simplex5()
        {
            Constraint[] constraints = new Constraint[3];
            double[] c1Vars = { 2, -1, 1 };
            Constraint c1 = new Constraint(c1Vars, 1, "<=");
            constraints[0] = c1;
            double[] c2Vars = { 4, -2, 1 };
            Constraint c2 = new Constraint(c2Vars, -2, ">=");
            constraints[1] = c2;
            double[] c3Vars = { 3, 0, 1 };
            Constraint c3 = new Constraint(c3Vars, 5, "<=");
            constraints[2] = c3;
            double[] funcVars = { 1, -1, -3 };
            Function function = new Function(funcVars, 0, false);
            Simplex s = new Simplex(function, constraints);
        }
        
        private void defaultBtn_Click(object sender, EventArgs e)
        {
            switch(defaultIndex)
            {
                case 0:
                    defaultIndex++;

                    //Constraint[] constraints = new Constraint[3];
                    double[] c1Vars = { 2, 3, 1, 2, 3 };
                    //Constraint c1 = new Constraint(c1Vars, 5, "<=");
                    //constraints[0] = c1;
                    double[] c2Vars = { 2, 15, 2, 1, -1 };
                    //Constraint c2 = new Constraint(c2Vars, 25, "=");
                    //constraints[1] = c2;
                    double[] c3Vars = { 3, -2, 4, 2, -1 };
                    //Constraint c3 = new Constraint(c3Vars, 16, ">=");
                    //constraints[2] = c3;

                    double[][] consMatrx = new double[3][];
                    consMatrx[0] = c1Vars;
                    consMatrx[1] = c2Vars;
                    consMatrx[2] = c3Vars;

                    string[] signs = { "<=", "=", ">=" };
                    double[] freeVars = { 35, 25, 16 };

                    

                    double[] funcVars = { 14, -22, 1, -3, 2 };
                    //Function function = new Function(funcVars, 0, true);
                    //Simplex s = new Simplex(function, constraints);

                    fillDefaultsConstraints(consMatrx, signs, freeVars);
                    fillDefaultsFunction(funcVars, 0, true);
                    Proceed();

                    break;
                case 1:

                    double[] c11Vars = { 2, 0, 5,1,8 };

                    double[] c12Vars = { -3,6,2,-2, 0 };

                    double[][] consMatrx1 = new double[2][];
                    consMatrx1[0] = c11Vars;
                    consMatrx1[1] = c12Vars;

                    string[] signs1 = { "=", "<=" };
                    double[] freeVars1 = { 12, 5 };

                    double[] funcVars1 = { 2, -1, 7, 11, 5 };

                    fillDefaultsConstraints(consMatrx1, signs1, freeVars1);
                    fillDefaultsFunction(funcVars1, 0, false);
                    Proceed();

                    defaultIndex++;
                    break;
                case 2:
                    defaultIndex++;
                    break;
                case 3:
                    defaultIndex++;
                    break;
                case 4:
                    defaultIndex++;
                    break;
                case 5:
                    defaultIndex = 0;
                    break;
            }
        }
    }
}
