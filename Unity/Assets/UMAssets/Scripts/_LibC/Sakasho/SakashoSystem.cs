
namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static void SakashoSystemResume()
        {
            TodoLogger.Log(TodoLogger.SakashoSystem, "LibSakasho.SakashoSystemResume");
        }

		public static void SakashoSystemCancelAPICall(int callId)
		{
			TodoLogger.Log(TodoLogger.SakashoSystem, "LibSakasho.SakashoSystemCancelAPICall");
		}

	}
}
