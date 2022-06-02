using System;
using System.Runtime.InteropServices;

public class CriAtomExAcbLoader : CriDisposable
{
	public enum Status
	{
		Stop = 0,
		Loading = 1,
		Complete = 2,
		Error = 3,
	}

	private CriAtomExAcbLoader(IntPtr handle, Nullable<GCHandle> dataHandle)
	{
	}

}
