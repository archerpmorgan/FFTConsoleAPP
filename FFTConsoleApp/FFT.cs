using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Python.Runtime;


namespace FFTConsoleApp
{
    public class FFT
    {
        private Py.GILState _state;
        private dynamic _sys;
        private dynamic _np;

        private string _code;
        
        private SingleThreadTaskScheduler _pythonTaskScheduler = new SingleThreadTaskScheduler(new CancellationTokenSource().Token);

        public double[][] FFTResult { get; set;  }
    
        public FFT() { 

            _pythonTaskScheduler.Schedule(() =>
            {
                try
                {
                    _state = Py.GIL();
                    _sys = Py.Import("sys");
                    _np = Py.Import("numpy");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
            _pythonTaskScheduler.Start();

            _code = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "FFTCalculator.py"));
        }

        public async void FastFourierTransform(double[] values, double samplingRate)
        {

            Console.WriteLine("Processing new message in FFT module");
            double[][] fftresult = { };


            await _pythonTaskScheduler.Schedule(() =>
            {
                try
                {
                    //TODO: run your python code here.

                    PythonEngine.RunSimpleString(_code);

                    dynamic t = _sys.FFTCalculator;
                    fftresult = (double[][])t.fft_calculate(values, samplingRate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            });
        }
    }
}