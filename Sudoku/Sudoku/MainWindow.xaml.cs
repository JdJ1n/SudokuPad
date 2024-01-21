using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Sudoku.Judge;

namespace Sudoku
{
    public partial class MainWindow : Window
    {
        private static Subbox[,] sudoku = new Subbox[9, 9];
        public int x = 0;
        public int y = 0;
        public int status = 0;
        public int laststatus = 0;
        public int[,] coord = new int[,] { { 0, 0 } };
        public bool multi = false;
        private CommandeInvoker invoker = CommandeInvoker.Instance;
        private CommandeLoggerFactory clf = new CommandeLoggerFactory();

        public MainWindow()
        {
            InitializeComponent();
            InitializeSudoku();
            InitializeSudokuButton();
            InitializeStatusButton();
            InitializeInputButton();
        }

        private void InitializeSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = new Subbox(i, j, "", 0);
                }
            }
        }

        private void InitializeSudokuButton()
        {
            for (int i = 0; i < SudokuPanel.Children.Count; i++)
            {
                if (SudokuPanel.Children[i] is Grid g)
                {
                    for (int j = 0; j < g.Children.Count; j++)
                    {
                        if (g.Children[j] is SubBox b)
                        {
                            b.SetTag(b.Name);
                            b.GetButton().Click += new RoutedEventHandler(SudokuButtonClick);
                        }
                    }
                }
            }
        }

        private void SudokuButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBEE6FD"));
            b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF414141"));
            string[] name = ((string)b.Tag).Split('_');
            x = int.Parse(name[1]);
            y = int.Parse(name[2]);
            if (multi == false)
            {
                coord[0, 0] = x;
                coord[0, 1] = y;
            }
            else
            {
                bool hascoord = false;
                for (int i = 0; i < coord.GetLength(0); i++) { if (coord[i, 0] == x && coord[i, 1] == y) { coord = RemoveIndices(coord, i); hascoord = true; } }
                if (!hascoord) {
                    coord = AddIndices(coord, x, y);
                }
            }
            UpdateTable();
        }

        private int[,] RemoveIndices(int[,] IndicesArray, int RemoveAt)
        {
            int[,] newIndicesArray = new int[IndicesArray.GetLength(0) - 1, IndicesArray.GetLength(1)];
            int i = 0;
            int j = 0;
            while (i < IndicesArray.GetLength(0))
            {
                if (i != RemoveAt)
                {
                    newIndicesArray[j, 0] = IndicesArray[i, 0];
                    newIndicesArray[j, 1] = IndicesArray[i, 1];
                    j++;
                }
                i++;
            }
            return newIndicesArray;
        }

        private int[,] AddIndices(int[,] IndicesArray, int ax,int ay)
        {
            int[,] newIndicesArray = new int[IndicesArray.GetLength(0) + 1, IndicesArray.GetLength(1)];
            int i = 0;
            while (i < IndicesArray.GetLength(0))
            {
                newIndicesArray[i, 0] = IndicesArray[i, 0];
                newIndicesArray[i, 1] = IndicesArray[i, 1];
                i++;
            }
            newIndicesArray[i, 0] = ax;
            newIndicesArray[i, 1] = ay;
            return newIndicesArray;
        }

        private void InitializeStatusButton()
        {
            for (int i = 0; i < InputStatus.Children.Count; i++)
            {
                if (InputStatus.Children[i] is CheckBox b)
                {
                    b.IsChecked = i == status;
                    b.Click += new RoutedEventHandler(StatusButtonClick);
                }
            }
        }

        private void StatusButtonClick(object sender, RoutedEventArgs e)
        {
            CheckBox b = (CheckBox)sender;
            if (status != int.Parse(b.Tag.ToString()))
            {
                laststatus = status;
                status = int.Parse(b.Tag.ToString());
                InitializeStatusButton();
            }
            else { b.IsChecked = true; }
            InitializeInputButton();
        }

        private void InitializeInputButton()
        {
            for (int i = 0; i < InputPanel.Children.Count; i++)
            {
                if (InputPanel.Children[i] is Button b)
                {
                    try { b.Click -= InputButtonClick0; } catch { }
                    try { b.Click -= InputButtonClick1; } catch { }
                    try { b.Click -= InputButtonClick2; } catch { }
                    try { b.Click -= InputButtonClick3; } catch { }
                    switch (status)
                    {
                        case 0:
                            b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SwitchColor(0)));
                            b.Click += new RoutedEventHandler(InputButtonClick0);
                            break;
                        case 1:
                            b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SwitchColor(0)));
                            b.Click += new RoutedEventHandler(InputButtonClick1);
                            break;
                        case 2:
                            b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SwitchColor(0)));
                            b.Click += new RoutedEventHandler(InputButtonClick2);
                            break;
                        default:
                            string[] name = b.Name.Split('_');
                            b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SwitchColor(int.Parse(name[1]))));
                            b.Click += new RoutedEventHandler(InputButtonClick3);
                            break;
                    }
                }
            }
        }

        private void InputButtonClick0(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string[] name = b.Name.Split('_');
            ICommande commande = clf.UpdateDigit(sudoku, coord, name[1]);
            sudoku = invoker.Execute(commande, sudoku);
            UpdateTable();
        }

        private void InputButtonClick1(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string[] name = b.Name.Split('_');
            ICommande commande = clf.UpdateCorner(sudoku, coord, name[1]);
            sudoku = invoker.Execute(commande, sudoku);
            UpdateTable();
        }

        private void InputButtonClick2(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string[] name = b.Name.Split('_');
            ICommande commande = clf.UpdateCenter(sudoku, coord, name[1]);
            sudoku = invoker.Execute(commande, sudoku);
            UpdateTable();
        }

        private void InputButtonClick3(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string[] name = b.Name.Split('_');
            ICommande commande = clf.UpdateColor(sudoku, coord, name[1]);
            sudoku = invoker.Execute(commande, sudoku);
            UpdateTable();
        }

        private void UpdateTable()
        {
            bool[,] legals = new JudgeTable(sudoku).GetLegalTable();
            for (int i = 0; i < SudokuPanel.Children.Count; i++)
            {
                if (SudokuPanel.Children[i] is Grid g)
                {
                    for (int j = 0; j < g.Children.Count; j++)
                    {
                        if (g.Children[j] is SubBox b)
                        {
                            int sx = int.Parse(b.Name.Split('_')[1]) - 1;
                            int sy = int.Parse(b.Name.Split('_')[2]) - 1;

                            b.SetCorner(sudoku[sx, sy].Corner.GetCornerNbs().Skip(1));
                            string center = "";
                            foreach (int cen in sudoku[sx, sy].Center.GetCenterNbs().Skip(1))
                            {
                                center += cen.ToString();
                            }
                            b.SetCenter(center);
                            if (!legals[sx, sy])
                            {
                                b.GetButton().Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                            }
                            else
                            {
                                b.GetButton().Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SwitchColor(sudoku[sx, sy].Color)));
                                b.GetButton().BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0E0E0"));
                                b.GetButton().BorderThickness = new Thickness(0.0);

                                for (int k = 0; k < coord.GetLength(0); k++)
                                {
                                    if (sx == coord[k, 0] - 1 && sy == coord[k, 1] - 1)
                                    {
                                        b.GetButton().BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF414141"));
                                        b.GetButton().BorderThickness = new Thickness(4.0);
                                    }
                                }
                            }
                            b.SetValue(sudoku[sx, sy].Value.Trim());
                            if ((string)b.GetButton().Content != "") { b.AllHidden(); } else { b.AllVisible(); }
                        }
                    }
                }
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            ICommande commande = clf.UpdateDelete(sudoku, coord, status);
            sudoku = invoker.Execute(commande, sudoku);
            UpdateTable();
        }

        private void MultiClick(object sender, RoutedEventArgs e)
        {
            CheckBox b = (CheckBox)sender;
            if (multi == false)
            {
                multi = true; b.IsChecked = true;
                x = 0;
                y = 0;
                coord = new int[,] { { 0, 0 } };
            }
            else
            {
                multi = false; b.IsChecked = false;
                x = 0;
                y = 0;
                coord = new int[,] { { 0, 0 } };
            }
        }

        private void ImportClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog import = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "EXCEL file (*.xlsx)|*.xlsx"
            };
            if (import.ShowDialog().GetValueOrDefault())
            {
                FuncExcel excel = new FuncExcel(import.FileName, 1);
                sudoku = new Import().ImportData(excel);
                excel.Close();
                UpdateTable();
                _ = MessageBox.Show("Sudoku loaded successfully!");
            }
        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "EXCEL file (*.xlsx)|*.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                FuncExcel excel = new FuncExcel();
                excel.CreateNewFile();
                excel = new Export().ExportData(sudoku);
                excel.SaveAs(saveFileDialog.FileName);
                excel.Close();
                _ = MessageBox.Show("Sudoku saved successfully!");
            }
        }

        private void UndoClick(object sender, RoutedEventArgs e)
        {
            sudoku = invoker.Undo(sudoku);
            UpdateTable();
        }

        private void RedoClick(object sender, RoutedEventArgs e)
        {
            sudoku = invoker.Redo(sudoku);
            UpdateTable();
        }

        public static string SwitchColor(int boxcolor)
        {
            return boxcolor switch
            {
                1 => "#FFFF6B04",
                2 => "#FFFFA500",
                3 => "#FFFFFF00",
                4 => "#FF00FF00",
                5 => "#FF00FFFF",
                6 => "#FF68E2E8",
                7 => "#FF800080",
                8 => "#FF808080",
                9 => "#FF999900",
                _ => "#FFFFFFFF",
            };
        }
    }
}
