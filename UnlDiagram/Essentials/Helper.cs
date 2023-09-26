using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlDiagram.Models.Enums;

namespace UnlDiagram.Essentials
{
    public static class Helper
    {
        public static double GetDistance(PointF point1, PointF point2) // Help class
        {
            double xDiff = point2.X - point1.X;
            double yDiff = point2.Y - point1.Y;
            return Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
        }

        public static void FillVariableTypes(ref ComboBox combo) // help class
        {
            combo.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(VariablesTypes)))
            {
                if (name != "Custom")
                {
                    combo.Items.Add(name.Substring(1));
                }
            }
        }

        public static void FillAccessTypes(ref ComboBox combo) // help class
        {
            combo.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(AccessModifiers)))
            {
                combo.Items.Add(name.Substring(1));
            }
        }

        public static bool ArePointsUnique(PointF p1, PointF p2, PointF p3, PointF p4) // help class
        {
            if (p1 == p2 || p1 == p3 || p1 == p4 || p2 == p3 || p2 == p4 || p3 == p4)
            {
                return false;
            }
            return true;
        }
    }
}
