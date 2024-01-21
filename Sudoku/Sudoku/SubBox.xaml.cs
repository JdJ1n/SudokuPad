using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku
{
    public partial class SubBox : UserControl
    {
        //new
        public SubBox()
        {
            InitializeComponent();
        }

        public Button GetButton()
        {
            return textBox;
        }

        public void SetValue(string value)
        {
            textBox.Content = value;
        }

        public void SetTag(string tag)
        {
            textBox.Tag = tag;
        }

        public void SetCenter(string cen)
        {
            textBoxCentre.Text = cen;
        }

        public void SetCorner(IEnumerable<int> cor)
        {
            switch (cor.Count())
            {
                case 1: textBoxLeftTop.Text = cor.First().ToString(); textBoxRightTop.Text = ""; textBoxLeftBottom.Text = ""; textBoxRightBottom.Text = ""; break;
                case 2: textBoxLeftTop.Text = cor.First().ToString(); textBoxRightTop.Text = cor.Last().ToString(); textBoxLeftBottom.Text = ""; textBoxRightBottom.Text = ""; break;
                case 3: textBoxLeftTop.Text = cor.First().ToString(); textBoxRightTop.Text = cor.ElementAt(1).ToString(); textBoxLeftBottom.Text = cor.Last().ToString(); textBoxRightBottom.Text = ""; break;
                case 4: textBoxLeftTop.Text = cor.First().ToString(); textBoxRightTop.Text = cor.ElementAt(1).ToString(); textBoxLeftBottom.Text = cor.ElementAt(2).ToString(); textBoxRightBottom.Text = cor.Last().ToString(); break;
                default: textBoxLeftTop.Text = ""; textBoxRightTop.Text = ""; textBoxLeftBottom.Text = ""; textBoxRightBottom.Text = ""; break;
            }
        }

        public void AllHidden()
        {
            textBoxCentre.Visibility = Visibility.Hidden;
            textBoxLeftBottom.Visibility = Visibility.Hidden;
            textBoxLeftTop.Visibility = Visibility.Hidden;
            textBoxRightBottom.Visibility = Visibility.Hidden;
            textBoxRightTop.Visibility = Visibility.Hidden;
        }

        public void AllVisible()
        {
            textBoxCentre.Visibility = Visibility.Visible;
            textBoxLeftBottom.Visibility = Visibility.Visible;
            textBoxLeftTop.Visibility = Visibility.Visible;
            textBoxRightBottom.Visibility = Visibility.Visible;
            textBoxRightTop.Visibility = Visibility.Visible;
        }
    }
}