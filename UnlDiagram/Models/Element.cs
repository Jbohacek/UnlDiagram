using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using UnlDiagram.Models.Enums;

namespace UnlDiagram.Models
{
    public class Element
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool CanBeDeleted { get; set; } = true;
        public bool CanMove { get; set; } = true;
        public bool DisplayDots { get; set; } = false;

        private static int _displayCount = 1;
        public int DisplayOrder { get; set; }

        //Gui
        public PointF Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public PointF LeftTop => Location;
        public PointF RightTop => new(Width + Location.X, Location.Y);
        public PointF LeftBottom => new(Location.X, Location.Y + Height);
        public PointF RightBottom => new(Location.X + Width, Location.Y + Height);

        public RectangleF Rec => new(Location.X, Location.Y, Width, Height);

        public Color Color { get; set; } = Color.White;
        public Font Font { get; set; } = new Font("Menlo", 16f, FontStyle.Regular);

        public Element()
        {
            
        }

        public Element(PointF location, int width, int height, int displayOrder = 0)
        {
            Id = Guid.NewGuid();
            Location = location;
            Width = width;
            Height = height;
            if (displayOrder == 0)
            {
                DisplayOrder = _displayCount;
                _displayCount++;
            }
            else
            {
                DisplayOrder = displayOrder;
            }
            
        }


        public bool IsIn(PointF cursorLocation, int offset = 0)
        {
            
            if (LeftTop.X - offset >= cursorLocation.X)
            {
                return false;
            }

            if (RightTop.X + offset <= cursorLocation.X)
            {
                return false;
            }

            if (LeftTop.Y - offset >= cursorLocation.Y)
            {
                return false;
            }

            if (LeftBottom.Y + offset <= cursorLocation.Y)
            {
                return false;
            }
            return true;
        }

        // Zmenšit kod
        public Cursor GetCloseCursor(int x, int y, int distance = 15)
        {
            if (GetDistance(LeftTop, new PointF(x, y)) < distance)
            {
                return Cursors.SizeNWSE;
            }
            if (GetDistance(LeftBottom, new PointF(x, y)) < distance)
            {
                return Cursors.SizeNESW;
            }
            if (GetDistance(RightBottom, new PointF(x, y)) < distance)
            {
                return Cursors.SizeNWSE;
            }
            if (GetDistance(RightTop, new PointF(x, y)) < distance)
            {
                return Cursors.SizeNESW;
            }

            return Cursors.Arrow;
            
        }

        public static double GetDistance(PointF point1, PointF point2)
        {
            double xDiff = point2.X - point1.X;
            double yDiff = point2.Y - point1.Y;
            return Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Id: {Id}");
            stringBuilder.AppendLine($"IsDeleted: {IsDeleted}");
            stringBuilder.AppendLine($"CanBeDeleted: {CanBeDeleted}");
            stringBuilder.AppendLine($"CanMove: {CanMove}");
            stringBuilder.AppendLine($"DisplayDots: {DisplayDots}");
            stringBuilder.AppendLine($"Location: {Location}");
            stringBuilder.AppendLine($"Width: {Width}");
            stringBuilder.AppendLine($"Height: {Height}");
            stringBuilder.AppendLine($"LeftTop: {LeftTop}");
            stringBuilder.AppendLine($"RightTop: {RightTop}");
            stringBuilder.AppendLine($"LeftBottom: {LeftBottom}");
            stringBuilder.AppendLine($"RightBottom: {RightBottom}");
            return stringBuilder.ToString();
        }

        public void WriteSelf()
        {
            Debug.WriteLine(this.ToString());
        }

        public static void FillVariableTypes(ref ComboBox combo)
        {
            combo.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(VariablesTypes)))
            {
                if (name != "Custom")
                {
                    combo.Items.Add(name);
                }
            }
        }

        public static void FillAccessTypes(ref ComboBox combo)
        {
            combo.Items.Clear();
            foreach (string name in Enum.GetNames(typeof(AccessModifiers)))
            {
                combo.Items.Add(name);
            }
        }
    }
}
