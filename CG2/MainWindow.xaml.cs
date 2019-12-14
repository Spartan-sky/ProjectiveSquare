﻿using System;
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
            this.Navigate(new Uri("/Pages/ProjectCubePage.xaml", UriKind.Relative));


        }

        public void Navigate(Uri nextPage)
        {
            this.Content = nextPage;
        }
    }

    public interface ISwitchable
    {
        void UtilizeState(object state);
    }

    public static class Switcher
    {
        public static MainWindow mainWindow;

        public static void Switch(Uri newPage)
        {
            mainWindow.Navigate(newPage);
        }
    }
}
