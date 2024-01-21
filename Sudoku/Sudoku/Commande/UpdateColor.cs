using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class UpdateColor : ICommande
    {
        private Subbox[,] sudo;
        private int[,] coord;
        private string donnee;

        public UpdateColor(Subbox[,] sudoku, int[,] coord, string donnee)
        {
            sudo = sudoku;
            this.coord = coord;
            this.donnee = donnee;
        }

        public void Execute()
        {
            for (int i = 0; i < coord.GetLength(0); i++)
            {
                if (coord[i, 0] != 0 && coord[i, 1] != 0)
                {
                    sudo[coord[i, 0] - 1, coord[i, 1] - 1] = sudo[coord[i, 0] - 1, coord[i, 1] - 1].SetColor(int.Parse(donnee));
                }
            }
        }

        public Subbox[,] GetSudoku()
        {
            return sudo;
        }
    }
}
