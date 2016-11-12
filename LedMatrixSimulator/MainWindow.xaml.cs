using System;
using System.Windows;
using System.Windows.Media;

namespace LedMatrixSimulator
{ 
    public partial class MainWindow : Window
    {
        MatrixDraw mDraw = null; 

        public MainWindow()
        {
            InitializeComponent();
            mDraw = MatrixDraw.Create();
        }       

        private void drawMatrixBtn_Click(object sender, RoutedEventArgs e)
        {
           mDraw.DrawMatrixFromConfig();
        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            mDraw.SetLed(Convert.ToInt16(rowTBox.Text.ToString()),
                   Convert.ToInt16(colTBox.Text.ToString()),
                   Color.FromRgb(Convert.ToByte(rTBox.Text.ToString()),
                                 Convert.ToByte(gTBox.Text.ToString()),
                                 Convert.ToByte(bTBox.Text.ToString())));

        }
    }
}
