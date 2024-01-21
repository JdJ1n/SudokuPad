using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using Sudoku.Judge;
using System;

namespace SudokuTests
{
    [TestClass]
    public class JudgeTest
    {
        private readonly Subbox[,] sudoku = new Subbox[9, 9];
        [TestInitialize]
        public void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = new Subbox(i, j, "", 0);
                }
            }
        }
        public void Set(int x, int y, string z)
        {
            sudoku[x - 1, y - 1] = new Subbox(x - 1, y - 1, z,0);
        }

        public bool IsLegal(int x, int y)
        {
            bool[,] legals = new JudgeTable(sudoku).GetLegalTable();
            return legals[x - 1, y - 1];
        }

        [TestMethod]
        public void TestJudge1()
        {
            Initialize();
            Assert.AreEqual(true, IsLegal(8, 9));
        }

        [TestMethod]
        public void TestJudge2()
        {
            Initialize();
            Set(8, 9, "8");
            Set(7, 7, "8");
            Assert.AreEqual(false, IsLegal(8, 9));
        }

        [TestMethod]
        public void TestJudge3()
        {
            Initialize();
            Set(8, 9, "8");
            Set(7, 7, "8");
            Assert.AreEqual(true, IsLegal(7, 9));
        }

        [TestMethod]
        public void TestJudge4()
        {
            Initialize();
            Set(8, 9, "8");
            Set(8, 1, "8");
            Assert.AreEqual(false, IsLegal(8, 9));
        }

        [TestMethod]
        public void TestJudge5()
        {
            Initialize();
            Set(8, 9, "8");
            Set(2, 9, "8");
            Assert.AreEqual(false, IsLegal(8, 9));
        }
    }
}
