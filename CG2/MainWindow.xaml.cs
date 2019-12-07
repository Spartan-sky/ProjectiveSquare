using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CG2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Canvas paper = Paper;
            //const int nPoints = 8;
            //const int nEdges = 12;
            Polygon line = PolygonLine();

            //// Build a table of vertices
            //double[,] vtable = new double[nPoints, 3]
            //{
            //    { -0.5, -0.5, 2.5}, { -0.5, 0.5, 2.5},
            //    { 0.5, 0.5 ,2.5}, {0.5, -0.5, 2.5},
            //    { -0.5, -0.5, 3.5}, { -0.5, 0.5, 3.5},
            //    { 0.5, 0.5, 3.5}, {0.5, -0.5, 3.5},
            //};

            //// Build a table of edges
            //int[,] etable = new int[nEdges, 2]
            //{
            //    {0,1}, {1,2}, {2,3}, {3,0}, {0,4}, {1,5},
            //    {2,6}, {3,7}, {4,5}, {5,6}, {6,7}, {7,4}
            //};

            //double xmin = -0.5, xmax = 0.5;
            //double ymin = -0.5, ymax = 0.5;

            //Point[] pictureVertices = new Point[nPoints];

            //double scale = 100;
            //for(int i = 0; i < nPoints; i++)
            //{
            //    double x = vtable[i, 0];
            //    double y = vtable[i, 2];
            //    double z = vtable[i, 3];
            //    double xprime = x / z;
            //    double yprime = y / z;

            //    pictureVertices[i].X = scale *
            //        (1 - (xprime - xmin) / (xmax - xmin));
            //    pictureVertices[i].Y = scale *
            //        (1 - (yprime - ymin) / (ymax - ymin));
            //    line.Points.Add(pictureVertices[i].X,
            //        pictureVertices[i].Y);
            //    //gp.Children.Add(new Point(pictureVertices[i]);
            //}

            PointCollection points = new PointCollection();
            for(float x=0; x < 50; x++)
            {
                Point p = new Point(x, Math.Sin(x));
                points.Add(p);
            }

            line.Points = points;
            paper.Children.Add(line);

        }

        private Polygon PolygonLine()
        {
            Polygon polygonLine = new Polygon();
            polygonLine.Stroke = Brushes.Black;
            polygonLine.Fill = Brushes.LightSeaGreen;
            polygonLine.StrokeThickness = 0.2;
            polygonLine.HorizontalAlignment = HorizontalAlignment.Left;
            polygonLine.VerticalAlignment = VerticalAlignment.Center;

            return polygonLine;
        }
    }
}
