using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class UpdateCorner: ICommande
    {
        private Subbox[,] sudo;
        private int[,] coord;
        private string donnee;

        public UpdateCorner(Subbox[,] sudoku, int[,] coord, string donnee)
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
                    Subbox t = sudo[coord[i, 0] - 1, coord[i, 1] - 1];
                    Subbox ch = new Subbox(t.Row, t.Column, t.Value, t.Color, t.Corner, t.Center);
                    if (ch.Corner.GetCornerNbs().Count() < 6)
                    {
                        if (ch.Corner.Contains(int.Parse(donnee)))
                        {
                            ch = ch.SetCorner(ch.Corner.Delete(int.Parse(donnee)));
                        }
                        else if (ch.Corner.GetCornerNbs().Count() < 5) { ch = ch.SetCorner(ch.Corner.Add(int.Parse(donnee))); }
                        sudo[coord[i, 0] - 1, coord[i, 1] - 1] = ch;
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
