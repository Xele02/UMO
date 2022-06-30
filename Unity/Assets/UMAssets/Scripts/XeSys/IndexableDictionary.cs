
using System.Collections.Generic;

namespace XeSys
{
    internal class IndexableDictionary<TKey, TValue>
    {
        private List<TKey> m_keyList; // 0x0
        private Dictionary<TKey, TValue> m_dictionary; // 0x0

        public TValue this[int index] { get { return m_dictionary[m_keyList[index]]; } }
        // RVA: -1 Offset: -1
        /* GenericInstMethod :
        |
        |-RVA: 0x30A6670 Offset: 0x30A6670 VA: 0x30A6670
        |-IndexableDictionary<int, object>.get_Item
        |-IndexableDictionary<int, TransitionRoot>.get_Item
        |
        |-RVA: 0x30A6BA0 Offset: 0x30A6BA0 VA: 0x30A6BA0
        |-IndexableDictionary<object, object>.get_Item
        |-IndexableDictionary<string, string>.get_Item
        |-IndexableDictionary<string, LayoutObjectPool>.get_Item
        |-IndexableDictionary<string, UGUIObjectPool>.get_Item
        |-IndexableDictionary<string, BgControl.BgTexture>.get_Item
        |-IndexableDictionary<string, IconTextureLodingInfo>.get_Item
        |-IndexableDictionary<string, IiconTexture>.get_Item
        */

        public TValue this[TKey key] { get { return m_dictionary[key]; } }
        // RVA: -1 Offset: -1
        /* GenericInstMethod :
        |
        |-RVA: 0x30A66E8 Offset: 0x30A66E8 VA: 0x30A66E8
        |-IndexableDictionary<int, object>.get_Item
        |
        |-RVA: 0x30A6C18 Offset: 0x30A6C18 VA: 0x30A6C18
        |-IndexableDictionary<object, object>.get_Item
        |-IndexableDictionary<string, LayoutObjectPool>.get_Item
        |-IndexableDictionary<string, UGUIObjectPool>.get_Item
        */

        public int Count { get { return m_keyList.Count; } }
        // RVA: -1 Offset: -1
        /* GenericInstMethod :
        |
        |-RVA: 0x30A686C Offset: 0x30A686C VA: 0x30A686C
        |-IndexableDictionary<int, object>.get_Count
        |-IndexableDictionary<int, TransitionRoot>.get_Count
        |
        |-RVA: 0x30A6D9C Offset: 0x30A6D9C VA: 0x30A6D9C
        |-IndexableDictionary<object, object>.get_Count
        |-IndexableDictionary<string, string>.get_Count
        |-IndexableDictionary<string, LayoutObjectPool>.get_Count
        |-IndexableDictionary<string, UGUIObjectPool>.get_Count
        |-IndexableDictionary<string, BgControl.BgTexture>.get_Count
        |-IndexableDictionary<string, IconTextureLodingInfo>.get_Count
        |-IndexableDictionary<string, IiconTexture>.get_Count
        */


        // RVA: -1 Offset: -1
        public IndexableDictionary(int capacity = 0)
        {
            m_keyList = new List<TKey>(capacity);
            m_dictionary = new Dictionary<TKey, TValue>(capacity);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A6400 Offset: 0x30A6400 VA: 0x30A6400
        |-IndexableDictionary<int, object>..ctor
        |-IndexableDictionary<int, TransitionRoot>..ctor
        |
        |-RVA: 0x30A6930 Offset: 0x30A6930 VA: 0x30A6930
        |-IndexableDictionary<object, object>..ctor
        |-IndexableDictionary<string, string>..ctor
        |-IndexableDictionary<string, LayoutObjectPool>..ctor
        |-IndexableDictionary<string, UGUIObjectPool>..ctor
        |-IndexableDictionary<string, BgControl.BgTexture>..ctor
        |-IndexableDictionary<string, IconTextureLodingInfo>..ctor
        |-IndexableDictionary<string, IiconTexture>..ctor
        */

        // RVA: -1 Offset: -1
        public void Add(TKey key, TValue value)
        {
            m_dictionary.Add(key, value);
            m_keyList.Add(key);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A64CC Offset: 0x30A64CC VA: 0x30A64CC
        |-IndexableDictionary<int, object>.Add
        |-IndexableDictionary<int, TransitionRoot>.Add
        |
        |-RVA: 0x30A69FC Offset: 0x30A69FC VA: 0x30A69FC
        |-IndexableDictionary<object, object>.Add
        |-IndexableDictionary<string, string>.Add
        |-IndexableDictionary<string, LayoutObjectPool>.Add
        |-IndexableDictionary<string, UGUIObjectPool>.Add
        |-IndexableDictionary<string, BgControl.BgTexture>.Add
        |-IndexableDictionary<string, IconTextureLodingInfo>.Add
        |-IndexableDictionary<string, IiconTexture>.Add
        */

        // RVA: -1 Offset: -1
        public void Remove(TKey key)
        {
            m_dictionary.Remove(key);
            m_keyList.Remove(key);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A654C Offset: 0x30A654C VA: 0x30A654C
        |-IndexableDictionary<int, object>.Remove
        |
        |-RVA: 0x30A6A7C Offset: 0x30A6A7C VA: 0x30A6A7C
        |-IndexableDictionary<object, object>.Remove
        |-IndexableDictionary<string, string>.Remove
        |-IndexableDictionary<string, LayoutObjectPool>.Remove
        |-IndexableDictionary<string, UGUIObjectPool>.Remove
        */

        // RVA: -1 Offset: -1
        public void Remove(int index)
        { 
            m_dictionary.Remove(m_keyList[index]);
            m_keyList.RemoveAt(index);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A65C4 Offset: 0x30A65C4 VA: 0x30A65C4
        |-IndexableDictionary<int, object>.Remove
        |
        |-RVA: 0x30A6AF4 Offset: 0x30A6AF4 VA: 0x30A6AF4
        |-IndexableDictionary<object, object>.Remove
        |-IndexableDictionary<string, BgControl.BgTexture>.Remove
        |-IndexableDictionary<string, IconTextureLodingInfo>.Remove
        |-IndexableDictionary<string, IiconTexture>.Remove
        */

        // RVA: -1 Offset: -1
        public bool TryGetValue(TKey key, out TValue value)
        {
            return m_dictionary.TryGetValue(key, out value);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A672C Offset: 0x30A672C VA: 0x30A672C
        |-IndexableDictionary<int, object>.TryGetValue
        |-IndexableDictionary<int, TransitionRoot>.TryGetValue
        |
        |-RVA: 0x30A6C5C Offset: 0x30A6C5C VA: 0x30A6C5C
        |-IndexableDictionary<object, object>.TryGetValue
        |-IndexableDictionary<string, string>.TryGetValue
        |-IndexableDictionary<string, LayoutObjectPool>.TryGetValue
        |-IndexableDictionary<string, UGUIObjectPool>.TryGetValue
        |-IndexableDictionary<string, BgControl.BgTexture>.TryGetValue
        |-IndexableDictionary<string, IconTextureLodingInfo>.TryGetValue
        |-IndexableDictionary<string, IiconTexture>.TryGetValue
        */

        // RVA: -1 Offset: -1
        public TValue GetValue(TKey key)
        {
            return m_dictionary[key];
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A6778 Offset: 0x30A6778 VA: 0x30A6778
        |-IndexableDictionary<int, object>.GetValue
        |-IndexableDictionary<int, TransitionRoot>.GetValue
        |
        |-RVA: 0x30A6CA8 Offset: 0x30A6CA8 VA: 0x30A6CA8
        |-IndexableDictionary<object, object>.GetValue
        */

        // RVA: -1 Offset: -1
        public TKey GetKey(int index)
        {
            return m_keyList[index];
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A67BC Offset: 0x30A67BC VA: 0x30A67BC
        |-IndexableDictionary<int, object>.GetKey
        |-IndexableDictionary<int, TransitionRoot>.GetKey
        |
        |-RVA: 0x30A6CEC Offset: 0x30A6CEC VA: 0x30A6CEC
        |-IndexableDictionary<object, object>.GetKey
        |-IndexableDictionary<string, IconTextureLodingInfo>.GetKey
        */

        // RVA: -1 Offset: -1
        public void Clear()
        {
            m_dictionary.Clear();
            m_keyList.Clear();
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A6800 Offset: 0x30A6800 VA: 0x30A6800
        |-IndexableDictionary<int, object>.Clear
        |-IndexableDictionary<int, TransitionRoot>.Clear
        |
        |-RVA: 0x30A6D30 Offset: 0x30A6D30 VA: 0x30A6D30
        |-IndexableDictionary<object, object>.Clear
        |-IndexableDictionary<string, string>.Clear
        |-IndexableDictionary<string, LayoutObjectPool>.Clear
        |-IndexableDictionary<string, UGUIObjectPool>.Clear
        |-IndexableDictionary<string, BgControl.BgTexture>.Clear
        |-IndexableDictionary<string, IconTextureLodingInfo>.Clear
        |-IndexableDictionary<string, IiconTexture>.Clear
        */

        // RVA: -1 Offset: -1
        public bool ContainsKey(TKey key)
        {
            return m_dictionary.ContainsKey(key);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A68A8 Offset: 0x30A68A8 VA: 0x30A68A8
        |-IndexableDictionary<int, object>.ContainsKey
        |
        |-RVA: 0x30A6DD8 Offset: 0x30A6DD8 VA: 0x30A6DD8
        |-IndexableDictionary<object, object>.ContainsKey
        |-IndexableDictionary<string, LayoutObjectPool>.ContainsKey
        |-IndexableDictionary<string, UGUIObjectPool>.ContainsKey
        |-IndexableDictionary<string, BgControl.BgTexture>.ContainsKey
        */

        // RVA: -1 Offset: -1
        public bool ContainsValue(TValue value)
        {
            return m_dictionary.ContainsValue(value);
        }
        /* GenericInstMethod :
        |
        |-RVA: 0x30A68EC Offset: 0x30A68EC VA: 0x30A68EC
        |-IndexableDictionary<int, object>.ContainsValue
        |
        |-RVA: 0x30A6E1C Offset: 0x30A6E1C VA: 0x30A6E1C
        |-IndexableDictionary<object, object>.ContainsValue
        |-IndexableDictionary<string, BgControl.BgTexture>.ContainsValue
        */
    }
}