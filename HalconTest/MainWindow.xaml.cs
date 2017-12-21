using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using HalconDotNet;

namespace HalconTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private HFramegrabber Framegrabber;
        private HImage Img;  

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*try
            {
                Framegrabber = new HFramegrabber("File", 1, 1, 0, 0, 0, 0, "default",
                -1, "default", -1, "default",
                @".\images\Desert.jpg", "default", 1, -1);
                Img = Framegrabber.GrabImage();
                Img.DispObj(hswc.HalconWindow);  
            }
            catch(HOperatorException ex)
            {
                MessageBox.Show(ex.Message, "HALCON error # " + ex.GetErrorCode());
            }*/

            new HDevelopExport();
        }
    }
}
