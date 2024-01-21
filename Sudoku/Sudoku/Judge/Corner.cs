using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Judge
{
    public class Corner
    {
        private readonly int init = 0;
        public IEnumerable<int> corner = new int[0];
        public Corner() { corner = corner.Append(init); }

        public bool Contains(int nb)
        {
            return corner.Contains(nb);
        }

        public Corner Delete(int nb)
        {
            return new Corner(corner.Where(n => n != nb));
        }

        public Corner Add(int nb)
        {
            return new Corner(corner.Append(nb));
        }

        public IEnumerable<int> GetCornerNbs()
        {
            IOrderedEnumerable<int> results = corner.OrderBy(n => n);
            return results;
        }

        public Corner(IEnumerable<int> cor)
        {
            IEnumerable<int> cn = new int[0];
            foreach (int v in cor)
            {
                cn = cn.Append(v);
            }
            corner = cn;
        }

        public override string ToString()
        {
            string cent = "";
            foreach (var i in corner)
                cent += Convert.ToString(i);
            return cent;
        }
    }
}