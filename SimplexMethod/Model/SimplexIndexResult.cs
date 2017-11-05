using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class SimplexIndexResult
    {
        public Tuple<int, int> index;
        public SimplexResult result;

        public SimplexIndexResult(Tuple<int, int> index, SimplexResult result)
        {
            this.index = index;
            this.result = result;
        }
    }
}
