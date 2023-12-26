
using System.Collections;
using UdonLib;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.AR
{
    public class AREngineBase
    {
        protected const string DATASET_LOCAL_PATH = "/ardata";
        protected VuforiaManager m_vm; // 0x8
        protected bool m_initializeOk; // 0xC
        protected VuforiaManager.ERROR_TYPE m_errorStatus; // 0x10

        
        // RVA: 0x11CF08C Offset: 0x11CF08C VA: 0x11CF08C
        protected AREngineBase(VuforiaManager vm)
        {
            m_vm = vm;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678084 Offset: 0x678084 VA: 0x678084
        // RVA: 0x11CF0AC Offset: 0x11CF0AC VA: 0x11CF0AC Slot: 4
        public virtual IEnumerator CoInitialize()
        {
            //0x11CF584
            m_initializeOk = false;
            yield return null;
        }

        // RVA: 0x11CF158 Offset: 0x11CF158 VA: 0x11CF158
        public bool IsInitializeOK()
        {
            return m_initializeOk;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6780FC Offset: 0x6780FC VA: 0x6780FC
        // RVA: 0x11CF160 Offset: 0x11CF160 VA: 0x11CF160 Slot: 5
        public virtual IEnumerator CoLoadMarkerData(AssetBundleLoadAllAssetOperationBase op)
        {
            //0x11CF684
            yield return null;
        }

        // RVA: 0x11CF1F4 Offset: 0x11CF1F4 VA: 0x11CF1F4 Slot: 6
        public virtual Camera GetARCamera()
        {
            return null;
        }

        // RVA: 0x11CF1FC Offset: 0x11CF1FC VA: 0x11CF1FC Slot: 7
        public virtual Camera GetCanvasCamera()
        {
            return null;
        }

        // RVA: 0x11CF204 Offset: 0x11CF204 VA: 0x11CF204 Slot: 8
        public virtual Camera GetRenderCamera()
        {
            return null;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x678174 Offset: 0x678174 VA: 0x678174
        // RVA: 0x11CF20C Offset: 0x11CF20C VA: 0x11CF20C Slot: 9
        public virtual IEnumerator StartTracking()
        {
            yield return null;
        }

        // RVA: 0x11CF2A0 Offset: 0x11CF2A0 VA: 0x11CF2A0 Slot: 10
        public virtual void SetupTrackingMode(GameObject trackingObj, int trackingType)
        {
            return;
        }

        // RVA: 0x11CF2A4 Offset: 0x11CF2A4 VA: 0x11CF2A4 Slot: 11
        public virtual void StopExtendedTracking(GameObject trackingObj)
        {
            return;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6781EC Offset: 0x6781EC VA: 0x6781EC
        // RVA: 0x11CF2A8 Offset: 0x11CF2A8 VA: 0x11CF2A8 Slot: 12
        // public virtual IEnumerator CoChangeCameraSide() { }

        // RVA: 0x11CF33C Offset: 0x11CF33C VA: 0x11CF33C Slot: 13
        public virtual void StopTracking(GameObject currTrackingObj)
        {
            return;
        }

        // RVA: 0x11CF340 Offset: 0x11CF340 VA: 0x11CF340 Slot: 14
        public virtual void RestartTracking()
        {
            return;
        }

        // RVA: 0x11CF344 Offset: 0x11CF344 VA: 0x11CF344 Slot: 15
        // public virtual void FinishProcess() { }

        // RVA: 0x11CF348 Offset: 0x11CF348 VA: 0x11CF348 Slot: 16
        public virtual void RenderPhotoTexture(RenderTexture rt, Texture2D photoTexture)
        {
            return;
        }

        // RVA: 0x11CF34C Offset: 0x11CF34C VA: 0x11CF34C Slot: 17
        public virtual void SetCurrentMasterData(ARMarkerMasterData.Data data)
        {
            return;
        }

        // RVA: 0x11CF350 Offset: 0x11CF350 VA: 0x11CF350 Slot: 18
        public virtual void StartCamera()
        {
            return;
        }

        // RVA: 0x11CF354 Offset: 0x11CF354 VA: 0x11CF354 Slot: 19
        public virtual void StopCamera()
        {
            return;
        }

        // RVA: 0x11CF358 Offset: 0x11CF358 VA: 0x11CF358 Slot: 20
        public virtual Quaternion GetDivaOffsetRotation()
        {
            return Quaternion.identity;
        }

        // RVA: 0x11CF3DC Offset: 0x11CF3DC VA: 0x11CF3DC
        public VuforiaManager.ERROR_TYPE GetErrorType()
        {
            return m_errorStatus;
        }

        // RVA: 0x11CF3E4 Offset: 0x11CF3E4 VA: 0x11CF3E4
        protected bool CheckAvailableStorageKB(long kb)
        {
            long l;
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                l = IOSBridge.GetAvailableStorageKB;
            }
            else
            {
                l = AndroidUtils.GetAvailableStorageKB;
            }
            return kb < l;
        }

        // RVA: 0x11CF498 Offset: 0x11CF498 VA: 0x11CF498 Slot: 21
        public virtual bool CheckError()
        {
            return false;
        }
    }
}