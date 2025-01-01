
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.AR
    {
    public enum ARObjDispMask
    {
        TRACKING_LOST = 0,
        DIVA_REASON = 1,
    }

    public class ARObject : MonoBehaviour
    {
        private const float FADE_TIME = 0.3f;
        private int m_displayMaskFlag; // 0xC
        [SerializeField]
        private ARDivaManager m_divaMan; // 0x10
        [SerializeField]
        private ARDivaObject m_divaObj; // 0x14
        private GameObject m_mikeObj; // 0x18
        private ARMarkerMasterData.Data m_masterData; // 0x1C
        private int m_isLoading; // 0x20
        private bool m_isReady; // 0x24
        private const float DIVA_SCALE = 1;
        private static ARObject ms_instance; // 0x0

        // RVA: 0x11E3E88 Offset: 0x11E3E88 VA: 0x11E3E88
        private void Awake()
        {
            ms_instance = this;
            gameObject.AddComponent<ARDivaFlip>();
        }

        // // RVA: 0x11E3F50 Offset: 0x11E3F50 VA: 0x11E3F50
        // public static ARObject GetInstance() { }

        // RVA: 0x11E3FDC Offset: 0x11E3FDC VA: 0x11E3FDC
        private void Start()
        {
            return;
        }

        // RVA: 0x11E3FE0 Offset: 0x11E3FE0 VA: 0x11E3FE0
        private void Update()
        {
            if(transform.parent != null)
            {
                Vector3 v = new Vector3(1.0f / transform.parent.localScale.x, 1.0f / transform.parent.localScale.y, 1.0f / transform.parent.localScale.z);
                if(transform.localScale != v)
                {
                    transform.localScale = v;
                }
            }
        }

        // RVA: 0x11E4210 Offset: 0x11E4210 VA: 0x11E4210
        public void SetOffsetRotation(Quaternion offsetRot)
        {
            transform.localRotation = offsetRot;
        }

        // RVA: 0x11E4270 Offset: 0x11E4270 VA: 0x11E4270
        public void SetDiaplayMask(ARObjDispMask mask, bool disp)
        {
            if(m_isReady)
            {
                int oldFlag = m_displayMaskFlag;
                if(disp)
                    m_displayMaskFlag &= ~(1 << (int)mask);
                else
                    m_displayMaskFlag |= 1 << (int)mask;
                //Debug.Log
                if(m_divaMan.IsLoaded)
                {
                    if((m_displayMaskFlag == 0) != (oldFlag == 0))
                    {
                        if(m_displayMaskFlag == 0)
                            this.StartCoroutineWatched(Co_ShowDiva(0));
                        else
                            HideDiva();
                    }
                }
            }
        }

        // RVA: 0x11E4908 Offset: 0x11E4908 VA: 0x11E4908
        public void ResetObject()
        {
            if(m_mikeObj != null)
            {
                Destroy(m_mikeObj);
                m_mikeObj = null;
            }
            m_divaMan.Reset();
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        // RVA: 0x11E4B30 Offset: 0x11E4B30 VA: 0x11E4B30
        public void SetDivaAndShow(ARMarkerMasterData.Data data, int summonCnt)
        {
            m_displayMaskFlag = 0;
            m_masterData = data;
            this.StartCoroutineWatched(Co_ShowDiva(0));
        }

        // RVA: 0x11E4B64 Offset: 0x11E4B64 VA: 0x11E4B64
        public bool CanDraw()
        {
            return m_displayMaskFlag == 0;
        }

        // // RVA: 0x11E4B78 Offset: 0x11E4B78 VA: 0x11E4B78
        // private Vector3 parseVector3(string words, Vector3 defVal) { }

        // // RVA: 0x11E4D28 Offset: 0x11E4D28 VA: 0x11E4D28
        // private void ResetDiva() { }

        // // RVA: 0x11E48B8 Offset: 0x11E48B8 VA: 0x11E48B8
        // private void ShowDiva(int summonCnt) { }

        // RVA: 0x11E4DE0 Offset: 0x11E4DE0 VA: 0x11E4DE0
        public bool IsLoading()
        {
            return m_isLoading > 0;
        }

        // RVA: 0x11E48B0 Offset: 0x11E48B0 VA: 0x11E48B0
        public bool IsReady()
        {
            return m_isReady;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x6786C4 Offset: 0x6786C4 VA: 0x6786C4
        // // RVA: 0x11E4D54 Offset: 0x11E4D54 VA: 0x11E4D54
        private IEnumerator Co_ShowDiva(int summonCnt)
        {
            //0x11E4F08
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[m_masterData.costumeId - 1];
            //cos.DAJGPBLEEOB_PrismCostumeModelId;
            m_isLoading++;
            while(m_isLoading != 1 || (m_divaMan.IsLoaded && !m_isReady))
                yield return null;
            m_isReady = false;
            if(m_divaMan.CheckLoadedDiva(m_masterData))
            {
                m_divaMan.Show();
                m_isLoading--;
                m_isReady = true;
                yield break;
            }
            ARMenuManager.Instance.SetEnableOperate(false);
            GameManager.Instance.fullscreenFader.Fade(0.3f, Color.white);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            m_divaObj.transform.localPosition = m_masterData.position;
            m_divaObj.transform.localRotation = Quaternion.Euler(m_masterData.rotation);
            m_divaObj.transform.localScale = Vector3.one;
            m_divaMan.Load(m_masterData);
            yield return null;
            while(m_divaMan.IsLoading)
                yield return null;
            m_divaMan.Play();
            yield return new WaitForSeconds(1);
            ARDivaHitCheck ardc = FindObjectOfType<ARDivaHitCheck>();
            if(ardc.IsHitDiva(VuforiaManager.Instance.GetCameraAR().transform.position, 1))
            {
                m_divaMan.Pause(0);
                SetDiaplayMask(ARObjDispMask.DIVA_REASON, false);
            }
            m_isLoading--;
            if(m_displayMaskFlag != 0)
                HideDiva();
            GameManager.Instance.fullscreenFader.Fade(0.3f, 0);
            yield return GameManager.Instance.WaitFadeYielder;
            yield return null;
            ARMenuManager.Instance.SetEnableOperate(true);
            m_isReady = true;
        }

        // // RVA: 0x11E48DC Offset: 0x11E48DC VA: 0x11E48DC
        private void HideDiva()
        {
            m_divaMan.Hide();
        }

        // RVA: 0x11E4E14 Offset: 0x11E4E14 VA: 0x11E4E14
        public void PauseDiva()
        {
            if(m_divaMan.IsLoaded)
            {
                m_divaMan.Pause(0);
            }
        }

        // RVA: 0x11E4E70 Offset: 0x11E4E70 VA: 0x11E4E70
        public void ResumeDiva()
        {
            if(m_divaMan.IsLoaded)
            {
                m_divaMan.Resume(0);
            }
        }

        // // RVA: 0x11E4ECC Offset: 0x11E4ECC VA: 0x11E4ECC
        // public GameObject GetDivaGameObject() { }
    }
}