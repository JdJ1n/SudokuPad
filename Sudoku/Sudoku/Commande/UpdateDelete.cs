using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class UpdateDelete : ICommande
    {
        private Subbox[,] sudo;
        private int[,] coord;
        private int status;

        public UpdateDelete(Subbox[,] sudoku, int[,] coord, int status)
        {
            sudo = sudoku;
            this.coord = coord;
            this.status = status;
        }

        public void Execute()
        {
            for (int i = 0; i < coord.GetLength(0); i++)
            {
                if (coord[i, 0] != 0 && coord[i, 1] != 0)
                {
                    switch (status)
                    {
                        case 0:
                            sudo[coord[i, 0] - 1, coord[i, 1] - 1] = sudo[coord[i, 0] - 1, coord[i, 1] - 1].SetValue("");
                            break;
                        case 1:
                            sudo[coord[i, 0] - 1, coord[i, 1] - 1] = sudo[coord[i, 0] - 1, coord[i, 1] - 1].SetCorner(new Corner());
                            break;
                        case 2:
                            sudo[coord[i, 0] - 1, coord[i, 1] - 1] = sudo[coord[i, 0] - 1, coord[i, 1] - 1].SetCenter(new Center());
                            break;
                        case 3:
                            sudo[coord[i, 0] - 1, coord[i, 1] - 1] = sudo[coord[i, 0] - 1, coord[i, 1] - 1].SetColor (0);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public Subbox[,] GetSudoku()
        {
            return sudo;
        }
    }
}
