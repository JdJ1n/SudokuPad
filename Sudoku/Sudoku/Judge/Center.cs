using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Judge
{
    public class Center
    {
        private readonly int init = 0;
        public IEnumerable<int> center = new int[0];
        public Center() { center = center.Append(init) ; }

        public bool Contains(int nb)
        {
            return center.Contains(nb);
        }

        public Center Delete(int nb)
        {
            return new Center(center.Where(n => n != nb));
        }

        public Center Add(int nb)
        {
            return new Center(center.Append(nb));
        }

        public IEnumerable<int> GetCenterNbs()
        {
            IOrderedEnumerable<int> results = center.OrderBy(n => n);
            return results;
        }

        public Center(IEnumerable<int> cen)
        {
            IEnumerable<int> ct = new int[0];
            foreach (int v in cen)
            {
                ct = ct.Append(v);
            }
            center = ct;
        }

        public override string ToString()
        {
            string cent = "";
            foreach (var i in center)
                cent += Convert.ToString(i);
            return cent;
        }
    }
}