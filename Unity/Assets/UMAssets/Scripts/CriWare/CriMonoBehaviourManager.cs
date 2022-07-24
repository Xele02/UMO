using UnityEngine;
using System.Threading;
using System.Collections.Generic;

namespace CriWare
{

    public class CriMonoBehaviourManager : MonoBehaviour
    {
        private static CriMonoBehaviourManager _instance; // 0x0
        private static List<CriMonoBehaviour> criMonoBehaviourList = new List<CriMonoBehaviour>(); // 0x4

        public static CriMonoBehaviourManager instance { get{
            CreateInstance();
            return _instance;
        } } // 0x29663F8

        // RVA: 0x2966904 Offset: 0x2966904 VA: 0x2966904
        public static void CreateInstance()
        {
            if(_instance != null)
                return;
            
            CriWare.Common.managerObject.AddComponent<CriMonoBehaviourManager>();
        }

        // RVA: 0x2966A34 Offset: 0x2966A34 VA: 0x2966A34
        private static int GetIndex(CriMonoBehaviour criMonoBehaviour)
        {
            for(int i = 0; i < criMonoBehaviourList.Count; i++)
            {
                if(criMonoBehaviour.guid == criMonoBehaviourList[i].guid)
                    return i;
            }
            return -1;
        }

        // RVA: 0x2966488 Offset: 0x2966488 VA: 0x2966488
        public bool Register(CriMonoBehaviour criMonoBehaviour)
        {
            lock (criMonoBehaviourList) {
                if (GetIndex(criMonoBehaviour) >= 0) {
                    UnityEngine.Debug.LogWarning("[CRIWARE] Internal: Duplicated CriMonoBehaviour GUID");
                    return false;
                }
                criMonoBehaviourList.Add(criMonoBehaviour);
            }
            return true;
        }

        // RVA: 0x29666E8 Offset: 0x29666E8 VA: 0x29666E8
        public static bool UnRegister(CriMonoBehaviour criMonoBehaviour)
        {
            lock (criMonoBehaviourList) {
                int index = GetIndex(criMonoBehaviour);
                if (index < 0) {
                    return false;
                }
                criMonoBehaviourList.RemoveAt(index);
            }
            return true;
        }

        // RVA: 0x2966C78 Offset: 0x2966C78 VA: 0x2966C78
        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                return;
            }
            UnityEngine.Object.Destroy(this);
        }

        // RVA: 0x2966DCC Offset: 0x2966DCC VA: 0x2966DCC
        private void Update()
        {
            lock (criMonoBehaviourList) {
                for (int i = 0; i < criMonoBehaviourList.Count; i++) {
                    criMonoBehaviourList[i].CriInternalUpdate();
                }
            }
        }

        // RVA: 0x296701C Offset: 0x296701C VA: 0x296701C
        private void LateUpdate()
        {
            lock (criMonoBehaviourList) {
                for (int i = 0; i < criMonoBehaviourList.Count; i++) {
                    criMonoBehaviourList[i].CriInternalLateUpdate();
                }
            }
        }
    }
}