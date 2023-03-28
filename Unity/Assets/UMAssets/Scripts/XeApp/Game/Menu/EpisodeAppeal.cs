using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;

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
		private EpisodeAppeal.AppealType appealType; // 0x88
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
			TodoLogger.Log(0, "Co_LoadDirectionLayout");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9C4C Offset: 0x6D9C4C VA: 0x6D9C4C
		//// RVA: 0x1275C7C Offset: 0x1275C7C VA: 0x1275C7C
		public IEnumerator LoadResource(int episodeId, int sceneId)
		{
			TodoLogger.Log(0, "LoadResource");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9CC4 Offset: 0x6D9CC4 VA: 0x6D9CC4
		//// RVA: 0x1275D5C Offset: 0x1275D5C VA: 0x1275D5C
		//private IEnumerator DivaResourceLoad(MFDJIFIIPJD itemInfo) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D9D3C Offset: 0x6D9D3C VA: 0x6D9D3C
		//// RVA: 0x1275E24 Offset: 0x1275E24 VA: 0x1275E24
		//private IEnumerator ValkyrieResourceLoad(MFDJIFIIPJD itemInfo) { }

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
			TodoLogger.Log(0, "Co_Play");
			yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D9E2C Offset: 0x6D9E2C VA: 0x6D9E2C
		//// RVA: 0x12761AC Offset: 0x12761AC VA: 0x12761AC
		//private IEnumerator Co_PlayDiva() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D9EA4 Offset: 0x6D9EA4 VA: 0x6D9EA4
		//// RVA: 0x1276258 Offset: 0x1276258 VA: 0x1276258
		//private IEnumerator Co_PlayValkyrie() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D9F1C Offset: 0x6D9F1C VA: 0x6D9F1C
		//// RVA: 0x1276304 Offset: 0x1276304 VA: 0x1276304
		//private IEnumerator ValkyrieChengeFromSe() { }

		//// RVA: 0x12763B0 Offset: 0x12763B0 VA: 0x12763B0
		//private void ApplyDivaAdjustY(Transform divaObjectTransform, float y) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D9F94 Offset: 0x6D9F94 VA: 0x6D9F94
		//// RVA: 0x1276410 Offset: 0x1276410 VA: 0x1276410
		//private IEnumerator Co_WaitAnimator(Animator animator, float waitNormalizeTime) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DA00C Offset: 0x6DA00C VA: 0x6DA00C
		//// RVA: 0x12764FC Offset: 0x12764FC VA: 0x12764FC
		//private IEnumerator Co_WaitChangeState(Animator animator, int hash) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DA084 Offset: 0x6DA084 VA: 0x6DA084
		//// RVA: 0x12765DC Offset: 0x12765DC VA: 0x12765DC
		//private IEnumerator Co_VoiceDelayedPlay(float delayTime) { }

		//// RVA: 0x12766B0 Offset: 0x12766B0 VA: 0x12766B0
		//public void skipFunc() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DA0FC Offset: 0x6DA0FC VA: 0x6DA0FC
		//// RVA: 0x12766BC Offset: 0x12766BC VA: 0x12766BC
		//private IEnumerator Co_ApplyDivaAdjustCurver(Transform divaObjectTransform, AnimationCurve curve) { }
	}
}
