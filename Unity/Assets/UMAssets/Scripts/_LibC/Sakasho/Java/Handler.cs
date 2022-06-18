namespace ExternLib.Java_Sakasho
{
    public class Handler
    {
        // Android message queue
        public bool post(Runnable r)
        {
            // execute directly
            r.run();
            return true;
        }
    }

}