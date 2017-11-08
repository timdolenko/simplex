using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    

    public class ProblemsService
    {
        public static ProblemsService shared = new ProblemsService();

        int currentProblemIndex = -1;
        public List<Problem> problems = new List<Problem>();

        public ProblemsService()
        {
            initDefaults();
        }

        public Problem GetNext()
        {
            currentProblemIndex++;
            if (currentProblemIndex == problems.Count)
            {
                currentProblemIndex = 0;
            }
            return problems[currentProblemIndex];
        }

        void initDefaults()
        {

            double[] c91Vars = { 4, 5, 1, 2, 3, 1, 0 };
            double[] c92Vars = { 2, -10, 3, 1, 7,0,1 };
            double[] c93Vars = { 2, -2, 15, 2, -1,0,0 };

            double[][] consMatrx9 = new double[3][];
            consMatrx9[0] = c91Vars;
            consMatrx9[1] = c92Vars;
            consMatrx9[2] = c93Vars;

            string[] signs9 = { "=", "=", "=" };
            double[] freeVars9 = { 35, 12, 28 };

            double[] funcVars9 = { 15, -4, 1, -3, 2,0,0 };

            problems.Add(new Problem(consMatrx9, signs9, freeVars9, funcVars9, 0, true));

            double[] c51Vars = { 4, 5, 1, 2, 3 };
            double[] c52Vars = { 2, 15, -2, 1, -4 };
            double[] c53Vars = { 2, -2, 15, 2, -1 };

            double[][] consMatrx5 = new double[3][];
            consMatrx5[0] = c51Vars;
            consMatrx5[1] = c52Vars;
            consMatrx5[2] = c53Vars;

            string[] signs5 = { "<=", ">=", "=" };
            double[] freeVars5 = { 35, 23, 28 };

            double[] funcVars5 = { 15, -4, 1, -3, 2 };

            problems.Add(new Problem(consMatrx5, signs5, freeVars5, funcVars5, 0, true));

            double[] c1Vars = { 2, 3, 1, 2, 3 };
            double[] c2Vars = { 2, 15, 2, 1, -1 };
            double[] c3Vars = { 3, -2, 4, 2, -1 };

            double[][] consMatrx = new double[3][];
            consMatrx[0] = c1Vars;
            consMatrx[1] = c2Vars;
            consMatrx[2] = c3Vars;

            string[] signs = { "<=", "=", ">=" };
            double[] freeVars = { 35, 25, 16 };
            double[] funcVars = { 14, -22, 1, -3, 2 };

            problems.Add(new Problem(consMatrx, signs, freeVars, funcVars, 0, true));

            double[] c11Vars = { 2, 0, 5, 1, 8 };

            double[] c12Vars = { -3, 6, 2, -2, 0 };

            double[][] consMatrx1 = new double[2][];
            consMatrx1[0] = c11Vars;
            consMatrx1[1] = c12Vars;

            string[] signs1 = { "=", "<=" };
            double[] freeVars1 = { 12, 5 };

            double[] funcVars1 = { 2, -1, 7, 11, 5 };

            problems.Add(new Problem(consMatrx1, signs1, freeVars1, funcVars1, 0, false));

            double[] c21Vars = { 1, 1 };
            double[] c22Vars = { 2, 3 };
            double[] c23Vars = { 14, 30 };

            double[][] consMatrx2 = new double[3][];
            consMatrx2[0] = c21Vars;
            consMatrx2[1] = c22Vars;
            consMatrx2[2] = c23Vars;

            string[] signs2 = { "<=", "<=", "<=" };
            double[] freeVars2 = { 550, 1200, 9600 };

            double[] funcVars2 = { 3, 4 };

            problems.Add(new Problem(consMatrx2, signs2, freeVars2, funcVars2, 0, true));

            double[] c31Vars = { 1,1,-1 };
            double[] c32Vars = { 1,-1,2 };
            double[] c33Vars = { -2,-8,3 };

            double[][] consMatrx3 = new double[3][];
            consMatrx3[0] = c31Vars;
            consMatrx3[1] = c32Vars;
            consMatrx3[2] = c33Vars;

            string[] signs3 = { ">=", ">=", ">=" };
            double[] freeVars3 = { 8, 2, 1 };

            double[] funcVars3 = { 2, 1, -2 };

            problems.Add(new Problem(consMatrx3, signs3, freeVars3, funcVars3, 0, false));

            double[] c41Vars = { 0,-1,1,1,0 };
            double[] c42Vars = {-5,1,1,0, 0 };
            double[] c43Vars = { -8,1,2,0,-1 };

            double[][] consMatrx4 = new double[3][];
            consMatrx4[0] = c41Vars;
            consMatrx4[1] = c42Vars;
            consMatrx4[2] = c43Vars;

            string[] signs4 = { "=", "=", "=" };
            double[] freeVars4 = { 1,2,3 };

            double[] funcVars4 = { -3,1,4,0,0 };

            problems.Add(new Problem(consMatrx4, signs4, freeVars4, funcVars4, 0, true));

            double[] c61Vars = { 1,1,-3,1,-1 };
            double[] c62Vars = { 6,-3,-1,-2,2 };
            double[] c63Vars = { 3,-2,1,2,3 };

            double[][] consMatrx6 = new double[3][];
            consMatrx6[0] = c61Vars;
            consMatrx6[1] = c62Vars;
            consMatrx6[2] = c63Vars;

            string[] signs6 = { "=", ">=", "<=" };
            double[] freeVars6 = { 4,2,8 };

            double[] funcVars6 = {2,3,-3,1,0 };

            problems.Add(new Problem(consMatrx6, signs6, freeVars6, funcVars6, 0, true));

        }
    }
}
