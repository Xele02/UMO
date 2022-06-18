using ExternLib.Java_Sakasho;

namespace ExternLib.Java_Sakasho.jp.dena.sakasho.core
{
    public class SakashoSystem
    {
        // private static final String a = "SakashoSystem";
        // private static String b;
        private static bool _c;
        // private static Handler d;
        // private static Activity e;
        // private static String f;
        // private static String g;
        // private static String h;
        // private static String i;
        // private static ds j;
        private static string _k;
        private static string _l;
        private static string _m;
        private static h _n;
        // private static List o;
        // private static HandlerThread p;
        private static Handler _q;
        // private static HandlerThread r;
        // private static Handler s;
        private static int _t;
        // private static Set u;
        // private static JSONObject v;

        static SakashoSystem()
        {
            /*try {
                System.loadLibrary("sakasho");
            } catch (UnsatisfiedLinkError var1) {
            i();
            }*/
            _c = true;
            // u = new HashSet();
        }

        public static bool isDebugBuild()
        {
            return false;
        }

        public static int o()
        {
            int res;
            res = _t + 1;
            _t = res;
            return res;
        }

        public static void a(Runnable var0)
        {
            a(var0, false, 0L);
        }

        public static void a(Runnable var0, bool var1)
        {
            a(var0, true, 0L);
        }

        private static void a(Runnable var0, bool var1, long var2)
        {
            if (true/*!var1 && Thread.currentThread() == Looper.getMainLooper().getThread()*/)
            {
                var0.run();
            }/* else {
                Handler var4 = v();
                if (var4 == null) {
                    i();
                } else {
                    var4.postDelayed(var0, 0L);
                }
            }*/
        }

        public static void b(Runnable var0)
        {
            Handler var1 = w();
            if (var1 == null)
            {
                i();
            }
            else
            {
                var1.post(var0);
            }
        }

        public static h i()
        {
            if (_n == null)
            {
                if (isDebugBuild())
                {
                    //n = new f();
                }
                else
                {
                    _n = new i();
                }
            }

            return _n;
        }

        public static int k()
        {
            int var1 = z();
            string var2 = null;//d("sakasho_os_boot_elapsed_time_to_server_time_delta");
            int var0 = 0;
            if (var2 == null)
            {
                var0 = 0;
            }
            else
            {
                //var0 = Integer.parseInt(decipherText(eu.b(var2)));
            }

            return var1 + var0;
        }

        public static string q()
        {
            return _k;
        }

        public static string r() {
            return _l;
        }

        public static string s() {
            return _m;
        }

        private static int z()
        {
            //return (int)(SystemClock.elapsedRealtime() / 1000L)
            return (int)UnityEngine.Time.realtimeSinceStartup;
        }

        private static Handler w() {
        //synchronized(SakashoSystem.class){}

            Handler var0;
            var0 = _q;

            return var0;
        }

    }
}