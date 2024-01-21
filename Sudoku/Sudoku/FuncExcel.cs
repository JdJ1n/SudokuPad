using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class FuncExcel
    {
        string path = "";
        _Application excel = new Application();
        Workbook wb;
        Worksheet ws;

        public FuncExcel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public FuncExcel() { }

        public void CreateNewFile()
        {
            wb = excel.Workbooks.Add(true);
            ws = wb.ActiveSheet as Worksheet;
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            return ws.Cells[i, j].Value == null ? "" : Convert.ToString(ws.Cells[i, j].Value);
        }

        public IEnumerable<int> GetCenter(int i, int j)
        {
            i += 31;
            j += 31;
            string str = Convert.ToString(ws.Cells[i, j].Value);
            IEnumerable<int> center = new int[0];
            for (int n = 0; n < str.Length; n++)
            {
                if (!str.Contains("0") && n == 0)
                    center = center.Append(0);
                center = center.Append(int.Parse(str[n].ToString()));
            }
            return center;
        }

        public IEnumerable<int> GetCorner(int i, int j)
        {
            i += 41;
            j += 41;
            string str = Convert.ToString(ws.Cells[i, j].Value);
            IEnumerable<int> corner = new int[0];
            for (int n = 0; n < str.Length; n++)
            {
                if (!str.Contains("0") && n == 0)
                    corner = corner.Append(0);
                corner = corner.Append(int.Parse(str[n].ToString()));
            }
            return corner;
        }

        public string ReadAllCell()
        {
            String content = "";
            for(int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    content += ws.Cells[i, j].Value == null ? "" : Convert.ToString(ws.Cells[i, j].Value);
                }
            }
            return content;
        }

        public int GetCellColor(int i, int j)
        {
            var columnHeadingsRange = ws.Range[ws.Cells[i + 1 , j + 1], ws.Cells[i + 1, j + 1]];
            string color = columnHeadingsRange.Interior.Color.ToString();
            switch (color)
            {
                case "26367":
                    return 1;
                case "39423":
                    return 2;
                case "6750207":
                    return 3;
                case "3407718":
                    return 4;
                case "16776960":
                    return 5;
                case "13408512":
                    return 6;
                case "10027161":
                    return 7;
                case "9868950":
                    return 8;
                case "52428":
                    return 9;
                case "15395562":
                    return 0;
                default:
                    return 0;
            }
        }

        public void WriteCell(int i, int j, string value, Center center, Corner corner, int color)
        {
            i++;
            j++;
            ws.Cells[i, j].Value = value;
            ws.Cells[i + 30, j + 30].Value = center.ToString();
            ws.Cells[i + 40, j + 40].Value = corner.ToString();
            var columnHeadingsRange = ws.Range[ws.Cells[i,j], ws.Cells[i,j]];
            switch (color)
            {
                case 1:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FF6600");
                    break;
                case 2:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                    break;
                case 3:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FFFF66");
                    break;
                case 4:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#66FF33");
                    break;
                case 5:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#00FFFF");
                    break;
                case 6:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#0099CC");
                    break;
                case 7:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#990099");
                    break;
                case 8:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#969696");
                    break;
                case 9:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#CCCC00");
                    break;
                case 0:
                    columnHeadingsRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#EAEAEA");
                    break;
                default:
                    break;
            }
        }

        public void SaveAs(string path)
        {
            wb.Save();
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }
    }
}

