using System;

public class CriAtomExAuxIn : CriDisposable
{
	public struct Config
	{
		public int maxChannels;
		public int maxSamplingRate;
		public CriAtomEx.SoundRendererType soundRendererType;
	}

	public CriAtomExAuxIn(Nullable<CriAtomExAuxIn.Config> config)
	{
	}

}
