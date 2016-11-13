using System;
using System.Windows;
using System.Windows.Media;

namespace LedMatrixSimulator
{ 
    public partial class MainWindow : Window
    {
        MatrixDraw mDraw = null;
        LedMatrixTester mTester = null;

        public MainWindow()
        {
            InitializeComponent();
            mDraw = MatrixDraw.Create();
            mTester = new LedMatrixTester();
        }       

        private void drawMatrixBtn_Click(object sender, RoutedEventArgs e)
        {
           mDraw.DrawMatrixFromConfig();
        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            mTester.lightUpLed();
        }
    }
}
