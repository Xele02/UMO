using System;

namespace CriWare
{

	[Serializable]
	public class CriAtomCueSheet
	{
		public string name = ""; // 0x8
		public string acbFile = ""; // 0xC
		public string awbFile = ""; // 0x10
		public CriAtomExAcb acb; // 0x14
		public CriAtomExAcbLoader.Status loaderStatus; // 0x18

		// public bool IsLoading { get; } 0x287C3EC
		// public bool IsError { get; } 0x28800F4
	}
}