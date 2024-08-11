// In 2021.1 this is part of Unity
#if !UNITY_2021_1_OR_NEWER
namespace UnityEngine.Pool
{
    internal interface IObjectPool<T> where T : class
    {
        int CountInactive { get; }

        T Get();
        PooledObject<T> Get(out T v);
        void Release(T element);
        void Clear();
    }
}
#endif
