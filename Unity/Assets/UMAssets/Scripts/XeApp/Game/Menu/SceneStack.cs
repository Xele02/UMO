using System.Collections.Generic;

namespace XeApp.Game.Menu
{
    public class SceneStack : List<SceneStackInfo>
    {
        // // RVA: 0xA5939C Offset: 0xA5939C VA: 0xA5939C
        public SceneStackInfo Pop()
        {
            SceneStackInfo top = GetTop();
            RemoveAt(Count-1);
            return top;
        }

        // // RVA: 0xA594D4 Offset: 0xA594D4 VA: 0xA594D4
        public void Push(SceneStackInfo info)
        {
            Add(info);
        }

        // // RVA: 0xA5942C Offset: 0xA5942C VA: 0xA5942C
        public SceneStackInfo GetTop()
        {
            if(Count > 0)
            {
                return this[Count-1];
            }
            return null;
        }

        // // RVA: 0xA59540 Offset: 0xA59540 VA: 0xA59540
        // public SceneStackInfo GetAt(int index) { }

        // // RVA: 0xA595AC Offset: 0xA595AC VA: 0xA595AC
        // public void Copy(SceneStack o) { }
    }
}