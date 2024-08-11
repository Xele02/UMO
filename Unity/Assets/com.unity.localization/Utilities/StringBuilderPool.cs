using System.Text;
using UnityEngine.Pool;

namespace UnityEngine.Localization
{
    internal static class StringBuilderPool
    {
        internal static readonly ObjectPool<StringBuilder> s_Pool = new ObjectPool<StringBuilder>(() => new StringBuilder(), null, sb => sb.Clear(), collectionCheck: false);

        public static StringBuilder Get() => s_Pool.Get();
        public static PooledObject<StringBuilder> Get(out StringBuilder value) => s_Pool.Get(out value);
        public static void Release(StringBuilder toRelease) => s_Pool.Release(toRelease);
    }
}
