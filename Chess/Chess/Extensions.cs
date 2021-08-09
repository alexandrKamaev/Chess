using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    static class Extensions
    {

        public static Dictionary<int, string> dict = new Dictionary<int, string>() {
            { 1,"A"},
            {2, "B" },
            {3, "C" },
            {4, "D" },
            {5, "E" },
            {6, "F" },
            {7, "G" },
            {8, "H" }
        };
        public static bool OnBoard(this Point curPoint)
        {
            return curPoint.X >= 1 && curPoint.X <= 8 && curPoint.Y >= 1 && curPoint.Y <= 8;           
        }

        public static Point AddPoint(this ref Point curPoint, Point addPoint)
        {
            return curPoint = new Point(curPoint.X + addPoint.X, curPoint.Y + addPoint.Y);          
        }

        public static string GetValueChess(this Point point)
        {
            return $"{dict[point.Y]}{point.X}";
        }

        
    }


}
