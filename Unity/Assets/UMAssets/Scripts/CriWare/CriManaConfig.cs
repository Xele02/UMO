//using System;

//[Serializable]
//public class CriManaConfig
//{
//	[Serializable]
//	public class PCH264PlaybackConfig
//	{
//		public bool useH264Playback = true; // 0x8
//	}

//	[Serializable]
//	public class VitaH264PlaybackConfig
//	{
//		public bool useH264Playback; // 0x8
//		public int maxWidth = 960; // 0xC
//		public int maxHeight = 544; // 0x10
//		public bool getMemoryFromTexture; // 0x14
//	}

//	[Serializable]
//	public class WebGLConfig
//	{
//		public string webworkerPath = "StreamingAssets"; // 0x8
//		public int heapSize = 32; // 0xC
//	}

//	public int numberOfDecoders = 8; // 0x8
//	public int numberOfMaxEntries = 4; // 0xC
//	public readonly bool graphicsMultiThreaded = true; // 0x10
//	public CriManaConfig.PCH264PlaybackConfig pcH264PlaybackConfig = new CriManaConfig.PCH264PlaybackConfig(); // 0x14
//	public CriManaConfig.VitaH264PlaybackConfig vitaH264PlaybackConfig = new CriManaConfig.VitaH264PlaybackConfig(); // 0x18
//	public CriManaConfig.WebGLConfig webglConfig = new CriManaConfig.WebGLConfig(); // 0x1C

//}
