using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public interface ICommandeFactory
    {
        ICommande UpdateDigit(Subbox[,] sudoku, int[,] coord, string donnee);
        ICommande UpdateCenter(Subbox[,] sudoku, int[,] coord, string donnee);
        ICommande UpdateCorner(Subbox[,] sudoku, int[,] coord, string donnee);
        ICommande UpdateColor(Subbox[,] sudoku, int[,] coord, string donnee);
        ICommande UpdateDelete(Subbox[,] sudoku, int[,] coord, int status);
        
    }
}
