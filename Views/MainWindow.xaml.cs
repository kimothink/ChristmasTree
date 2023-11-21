using ChristmasTree.ViewModels;
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

namespace ChristmasTree.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SnowEngine snow = null;
        public MainWindow()
        {
            InitializeComponent();
            snow = new SnowEngine(canvas,
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow1.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow2.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow3.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow4.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow5.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow6.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow7.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow8.png",
               "C:\\Users\\John\\Documents\\GitHub\\ChristmasTree\\Resources\\snow9.png"
               );
            //snow.Start();
            snow.Start();

            Loaded += new RoutedEventHandler(Image_Drag_Moving);


        }

        /// <summary>
        /// 이미지 드래그 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_Drag_Moving(object sender, RoutedEventArgs e)
        {
            Drag.SetWindow(this);
            Drag.SetDrag(Tree, true);
        }


    }
}
