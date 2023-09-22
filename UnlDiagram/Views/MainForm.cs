using System.Diagnostics.Eventing.Reader;
using UnlDiagram.Models;
using UnlDiagram.Models.Elements;

namespace UnlDiagram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        readonly List<ClassElement> _classElements = new List<ClassElement>();


        private void MainView_Paint(object sender, PaintEventArgs e)
        {
            foreach (var classElement in _classElements.OrderBy(x => x.DisplayOrder))
            {
                classElement.Draw(e.Graphics);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var pak = new ClassElement(new PointF(50, 50), 200, 300, "Pokus");
            _classElements.Add(pak);
            MainView.Refresh();
        }

        private Element? _sElement = null;
        private float _xoffSet = 0;
        private float _yoffSet = 0;

        private void MainView_MouseDown(object sender, MouseEventArgs e)
        {
            var selected = _classElements.Where(x => x.IsIn(new PointF(e.X, e.Y)) == true);
            var selectedItem = selected?.MaxBy(x => x.DisplayOrder);
            if (selectedItem != null)
            {
                _sElement = selectedItem;
                _xoffSet = e.X - _sElement.Location.X;
                _yoffSet = e.Y - _sElement.Location.Y;
            }

        }

        private void MainView_MouseUp(object sender, MouseEventArgs e)
        {
            _sElement = null;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (_sElement != null)
            {
                MainView.Refresh();
            }
        }

        // Cursor se musí dávat jako poslední jinak bliká
        private void MainView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_classElements.Any(x => x.IsIn(new PointF(e.X, e.Y)) == true))
            {
                Cursor.Current = Cursors.NoMove2D;


            }
            else if (Cursor.Current != Cursors.Arrow)
            {
                Cursor.Current = Cursors.Arrow;
            }

            foreach (var classElement in _classElements.Where(x => x.IsIn(new PointF(e.X, e.Y), 15)))
            {
                classElement.DisplayDots = true;
                Cursor.Current = classElement.GetCloseCursor(e.X, e.Y);
                MainView.Refresh();
            }

            foreach (var classElement in _classElements.Where(x => x.IsIn(new PointF(e.X, e.Y), 15) == false))
            {
                classElement.DisplayDots = false;
                MainView.Refresh();
            }

            if (_sElement != null)
            {
                _sElement.Location = new PointF(e.X - _xoffSet, e.Y - _yoffSet);
            }
        }
    }
}