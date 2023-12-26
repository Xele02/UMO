
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.RhythmGame;
using XeSys;

namespace XeApp.Game.AR
{
    public class ARDivaManager : MonoBehaviour
    {
        [SerializeField]
        private Canvas m_debugCanvas; // 0xC
        [SerializeField]
        private ARMusicPlayer m_musicPlayer; // 0x10
        [SerializeField]
        private ARTalkPlayer m_talkPlayer; // 0x14
        [SerializeField]
        private ARDivaObject m_divaObject; // 0x18
        private GameObject[] m_shadowObj = new GameObject[2]; // 0x1C
        private GameObject m_shadowPref; // 0x20
        private DivaResource m_divaResource; // 0x24
        private RhythmGameResource m_gameResource; // 0x28
        private MenuDivaGazeControl m_divaGazeControl; // 0x2C
        private bool m_isInitialized; // 0x30
        private int m_divaId = -1; // 0x34
        private int m_modelId = -1; // 0x38
        private int m_wavId = -1; // 0x3C
        private ARDivaMotionId m_motionId = ARDivaMotionId.None; // 0x40
        private int m_pauseBitFlag; // 0x44

        public bool IsLoading { get; private set; } // 0x48
        public bool IsLoaded { get; private set; } // 0x49

        // RVA: 0x161D684 Offset: 0x161D684 VA: 0x161D684
        public void Start()
        {
            m_debugCanvas.gameObject.SetActive(false);
            this.StartCoroutineWatched(Co_Initialize());
        }

        // RVA: 0x161D778 Offset: 0x161D778 VA: 0x161D778
        public void OnDestroy()
        {
            m_divaObject.Release();
            m_divaResource.ReleaseAll();
        }

        // [IteratorStateMachineAttribute] // RVA: 0x677B64 Offset: 0x677B64 VA: 0x677B64
        // // RVA: 0x161D6F0 Offset: 0x161D6F0 VA: 0x161D6F0
        private IEnumerator Co_Initialize()
        {
            //0x11CCEF0
            m_isInitialized = false;
            while(GameManager.Instance == null)
                yield return null;
            m_divaResource = GameManager.Instance.divaResource;
            IsLoading = false;
            IsLoaded = false;
            while(ARMenuManager.Instance == null)
                yield return null;
            ARMenuManager.Instance.pauseButton.OnPauseCallback = Pause;
            ARMenuManager.Instance.pauseButton.OnResumeCallback = Resume;
            m_isInitialized = true;
        }

        // // RVA: 0x161D7C8 Offset: 0x161D7C8 VA: 0x161D7C8
        // public bool IsReady() { }

        // RVA: 0x161D7D0 Offset: 0x161D7D0 VA: 0x161D7D0
        public bool IsPaused()
        {
            if(m_motionId == ARDivaMotionId.Talk)
            {
                return m_talkPlayer.IsPaused();
            }
            if(m_motionId == ARDivaMotionId.Dance)
            {
                return m_musicPlayer.IsPaused();
            }
            return false;
        }

        // RVA: 0x161D838 Offset: 0x161D838 VA: 0x161D838
        public bool CheckLoadedDiva(ARMarkerMasterData.Data markerData)
        {
            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[markerData.costumeId - 1];
            bool b = false;
            if(IsLoaded && m_divaId == markerData.divaId)
            {
                if(m_modelId == cos.DAJGPBLEEOB_PrismCostumeModelId && m_wavId == markerData.wavId && m_motionId == markerData.motionId)
                    b = true;
            }
            return b;
        }

        // RVA: 0x161DA18 Offset: 0x161DA18 VA: 0x161DA18
        public void Reset() 
        {
            this.StopAllCoroutinesWatched();
            Hide();
            m_pauseBitFlag = 0;
            Pause(PauseType.Force);
            m_musicPlayer.Reset();
            m_talkPlayer.Stop();
            IsLoaded = false;
            for(int i = 0; i < m_shadowObj.Length; i++)
            {
                if(m_shadowObj[i] != null)
                {
                    CircleShadow c = m_shadowObj[i].GetComponent<CircleShadow>();
                    if(c != null)
                        c.Reset();
                }
            }
        }

        // // RVA: 0x161DFA4 Offset: 0x161DFA4 VA: 0x161DFA4
        private void ListupDownloadList(List<string> assetList, List<string> cueSheetList, ARMarkerMasterData.Data markerData)
        {
            assetList.Add("dv/ca/cmn.xab");
            assetList.Add(string.Format("dv/ca/{0:D3}.xab", markerData.divaId));
            int cosId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[markerData.costumeId - 1].DAJGPBLEEOB_PrismCostumeModelId;
            assetList.Add(string.Format("dv/cs/{0:D3}_{1:D3}.xab", markerData.divaId, cosId));
            assetList.Add(string.Format("dv/bs/{0:D3}_{1:D3}.xab", markerData.divaId, cosId));
            int pId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(markerData.divaId).FPMGHDKACOF_PersonalityId;
            assetList.Add(string.Format("dv/ty/{0:D3}.xab", pId));
            if(markerData.motionId == ARDivaMotionId.Talk)
            {
                assetList.Add("mn/ft.xab");
                cueSheetList.Add(string.Format("cs_ar_diva_{0:D3}", markerData.divaId));
            }
            else if(markerData.motionId == ARDivaMotionId.Dance)
            {
                assetList.Add("mc/cmn/bs.xab");
                assetList.Add("dv/mk/bt/cmn.xab");
                int bId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(markerData.divaId).IDDHKOEFJFB_BodyId;
                assetList.Add(string.Format("mc/{0:D4}/ar{1:D3}.xab", markerData.wavId, bId));
                assetList.Add(string.Format("mc/{0:D4}/bt{1:D3}.xab", markerData.wavId, bId));
                assetList.Add(string.Format("mc/{0:D4}/ft.xab", markerData.wavId));
                assetList.Add(string.Format("mc/{0:D4}/sc.xab", markerData.wavId));
                assetList.Add(string.Format("dv/mk/bt/{0:D3}.xab", markerData.wavId));
                cueSheetList.Add(string.Format("cs_ar_w_{0:D4}", markerData.wavId));
            }
            if(markerData.stampId > 0)
            {
                assetList.Add(string.Format("ct/ar/st/01/{0}{1:D2}.xab", markerData.eventId, markerData.eventId));
                assetList.Add(string.Format("ct/ar/st/02/{0}{1:D2}.xab", markerData.eventId, markerData.eventId));
            }
        }

        // [IteratorStateMachineAttribute] // RVA: 0x677BDC Offset: 0x677BDC VA: 0x677BDC
        // // RVA: 0x161E92C Offset: 0x161E92C VA: 0x161E92C
        private IEnumerator Co_DownloadAssets(ARMarkerMasterData.Data markerData)
        {
            //0x11CC9FC
            List<string> l = new List<string>();
            List<string> l2 = new List<string>();
            ListupDownloadList(l, l2, markerData);
            for(int i = 0; i < l.Count; i++)
            {
                if(KDLPEDBKMID.HHCJCDFCLOB.EGIFDIFALKK(l[i]))
                {
                    KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(l[i]);
                }
                else
                {
                    Debug.Log("not found asset : " + l[i]);
                }
            }
            for(int i = 0; i < l2.Count; i++)
            {
                SoundResource.InstallCueSheet(l2[i]);
            }
            yield return null;
            while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
                yield return null;
        }

        // // RVA: 0x161E9D0 Offset: 0x161E9D0 VA: 0x161E9D0
        public void Release()
        {
            if(m_gameResource != null)
            {
                DestroyImmediate(m_gameResource);
                m_gameResource = null;
            }
            m_divaResource.ReleaseAll();
            m_divaObject.Stop();
            IsLoaded = false;
        }

        // RVA: 0x161EAF0 Offset: 0x161EAF0 VA: 0x161EAF0
        public void Load(ARMarkerMasterData.Data markerData)
        {
            if(IsLoading)
                return;
            this.StopAllCoroutinesWatched();
            this.StartCoroutineWatched(Co_Load(markerData));
        }

        // [IteratorStateMachineAttribute] // RVA: 0x677C54 Offset: 0x677C54 VA: 0x677C54
        // // RVA: 0x161EB38 Offset: 0x161EB38 VA: 0x161EB38
        private IEnumerator Co_Load(ARMarkerMasterData.Data markerData)
        {
            int divaId; // 0x1C
            ARDivaMotionId motionId; // 0x20
            int modelId; // 0x24
            int wavId; // 0x28
            int bgmId; // 0x2C
            float shadowScale; // 0x30
            int i; // 0x34
            CircleShadow shadow; // 0x38

            //0x11CD464
            IsLoading = true;
            m_musicPlayer.Stop();
            m_talkPlayer.Stop();
            Release();
            yield return Resources.UnloadUnusedAssets();
            yield return Co.R(Co_DownloadAssets(markerData));
            divaId = markerData.divaId;
            motionId = markerData.motionId;
            modelId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[markerData.costumeId - 1].DAJGPBLEEOB_PrismCostumeModelId;
            wavId = markerData.wavId;
            bgmId = BgmPlayer.AR_BGM_ID_BASE + wavId;
            yield return Co.R(Co_LoadResource(divaId, modelId, wavId, motionId));
            ARFacialBlendAnimMediator bam = m_divaObject.GetComponentInChildren<ARFacialBlendAnimMediator>();
            bam.motionId = motionId;
            m_divaObject.motionId = motionId;
            m_divaObject.Initialize(m_divaResource, divaId, false);
            if(motionId == 0)
            {
                m_divaObject.AdjustHight(m_gameResource.musicData.musicParam.mikeStandOffsetRate);
                m_divaObject.SetupBoneSpring(m_gameResource, 0);
            }
            m_divaObject.LockBoneSpring(0);
            shadowScale = VuforiaManager.GetCharaModelHeight(divaId) / VuforiaManager.GetCharaModelHeight(1);
            for(i = 0; i < m_shadowObj.Length; i++)
            {
                if(m_shadowObj[i] == null)
                {
                    m_shadowObj[i] = Instantiate(m_shadowPref, m_divaObject.transform);
                }
                m_shadowObj[i].SetActive(true);
                shadow = m_shadowObj[i].GetComponent<CircleShadow>();
                if(shadow != null)
                {
                    ARObject aro = FindObjectOfType<ARObject>();
                    shadow.SetSerialNo(i);
                    shadow.SetBaseScale(shadowScale);
                    shadow.SetARObject(aro);
                    shadow.Initialize();
                    while(!shadow.IsInitialized())
                        yield return null;
                }
            }
            if(motionId == 0)
            {
                bool isFinish = false;
                m_musicPlayer.Setup(m_divaObject, bgmId, () =>
                {
                    //0x11CC9CC
                    isFinish = true;
                });
                //LAB_011ce378
                while(!isFinish)
                    yield return null;
            }
            else if(motionId == ARDivaMotionId.Talk)
            {
                yield return Co.R(m_talkPlayer.Co_Setup(m_divaObject, markerData));
            }
            //LAB_011ce400
            m_divaId = divaId;
            m_modelId = modelId;
            m_wavId = wavId;
            m_motionId = motionId;
            yield return null;
            ARMenuManager.Instance.pauseButton.Reset();
            if(markerData.pattern == ARDivaPatternId.LifeSize)
            {
                if(m_divaObject.divaPrefab != null)
                {
                    BoneSpringController bsc = m_divaObject.divaPrefab.GetComponentInChildren<BoneSpringController>(true);
                    Matrix4x4 m = Matrix4x4.identity;
                    m.SetColumn(0, m_divaObject.divaPrefab.transform.right);
                    m.SetColumn(1, m_divaObject.divaPrefab.transform.up);
                    m.SetColumn(2, m_divaObject.divaPrefab.transform.forward);
                    bsc.fieldForce_ = m * bsc.fieldForce_;
                }
            }
            Show();
            IsLoading = false;
            IsLoaded = true;
        }

        // [IteratorStateMachineAttribute] // RVA: 0x677CCC Offset: 0x677CCC VA: 0x677CCC
        // // RVA: 0x161EBDC Offset: 0x161EBDC VA: 0x161EBDC
        private IEnumerator Co_LoadResource(int divaId, int modelId, int wavId, ARDivaMotionId motionId)
        {
            int primeId; // 0x24
            AssetBundleLoadAllAssetOperationBase op; // 0x28

            //0x11CE90C
            primeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(divaId).IDDHKOEFJFB_BodyId;
            m_divaResource.LoadBasicResource(divaId, modelId, 0);
            if(motionId == ARDivaMotionId.Talk)
            {
                m_divaResource.LoadARResource(divaId, modelId);
                //LAB_011ceed0
                while(!m_divaResource.isARAllLoaded)
                    yield return null;
            }
            if(motionId == ARDivaMotionId.Dance)
            {
                m_divaResource.LoadFacialResource(divaId, wavId, 1);
                m_divaResource.LoadMusicAnimationResource(wavId, primeId, 1, 1, 0);
                while(!m_divaResource.isMusicAllLoaded)
                    yield return null;
                m_divaResource.LoadARMusicAnimationResource(wavId, primeId);
                while(!m_divaResource.isLoadedARMusicAnimationResource)
                    yield return null;
                m_gameResource = m_divaObject.gameObject.AddComponent<RhythmGameResource>();
                m_gameResource.musicData.LoadARData(wavId);
                if(m_gameResource.musicBoneSpringResource[0] == null)
                {
                    m_gameResource.musicBoneSpringResource[0].LoadMusicResouces(wavId, primeId, 1, 0);
                }
                yield return new WaitWhile(() =>
                {
                    //0x161F164
                    if(m_gameResource.musicData.isARLoaded)
                    {
                        if(m_gameResource.musicBoneSpringResource[0] != null)
                        {
                            return !m_gameResource.musicBoneSpringResource[0].isAllLoaded;
                        }
                        return false;
                    }
                    return true;
                });
            }
            if(m_shadowPref != null)
                yield break;
            op = AssetBundleManager.LoadAllAssetAsync("ar/dv.xab");
            yield return op;
            m_shadowPref = op.GetAsset<GameObject>("CircleShadow");
            op = null;
            yield break;
        }

        // RVA: 0x161ECC8 Offset: 0x161ECC8 VA: 0x161ECC8
        public void Play()
        { 
            m_divaObject.UnlockBoneSpring(true, 0);
            if(m_motionId != ARDivaMotionId.Talk)
            {
                if(m_motionId != ARDivaMotionId.Dance)
                    return;
                m_musicPlayer.StartPlayMusic();
                return;
            }
            m_talkPlayer.StartPlay();
        }

        // RVA: 0x161DED8 Offset: 0x161DED8 VA: 0x161DED8
        public void Pause(PauseType type = 0)
        {
            if(type < PauseType.System && type > PauseType.Force)
                return;
            if(type != PauseType.Force)
                m_pauseBitFlag |= 1 << (int)type;
            if(m_motionId == ARDivaMotionId.Talk)
            {
                m_talkPlayer.Pause();
            }
            else if(m_motionId == ARDivaMotionId.Dance)
            {
                m_musicPlayer.Pause();
            }
            ARMenuManager.Instance.pauseButton.Pause();
        }

        // RVA: 0x161ED58 Offset: 0x161ED58 VA: 0x161ED58
        public void Resume(PauseType type = 0)
        {
            if(type < PauseType.System && type > PauseType.Force)
                return;
            if(type == PauseType.Force)
                m_pauseBitFlag = 0;
            else
            {
                m_pauseBitFlag &= ~(1 << (int)type);
                if(m_pauseBitFlag != 0)
                    return;
            }
            if(m_motionId == ARDivaMotionId.Talk)
            {
                m_talkPlayer.Resume();
            }
            else if(m_motionId == ARDivaMotionId.Dance)
            {
                m_musicPlayer.Resume();
            }
            ARMenuManager.Instance.pauseButton.Resume();
        }

        // RVA: 0x161EE3C Offset: 0x161EE3C VA: 0x161EE3C
        public void Show()
        {
            m_divaObject.SetEnableRenderer(true);
            if(ARMenuManager.Instance == null)
                return;
            ARMenuManager.Instance.resetButton.gameObject.SetActive(true);
            ARMenuManager.Instance.pauseButton.gameObject.SetActive(m_motionId == 0);
            for(int i = 0; i < m_shadowObj.Length; i++)
            {
                if(m_shadowObj[i] != null)
                {
                    m_shadowObj[i].SetActive(true);
                }
            }
        }

        // RVA: 0x161DC44 Offset: 0x161DC44 VA: 0x161DC44
        public void Hide()
        {
            m_divaObject.SetEnableRenderer(false);
            if(ARMenuManager.Instance == null)
                return;
            ARMenuManager.Instance.resetButton.gameObject.SetActive(false);
            ARMenuManager.Instance.pauseButton.gameObject.SetActive(false);
            for(int i = 0; i < m_shadowObj.Length; i++)
            {
                if(m_shadowObj[i] != null)
                {
                    m_shadowObj[i].SetActive(false);
                }
            }
        }
    }
}