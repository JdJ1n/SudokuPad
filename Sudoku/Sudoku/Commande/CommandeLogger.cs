using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class CommandLogger : ICommande
    {
        private ICommande command;
        private Subbox[,] sudo;

        public CommandLogger(ICommande command, Subbox[,] sudoku)
        {
            this.command = command;
            sudo = sudoku;
        }

        public void Execute()
        {
            command.Execute();
        }

        public Subbox[,] GetSudoku()
        {
            return sudo;
        }
    }
}
