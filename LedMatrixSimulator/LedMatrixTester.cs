using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;

namespace LedMatrixSimulator
{
    class LedMatrixTester
    {
        MatrixDraw mDraw = null;

        private Random randomGen = new Random();
       
        public LedMatrixTester()
        {
            mDraw = MatrixDraw.Create();
        }
        public void lightUpLed()
        {
            Color color = Color.FromRgb((byte)randomGen.Next(0, 255),
                (byte)randomGen.Next(0, 255),
                (byte)randomGen.Next(0, 255));

            mDraw.SetLed((Int16)randomGen.Next(1, mDraw.matrixWidth + 1), (Int16)randomGen.Next(1, mDraw.matrixHeight + 1), color);
        }
    }
}
