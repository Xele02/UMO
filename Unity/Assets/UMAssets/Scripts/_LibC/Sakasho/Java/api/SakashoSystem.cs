
namespace ExternLib.Java_Sakasho.jp.dena.sakasho.api
{
    public class SakashoSystem
    {
        public interface OnSuccess {
            void onSuccess(string var1);
        }
        public interface OnError {
            void onError(SakashoError var1);
        }
    }
}