using Sudoku.Judge;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Export
    {
        public FuncExcel ExportData(Subbox[,] dataexport)
        {
            FuncExcel excel = new FuncExcel();
            excel.CreateNewFile();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    excel.WriteCell(i, j, Convert.ToString(dataexport[i, j].Value), dataexport[i,j].Center, dataexport[i,j].Corner,dataexport[i,j].Color);
                }
            }
            return excel;
        }
    }
}
