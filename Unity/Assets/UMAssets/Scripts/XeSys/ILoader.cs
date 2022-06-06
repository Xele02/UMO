using System.Collections.Generic;

namespace XeSys
{
    public interface ILoader
    {
        // RVA: -1 Offset: -1 Slot: 2
        bool isLoading { get; } // get_isLoading

        // RVA: -1 Offset: -1 Slot: 0
        int Load(string path, FileLoadedPostProcess callback);

        // RVA: -1 Offset: -1 Slot: 1
        int Load(string path, FileLoadedPostProcess callback, Dictionary<string, string> args, int argValue);
    }
}