using Sudoku.Judge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Import
    {
        private readonly Subbox[,] sudoku = new Subbox[9, 9];
        public Subbox[,] ImportData(FuncExcel excel)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Center center = new Center(excel.GetCenter(i, j));
                    Corner corner = new Corner(excel.GetCorner(i, j));
                    sudoku[i, j] = new Subbox(i+1, j+1, excel.ReadCell(i, j), excel.GetCellColor(i, j), corner, center);
                }
            }
            return sudoku;
        }
    }
}
