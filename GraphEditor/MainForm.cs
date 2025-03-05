using System.Windows.Forms;

namespace Lab1
{
    public partial class MainForm : Form
    {

        private Shape[] shapes = new Shape[0];


        public MainForm()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            shapes = new Shape[0];
            pictureBox.Invalidate();
        }


        private void buttonLine_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Line(Color.Black, 5, new Point(20, 20), new Point(40, 100));
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new RectangleF(Color.Red, Color.Orange, 5, new Point(50, 50), 150, 100);
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Ellipse(Color.Red, Color.DarkRed, 5, new Point(210, 50), 200, 300);
        }

        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);

            Point[] points = new Point[]
            {
                new Point(420, 50),
                new Point(470, 50),
                new Point(520, 100),
                new Point(470, 150),
                new Point(420, 100)
            };

            shapes[^1] = new Polygon(Color.Green, Color.Lime, 5, points);
        }

        private void buttonBrLine_Click(object sender, EventArgs e)
        {
            Array.Resize(ref shapes, shapes.Length + 1);

            Point[] points = new Point[]
            {
                new Point(550, 50),
                new Point(600, 150),
                new Point(550, 250),
                new Point(600, 350)
            };

            shapes[^1] = new BrokenLine(Color.Red, 5, points);
        }
    }
}
