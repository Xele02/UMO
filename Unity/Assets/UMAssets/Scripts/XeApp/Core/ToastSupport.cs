
namespace XeApp.Core
{
	public class ToastSupport
	{
		private static long intervalTime; // 0x0
		private const long WaitTime = 2;

		// RVA: 0x1D77A18 Offset: 0x1D77A18 VA: 0x1D77A18
		public static void Post(string str)
		{
			TodoLogger.LogError(TodoLogger.Toast, "Post");
		}
	}
}
