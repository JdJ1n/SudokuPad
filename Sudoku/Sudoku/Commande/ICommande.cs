using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public interface ICommande
    {
        void Execute();
        Subbox[,] GetSudoku();
    }
}
