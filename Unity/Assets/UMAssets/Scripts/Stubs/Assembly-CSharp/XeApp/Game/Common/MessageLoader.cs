using XeSys;

namespace XeApp.Game.Common
{
	public class MessageLoader : Singleton<MessageLoader>
	{
		public enum InstallSource
		{
			Resource = 0,
			LocalStorage = 1,
		}

		public InstallSource defaultInstallSource;
	}
}
