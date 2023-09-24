using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using UnlDiagram.Models;
using UnlDiagram.Models.Elements;
using UnlDiagram.Models.Enums;
using Timer = System.Threading.Timer;

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
            var selected = _classElements.Where(x => x.IsIn(new PointF(e.X, e.Y), 10) == true);
            var selectedItem = selected?.MaxBy(x => x.DisplayOrder);
            if (selectedItem != null)
            {
                selectedItem.PossibleState = selectedItem.GetCloseState(e.X, e.Y);
                Debug.WriteLine(selectedItem.PossibleState);

                _sElement = selectedItem;
                _sElement.LastHeight = selectedItem.Height;
                _sElement.LastWidth = selectedItem.Width;
                _sElement.LastLocation = new PointF(_sElement.Location.X, _sElement.Location.Y);
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




        private void MainView_MouseMove(object sender, MouseEventArgs e)
        {
            //Stopwatch a = new Stopwatch();
            //a.Start();
            Cursor setCursor;
            bool found = false;
            var state = ElementsStates.None;

            foreach (var classElement in _classElements)
            {
                if (classElement.IsIn(new PointF(e.X, e.Y), 10))
                {
                    classElement.DisplayDots = true;
                    setCursor = classElement.GetCloseCursor(e.X, e.Y);
                    if (setCursor == Cursors.Arrow && classElement.IsIn(new PointF(e.X, e.Y)))
                    {
                        setCursor = Cursors.SizeAll;
                    }

                    if (MainView.Cursor != setCursor && setCursor != Cursors.Arrow)
                    {
                        MainView.Cursor = setCursor;
                        MainView.Refresh();
                    }
                    found = true;
                    break;
                }
                else
                {
                    classElement.DisplayDots = false;
                }
            }

            if (MainView.Cursor != Cursors.Arrow && found == false)
            {
                setCursor = Cursors.Arrow;
                MainView.Cursor = setCursor;
                MainView.Refresh();
            }


            if (_sElement == null) return;

            //state = _sElement.GetCloseState(e.X, e.Y);ø
            if (_sElement.PossibleState == ElementsStates.Moving)
            {
                _sElement.Location = new PointF(e.X - _xoffSet, e.Y - _yoffSet);
            }
            if (_sElement.PossibleState == ElementsStates.ResizeRT)
            {
                _sElement.Width = e.X - (int)_sElement.Location.X;
                _sElement.Location = new PointF(_sElement.Location.X, e.Y);
                _sElement.Height = (int)(_sElement.LastHeight + (_sElement.LastLocation.Y - _sElement.Location.Y));
            }
            if (_sElement.PossibleState == ElementsStates.ResizeLT)
            {
                _sElement.Location = new PointF(e.X, e.Y);
                _sElement.Width = (int)(_sElement.LastWidth + (_sElement.LastLocation.X - _sElement.Location.X));
                _sElement.Height = (int)(_sElement.LastHeight + (_sElement.LastLocation.Y - _sElement.Location.Y));
            }

            if (_sElement.PossibleState == ElementsStates.ResizeRB)
            {
                _sElement.Width = e.X - (int)_sElement.Location.X;
                _sElement.Height = e.Y - (int)_sElement.Location.Y;
            }
            if (_sElement.PossibleState == ElementsStates.ResizeLB)
            {
                _sElement.Location = new PointF(e.X, _sElement.Location.Y);
                _sElement.Width = (int)(_sElement.LastWidth + (_sElement.LastLocation.X - _sElement.Location.X));
                _sElement.Height = e.Y - (int)_sElement.Location.Y;
            }


            //a.Stop();
            //Debug.WriteLine(a.ElapsedTicks);
        }
    }
}