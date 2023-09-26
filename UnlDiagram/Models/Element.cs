using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;
using UnlDiagram.Essentials;
using UnlDiagram.Models.Enums;

namespace UnlDiagram.Models
{
    public class Element
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool Visible { get; set; } = true;
        public bool CanMove { get; set; } = true;
        public bool DisplayDots { get; set; } = false;

        private static int _displayCount = 1;
        public int DisplayOrder { get; set; }

        //Gui
        public PointF Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int LastWidth { get; set; }
        public int LastHeight { get; set; }
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public PointF LastLocation { get; set; }

        //přidat X a Y

        [XmlIgnore] public PointF LeftTop => Location;
        [XmlIgnore] public PointF RightTop => new(Width + Location.X, Location.Y);
        [XmlIgnore] public PointF LeftBottom => new(Location.X, Location.Y + Height);
        [XmlIgnore] public PointF RightBottom => new(Location.X + Width, Location.Y + Height);

        public RectangleF Rec => new(Location.X, Location.Y, Width, Height);

        [XmlIgnore]
        public Color Color { get; set; } = Color.White;
        [XmlIgnore]
        public Font Font { get; set; } = new Font("Menlo", 16f, FontStyle.Regular);
        public ElementsStates PossibleState { get; set; } = ElementsStates.None;


        public Element()
        {
            
        }

        public Element(PointF location, int width, int height, int displayOrder = 0)
        {
            Id = Guid.NewGuid();
            Location = location;
            Width = width;
            Height = height;
            MinHeight = height;
            MinWidth = width;
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
            return LeftTop.X - offset < cursorLocation.X &&
                   RightTop.X + offset > cursorLocation.X &&
                   LeftTop.Y - offset < cursorLocation.Y &&
                   LeftBottom.Y + offset > cursorLocation.Y;
        }

        
        public Cursor GetCloseCursor(int x, int y, int distance = 15)
        {
            if (!Helper.ArePointsUnique(LeftTop, LeftBottom, RightBottom, RightTop))
            {
                return Cursors.SizeAll;
            }
            var corners = new Dictionary<PointF, Cursor>
            {
                { LeftTop, Cursors.SizeNWSE },
                { LeftBottom, Cursors.SizeNESW },
                { RightBottom, Cursors.SizeNWSE },
                { RightTop, Cursors.SizeNESW }
            };
            foreach (var corner in 
                     corners.Where(corner => Helper.GetDistance(corner.Key, new PointF(x, y)) < distance))
            {
                return corner.Value;
            }
            return Cursors.Arrow;
        }
        public ElementsStates GetCloseState(int x, int y, int distance = 15)
        {
            
            var corners = new Dictionary<PointF, ElementsStates>
            {
                { LeftTop, ElementsStates.ResizeLT },
                { LeftBottom, ElementsStates.ResizeLB },
                { RightBottom, ElementsStates.ResizeRB },
                { RightTop, ElementsStates.ResizeRT }
            };
            foreach (var corner in
                     corners.Where(corner => Helper.GetDistance(corner.Key, new PointF(x, y)) < distance))
            {
                return corner.Value;
            }

            return ElementsStates.Moving;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Id: {Id}");
            stringBuilder.AppendLine($"IsDeleted: {IsDeleted}");
            stringBuilder.AppendLine($"Visible: {Visible}");
            stringBuilder.AppendLine($"CanMove: {CanMove}");
            stringBuilder.AppendLine($"DisplayDots: {DisplayDots}");
            stringBuilder.AppendLine($"DisplayOrder: {DisplayOrder}");
            stringBuilder.AppendLine($"Location: {Location}");
            stringBuilder.AppendLine($"Width: {Width}");
            stringBuilder.AppendLine($"Height: {Height}");
            stringBuilder.AppendLine($"LeftTop: {LeftTop}");
            stringBuilder.AppendLine($"RightTop: {RightTop}");
            stringBuilder.AppendLine($"LeftBottom: {LeftBottom}");
            stringBuilder.AppendLine($"RightBottom: {RightBottom}");
            return stringBuilder.ToString();
        }
    }
}
