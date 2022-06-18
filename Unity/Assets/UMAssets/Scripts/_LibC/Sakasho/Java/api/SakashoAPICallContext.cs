
namespace ExternLib.Java_Sakasho.jp.dena.sakasho.api
{
    public class SakashoAPICallContext
    {
        public static int CALL_ID_VOID = 0;
        public int _callId;

        // public SakashoAPICallContext() {
        //     this(0);
        // }

        public SakashoAPICallContext(int var1)
        {
            _callId = var1;
        }

        // public boolean cancelAPICall() {
        //     return SakashoSystem.cancelAPICall(this.callId);
        // }

        // public boolean isCancellable() {
        //     return this.callId > 0;
        // }
    }
}