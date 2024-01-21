using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Judge
{
    public class Subbox
    {
        public readonly string Value;
        public readonly int Row;
        public readonly int Column;
        public readonly int Box;
        public Corner Corner { get; private set; }
        public Center Center { get; private set; }
        public readonly int Color;

        public Subbox(int x, int y, string z, int c)
        {
            Row = x + 1;
            Column = y + 1;
            Value = z;
            Color = c;
            Corner = new Corner();
            Center = new Center();

            if (1 <= Row && Row <= 3 && 1 <= Column && Column <= 3)
            {
                Box = 1;
            }
            else if (4 <= Row && Row <= 6 && 1 <= Column && Column <= 3)
            {
                Box = 2;
            }
            else if (7 <= Row && Row <= 9 && 1 <= Column && Column <= 3)
            {
                Box = 3;
            }
            else if (1 <= Row && Row <= 3 && 4 <= Column && Column <= 6)
            {
                Box = 4;
            }
            else if (4 <= Row && Row <= 6 && 4 <= Column && Column <= 6)
            {
                Box = 5;
            }
            else if (7 <= Row && Row <= 9 && 4 <= Column && Column <= 6)
            {
                Box = 6;
            }
            else if (1 <= Row && Row <= 3 && 7 <= Column && Column <= 9)
            {
                Box = 7;
            }
            else if (4 <= Row && Row <= 6 && 7 <= Column && Column <= 9)
            {
                Box = 8;
            }
            else if (7 <= Row && Row <= 9 && 7 <= Column && Column <= 9)
            {
                Box = 9;
            }
        }

        public Subbox(int x, int y, string z, int c, Corner cor, Center cen)
        {
            Row = x;
            Column = y;
            Value = z;
            Color = c;
            Corner = new Corner(cor.corner);
            Center = new Center(cen.center);

            if (1 <= Row && Row <= 3 && 1 <= Column && Column <= 3)
            {
                Box = 1;
            }
            else if (4 <= Row && Row <= 6 && 1 <= Column && Column <= 3)
            {
                Box = 2;
            }
            else if (7 <= Row && Row <= 9 && 1 <= Column && Column <= 3)
            {
                Box = 3;
            }
            else if (1 <= Row && Row <= 3 && 4 <= Column && Column <= 6)
            {
                Box = 4;
            }
            else if (4 <= Row && Row <= 6 && 4 <= Column && Column <= 6)
            {
                Box = 5;
            }
            else if (7 <= Row && Row <= 9 && 4 <= Column && Column <= 6)
            {
                Box = 6;
            }
            else if (1 <= Row && Row <= 3 && 7 <= Column && Column <= 9)
            {
                Box = 7;
            }
            else if (4 <= Row && Row <= 6 && 7 <= Column && Column <= 9)
            {
                Box = 8;
            }
            else if (7 <= Row && Row <= 9 && 7 <= Column && Column <= 9)
            {
                Box = 9;
            }
        }

        public Subbox(Subbox sub)
        {
            Row = sub.Row;
            Column = sub.Column;
            Value = sub.Value;
            Color = sub.Color;
            Corner = new Corner(sub.Corner.corner);
            Center = new Center(sub.Center.center);

            if (1 <= Row && Row <= 3 && 1 <= Column && Column <= 3)
            {
                Box = 1;
            }
            else if (4 <= Row && Row <= 6 && 1 <= Column && Column <= 3)
            {
                Box = 2;
            }
            else if (7 <= Row && Row <= 9 && 1 <= Column && Column <= 3)
            {
                Box = 3;
            }
            else if (1 <= Row && Row <= 3 && 4 <= Column && Column <= 6)
            {
                Box = 4;
            }
            else if (4 <= Row && Row <= 6 && 4 <= Column && Column <= 6)
            {
                Box = 5;
            }
            else if (7 <= Row && Row <= 9 && 4 <= Column && Column <= 6)
            {
                Box = 6;
            }
            else if (1 <= Row && Row <= 3 && 7 <= Column && Column <= 9)
            {
                Box = 7;
            }
            else if (4 <= Row && Row <= 6 && 7 <= Column && Column <= 9)
            {
                Box = 8;
            }
            else if (7 <= Row && Row <= 9 && 7 <= Column && Column <= 9)
            {
                Box = 9;
            }
        }

        public Subbox SetValue(string v)
        {
            return new Subbox(Row, Column, v, Color, Corner, Center);
        }

        public Subbox SetCorner(Corner cor)
        {
            return new Subbox(Row, Column, Value, Color, cor, Center);
        }

        public Subbox SetCenter(Center cen)
        {
            return new Subbox(Row, Column, Value, Color, Corner, cen);
        }

        public Subbox SetColor(int c)
        {
            return new Subbox(Row, Column, Value, c, Corner, Center);
        }
    }
}