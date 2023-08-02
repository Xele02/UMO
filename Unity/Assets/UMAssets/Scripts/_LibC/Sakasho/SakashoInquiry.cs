using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoInquiryGetInquiryResponsesNumber(int callbackId, string json)
        {
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["num_replies"] = 0;

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }
    }
}
