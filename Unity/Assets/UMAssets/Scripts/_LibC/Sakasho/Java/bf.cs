namespace ExternLib.Java_Sakasho
{
    public abstract class bf : bg {
        class __1 : bg {
            class ___1 : Runnable
            {
                int _a;
                bv[] _b;
                byte[] _c;
                bf.__1 _d;

                public ___1(bf.__1 var1, int var2, bv[] var3, byte[] var4)
                {
                    this._d = var1;
                    this._a = var2;
                    this._b = var3;
                    this._c = var4;
                }

                public void run()
                {
                    this._d._a._a.a(this._a, this._b, this._c);
                }
            }

            class ___2 : Runnable
            {
                int _a;
                string _b;
                byte[] _c;
                bf.__1 _d;

                public ___2(bf.__1 var1, int var2, string var3, byte[] var4)
                {
                    this._d = var1;
                    this._a = var2;
                    this._b = var3;
                    this._c = var4;
                }

                public void run()
                {
                    this._d._a._a.a(this._a, this._b, this._c);
                }
            }

            bf _a;

            public __1(bf var1)
            {
                this._a = var1;
            }
            public void a(int var1, string var2, byte[] var3)
            {
                bf.a(this._a, new bf.__1.___2(this, var1, var2, var3));
            }
            public void a(int var1, bv[] var2, byte[] var3)
            {
                bf.a(this._a, new bf.__1.___1(this, var1, var2, var3));
            }
        }

        class __2 : Runnable
        {
            int _a;
            bv[] _b;
            byte[] _c;
            bf _d;

            public __2(bf var1, int var2, bv[] var3, byte[] var4)
            {
                this._d = var1;
                this._a = var2;
                this._b = var3;
                this._c = var4;
            }

            public void run()
            {
                this._d.b(this._a, this._b, this._c);
            }
        }

        class __3 : Runnable
        {
            int _a;
            string _b;
            byte[] _c;
            bf _d;

            public __3(bf var1, int var2, string var3, byte[] var4)
            {
                this._d = var1;
                this._a = var2;
                this._b = var3;
                this._c = var4;
            }

            public void run()
            {
                this._d.b(this._a, this._b, this._c);
            }
        }

        bg _a;
        protected bg _b;

        public bf(bg var1)
        {
            this._a = var1;
            this._b = new __1(this);
        }
        
        static void a(bf var0, Runnable var1)
        {
            if (true/*SakashoSystem.isOnUnity()*/)
            {
                var1.run();
            }
            else 
            {
                //SakashoSystem.a(var1, true);
            }
        }

        public void a(int var1, bv[] var2, byte[] var3)
        {
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.b(new bf.__2(this, var1, var2, var3));
        }
        public void a(int var1, string var2, byte[] var3) {
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.b(new bf.__3(this, var1, var2, var3));
        }

        public abstract void b(int var1, string var2, byte[] var3);
        public abstract void b(int var1, bv[] var2, byte[] var3);
    }
}