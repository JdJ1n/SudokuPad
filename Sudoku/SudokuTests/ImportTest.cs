using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Input;
using Sudoku.Judge;
using System.IO;

namespace SudokuTests
{
    [TestClass]
    public class ImportTest
    {
        private readonly Subbox[,] sudokupre = new Subbox[9, 9];
        private Subbox[,] sudokuimp = new Subbox[9, 9];
        [TestInitialize]
        public void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudokupre[i, j] = new Subbox(i, j, "", 0);
                }
            }
        }
        public void Set(int x, int y, string z)
        {
            sudokupre[x - 1, y - 1] = new Subbox(x - 1, y - 1, z, 0);
        }

        public bool AreEqual(Subbox[,] subboxes1, Subbox[,] subboxes2)
        {
            bool identity = true;
            foreach (Subbox s in subboxes1) {
                if (s.Value != subboxes2[s.Row - 1, s.Column - 1].Value) {
                    identity = false;
                }
            }
            return identity;
        }

        public static string GetProjectRootPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            return rootpath;
        }

        [TestMethod]
        public void TestImport1()
        {
            Set(1, 1, "1");
            Set(2, 2, "4");
            Set(3, 3, "9");
            sudokuimp = new Import().ImportData(new FuncExcel(GetProjectRootPath()+"SudokuTest1.xlsx", 1));
            Assert.IsTrue(AreEqual(sudokupre,sudokuimp));
        }

        [TestMethod]
        public void TestImport2()
        {
            sudokuimp = new Import().ImportData(new FuncExcel(GetProjectRootPath() + "SudokuTest1.xlsx", 1));
            Assert.IsFalse(AreEqual(sudokupre, sudokuimp));
        }
    }
}
