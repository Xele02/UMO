using System;

public class CriAtomExAsrRack : CriDisposable
{
	public struct Config
	{
		public float serverFrequency;
		public int numBuses;
		public int outputChannels;
		public int outputSamplingRate;
		public CriAtomEx.SoundRendererType soundRendererType;
		public int outputRackId;
	}

	public struct PlatformConfig
	{
		public byte reserved;
	}

	public CriAtomExAsrRack(CriAtomExAsrRack.Config config, CriAtomExAsrRack.PlatformConfig platformConfig)
	{
	}

}
