using System.Collections.Generic;

namespace CriWare
{
    public class CriFsServer : CriMonoBehaviour
    {
        private static CriFsServer _instance; // 0x0
        private List<CriFsRequest> requestList; // 0x1C

        public static CriFsServer instance { get { 
            CreateInstance();
            return _instance;
        } } // get_instance 0x294BA90
        public int installBufferSize { get; set; } // 0x20

        // // RVA: 0x294BB20 Offset: 0x294BB20 VA: 0x294BB20
        public static void CreateInstance()
        {
            if(_instance != null)
                return;
            CriWare.Common.managerObject.AddComponent<CriFsServer>();
            _instance.installBufferSize = CriFsPlugin.installBufferSize;
        }

        // // RVA: 0x294A6DC Offset: 0x294A6DC VA: 0x294A6DC
        // public static void DestroyInstance() { }

        // RVA: 0x294BCFC Offset: 0x294BCFC VA: 0x294BCFC
        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                requestList = new List<CriFsRequest>();
                requestList.Add(new CriFsRequest());
                requestList.RemoveAt(0);
                return;
            }
            UnityEngine.Object.Destroy(this);
        }

        // RVA: 0x294BF04 Offset: 0x294BF04 VA: 0x294BF04
        private void OnDestroy()
        {
            TodoLogger.Log(0, "TODO");
        }

        // // RVA: 0x294C138 Offset: 0x294C138 VA: 0x294C138 Slot: 6
        public override void CriInternalUpdate()
        {
            CriFsInstaller.ExecuteMain();
            if(CriFsWebInstaller.isInitialized)
            {
                CriFsWebInstaller.ExecuteMain();
            }
            for(int i = 0; i < requestList.Count; i++)
            {
                requestList[i].Update();
            }
            for(int i = 0; i < requestList.Count; i++)
            {
                if(requestList[i].isDone || requestList[i].isDisposed)
                {
                requestList.Remove(requestList[i]);
                }
            }
        }

        // // RVA: 0x294C464 Offset: 0x294C464 VA: 0x294C464 Slot: 7
        public override void CriInternalLateUpdate()
        {
            return;
        }

        // // RVA: 0x294C468 Offset: 0x294C468 VA: 0x294C468
        public void AddRequest(CriFsRequest request)
        {
            requestList.Add(request);
        }

        // // RVA: 0x294C4E8 Offset: 0x294C4E8 VA: 0x294C4E8
        public CriFsLoadFileRequest LoadFile(CriFsBinder binder, string path, CriFsRequest.DoneDelegate doneDelegate, int readUnitSize)
        {
            CriFsLoadFileRequest request = new CriFsLoadFileRequest(binder, path, doneDelegate, readUnitSize);
            AddRequest(request);
            return request;
        }

        // // RVA: 0x294C588 Offset: 0x294C588 VA: 0x294C588
        // public CriFsLoadAssetBundleRequest LoadAssetBundle(CriFsBinder binder, string path, int readUnitSize) { }

        // // RVA: 0x294C620 Offset: 0x294C620 VA: 0x294C620
        // public CriFsInstallRequest Install(CriFsBinder srcBinder, string srcPath, string dstPath, CriFsRequest.DoneDelegate doneDelegate) { }

        // // RVA: 0x294C6EC Offset: 0x294C6EC VA: 0x294C6EC
        // public CriFsInstallRequest WebInstall(string srcPath, string dstPath, CriFsRequest.DoneDelegate doneDelegate) { }

        // // RVA: 0x294C8AC Offset: 0x294C8AC VA: 0x294C8AC
        // public CriFsBindRequest BindCpk(CriFsBinder targetBinder, CriFsBinder srcBinder, string path) { }

        // // RVA: 0x294C948 Offset: 0x294C948 VA: 0x294C948
        // public CriFsBindRequest BindDirectory(CriFsBinder targetBinder, CriFsBinder srcBinder, string path) { }

        // // RVA: 0x294C9E4 Offset: 0x294C9E4 VA: 0x294C9E4
        // public CriFsBindRequest BindFile(CriFsBinder targetBinder, CriFsBinder srcBinder, string path) { }
    }
}