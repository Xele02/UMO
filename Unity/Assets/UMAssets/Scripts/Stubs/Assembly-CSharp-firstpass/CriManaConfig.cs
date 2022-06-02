using System;

[Serializable]
public class CriManaConfig
{
	[Serializable]
	public class PCH264PlaybackConfig
	{
		public bool useH264Playback;
	}

	[Serializable]
	public class VitaH264PlaybackConfig
	{
		public bool useH264Playback;
		public int maxWidth;
		public int maxHeight;
		public bool getMemoryFromTexture;
	}

	[Serializable]
	public class WebGLConfig
	{
		public string webworkerPath;
		public int heapSize;
	}

	public int numberOfDecoders;
	public int numberOfMaxEntries;
	public PCH264PlaybackConfig pcH264PlaybackConfig;
	public VitaH264PlaybackConfig vitaH264PlaybackConfig;
	public WebGLConfig webglConfig;
}
