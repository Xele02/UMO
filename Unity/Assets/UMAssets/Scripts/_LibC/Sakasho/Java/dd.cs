using System.Collections.Generic;

namespace ExternLib.Java_Sakasho
{
    public class dd : Dictionary<string, de>
    {
        private static long _serialVersionUID = 1L;
        private int _a = 100;

        public bool Unused() { return _a == 0 && _serialVersionUID == 0; }

        public dd(int var1)
        {
        }

        // protected final boolean removeEldestEntry(Map.Entry var1)
        // {
        //     return this.size() > this.a;
        // }
    }
}