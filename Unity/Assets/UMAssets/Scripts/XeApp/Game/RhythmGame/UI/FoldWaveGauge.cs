using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class FoldWaveGauge : MonoBehaviour
	{
		public enum AnimationLayers
		{
			BaseLayer = 0,
			CircleLoop = 1,
			CircleFlashLoop = 2,
			GaugeFlash = 3,
			GaugeLoopEffect = 4,
			BattleInEffect = 5,
		}

		[SerializeField]
		private NumericMeshMultiPolygon m_numericMesh; // 0xC
		[SerializeField]
		private GameObject m_gaugePrefab; // 0x10
		[SerializeField]
		private GameObject m_meshParent; // 0x14
		[SerializeField]
		private Animator m_circleAnime; // 0x18
		[SerializeField]
		private GameObject m_circleEffectPrefab; // 0x1C
		[SerializeField]
		private FoldWaveGaugeCircleUvChanger m_circleUvChange; // 0x20
		private Renderer[] m_renderers; // 0x24
		private MeshTile[] m_meshTiles; // 0x28
		private FoldWaveGaugeEffect m_gaugeEffect; // 0x2C
		private EffectBundleController m_circleEffectController; // 0x30
		private RandomRotate m_randomCircleEffect; // 0x34
		private MaterialPropertyBlock m_materialPropertyBlock; // 0x38
		private Animator m_mainAnimator; // 0x3C
		private Animator m_gaugeAnimator; // 0x40
		private bool m_isHide; // 0x44
		private int m_currentGauge; // 0x48
		private int m_addColorShaderId; // 0x4C
		private int m_value; // 0x50
		private int m_prevGaugeLevel; // 0x54
		private const float FlashColor = 0.35f;
		private const int GaugeNum = 2;
		private const int CircleAnimeLayerIndex = 2;
		private readonly Rect[] uvTbl = new Rect[3] {
			new Rect(0.5f,0.6015625f,0.125f,0.0078125f),
			new Rect(0.5f,0.59375f,0.125f,0.0078125f),
			new Rect(0.5f,0.6171875f,0.125f,0.0078125f)
		}; // 0x58
		private const int MaxGaugeLavel = 1;
		private static readonly int[] CircleEffectGroupHashTbl = new int[5] {
			"Miss".GetHashCode(), "Bad".GetHashCode(), "Good".GetHashCode(), 
			"Great".GetHashCode(), "Perfect".GetHashCode()
		}; // 0x0
		private static readonly int FoldGaugeInHash = Animator.StringToHash("R_top_UI_N"); // 0x4
		private static readonly int BattleInEffectHash = Animator.StringToHash("fx_BTcut_OFF"); // 0x8
		private static readonly int FaugeParticleEffectStateHash = Animator.StringToHash("fx_UI_gage"); // 0xC
		private static readonly int SuccessParamHash = Animator.StringToHash("Success"); // 0x10
		private static readonly int NoValkyrieSuccess = Animator.StringToHash("NoValkyrieSuccess"); // 0x14
		private static readonly int FailedParamHash = Animator.StringToHash("Failed"); // 0x18
		private static readonly int FgaugeAlphaIdle_Hash = Animator.StringToHash("FgaugeAlphaIdle"); // 0x1C
		private static readonly int FgaugeAlphaOut_Hash = Animator.StringToHash("FgaugeAlphaOut"); // 0x20

		// // RVA: 0x155EF0C Offset: 0x155EF0C VA: 0x155EF0C
		public void Initialize()
		{
			m_mainAnimator = GetComponent<Animator>();
			m_meshTiles = new MeshTile[2];
			m_addColorShaderId = Shader.PropertyToID("_AddColor");
			m_renderers = new Renderer[m_meshTiles.Length];
			GameObject g = RhythmGameHUD.RhythmGameInstantiatePrefab(m_gaugePrefab);
			g.transform.SetParent(m_meshParent.transform, false);
			m_meshTiles = g.GetComponentsInChildren<MeshTile>(true);
			m_gaugeAnimator = g.GetComponent<Animator>();
			for(int i = 0; i < m_meshTiles.Length; i++)
			{
				m_meshTiles[i].Initialize();
				m_renderers[i] = m_meshTiles[i].GetComponent<Renderer>();
			}
			m_gaugeEffect = GetComponent<FoldWaveGaugeEffect>();
			m_gaugeEffect.Initialize();
			GameObject c = RhythmGameHUD.RhythmGameInstantiatePrefab(m_circleEffectPrefab);
			m_circleEffectController = c.GetComponent<EffectBundleController>();
			c.transform.SetParent(m_meshParent.transform, false);
			m_randomCircleEffect = c.GetComponent<RandomRotate>();
			m_prevGaugeLevel = 0;
			m_materialPropertyBlock = new MaterialPropertyBlock();
		}

		// // RVA: 0x155F48C Offset: 0x155F48C VA: 0x155F48C
		public void SetValue(int value, bool forceAnime = false, bool isLowSpec = false)
		{
			if(value < 100)
			{
				m_meshTiles[0].Value = value / 100.0f;
				m_meshTiles[1].Value = 0;
				m_currentGauge = 0;
				m_meshTiles[0].gameObject.SetActive(true);
				m_meshTiles[1].gameObject.SetActive(false);
				m_gaugeEffect.SetMarkPosition(value / 100.0f);
			}
			else
			{
				m_meshTiles[1].UvRect = uvTbl[1];
				m_meshTiles[0].Value = 1;
				m_meshTiles[1].Value = 1;
				m_currentGauge = 1;
				m_meshTiles[0].gameObject.SetActive(false);
				m_meshTiles[1].gameObject.SetActive(true);
				m_gaugeEffect.SetMarkPosition(1);
			}
			m_gaugeEffect.UpdateGaugeEffectScale(value / 100.0f);
			int v = Mathf.Clamp(value / 100, 0, 1);
			m_mainAnimator.SetLayerWeight(2, v > 0 ? 1 : 0);
			m_circleUvChange.UpdateUv(v > 0 ? FoldWaveGaugeCircleUvChanger.UvType.Rainbow : FoldWaveGaugeCircleUvChanger.UvType.Blue);
			if(m_value < value && m_prevGaugeLevel != v)
			{
				m_gaugeEffect.ShowHighlight(false);
				SoundManager.Instance.sePlayerGame.Play(27);
			}
			m_value = value;
			m_prevGaugeLevel = v;
			m_numericMesh.SetNumber(value, 0);
		}

		// // RVA: 0x15601F8 Offset: 0x15601F8 VA: 0x15601F8
		public void ShowGauge()
		{
			m_meshParent.SetActive(true);
			m_mainAnimator.Play(FoldGaugeInHash, 0, 0);
			m_mainAnimator.Play(BattleInEffectHash, 5, 0);
			m_mainAnimator.Play(FaugeParticleEffectStateHash, 4, 0);
			m_mainAnimator.SetLayerWeight(2, 0);
			m_gaugeAnimator.Play(FgaugeAlphaIdle_Hash, 1, 0);
			SetValue(m_value, false, false);
			m_isHide = false;
		}

		// // RVA: 0x15603F8 Offset: 0x15603F8 VA: 0x15603F8
		// public void GaugeFlash() { }

		// // RVA: 0x1560510 Offset: 0x1560510 VA: 0x1560510
		// public void ShowEffect(int result) { }

		// [IteratorStateMachineAttribute] // RVA: 0x747234 Offset: 0x747234 VA: 0x747234
		// // RVA: 0x1560468 Offset: 0x1560468 VA: 0x1560468
		// private IEnumerator ColorAnimeCoroutine(Renderer renderer) { }

		// // RVA: 0x15607AC Offset: 0x15607AC VA: 0x15607AC
		// public void HideGauge() { }

		// // RVA: 0x15607E8 Offset: 0x15607E8 VA: 0x15607E8
		// public void Success(bool isValkyrieOff) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7472AC Offset: 0x7472AC VA: 0x7472AC
		// // RVA: 0x15608F8 Offset: 0x15608F8 VA: 0x15608F8
		// private IEnumerator WaitSuccessAnimationCoroutine() { }

		// // RVA: 0x15609A4 Offset: 0x15609A4 VA: 0x15609A4
		// public void Faild() { }
	}
}
