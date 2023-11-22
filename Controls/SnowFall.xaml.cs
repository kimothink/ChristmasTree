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

namespace ChristmasTree.Controls
{
    /// <summary>
    /// SnowFall.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SnowFall : UserControl
    {
        private readonly SnowEngine snow = null;

        public SnowFall()
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
        }
    }
}
