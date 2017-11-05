using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class Problem
    {
        public double[][] consMatrx;
        public string[] signs;
        public double[] freeVars;
        public double[] funcVars;
        public double c;
        public bool isExtrMax;

        public Problem(double[][] constraintMatrix, string[] signs, double[] freeVariables, double[] functionVariables, double c, bool isExtrMax)
        {
            this.consMatrx = constraintMatrix;
            this.signs = signs;
            this.freeVars = freeVariables;
            this.funcVars = functionVariables;
            this.c = c;
            this.isExtrMax = isExtrMax;
        }
    }
}
