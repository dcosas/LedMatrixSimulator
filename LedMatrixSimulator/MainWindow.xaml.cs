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

namespace LedMatrixSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ellipse> ellipseCollection = new List<Ellipse>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void DrawMatrixFromConfig()
        {
            var _matrixHeight = Convert.ToInt16(matrixHeightTBox.Text.ToString());
            var _matrixWidth = Convert.ToInt16(matrixWidthTBox.Text.ToString());
            var _dotSize = Convert.ToInt16(dotSizeTBox.Text.ToString());
            var _dotSpacing = Convert.ToInt16(dotSpacingTBox.Text.ToString());

            double left = 0.0f;
            double top = 0.0f;

            myCanvas.Children.RemoveRange(0, myCanvas.Children.Count);
            
            //StackPanel panel = new StackPanel();
            for ( var i = 0; i < _matrixHeight; i++)
            {
                for ( var j=0; j<_matrixWidth; j++)
                {
                    Ellipse ellipse = new Ellipse();
                    SolidColorBrush solidBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    ellipse.Fill = solidBrush;
                    ellipse.StrokeThickness = 0;
                    ellipse.Width = _dotSize;
                    ellipse.Height = _dotSize;
                    left += _dotSpacing;                   
                    ellipse.Margin = new Thickness(left, top, 0, 0);
                    myCanvas.Children.Add(ellipse);

                    ellipseCollection.Add(ellipse);
                    //panel.Children.Add(elipse);
                    //this.Content = panel;
                }
                top += _dotSpacing;
                left = 0;
            }
        }

        private void drawMatrixBtn_Click(object sender, RoutedEventArgs e)
        {
            DrawMatrixFromConfig();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            var ellipse = ellipseCollection.ElementAt(5);
            ellipse.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            RedrawMatrix();
        }

        public void RedrawMatrix()
        {
            var _matrixHeight = Convert.ToInt16(matrixHeightTBox.Text.ToString());
            var _matrixWidth = Convert.ToInt16(matrixWidthTBox.Text.ToString());

            myCanvas.Children.RemoveRange(0, myCanvas.Children.Count);
            
            for (var i = 0; i < _matrixHeight * _matrixWidth; i++)
            {
                myCanvas.Children.Add(ellipseCollection.ElementAt(i));
            }
        }
    }
}
