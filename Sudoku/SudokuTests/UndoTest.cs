using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sudoku;
using Sudoku.Judge;

namespace SudokuTests
{
    [TestClass]
    public class UndoTest
    {
        private Subbox[,] sudokuUndo = new Subbox[9, 9];
        private CommandeInvoker invoker = CommandeInvoker.Instance;
        private CommandeLoggerFactory clf = new CommandeLoggerFactory();
        private int[,] coord = new int[,] { { 1, 1 } };

        [TestInitialize]
        public void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudokuUndo[i, j] = new Subbox(i, j, "", 0);
                }
            }
        }

        public void Set(Subbox[,] sudo, int[,] coor, string value)
        {
            ICommande commande = clf.UpdateDigit(sudo, coor, value);
            sudokuUndo = invoker.Execute(commande, sudo);
        }

        [TestMethod]
        public void TestUndo1()
        {
            Initialize();
            Set(sudokuUndo, coord, "1");
            Set(sudokuUndo, coord, "4");
            sudokuUndo = invoker.Undo(sudokuUndo);
            Assert.AreEqual("1", sudokuUndo[coord[0, 0] - 1, coord[0, 1] - 1].Value);
        }

        [TestMethod]
        public void TestUndo2()
        {
            Initialize();
            Set(sudokuUndo, coord, "1");
            Set(sudokuUndo, coord, "2");
            Set(sudokuUndo, coord, "3");
            Set(sudokuUndo, coord, "4");
            Set(sudokuUndo, coord, "5");
            sudokuUndo = invoker.Undo(sudokuUndo);
            sudokuUndo = invoker.Undo(sudokuUndo);
            sudokuUndo = invoker.Undo(sudokuUndo);
            sudokuUndo = invoker.Undo(sudokuUndo);
            Assert.AreEqual("2", sudokuUndo[coord[0, 0] - 1, coord[0, 1] - 1].Value);
        }
    }
}