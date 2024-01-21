using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class JudgeTable : IJudge
    {
        private IEnumerable<Subbox> items = new Subbox[0];
        private readonly Subbox[,] subboxes = new Subbox[9, 9];

        public JudgeTable(Subbox[,] table)
        {
            subboxes = table;
            foreach (Subbox s in subboxes)
            {
                items = items.Append(s);
            }
        }
        public bool IsLegal(Subbox sub)
        {
            List<Subbox>judges= items.ToList();
            return sub.Value == "" || (judges.Where(n => n.Box == sub.Box).Count(n => n.Value == sub.Value) == 1 &&
                judges.Where(n => n.Row == sub.Row).Count(n => n.Value == sub.Value) == 1 &&
                judges.Where(n => n.Column == sub.Column).Count(n => n.Value == sub.Value) == 1);
        }

        public bool[,] GetLegalTable()
        {
            bool[,] illegals = new bool[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    illegals[i, j] = IsLegal(subboxes[i, j]);
                }
            }
            return illegals;
        }
    }
}
