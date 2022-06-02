using System;

public class CriAtomExOutputAnalyzer : CriDisposable
{
	public struct Config
	{
		public bool enableLevelmeter;
		public bool enableSpectrumAnalyzer;
		public bool enablePcmCapture;
		public bool enablePcmCaptureCallback;
		public int numSpectrumAnalyzerBands;
		public int numCapturedPcmSamples;
	}

	public CriAtomExOutputAnalyzer(CriAtomExOutputAnalyzer.Config config)
	{
	}

}
