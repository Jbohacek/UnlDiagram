using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlDiagram.Models.Parameters;

namespace UnlDiagram.Models.Elements
{
    public class ClassElement : Element
    {
        public string Name { get; set; }
        public List<ClassVariable> Variables { get; set; } = new List<ClassVariable>();
        public List<MethodVariable> Methods { get; set; } = new List<MethodVariable>();

        public ClassElement(PointF location, int width, int height, string name) : base(location, width, height)
        {
            Name = name;
        }

        public ClassElement()
        {
            Name = "?";
        }

        public void Draw(Graphics g)
        {
            //Draw rectangle
            g.FillRectangle(
                new SolidBrush(Color),
                Location.X,
                Location.Y,
                Width,
                Height);

            g.DrawRectangle(
                Pens.Black,
                Location.X,
                Location.Y,
                Width,
                Height);
            

            //DrawText
            StringFormat centerFormat = new StringFormat();
            centerFormat.LineAlignment = StringAlignment.Center;
            centerFormat.Alignment = StringAlignment.Center;

            g.DrawRectangle(
                Pens.Black,
                Location.X,
                Location.Y,
                Width,
                Font.Height + 5);

            g.DrawString(
                Name,
                Font,
                Brushes.Black,
                new RectangleF(
                    Location.X,
                    Location.Y,
                    Width,
                    Font.Height + 5
                    ),
                centerFormat);

            if (DisplayDots)
            {
                g.FillRectangle(Brushes.Beige,Location.X - 6,Location.Y - 6, 12,12);
                g.FillRectangle(Brushes.Beige, RightTop.X -6 , RightTop.Y - 6, 12, 12);
                g.FillRectangle(Brushes.Beige, LeftBottom.X - 6, LeftBottom.Y - 6, 12, 12);
                g.FillRectangle(Brushes.Beige, RightBottom.X - 6, RightBottom.Y - 6, 12, 12);
            }
        }
        
    }
}
