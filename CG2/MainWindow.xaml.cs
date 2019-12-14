using System;
using System.Collections.Generic;
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
            ProjectedCube projectedCube = new ProjectedCube(ref Paper);
            projectedCube.projectCube();
            

        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                    + nextPage.Name.ToString());
        }
    }

    public class ProjectedCube
    {
        const int nPoints = 8;
        const int nEdges = 12;
        Canvas paper;

        public ProjectedCube(ref Canvas paper)
        {
            this.paper = paper;
        }

        public void projectCube()
        {

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

            // Builds edges between vertices
            for (int i = 0; i < nEdges; i++)
            {
                int n1 = etable[i, 0];
                int n2 = etable[i, 1];

                double x1 = vtable[n1, 0];
                double y1 = vtable[n1, 1];
                double z1 = vtable[n1, 2];

                x1 = NewXCoordinate(x1, z1);
                y1 = NewYCoordinate(y1, z1);

                double x2 = vtable[n2, 0];
                double y2 = vtable[n2, 1];
                double z2 = vtable[n2, 2];

                x2 = NewXCoordinate(x2, z2);
                y2 = NewYCoordinate(y2, z2);

                paper.Children.Add(Line(x1, x2, y1, y2));
            }
        }

        private Line Line(double x1, double x2, double y1, double y2)
        {
            return new Line
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2
            };
        }

        private double NewXCoordinate(double x, double z)
        {
            double xmin = -0.5, xmax = 0.5;
            int scale = 450;

            double xprime = x / z;

            x = scale *
                (1 - (xprime - xmin) / (xmax - xmin));

            return x;
        }

        private double NewYCoordinate(double y, double z)
        {
            double ymin = -0.5, ymax = 0.5;
            int scale = 450;

            double yprime = y / z;

            y = scale *
                (1 - (yprime - ymin) / (ymax - ymin));

            return y;
        }
    }

    public interface ISwitchable
    {
        void UtilizeState(object state);
    }

    public static class Switcher
    {
        public static MainWindow mainWindow;

        public static void Switch(UserControl newPage)
        {
            mainWindow.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            mainWindow.Navigate(newPage, state);
        }
    }
}
