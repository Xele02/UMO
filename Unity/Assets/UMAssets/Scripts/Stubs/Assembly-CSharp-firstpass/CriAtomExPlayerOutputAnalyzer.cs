using System;

public class CriAtomExPlayerOutputAnalyzer : CriAtomExOutputAnalyzer
{
	public struct Config
	{
		public Config(int num_spectrum_analyzer_bands, int num_stored_output_data) : this()
		{
		}

		public int num_spectrum_analyzer_bands;
		public int num_stored_output_data;
	}

	public enum Type
	{
		LevelMeter = 0,
		SpectrumAnalyzer = 1,
		PcmCapture = 2,
	}

	public CriAtomExPlayerOutputAnalyzer(CriAtomExPlayerOutputAnalyzer.Type[] types, CriAtomExPlayerOutputAnalyzer.Config[] configs) : base(default(CriAtomExOutputAnalyzer.Config))
	{
	}

}
