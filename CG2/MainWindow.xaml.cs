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
            const int nPoints = 8;
            const int nEdges = 12;
            Line line = new Line();

            // Build a table of vertices
            double[,] vtable = new double[nPoints, 3]
            {
                { -0.5, -0.5, 2.5}, { -0.5, 0.5, 2.5},
                { 0.5, 0.5 ,2.5}, {0.5, -0.5, 2.5},
                { -0.5, -0.5, 3.5}, { -0.5, 0.5, 3.5},
                { 0.5, 0.5, 3.5}, {0.5, -0.5, 3.5},
            };

            // Build a table of edges
            int[,] etable = new int[nEdges, 2]
            {
                {0,1}, {1,2}, {2,3}, {3,0}, {0,4}, {1,5},
                {2,6}, {3,7}, {4,5}, {5,6}, {6,7}, {7,4}
            };

            double xmin = -0.5, xmax = 0.5;
            double ymin = -0.5, ymax = 0.5;

            Point[] pictureVertices = new Point[nPoints];
            Ellipse dot = new Ellipse();
            int scale = 40;
            
            for (int i = 0; i < nPoints; i++)
            {
                double x = vtable[i, 0];
                double y = vtable[i, 1];
                double z = vtable[i, 2];
                double xprime = x / z;
                double yprime = y / z;

                x = scale *
                    (1 - (xprime - xmin) / (xmax - xmin));
                y = scale *
                    (1 - (yprime - ymin) / (ymax - ymin));

                dot = Dot(x, y);

                paper.Children.Add(dot);
            }
            for(int i=0; i < nEdges; i++)
            {
                int n1 = etable[i, 0];
                int n2 = etable[i, 1];
            }
        }

        private Ellipse Dot(double x, double y)
        {
            Ellipse currentDot = new Ellipse();
            currentDot.Stroke = new SolidColorBrush(Colors.Black);
            currentDot.StrokeThickness = .1;
            currentDot.Height = 1;
            currentDot.Width = 1;
            currentDot.Fill = new SolidColorBrush(Colors.Black);
            currentDot.Margin = new Thickness(x, y, 0, 0);

            return currentDot;
        }
    }
}
