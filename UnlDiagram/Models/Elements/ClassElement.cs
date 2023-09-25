using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlDiagram.Models.Parameters;
using UnlDiagram.Views;

namespace UnlDiagram.Models.Elements
{
    public class ClassElement : Element
    {
        public string Name { get; set; }
        public List<ClassVariable> Variables { get; set; } = new List<ClassVariable>();
        public List<MethodVariable> Methods { get; set; } = new List<MethodVariable>();

        public float LastX = 0;
        public float LastY = 0;

        public ClassElement(PointF location, int width, int height, string name) : base(location, width, height)
        {
            Name = name;
        }

        public ClassElement()
        {
            Name = "?";
        }

        public void GetActions(ref ContextMenuStrip toolStrip, MainForm parent)
        {
            var items = toolStrip.Items;
            items.Clear();

            //edit
            var edit = new ToolStripButton("Edit");
            edit.Click += (s, e) =>
            {
                //Debug.WriteLine(this);
                var editForm = new EditForm(this);
                editForm.ShowDialog();
            };
            items.Add(edit);

            //Delete
            var delete = new ToolStripButton("Delete");
            delete.Click += (s, e) =>
            {
                Visible = false;
                IsDeleted = true;
                parent.View.Refresh();
            };
            items.Add(delete);

            //MoveUp
            var moveUp = new ToolStripButton("Move UP");
            if (parent.ClassElements.Max(x => x.DisplayOrder) == DisplayOrder) moveUp.Enabled = false;
            moveUp.Click += (s, e) =>
            {
                this.DisplayOrder += 2;
                parent.View.Refresh();
            };
            items.Add(moveUp);

            //MoveDown
            var moveDown = new ToolStripButton("Move DOWN");
            if (parent.ClassElements.Min(x => x.DisplayOrder) == DisplayOrder) moveDown.Enabled = false;
            moveDown.Click += (s, e) =>
            {
                this.DisplayOrder -= 2;
                parent.View.Refresh();
            };
            items.Add(moveDown);
        }

        public void Draw(Graphics g)
        {
            if(!Visible) return;

            if (Width < MinWidth)
            {
                Width = MinWidth;
                Location = new PointF(LastX, Location.Y) ;
            }

            if (Height < MinHeight)
            {
                Height = MinHeight;
                Location = new PointF(Location.X, LastY);
            }

            #region DrawRectangles

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

            #endregion

            #region DrawHeader
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


            #endregion


            //Draw variables
            var row = 0;
            List<string> writtenText = new List<string>();

            #region DrawVariables
            foreach (var classVariable in Variables)
            {
                writtenText.Add(classVariable.ToString());
                g.DrawString(
                    classVariable.ToString(),
                    Font,
                    Brushes.Black,
                    new RectangleF(
                        Location.X,
                        Location.Y + Font.Height + 5 + row * 20,
                        Width,
                        Font.Height + 5
                    )
                );
                row++;
            }


            #endregion

            if (row != 0 && Methods.Count > 0)
            {
                g.DrawLine(
                    Pens.Black,
                    Location.X,
                    Location.Y + Font.Height + 12 + row * 20,
                    Location.X + Width,
                    Location.Y + Font.Height + 12 + row * 20);
            }

            #region DrawMethods

            foreach (var method in Methods)
            {
                writtenText.Add(method.ToString());
                g.DrawString(
                    method.ToString(),
                    Font,
                    Brushes.Black,
                    new RectangleF(
                        Location.X,
                        Location.Y + Font.Height + 13 + row * 20,
                        Width,
                        Font.Height + 13
                    )
                );
                row++;
            }

            #endregion


            if (DisplayDots)
            {
                g.FillRectangle(Brushes.Beige,Location.X - 6,Location.Y - 6, 12,12);
                g.FillRectangle(Brushes.Beige, RightTop.X -6 , RightTop.Y - 6, 12, 12);
                g.FillRectangle(Brushes.Beige, LeftBottom.X - 6, LeftBottom.Y - 6, 12, 12);
                g.FillRectangle(Brushes.Beige, RightBottom.X - 6, RightBottom.Y - 6, 12, 12);
            }


            if (writtenText.Count > 0)
            {
                var longestText = writtenText.OrderByDescending(x => TextRenderer.MeasureText(x, Font).Width).First();
                MinWidth = TextRenderer.MeasureText(longestText, Font).Width + 50;
            }
            MinHeight = row * 20 + 50;

            LastX = Location.X;
            LastY = Location.Y;
        }
        
    }
}
