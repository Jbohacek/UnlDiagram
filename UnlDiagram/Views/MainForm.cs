using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using UnlDiagram.FIleService;
using UnlDiagram.Models;
using UnlDiagram.Models.Elements;
using UnlDiagram.Models.Enums;
using UnlDiagram.Views;
using Timer = System.Threading.Timer;

namespace UnlDiagram
{
    public partial class MainForm : Form
    {
        public PictureBox View { get; set; }
        public readonly List<ClassElement> ClassElements = new List<ClassElement>();

        private Element? _sElement = null;
        private float _xoffSet = 0;
        private float _yoffSet = 0;

        public MainForm()
        {
            InitializeComponent();
            View = MainView;
        }

        private void MainView_Paint(object sender, PaintEventArgs e)
        {
            foreach (var classElement in ClassElements.OrderBy(x => x.DisplayOrder))
            {
                classElement.Draw(e.Graphics);
            }
        }

        private void MainView_MouseDown(object sender, MouseEventArgs e)
        {
            var selected = ClassElements.Where(x => x.IsIn(new PointF(e.X, e.Y), 10) == true && x.Visible == true);
            var selectedItem = selected?.MaxBy(x => x.DisplayOrder);
            if (selectedItem == null)
            {
                if (e.Button != MouseButtons.Right) return;

                var addBut = new ToolStripButton("Add");
                addBut.Click += (obj, s) =>
                {
                    var newElement = new ClassElement(
                        new PointF(e.X, e.Y),
                        200,
                        300,
                        "New Element"
                        );
                    ClassElements.Add(newElement);
                    MainView.Refresh();
                };
                MenuStrip.Items.Clear();
                MenuStrip.Items.Add(addBut);
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                selectedItem.GetActions(ref MenuStrip, this);
            }

            #region ClickOnElement

            selectedItem.PossibleState = selectedItem.GetCloseState(e.X, e.Y);
            //Debug.WriteLine(selectedItem.PossibleState);

            _sElement = selectedItem;
            _sElement.LastHeight = selectedItem.Height;
            _sElement.LastWidth = selectedItem.Width;
            _sElement.LastLocation = new PointF(_sElement.Location.X, _sElement.Location.Y);
            _xoffSet = e.X - _sElement.Location.X;
            _yoffSet = e.Y - _sElement.Location.Y;
            MoveTimer.Start();

            #endregion
        }

        private void MainView_MouseUp(object sender, MouseEventArgs e)
        {
            _sElement = null;
            MoveTimer.Stop();
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
            Cursor setCursor;
            bool found = false;

            foreach (var classElement in ClassElements)
            {
                if (classElement.IsIn(new PointF(e.X, e.Y), 10))
                {
                    classElement.DisplayDots = false; // opravit
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
                    classElement.DisplayDots = false; // opravit
                }
            }

            if (MainView.Cursor != Cursors.Arrow && found == false)
            {
                setCursor = Cursors.Arrow;
                MainView.Cursor = setCursor;
                MainView.Refresh();
            }


            if (_sElement == null) return;

            switch (_sElement.PossibleState)
            {
                case ElementsStates.Moving:
                    _sElement.Location = new PointF(e.X - _xoffSet, e.Y - _yoffSet);
                    break;
                case ElementsStates.ResizeRT:
                    _sElement.Location = new PointF(_sElement.Location.X, e.Y);
                    _sElement.Width = e.X - (int)_sElement.Location.X;
                    _sElement.Height = (int)(_sElement.LastHeight + (_sElement.LastLocation.Y - _sElement.Location.Y));
                    break;
                case ElementsStates.ResizeLT:
                    _sElement.Location = new PointF(e.X, e.Y);
                    _sElement.Width = (int)(_sElement.LastWidth + (_sElement.LastLocation.X - _sElement.Location.X));
                    _sElement.Height = (int)(_sElement.LastHeight + (_sElement.LastLocation.Y - _sElement.Location.Y));
                    break;
                case ElementsStates.ResizeRB:
                    _sElement.Width = e.X - (int)_sElement.Location.X;
                    _sElement.Height = e.Y - (int)_sElement.Location.Y;
                    break;
                case ElementsStates.ResizeLB:
                    _sElement.Location = new PointF(e.X, _sElement.Location.Y);
                    _sElement.Width = (int)(_sElement.LastWidth + (_sElement.LastLocation.X - _sElement.Location.X));
                    _sElement.Height = e.Y - (int)_sElement.Location.Y;
                    break;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassElements.RemoveAll(x => x.IsDeleted);
            var saveFileDialog = new SaveFileDialog() { Filter = "XML Files (*.xml)|*.xml" };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            var x = FileManager.WriteToXmlFile(ClassElements, saveFileDialog.FileName);
            if (x.IsSuccessful == false)
            {
                MessageBox.Show(x.ErrorMessage);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog() { Filter = "XML Files (*.xml)|*.xml" };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string filePath = openFileDialog.FileName;
            ClassElements.Clear();
            ClassElements.AddRange(FileManager.ReadFromXmlFile<List<ClassElement>>(filePath));
            MainView.Refresh();
        }

        private void MainView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selected = ClassElements.Where(x => x.IsIn(new PointF(e.X, e.Y), 10) == true);
            var selectedItem = selected?.MaxBy(x => x.DisplayOrder);
            if (selectedItem == null) return;

            var editForm = new EditForm(selectedItem);
            editForm.ShowDialog();
        }
    }
}