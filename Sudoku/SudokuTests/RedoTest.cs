using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sudoku;
using Sudoku.Judge;

namespace SudokuTests
{
    [TestClass]
    public class RedoTest
    {
        private Subbox[,] sudokuRedo = new Subbox[9, 9];
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
                    sudokuRedo[i, j] = new Subbox(i, j, "", 0);
                }
            }
        }
        public void Set(Subbox[,] sudo, int[,] coor, string value)
        {
            ICommande commande = clf.UpdateDigit(sudo, coor, value);
            sudokuRedo = invoker.Execute(commande, sudo);
        }

        [TestMethod]
        public void TestExport1()
        {
            Initialize();
            Set(sudokuRedo, coord, "1");
            Set(sudokuRedo, coord, "4");
            sudokuRedo = invoker.Undo(sudokuRedo);
            sudokuRedo = invoker.Redo(sudokuRedo);
            Assert.AreEqual("4", sudokuRedo[coord[0, 0] - 1, coord[0, 1] - 1].Value);
        }

        [TestMethod]
        public void TestExport2()
        {
            Initialize();
            Set(sudokuRedo, coord, "1");
            Set(sudokuRedo, coord, "2");
            Set(sudokuRedo, coord, "3");
            Set(sudokuRedo, coord, "4");
            Set(sudokuRedo, coord, "5");
            sudokuRedo = invoker.Undo(sudokuRedo);
            sudokuRedo = invoker.Undo(sudokuRedo);
            sudokuRedo = invoker.Undo(sudokuRedo);
            sudokuRedo = invoker.Redo(sudokuRedo);
            sudokuRedo = invoker.Redo(sudokuRedo);
            Assert.AreEqual("4", sudokuRedo[coord[0, 0] - 1, coord[0, 1] - 1].Value);
        }
    }
}
