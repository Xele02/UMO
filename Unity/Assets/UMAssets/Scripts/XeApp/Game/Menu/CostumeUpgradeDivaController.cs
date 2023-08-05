using mcrs;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeDivaController : MonoBehaviour
	{
		public enum Controlype
		{
			CostumeSelect = 0,
			ItemSelect = 1,
		}

		private const int TouchNum = 3;
		private Controlype m_type; // 0xC
		private int m_divaId; // 0x10
		private int m_costumeModelId; // 0x14
		private int m_colorId; // 0x18
		private List<string> m_motionList = new List<string>(); // 0x1C
		private List<string> m_loopMotionList = new List<string>(); // 0x20
		private string m_queSheetName; // 0x24
		private DivaResource m_divaResource; // 0x28
		private SimpleDivaAnimation m_simpleDivaAnimation; // 0x2C
		private SimpleDivaObject m_divaObject; // 0x30
		private MenuDivaManager m_divaManager; // 0x38
		private float m_intervalTimer; // 0x3C
		private int m_prevIntervalVoiceId = -1; // 0x40
		private Camera m_camera = new Camera(); // 0x44
		private static readonly string[] DownLoadDivaAssetPath = new string[3] {
			"dv/ca/{0:D3}.xab", "dv/cs/{0:D3}_{1:D3}.xab", "dv/ca/{0:D3}.xab"
		}; // 0x0
		private static readonly string DownLoadCmnDivaAssetPath = "dv/ca/cmn.xab"; // 0x4
		private static readonly string DownLoadCsDivaTexAssetPath = "dv/cs/{0:D3}_{1:D3}_{2:D2}.xab"; // 0x8
		private static readonly string DownLoadBsDivaAssetPath = "dv/bs/{0:D3}_{1:D3}.xab"; // 0xC
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x48

		public bool isLoadedModel { get; private set; } // 0x34

		//// RVA: 0x16F1B30 Offset: 0x16F1B30 VA: 0x16F1B30
		public void Initialize(Controlype type, int divaId, int costumeModelId, int colorId = 0)
		{
			m_type = type;
			m_divaId = divaId;
			m_costumeModelId = costumeModelId;
			m_colorId = colorId;
			m_motionList.Clear();
			m_loopMotionList.Clear();
			if (type == Controlype.CostumeSelect)
			{
				m_loopMotionList.Add("diva_{0:D3}_menu_simple_loop02_{1}");
				m_motionList.Add("diva_{0:D3}_menu_reaction01_{1}");
				m_motionList.Add("diva_{0:D3}_menu_reaction02_{1}");
				m_motionList.Add("diva_{0:D3}_menu_reaction03_{1}");
			}
			m_queSheetName = "cs_cosupg";
			if(m_divaResource == null)
			{
				GameObject g = new GameObject("DivaResourceObj");
				g.transform.SetParent(transform);
				m_divaResource = g.AddComponent<DivaResource>();
			}
			m_divaManager = MenuScene.Instance.divaManager;
			m_intervalTimer = 0;
			InitializeCamera();
		}

		//// RVA: 0x16F232C Offset: 0x16F232C VA: 0x16F232C
		public void LoadDivaResource()
		{
			isLoadedModel = false;
			this.StartCoroutineWatched(Co_LoadDivaResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CE9EC Offset: 0x6CE9EC VA: 0x6CE9EC
		//// RVA: 0x16F235C Offset: 0x16F235C VA: 0x16F235C
		private IEnumerator Co_LoadDivaResource()
		{
			//0x16F382C
			yield return this.StartCoroutineWatched(Co_LoadSimpleDivaAnimation());
			m_simpleDivaAnimation.LoadResource(m_divaId, m_costumeModelId, m_colorId, m_motionList, m_loopMotionList, "cs_cosupg");
			yield return new WaitWhile(() =>
			{
				//0x16F36C8
				return m_simpleDivaAnimation.m_IsLoading;
			});
			m_divaObject = m_simpleDivaAnimation.transform.Find("SimpleDivaPrefab").GetComponent<SimpleDivaObject>();
			m_divaObject.setAdjuster();
			m_divaObject.gameObject.SetActive(true);
			m_simpleDivaAnimation.transform.SetParent(m_divaManager.transform);
			m_simpleDivaAnimation.SetVisible(true);
			InitializeCamera();
			isLoadedModel = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CEA64 Offset: 0x6CEA64 VA: 0x6CEA64
		//// RVA: 0x16F2408 Offset: 0x16F2408 VA: 0x16F2408
		private IEnumerator Co_LoadSimpleDivaAnimation()
		{
			//0x16F3C94
			if(m_simpleDivaAnimation == null)
			{
				bool isLoaded = false;
				ResourcesManager.Instance.Load("Menu/Prefab/3dModel/SimpleDivaAnimation", (FileResultObject anm) =>
				{
					//0x16F36FC
					GameObject g = Instantiate(anm.unityObject) as GameObject;
					m_simpleDivaAnimation = g.GetComponent<SimpleDivaAnimation>();
					isLoaded = true;
					return false;
				});
				yield return new WaitUntil(() =>
				{
					//0x16F3820
					return isLoaded;
				});
				m_simpleDivaAnimation.m_divaResource = m_divaResource;
			}
		}

		//// RVA: 0x16F24B4 Offset: 0x16F24B4 VA: 0x16F24B4
		public void DestoryCamera()
		{
			EnableCamera(false);
			Destroy(m_camera.gameObject);
			m_camera = null;
		}

		//// RVA: 0x16F2684 Offset: 0x16F2684 VA: 0x16F2684
		public void Release()
		{
			DestoryCamera();
			if(m_simpleDivaAnimation != null)
			{
				m_simpleDivaAnimation.Release();
				Destroy(m_simpleDivaAnimation.gameObject);
			}
		}

		//// RVA: 0x16F1E6C Offset: 0x16F1E6C VA: 0x16F1E6C
		public void InitializeCamera()
		{
			if(m_camera == null)
			{
				m_camera = Instantiate(m_divaManager.transform.Find("DivaCamera").GetComponent<Camera>().gameObject).GetComponent<Camera>();
				m_camera.transform.SetPositionX(0);
				m_camera.transform.SetPositionY(0);
				m_camera.transform.SetPositionZ(30);
				m_camera.transform.rotation = Quaternion.Euler(0, -168, 0);
			}
			Vector3 p = m_camera.transform.localPosition;
			if(m_divaResource.divaMenuParam != null)
			{
				p.y = m_divaResource.divaMenuParam.CameraPosY(DivaMenuParam.CameraPosType.Default)[m_divaId - 1] + 1;
			}
			m_camera.transform.localPosition = p;
			EnableCamera(true);
		}

		//// RVA: 0x16F2570 Offset: 0x16F2570 VA: 0x16F2570
		private void EnableCamera(bool isEnable)
		{
			m_divaManager.transform.Find("DivaCamera").GetComponent<Camera>().enabled = !isEnable;
			m_camera.enabled = isEnable;
		}

		//// RVA: 0x16F279C Offset: 0x16F279C VA: 0x16F279C
		public void StopMotion()
		{
			m_simpleDivaAnimation.StopMotion();
		}

		//// RVA: 0x16F27C8 Offset: 0x16F27C8 VA: 0x16F27C8
		public void StartEntryMotion()
		{
			if (!isLoadedModel)
				return;
			m_simpleDivaAnimation.StartEntryMotion();
			PlayVoice(CostumeUpgradeVoiceDataTable.VoiceType.Entry, -1);
		}

		//// RVA: 0x16F28C8 Offset: 0x16F28C8 VA: 0x16F28C8
		public bool IsPlayingIdle()
		{
			return m_simpleDivaAnimation.IsPlayingIdle();
		}

		//// RVA: 0x16F28F4 Offset: 0x16F28F4 VA: 0x16F28F4
		public bool IsPlayingEntry()
		{
			return m_simpleDivaAnimation.IsPlayingEntry();
		}

		//// RVA: 0x16F2920 Offset: 0x16F2920 VA: 0x16F2920
		public void UpdateIntervalMotion()
		{
			if(IsPlayingIdle())
			{
				m_intervalTimer += Time.deltaTime;
				if(!PopupWindowManager.IsActivePopupWindow() && 10 <= m_intervalTimer)
				{
					m_intervalTimer = 0;
					StartIntervalMotion();
				}
			}
		}

		//// RVA: 0x16F2A08 Offset: 0x16F2A08 VA: 0x16F2A08
		public void StartIntervalMotion()
		{
			if (!isLoadedModel)
				return;
			m_simpleDivaAnimation.StartSimpleMotion(0);
			m_prevIntervalVoiceId = PlayVoice(CostumeUpgradeVoiceDataTable.VoiceType.Idle, m_prevIntervalVoiceId);
		}

		//// RVA: 0x16F2A5C Offset: 0x16F2A5C VA: 0x16F2A5C
		public void StartTouchMotion()
		{
			if(isLoadedModel)
			{
				if(m_simpleDivaAnimation.IsPlayingIdle())
				{
					if(m_simpleDivaAnimation.IsPlayingIdleMouth())
					{
						if (m_simpleDivaAnimation.IsPlayingVoice())
							return;
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_HOME_000);
						m_intervalTimer = 0;
						int num = UnityEngine.Random.Range(0, 3);
						m_simpleDivaAnimation.StartSimpleMotion(num);
						PlayVoice(CostumeUpgradeVoiceDataTable.VoiceType.Touch1 + num, -1);
					}
				}
			}
		}

		//// RVA: 0x16F2B90 Offset: 0x16F2B90 VA: 0x16F2B90
		//public void StartIdleMotion() { }

		//// RVA: 0x16F2814 Offset: 0x16F2814 VA: 0x16F2814
		public int PlayVoice(CostumeUpgradeVoiceDataTable.VoiceType type, int exclusionId = -1)
		{
			return m_simpleDivaAnimation.PlayVoiceRandom(CostumeUpgradeVoiceDataTable.VoiceTable(type), exclusionId);
		}

		//// RVA: 0x16F2C8C Offset: 0x16F2C8C VA: 0x16F2C8C
		public void StopVoice()
		{
			if (!isLoadedModel)
				return;
			m_simpleDivaAnimation.StopVoice();
		}

		//// RVA: 0x16F2CC4 Offset: 0x16F2CC4 VA: 0x16F2CC4
		public void SetVisible(bool isEnable)
		{
			m_intervalTimer = 0;
			if (isLoadedModel)
				m_divaObject.SetEnableEffect(isEnable);
			EnableCamera(isEnable);
		}

		//// RVA: 0x16F1E60 Offset: 0x16F1E60 VA: 0x16F1E60
		//private void ResetIntervalTime() { }

		//// RVA: 0x16F2D1C Offset: 0x16F2D1C VA: 0x16F2D1C
		public void TryInstall(int divaId, int modelId)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(divaId, modelId);
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(DownLoadCmnDivaAssetPath);
			for(int i = 0; i < DownLoadDivaAssetPath.Length; i++)
			{
				m_strBuilder.SetFormat(DownLoadDivaAssetPath[i], divaId, modelId);
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
			}
			if(cosInfo.GLEEPAFMPLO_HasTextureBundle)
			{
				m_strBuilder.SetFormat(DownLoadCsDivaTexAssetPath, divaId, modelId, 0);
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
			}
			if(!SoundResource.IsInstalledCueSheet("cs_cosupg"))
			{
				SoundResource.InstallCueSheet("cs_cosupg");
			}
			m_strBuilder.SetFormat(DownLoadBsDivaAssetPath, divaId, modelId);
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
		}
	}
}
