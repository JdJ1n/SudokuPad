using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using Sudoku.Judge;
using System;
using System.IO;

namespace SudokuTests
{
    [TestClass]
    public class ExportTest
    {
        private readonly Subbox[,] sudokuexp = new Subbox[9, 9];
        [TestInitialize]
        public void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudokuexp[i, j] = new Subbox(i, j, "", 1);
                }
            }
        }
        public void Set(int x, int y, string z)
        {
            sudokuexp[x - 1, y - 1] = new Subbox(x - 1, y - 1, z, 1);
        }

        public static string GetProjectRootPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            return rootpath;
        }

        [TestMethod]
        public void TestExport1()
        {
            Initialize();
            Set(1, 1, "1");
            Set(2, 2, "4");
            Set(3, 3, "9");
            FuncExcel export = new Export().ExportData(sudokuexp);
            Assert.AreEqual(new FuncExcel(GetProjectRootPath() + "SudokuTest1.xlsx", 1).ReadAllCell(), export.ReadAllCell());
        }

        [TestMethod]
        public void TestExport2()
        {
            Initialize();
            Assert.AreNotEqual(new FuncExcel(GetProjectRootPath() + "SudokuTest1.xlsx", 1).ReadAllCell(), new Export().ExportData(sudokuexp));
        }
    }
}
