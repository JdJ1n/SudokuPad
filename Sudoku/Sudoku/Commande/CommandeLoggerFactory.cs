using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class CommandeLoggerFactory: ICommandeFactory
    {
        public ICommande UpdateDigit(Subbox[,] sudoku, int[,] coord, string donnee)
            => new CommandLogger(new UpdateDigit(sudoku, coord, donnee), sudoku);
        public ICommande UpdateCenter(Subbox[,] sudoku, int[,] coord, string donnee)
            => new CommandLogger(new UpdateCenter(sudoku, coord, donnee), sudoku);
        public ICommande UpdateCorner(Subbox[,] sudoku, int[,] coord, string donnee)
            => new CommandLogger(new UpdateCorner(sudoku, coord, donnee), sudoku);
        public ICommande UpdateColor(Subbox[,] sudoku, int[,] coord, string donnee)
            => new CommandLogger(new UpdateColor(sudoku, coord, donnee), sudoku);
        public ICommande UpdateDelete(Subbox[,] sudoku, int[,] coord, int status)
            => new CommandLogger(new UpdateDelete(sudoku, coord, status), sudoku);
    }
}
