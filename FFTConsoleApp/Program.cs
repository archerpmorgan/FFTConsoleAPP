using System;

namespace FFTConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            FFT fft = new FFT();

            double[] vals = {1,2,3,4,5,4,3,2,1,2,3,4,5,4,3,2,1};

            fft.FastFourierTransform(vals, 5);

            for (int i = 0; i < fft.FFTResult.Length; i++ ){
                Console.WriteLine(fft.FFTResult[i]);
            }

        }

    }
}
