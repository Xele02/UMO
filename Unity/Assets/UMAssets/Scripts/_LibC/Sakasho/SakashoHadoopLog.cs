using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoHadoopLogSendLogToHadoop(int callbackId, string json)
        {
			// Hack directly send response
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			// end hack

			return 0;
        }
    }
}
