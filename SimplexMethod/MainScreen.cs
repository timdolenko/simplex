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
    public partial class MainScreen : System.Windows.Forms.Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        int constraintsCount = 0;
        int variablesCount = 0;

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
            nOfContraintsTextBox.Text = constraintsCount.ToString();
            variablesCount = consMatrx.First().Length;
            nOfVariablesTextBox.Text = variablesCount.ToString();
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
        
        private void defaultBtn_Click(object sender, EventArgs e)
        {
            Problem p = ProblemsService.shared.GetNext();
            fillDefaultsConstraints(p.consMatrx, p.signs, p.freeVars);
            fillDefaultsFunction(p.funcVars, p.c, p.isExtrMax);
            Proceed();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            nOfContraintsTextBox.Clear();
            nOfVariablesTextBox.Clear();
            resultsGridView.Columns.Clear();
            functionGridView.Columns.Clear();
            constraintsGridView.Columns.Clear();
            extrComboBox.SelectedIndex = -1;
            resultsLbl.ResetText();
        }
    }
}
