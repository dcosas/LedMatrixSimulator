using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LedMatrixSimulator
{
    class MatrixDraw
    {
        List<Ellipse> ellipseCollection = new List<Ellipse>();
        MainWindow myForm = Application.Current.Windows[0] as MainWindow;
        static MatrixDraw instance = null;
        public static MatrixDraw Create()
        {
            if (instance == null)
                instance = new MatrixDraw();

            return instance;
        }

        private MatrixDraw()
        {

        }

        public void DrawMatrixFromConfig()
        {
            var _matrixHeight = Convert.ToInt16(myForm.matrixHeightTBox.Text.ToString());
            var _matrixWidth = Convert.ToInt16(myForm.matrixWidthTBox.Text.ToString());
            var _dotSize = Convert.ToInt16(myForm.dotSizeTBox.Text.ToString());
            var _dotSpacing = Convert.ToInt16(myForm.dotSpacingTBox.Text.ToString());

            double left = 0.0f;
            double top = 0.0f;

            myForm.myCanvas.Children.RemoveRange(0, myForm.myCanvas.Children.Count);

            //StackPanel panel = new StackPanel();
            for (var i = 0; i < _matrixHeight; i++)
            {
                for (var j = 0; j < _matrixWidth; j++)
                {
                    Ellipse ellipse = new Ellipse();
                    SolidColorBrush solidBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    ellipse.Fill = solidBrush;
                    ellipse.StrokeThickness = 0;
                    ellipse.Width = _dotSize;
                    ellipse.Height = _dotSize;
                    left += _dotSpacing;
                    ellipse.Margin = new Thickness(left, top, 0, 0);
                    myForm.myCanvas.Children.Add(ellipse);

                    ellipseCollection.Add(ellipse);
                    //panel.Children.Add(elipse);
                    //this.Content = panel;
                }
                top += _dotSpacing;
                left = 0;
            }
        }

        private void RedrawMatrix()
        {
            var _matrixHeight = Convert.ToInt16(myForm.matrixHeightTBox.Text.ToString());
            var _matrixWidth = Convert.ToInt16(myForm.matrixWidthTBox.Text.ToString());

            myForm.myCanvas.Children.RemoveRange(0, myForm.myCanvas.Children.Count);

            for (var i = 0; i < _matrixHeight * _matrixWidth; i++)
            {
                myForm.myCanvas.Children.Add(ellipseCollection.ElementAt(i));
            }
        }

        public void SetLed(short line, short column, Color color)
        {
            if (line > Convert.ToInt16(myForm.matrixHeightTBox.Text.ToString()))
            {
                MessageBox.Show("Line exceeds the maximum height");
                return;
            }
            if (column > Convert.ToInt16(myForm.matrixWidthTBox.Text.ToString()))
            {
                MessageBox.Show("Column exceeds the maximum width");
                return;
            }

            var ellipse = ellipseCollection.ElementAt((line - 1) * Convert.ToInt16(myForm.matrixWidthTBox.Text.ToString()) + (column - 1));
            ellipse.Fill = new SolidColorBrush(color);
            RedrawMatrix();

        }

        public void test()
        {
            
            return;
        }
    }
}
