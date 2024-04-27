using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Text;
using mcrs;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EpisodeAppeal : MonoBehaviour
	{
		public enum AppealType
		{
			None = 0,
			Diva = 1,
			Valkyrie = 2,
		}

		private const float SKIP_WAIT_TIME = 1;
		[SerializeField]
		private TextMesh m_cosNameTextPrefab; // 0xC
		[SerializeField]
		private TextMesh m_newEpisodeNameTextPrefab; // 0x10
		[SerializeField]
		private TextMesh m_episodeNameTextPrefab; // 0x14
		[SerializeField]
		private TextMesh m_pilotNameTextPrefab; // 0x18
		private SimpleDivaObject m_divaObject; // 0x1C
		private DivaResource m_divaResource; // 0x20
		private StringBuilder m_bundleName = new StringBuilder(64); // 0x24
		private StringBuilder m_assetName = new StringBuilder(64); // 0x28
		private Texture2D m_plateTexture; // 0x2C
		private Texture2D m_rankUpPlateTexture; // 0x30
		private GameObject m_directionObject; // 0x34
		private GameObject m_valkyrieObject; // 0x38
		private Animator m_animator; // 0x3C
		private EpisodeAppealModelInterface m_modelInterface; // 0x40
		private Material m_plateMaterialInstance; // 0x44
		private List<Material> m_rankupPlateMaterialInstance; // 0x48
		private TextMesh m_cosNameTextInstance; // 0x4C
		private TextMesh m_episodeNameTextInstance; // 0x50
		private TextMesh m_episodeHeaderTextInstance; // 0x54
		private TextMesh m_pilotNameTextInstance; // 0x58
		private Coroutine m_cameraAnimeCoroutine; // 0x5C
		private RectTransform m_parentRect; // 0x60
		private Camera m_mainCamera; // 0x64
		private readonly int Cut_01_Hash = Animator.StringToHash("Cut_01"); // 0x68
		private readonly int Cut_02_Hash = Animator.StringToHash("Cut_02"); // 0x6C
		private readonly int Cut_03_Hash = Animator.StringToHash("Cut_03"); // 0x70
		private readonly int Cut_04_Hash = Animator.StringToHash("Cut_04"); // 0x74
		private readonly int Cut_03_VL_Hash = Animator.StringToHash("Cut_03_VL"); // 0x78
		private readonly int Cut_04_VL_Hash = Animator.StringToHash("Cut_04_VL"); // 0x7C
		private List<DivaResource.MotionOverrideClipKeyResource> overrideClipList = new List<DivaResource.MotionOverrideClipKeyResource>(); // 0x80
		private VoicePlayerBase m_voicePlayer; // 0x84
		private AppealType appealType; // 0x88
		private EpisodeAppealValkyrieObject m_valkyrieObj; // 0x8C
		private GameObject m_VFObject; // 0x90
		public bool IsSkip; // 0x94
		private int pilotId; // 0x98
		public static bool AnimChenge; // 0x0
		public bool IsAppeal = true; // 0x9C

		// RVA: 0x1275A74 Offset: 0x1275A74 VA: 0x1275A74
		private void Awake()
		{
			m_divaObject = GetComponentInChildren<SimpleDivaObject>(true);
			GameObject g = new GameObject("DivaResource");
			g.transform.SetParent(transform, false);
			m_divaResource = g.AddComponent<DivaResource>();
			m_voicePlayer = transform.GetComponent<VoicePlayerBase>();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9BD4 Offset: 0x6D9BD4 VA: 0x6D9BD4
		//// RVA: 0x1275BD0 Offset: 0x1275BD0 VA: 0x1275BD0
		public IEnumerator Co_LoadDirectionLayout()
		{
			AssetBundleLoadAssetOperation op;

			//0x1276C80
			op = AssetBundleManager.LoadAssetAsync("dr/ep/001.xab", "EP_appeal_prefab", typeof(GameObject));
			yield return op;
			m_directionObject = Instantiate(op.GetAsset<GameObject>());
			m_animator = m_directionObject.GetComponent<Animator>();
			m_modelInterface = m_directionObject.GetComponent<EpisodeAppealModelInterface>();
			m_directionObject.transform.SetParent(transform, false);
			AssetBundleManager.UnloadAssetBundle("dr/ep/001.xab", false);
			m_cosNameTextInstance = Instantiate(m_cosNameTextPrefab);
			m_cosNameTextInstance.transform.SetParent(m_modelInterface.CostumeNameTextMeshRoot.transform, false);
			Font f = GameManager.Instance.GetSystemFont();
			m_cosNameTextInstance.font = f;
			MeshRenderer mr = m_cosNameTextInstance.GetComponent<MeshRenderer>();
			mr.sortingLayerName = "Front";
			mr.material = f.material;
			m_episodeNameTextInstance = Instantiate(m_episodeNameTextPrefab);
			m_episodeNameTextInstance.transform.SetParent(m_modelInterface.EpisodeTextMeshRoot.transform, false);
			m_episodeNameTextInstance.font = f;
			mr = m_episodeNameTextInstance.GetComponent<MeshRenderer>();
			mr.sortingLayerName = "Front";
			mr.material = f.material;
			m_episodeHeaderTextInstance = Instantiate(m_newEpisodeNameTextPrefab);
			m_episodeHeaderTextInstance.transform.SetParent(m_modelInterface.EpisodeTextMeshRoot.transform, false);
			m_episodeHeaderTextInstance.font = f;
			mr = m_episodeHeaderTextInstance.GetComponent<MeshRenderer>();
			mr.sortingLayerName = "Front";
			mr.material = f.material;
			m_pilotNameTextInstance = Instantiate(m_pilotNameTextPrefab);
			m_pilotNameTextInstance.transform.SetParent(m_modelInterface.PilotNameTextMeshRoot.transform, false);
			m_pilotNameTextInstance.font = f;
			mr = m_pilotNameTextInstance.GetComponent<MeshRenderer>();
			mr.sortingLayerName = "Front";
			mr.material = f.material;
			m_plateMaterialInstance = new Material(m_modelInterface.PlateMesh.material);
			m_rankupPlateMaterialInstance = new List<Material>();
			for(int i = 0; i < m_modelInterface.RankupPlateMesh.Length; i++)
			{
				m_rankupPlateMaterialInstance.Add(new Material(m_modelInterface.RankupPlateMesh[i].material));
			}
			m_parentRect = GameManager.Instance.PopupCanvas.transform.GetChild(0).GetComponent<RectTransform>();
			m_animator.Play(Cut_04_Hash, 0, 1);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9C4C Offset: 0x6D9C4C VA: 0x6D9C4C
		//// RVA: 0x1275C7C Offset: 0x1275C7C VA: 0x1275C7C
		public IEnumerator LoadResource(int episodeId, int sceneId)
		{
			AssetBundleLoadAssetOperation op;

			//0x127AA8C
			if(episodeId == 0 || sceneId == 0)
				yield break;
			IsAppeal = true;
			List<LGMEPLIJLNB> l = LGMEPLIJLNB.FKDIMODKKJD_GetEpisodeRewards(episodeId);
			for(int i = 0; i < l.Count; i++)
			{
				AppealType a = AppealType.None;
				if(l[i].GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
				{
					a = AppealType.Diva;
				}
				else if(l[i].GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_Valkyrie)
				{
					a = AppealType.Valkyrie;
				}
				if(a != AppealType.None)
				{
					//LAB_0127b7b4
					appealType = a;
					if(l[i].GOOIIPFHOIG != null)
					{
						if(appealType == AppealType.Valkyrie)
						{
							yield return ValkyrieResourceLoad(l[i].GOOIIPFHOIG);
							if(m_valkyrieObj.IsNotAppeal)
							{
								IsAppeal = false;
								yield break;
							}
						}
						else if(appealType == AppealType.Diva)
						{
							yield return DivaResourceLoad(l[i].GOOIIPFHOIG);
						}
						//LAB_0127b7ec
						MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[sceneId - 1];
						if(dbScene.EKLIPGELKCL_Rarity < 6)
						{
							m_bundleName.SetFormat("ct/sc/me/02/{0:D6}_01.xab", sceneId);
							m_assetName.SetFormat("{0:D6}_01", sceneId);
							op = AssetBundleManager.LoadAssetAsync(m_bundleName.ToString(), m_assetName.ToString(), typeof(Texture));
							yield return op;
							m_plateMaterialInstance.SetTexture("_MainTex", op.GetAsset<Texture>());
							AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
							m_bundleName.SetFormat("ct/sc/me/02/{0:D6}_02.xab", sceneId);
							m_assetName.SetFormat("{0:D6}_02", sceneId);
							op = AssetBundleManager.LoadAssetAsync(m_bundleName.ToString(), m_assetName.ToString(), typeof(Texture));
							yield return op;
							for(int j = 0; j < m_rankupPlateMaterialInstance.Count; j++)
							{
								m_rankupPlateMaterialInstance[i].SetTexture("_MainTex", op.GetAsset<Texture>());
							}
							AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
							m_modelInterface.PlateMesh.material = m_plateMaterialInstance;
							for(int j = 0; j < m_rankupPlateMaterialInstance.Count; j++)
							{
								m_modelInterface.RankupPlateMesh[i].material = m_rankupPlateMaterialInstance[i];
							}
						}
						else
						{
							m_bundleName.SetFormat("ct/sc/me/02_2/{0:D6}_01.xab", sceneId);
							m_assetName.SetFormat("{0:D6}_01", sceneId);
							op = AssetBundleManager.LoadAssetAsync(m_bundleName.ToString(), m_assetName.ToString(), typeof(Material));
							yield return op;
							m_modelInterface.PlateMesh.material = op.GetAsset<Material>();
							AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
							m_bundleName.SetFormat("ct/sc/me/02_2/{0:D6}_02.xab", sceneId);
							m_assetName.SetFormat("{0:D6}_02", sceneId);
							op = AssetBundleManager.LoadAssetAsync(m_bundleName.ToString(), m_assetName.ToString(), typeof(Material));
							yield return op;
							for(int j = 0; j < m_rankupPlateMaterialInstance.Count; j++)
							{
								m_modelInterface.RankupPlateMesh[i].material = op.GetAsset<Material>();
							}
							AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
						}
						//LAB_0127b510
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						m_episodeHeaderTextInstance.text = bk.GetMessageByLabel("episode_appeal_text_001");
						m_episodeNameTextInstance.text = PIGBBNDPPJC.EJOJNFDHDHN_GetEpName(episodeId);
						m_modelInterface.SetLog(dbScene.AIHCEGFANAM_Serie);
						m_mainCamera = m_modelInterface.GetComponentInChildren<Camera>(true);
					}
					yield break;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9CC4 Offset: 0x6D9CC4 VA: 0x6D9CC4
		//// RVA: 0x1275D5C Offset: 0x1275D5C VA: 0x1275D5C
		private IEnumerator DivaResourceLoad(MFDJIFIIPJD itemInfo)
		{
			LCLCCHLDNHJ_Costume cosMaster; // 0x1C
			int divaId; // 0x20
			int modelId; // 0x24
			int cosId; // 0x28
			AssetBundleLoadAllAssetOperationBase operationDiva; // 0x2C

			//0x127A024
			cosMaster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
			if(m_divaResource != null)
			{
				Release();
				yield return null;
				yield return Resources.UnloadUnusedAssets();
			}
			divaId = 0;
			modelId = 0;
			cosId = 0;
			for(int i = 0; i < cosMaster.CDENCMNHNGA_Costumes.Count; i++)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = cosMaster.CDENCMNHNGA_Costumes[i];
				if(cos.JPIDIENBGKH_CostumeId == itemInfo.NNFNGLJOKKF_ItemId)
				{
					divaId = cos.AHHJLDLAPAN_PrismDivaId;
					modelId = cos.DAJGPBLEEOB_PrismCostumeModelId;
					cosId = cos.JPIDIENBGKH_CostumeId;
					break;
				}
			}
			bool isEndedChangeCueSheet = false;
			StringBuilder str = new StringBuilder();
			str.SetFormat("cs_apl_diva_{0:D3}", divaId);
			m_voicePlayer.RequestChangeCueSheet(str.ToString(), () =>
			{
				//0x1276910
				isEndedChangeCueSheet = true;
			});
			while(!isEndedChangeCueSheet)
				yield return null;
			m_divaResource.LoadBasicResource(divaId, modelId, 0);
			m_divaResource.LoadSimpleResource(divaId, modelId, 0);
			while(!m_divaResource.IsSimpleLoaded)
				yield return null;
			m_bundleName.SetFormat("dv/ca/{0:D3}.xab", divaId);
			operationDiva = AssetBundleManager.LoadAllAssetAsync(m_bundleName.ToString());
			yield return operationDiva;
			m_divaObject.Initialize(m_divaResource, divaId, false);
			overrideClipList.Add(DivaResource.MotionOverrideClipKeyResource.Set("diva_{0:D3}_appeal_start_{1}", "diva_cmn_appeal_start", divaId, operationDiva, m_assetName));
			overrideClipList.Add(DivaResource.MotionOverrideClipKeyResource.Set("diva_{0:D3}_appeal_loop_{1}", "diva_cmn_appeal_loop", divaId, operationDiva, m_assetName));
			m_divaObject.OverrideAnimations(overrideClipList);
			AssetBundleManager.UnloadAssetBundle(m_bundleName.ToString(), false);
			m_cosNameTextInstance.text = CKFGMNAIBNG.EJOJNFDHDHN_GetCostumeName(divaId, cosId);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9D3C Offset: 0x6D9D3C VA: 0x6D9D3C
		//// RVA: 0x1275E24 Offset: 0x1275E24 VA: 0x1275E24
		private IEnumerator ValkyrieResourceLoad(MFDJIFIIPJD itemInfo)
		{
			int valkyrieId; // 0x1C
			AssetBundleLoadAssetOperation op; // 0x20

			//0x127C1A0
			Release();
			valkyrieId = itemInfo.NNFNGLJOKKF_ItemId;
			m_VFObject = new GameObject("ValkyrieResource");
			m_VFObject.transform.SetParent(transform);
			m_VFObject.transform.localPosition = Vector3.zero;
			ValkyrieResource m_Resource = m_VFObject.AddComponent<ValkyrieResource>();
			yield return null;
			m_Resource.LoadResourcesForAppeal(valkyrieId);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1276924
				return !m_Resource.isAllLoaded;
			});
			GameObject g = new GameObject("ValkyrieObject");
			m_valkyrieObj = g.AddComponent<EpisodeAppealValkyrieObject>();
			m_valkyrieObj.AddUseEffectName("EF_Con_vernier");
			m_valkyrieObj.Initialize(m_Resource);
			m_valkyrieObj.Activate(true);
			m_valkyrieObj.SetForm(0);
			m_valkyrieObj.transform.SetParent(m_VFObject.transform, false);
			m_valkyrieObj.Hide();
			m_VFObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			m_valkyrieObj.Initialize(m_Resource);
			if(m_valkyrieObj.IsNotAppeal)
				yield break;
			PNGOLKLFFLH p = new PNGOLKLFFLH();
			p.KHEKNNFCAOI_Init(valkyrieId, 0, 0);
			pilotId = p.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId;
			m_cosNameTextInstance.text = p.IJBLEJOKEFH_ValkyrieName + JpStringLiterals.StringLiteral_367 + p.MJJCKMPICIK_PilotName;
			m_pilotNameTextInstance.text = p.OPBPKNHIPPE_Pilot.OPFGFINHFCE_Name;
			op = AssetBundleManager.LoadAssetAsync(string.Format("dr/pl/{0:D3}.xab", pilotId), "pilot", typeof(Material));
			yield return op;
			m_modelInterface.PilotTextureMeshRoot.GetComponent<MeshRenderer>().material = op.GetAsset<Material>();
			bool isEndedChangeCueSheet = false;
			StringBuilder str = new StringBuilder();
			str.SetFormat("cs_apl_pilot_{0:D3}", pilotId);
			m_voicePlayer.RequestChangeCueSheet(str.ToString(), () =>
			{
				//0x1276954
				isEndedChangeCueSheet = true;
			});
			while(!isEndedChangeCueSheet)
				yield return null;
		}

		//// RVA: 0x1275EEC Offset: 0x1275EEC VA: 0x1275EEC
		public void Release()
		{
			for(int i = 0; i < overrideClipList.Count; i++)
			{
				overrideClipList[i].Release();
			}
			overrideClipList.Clear();
			m_divaObject.ReleaseMediator();
			m_divaObject.Release();
			m_divaResource.ReleaseAll();
			m_plateTexture = null;
			m_rankUpPlateTexture = null;
			m_mainCamera = null;
			if(m_VFObject != null)
			{
				Destroy(m_VFObject);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9DB4 Offset: 0x6D9DB4 VA: 0x6D9DB4
		//// RVA: 0x1276100 Offset: 0x1276100 VA: 0x1276100
		public IEnumerator Co_Play()
		{
			//0x1277B00
			if(appealType == AppealType.Valkyrie)
			{
				if(!m_valkyrieObj.IsNotAppeal)
				{
					yield return Co.R(Co_PlayValkyrie());
				}
			}
			else if(appealType == AppealType.Diva)
			{
				yield return Co.R(Co_PlayDiva());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9E2C Offset: 0x6D9E2C VA: 0x6D9E2C
		//// RVA: 0x12761AC Offset: 0x12761AC VA: 0x12761AC
		private IEnumerator Co_PlayDiva()
		{
			Coroutine voiceCoroutine; // 0x14

			//0x1277C58
			m_divaObject.SetEnableRenderer(false);
			m_modelInterface.SetDivaName(m_divaObject.divaId);
			float w = m_parentRect.sizeDelta.x;
			float x = 1;
			if(SystemManager.isLongScreenDevice)
			{
				if(SystemManager.HasSafeArea)
				{
					x = m_mainCamera.rect.x + 1;
				}
			}
			m_modelInterface.SetPlateScale((w / m_parentRect.sizeDelta.y) / 1.777778f * x);
			m_animator.Play(Cut_01_Hash, 0, 0);
			GameManager.Instance.fullscreenFader.Fade(1, 0);
			yield return null;
			float f = m_animator.GetCurrentAnimatorStateInfo(0).length;
			yield return Co.R(Co_WaitAnimator(m_animator, (f - 1) / f));
			GameManager.Instance.fullscreenFader.Fade(0.6666667f, 1);
			yield return Co.R(Co_WaitChangeState(m_animator, Cut_01_Hash));
			m_animator.Play(Cut_02_Hash, 0, 0);
			GameManager.Instance.fullscreenFader.Fade(0.8333333f, 0);
			yield return Co.R(Co_WaitChangeState(m_animator, Cut_02_Hash));
			voiceCoroutine = null;
			m_animator.Play(Cut_03_Hash, 0, 0);
			yield return Co.R(Co_WaitChangeState(m_animator, Cut_03_Hash));
			m_animator.Play(Cut_04_Hash, 0, 0);
			m_divaObject.SetEnableRenderer(true);
			m_divaObject.SetEnableEffect(true, true);
			m_divaObject.Play("appeal_start");
			voiceCoroutine = this.StartCoroutineWatched(Co_VoiceDelayedPlay(m_modelInterface.DivaVoiceDelayTime.VoiceDelayTime[m_divaObject.divaId - 1]));
			m_cameraAnimeCoroutine = this.StartCoroutineWatched(Co_ApplyDivaAdjustCurver(m_divaObject.transform, m_modelInterface.DivaAdjustParam.DivaPositionAdjustCurves[m_divaObject.divaId - 1]));
			yield return null;
			f = m_animator.GetCurrentAnimatorStateInfo(0).length;
			yield return Co.R(Co_WaitAnimator(m_animator, (f - 0.5f) / f));
			GameManager.Instance.fullscreenFader.Fade(0.5f, 1);
			m_voicePlayer.source.Stop();
			SoundManager.Instance.sePlayerMenu.Stop();
			if(!IsSkip)
			{
				yield return Co.R(Co_WaitAnimator(m_animator, 1));
			}
			IsSkip = false;
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			if(m_cameraAnimeCoroutine != null)
			{
				this.StopCoroutineWatched(m_cameraAnimeCoroutine);
				m_cameraAnimeCoroutine = null;
			}
			if(voiceCoroutine != null)
			{
				this.StopCoroutineWatched(voiceCoroutine);
				voiceCoroutine = null;
			}
			m_animator.Play(Cut_04_Hash, 0, 1);
			m_voicePlayer.source.Stop();
			SoundManager.Instance.sePlayerMenu.Stop();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9EA4 Offset: 0x6D9EA4 VA: 0x6D9EA4
		//// RVA: 0x1276258 Offset: 0x1276258 VA: 0x1276258
		private IEnumerator Co_PlayValkyrie()
		{
			Coroutine voiceCoroutine; // 0x14

			//0x1278C00
			m_valkyrieObj.gameObject.SetActive(false);
			float w = m_parentRect.sizeDelta.x;
			float a1 = 1;
			if(SystemManager.isLongScreenDevice)
			{
				if(SystemManager.HasSafeArea)
				{
					a1 = m_mainCamera.rect.x + 1;
				}
			}
			m_modelInterface.SetPlateScale(((w / m_parentRect.sizeDelta.y) / 1.777778f) * a1);
			m_animator.Play(Cut_01_Hash, 0, 0);
			GameManager.Instance.fullscreenFader.Fade(1, 0);
			yield return null;
			float t = m_animator.GetCurrentAnimatorStateInfo(0).length;
			yield return Co.R(Co_WaitAnimator(m_animator, (t - 1) / t));
			GameManager.Instance.fullscreenFader.Fade(0.6666667f, 1);
			yield return Co.R(Co_WaitChangeState(m_animator, Cut_01_Hash));
			m_animator.Play(Cut_02_Hash, 0, 0);
			GameManager.Instance.fullscreenFader.Fade(0.8333333f, 0);
			yield return Co.R(Co_WaitChangeState(m_animator, Cut_02_Hash));
			m_animator.Play(Cut_03_VL_Hash, 0, 0);
			yield return Co.R(Co_WaitChangeState(m_animator, Cut_03_VL_Hash));
			m_animator.Play(Cut_04_VL_Hash, 0, 0);
			m_valkyrieObj.gameObject.SetActive(true);
			m_valkyrieObj.Enter();
			float f = 0;
			if(m_modelInterface.PilotVoiceDelayTime.VoiceDelayTime.Length < pilotId)
			{
				f = m_modelInterface.PilotVoiceDelayTime.VoiceDelayTime[pilotId];
			}
			voiceCoroutine = this.StartCoroutineWatched(Co_VoiceDelayedPlay(f));
			this.StartCoroutineWatched(ValkyrieChengeFromSe());
			yield return null;
			f = m_animator.GetCurrentAnimatorStateInfo(0).length;
			yield return Co.R(Co_WaitAnimator(m_animator, (f - 1) / f));
			GameManager.Instance.fullscreenFader.Fade(0.5f, 1);
			m_voicePlayer.source.Stop();
			SoundManager.Instance.sePlayerMenu.Stop();
			if(!IsSkip)
			{
				yield return Co.R(Co_WaitAnimator(m_animator, 1));
			}
			IsSkip = false;
			while(GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			if(m_cameraAnimeCoroutine != null)
			{
				this.StopCoroutineWatched(m_cameraAnimeCoroutine);
				m_cameraAnimeCoroutine = null;
			}
			if(voiceCoroutine != null)
			{
				this.StopCoroutineWatched(voiceCoroutine);
				voiceCoroutine = null;
			}
			m_animator.Play(Cut_04_VL_Hash, 0, 1);
			m_voicePlayer.source.Stop();
			SoundManager.Instance.sePlayerMenu.Stop();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9F1C Offset: 0x6D9F1C VA: 0x6D9F1C
		//// RVA: 0x1276304 Offset: 0x1276304 VA: 0x1276304
		private IEnumerator ValkyrieChengeFromSe()
		{
			bool IsFormChenge;

			//0x127BECC
			IsFormChenge = true;
			while(true)
			{
				if(m_valkyrieObj.GetCurrentForm() == FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter)
					IsFormChenge = false;
				yield return null;
				if(!IsFormChenge)
				{
					IsFormChenge = true;
					break;
				}
			}
			while(true)
			{
				if(m_valkyrieObj.GetCurrentForm() != FKGMGBHBNOC.HPJOCKGKNCC_Form.AEFCOHJBLPO_Num && m_valkyrieObj.GetCurrentForm() > FKGMGBHBNOC.HPJOCKGKNCC_Form.MABDGNNOPCB_Fighter)
				{
					SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VALKYRIE_000);
					IsFormChenge = false;
				}
				yield return null;
				if(!IsFormChenge)
					yield break;
			}
		}

		//// RVA: 0x12763B0 Offset: 0x12763B0 VA: 0x12763B0
		//private void ApplyDivaAdjustY(Transform divaObjectTransform, float y) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D9F94 Offset: 0x6D9F94 VA: 0x6D9F94
		//// RVA: 0x1276410 Offset: 0x1276410 VA: 0x1276410
		private IEnumerator Co_WaitAnimator(Animator animator, float waitNormalizeTime)
		{
			float waitTime; // 0x1C

			//0x1279A24
			IsSkip = false;
			waitTime = 0;
			while(true)
			{
				yield return null;
				waitTime += Time.deltaTime;
				if(waitNormalizeTime <= animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
					yield break;
				if(IsSkip && waitTime >= 1.0f)
				{
					SoundManager.Instance.sePlayerMenu.Stop();
					yield break;
				}
				if(AnimChenge)
				{
					waitTime = 0;
					AnimChenge = false;
				}
				IsSkip = false;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DA00C Offset: 0x6DA00C VA: 0x6DA00C
		//// RVA: 0x12764FC Offset: 0x12764FC VA: 0x12764FC
		private IEnumerator Co_WaitChangeState(Animator animator, int hash)
		{
			float waitTime;

			//0x1279D28
			IsSkip = false;
			waitTime = 0;
			while(true)
			{
				yield return null;
				waitTime += Time.deltaTime;
				if(animator.GetCurrentAnimatorStateInfo(0).shortNameHash != hash)
					yield break;
				if(IsSkip && waitTime >= 1)
				{
					SoundManager.Instance.sePlayerMenu.Stop();
					yield break;
				}
				if(AnimChenge)
				{
					waitTime = 0;
					AnimChenge = false;
				}
				IsSkip = false;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DA084 Offset: 0x6DA084 VA: 0x6DA084
		//// RVA: 0x12765DC Offset: 0x12765DC VA: 0x12765DC
		private IEnumerator Co_VoiceDelayedPlay(float delayTime)
		{
			float time; // 0x18

			//0x1279850
			time = 0;
			while(delayTime >= time)
			{
				time += Time.deltaTime;
				yield return null;
			}
			m_voicePlayer.source.Play("m_apl_000");
		}

		//// RVA: 0x12766B0 Offset: 0x12766B0 VA: 0x12766B0
		//public void skipFunc() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DA0FC Offset: 0x6DA0FC VA: 0x6DA0FC
		//// RVA: 0x12766BC Offset: 0x12766BC VA: 0x12766BC
		private IEnumerator Co_ApplyDivaAdjustCurver(Transform divaObjectTransform, AnimationCurve curve)
		{
			float sec; // 0x18
			float lastTime; // 0x1C

			//0x1276964
			sec = 0;
			lastTime = curve.keys[curve.keys.Length - 1].time;
			while(sec < lastTime)
			{
				sec += Time.deltaTime;
				divaObjectTransform.localPosition = new Vector3(0, curve.Evaluate(sec), 0);
				yield return null;
			}
			divaObjectTransform.localPosition = new Vector3(0, curve.Evaluate(lastTime), 0);
		}
	}
}
