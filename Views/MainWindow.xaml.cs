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
        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Image_Drag_Moving);

        }

        /// <summary>
        /// 이미지 드래그 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Image_Drag_Moving(object sender, RoutedEventArgs e)
        {
            Drag.SetWindow(this);
            Drag.SetDrag(Tree, true);
    
        }


    }
}
