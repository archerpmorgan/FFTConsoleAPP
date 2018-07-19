import sys
import numpy as np
from scipy import pi
from scipy.fftpack import fft
from System import Array

class FFTCalculator:

     def fft_calculate(self, array_values, sampling_rate):
        #sampling_rate should be in hz

        #convert values from System.Array to List
        values = []
        for i in range(len(Arrayvalues)):
            values.append(Arrayvalues[i])

        N = len(values)

        # Nyquist Sampling Criteria
        T = 1/sampling_rate # inverse of the sampling rate
        x = np.linspace(0.0, 1.0/(2.0*T), int(N/2))

        # FFT algorithm
        yr = fft(vib_data) # "raw" FFT with both + and - frequencies
        y = 2/N * np.abs(yr[0:np.int(N/2)]) # positive freqs only

        #[x,y] is the result where x is the frequencies bins in hz and y is the fft result for those bins
        fftresult = Array[Array](np.int(N/2))        
        
        for i in range(0, np.int(N/2)):
                fftresult[i]= Array[double](2)
                fftresult[i][0] = x[i]
                fftresult[i][1] = y[i]


        return fftresult

sys.FFTCalculator = FFTCalculator()