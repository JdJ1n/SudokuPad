using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class CommandeInvoker
    {
        private static CommandeInvoker instance;
        public static CommandeInvoker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandeInvoker();
                }
                return instance;
            }
        }

        private CommandeInvoker() { }
        private DoubleEndQueue<Subbox[,]> SudokuHistory = new DoubleEndQueue<Subbox[,]>(3);
        private Stack<Subbox[,]> UndidStack = new Stack<Subbox[,]>();

        public Subbox[,] Execute(ICommande command, Subbox[,] sudoku)
        {
            UndidStack.Clear();
            if (SudokuHistory.Count == 3) { SudokuHistory.RemoveHead(); }
            Subbox[,] temp = new Subbox[9, 9];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = new Subbox(sudoku[i, j]);
                }
            }
            SudokuHistory.AddTail(temp);
            command.Execute();
            return command.GetSudoku();
        }

        public Subbox[,] Undo(Subbox[,] sudoku)
        {
            if (SudokuHistory.Count == 0) { return sudoku; }
            Subbox[,] temp = new Subbox[9, 9];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = new Subbox(sudoku[i, j]);
                }
            }
            UndidStack.Push(temp);
            var su = SudokuHistory.RemoveTail();
            return su;
        }

        public Subbox[,] Redo(Subbox[,] sudoku)
        {
            if (UndidStack.Count == 0) { return sudoku; }
            Subbox[,] temp = new Subbox[9, 9];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = sudoku[i, j];
                }
            }
            SudokuHistory.AddTail(temp);
            return UndidStack.Pop();
        }
    }
}
