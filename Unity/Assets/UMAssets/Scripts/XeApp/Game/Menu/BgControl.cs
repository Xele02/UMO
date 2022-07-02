using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class BgControl
	{ 
		public enum BgTextureFlag
		{
			None = 0,
			Permanently = 1,
		}

		public class BgTexture
		{
			public Texture2D texture; // 0x8
			public Material material; // 0xC
			private BgControl.BgTextureFlag flags; // 0x10

			// RVA: 0x143F530 Offset: 0x143F530 VA: 0x143F530
			// public void SetFlags(BgControl.BgTextureFlag flags) { }

			// RVA: 0x143E340 Offset: 0x143E340 VA: 0x143E340
			// public bool CanDestory() { }
		}

		public class LimitedHomeBg
		{
			public static int INVALID_MUSIC_ID = -1; // 0x0
			public static int INVALID_BG_ID = -1; // 0x4
			public int m_bg_id = INVALID_BG_ID; // 0x8
			public int m_music_id = INVALID_MUSIC_ID; // 0xC
			public int m_time_zone = -1; // 0x10
			public GameObject m_prefab; // 0x14
			public GameObject m_camera; // 0x18
			public GameObject m_fade; // 0x1C
			public Image m_darkImage; // 0x20
			public bool m_enable; // 0x24
			// public CGFNKMNBNBN m_master; // 0x28
		}

		private GameObject m_bgRoot; // 0x8
		private GameObject m_bgInstance; // 0xC
		private BgBehaviour m_bgBehaviour; // 0x10
		private BgType m_type = BgType.Undefined; // 0x14
		// private BgTextureType m_textureType; // 0x18
		private int m_id; // 0x1C
		private GameAttribute.Type m_attr; // 0x20
		// private BgPriority m_priority; // 0x24
		private BgControl.BgTexture m_bgTexture; // 0x28
		private StringBuilder m_strBuilder = new StringBuilder(128); // 0x2C
		// private static IndexableDictionary<string, BgControl.BgTexture> m_cachedTextures = new IndexableDictionary<string, BgTexture>(8); // 0x0
		private bool m_fadeReserved; // 0x30
		private float m_fadeTime = -1.0f; // 0x34
		private Color m_fadeColor = Color.black; // 0x38
		private const string BgPrefabBundlePath = "ly/003.xab";
		private const string BgPrefabResourcePath = "Menu/Prefab/MenuBg";
		private const string HomeBgTextureBundlePath = "ct/bg/hm/";
		private const string SceneBgTextureBundlePath = "ct/sc/me/02/";
		private const string SceneBg2TextureBundlePath = "ct/sc/me/02_2/";
		private const string MusicBgTextureBundlePath = "ct/bg/mc/nm/";
		private const string GachaBgTextureBundlePath = "ct/bg/gc/";
		private const string MusicEventBgTextureBundlePath = "ct/ev/bg/";
		private const string ValkyrieBgTextureBundlePath = "ct/bg/vl/";
		private const string CostumeBgTextureBundlePath = "ct/bg/cs/";
		private const string ResultBgTextureBundlePath = "ct/bg/re/";
		private const string LoginBonusBgTextureBundlePath = "ct/bg/lo/";
		private const string NewYearEventBgTextureBundlePath = "ct/ev/bg/";
		private const string GachaBoxBgTextureBundlePath = "ct/ev/bg/";
		private const string HomeLimitedBgBundlePath = "mn/hm/bg/";
		private const string OfferBgTextureBundlePath = "ct/bg/of/";
		private const string RaidBgTextureBundlePath = "ct/bg/rd/";
		private const string LobbyMainBgTextureBundlePath = "ct/bg/lb/";
		private BgControl.LimitedHomeBg m_limitedHomeBg = new LimitedHomeBg(); // 0x48
		private StoryBgParam storyBgParam; // 0x4C
		private bool storyBgLoading; // 0x58

		// public BgControl.LimitedHomeBg limitedHomeBg { get; private set; } 0x143CA14 0x143CA1C
		// public ScrollRect storyBgScrollRect { get; private set; } 0x143EA44 0x143EA68

		// RVA: 0x143CA20 Offset: 0x143CA20 VA: 0x143CA20
		public BgControl(GameObject bgRoot)
		{
			m_bgRoot = bgRoot;
		}

		// // RVA: 0x1429568 Offset: 0x1429568 VA: 0x1429568
		// public static void ForceDestoryTexture() { }

		// // RVA: 0x143CBB8 Offset: 0x143CBB8 VA: 0x143CBB8
		// public GameObject GetCurrent() { }

		// // RVA: 0x143CBC0 Offset: 0x143CBC0 VA: 0x143CBC0
		public BgType GetCurrentType()
		{
			return m_type;
		}

		// // RVA: 0x143CBC8 Offset: 0x143CBC8 VA: 0x143CBC8
		// public BgTextureType GetCurrentTextureType() { }

		// // RVA: 0x143CBD0 Offset: 0x143CBD0 VA: 0x143CBD0
		// public int GetCurrentId() { }

		// // RVA: 0x143CBD8 Offset: 0x143CBD8 VA: 0x143CBD8
		public GameAttribute.Type GetCurrentAttr()
		{
			return m_attr;
		}

		// // RVA: 0x143CBE0 Offset: 0x143CBE0 VA: 0x143CBE0
		// public bool GetBgIsFade() { }

		// // RVA: 0x143CC20 Offset: 0x143CC20 VA: 0x143CC20
		// public bool IsSceneBg(BgType a_bg_type) { }

		// // RVA: 0x143CD18 Offset: 0x143CD18 VA: 0x143CD18
		// public bool Comparer(int bgId, BgType type) { }

		// // RVA: 0x143CD40 Offset: 0x143CD40 VA: 0x143CD40
		// public void Destroy() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5968 Offset: 0x6C5968 VA: 0x6C5968
		// // RVA: 0x143D2A4 Offset: 0x143D2A4 VA: 0x143D2A4
		public IEnumerator Load(UnityAction action)
		{
			//0x144265C
			GameObject prefab = null;
			ResourcesManager.Instance.Load(Path.Combine("Menu/Prefab/MenuBg","BgRoot"), (FileResultObject fo) => {
				//0x143EF38
				prefab = fo.unityObject as GameObject;
				return true;
			});
			while(prefab == null)
				yield return null;
			m_bgInstance = UnityEngine.Object.Instantiate<GameObject>(prefab);
			m_bgBehaviour = m_bgInstance.GetComponent<BgBehaviour>();
			m_bgInstance.transform.SetParent(m_bgRoot.transform, false);
			m_bgBehaviour.ResetBgImageRectSize(false);
			prefab = null;
			m_bgBehaviour.SetHome(CGFNKMNBNBN.MHJBBLBFHIB());
			m_bgBehaviour.ChangeAttribute(m_attr);
			if(action != null)
				action();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C59E0 Offset: 0x6C59E0 VA: 0x6C59E0
		// // RVA: 0x143D36C Offset: 0x143D36C VA: 0x143D36C
		public IEnumerator ChangeBgCoroutine(BgType bgType, int id = -1, SceneGroupCategory category = SceneGroupCategory.UNDEFINED, TransitionList.Type transitionType = TransitionList.Type.UNDEFINED, int attribute = -1)
		{
			UnityEngine.Debug.LogError("TODO BG ChangeBgCoroutine");
			yield return null;
		}

		// // RVA: 0x143D498 Offset: 0x143D498 VA: 0x143D498
		// public void ShowBgDark() { }

		// // RVA: 0x143D5A8 Offset: 0x143D5A8 VA: 0x143D5A8
		// public void HideBgDark() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5A58 Offset: 0x6C5A58 VA: 0x6C5A58
		// // RVA: 0x143D62C Offset: 0x143D62C VA: 0x143D62C
		// public IEnumerator ChangeHomeBgCoroutine(BgType bgType, int id = -1, int evolveId = -1, bool isBgDark = False, SceneGroupCategory category = -1, TransitionList.Type transitionType = -2, int attribute = -1) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5AD0 Offset: 0x6C5AD0 VA: 0x6C5AD0
		// // RVA: 0x143D794 Offset: 0x143D794 VA: 0x143D794
		// public IEnumerator Co_CreateLimitedBG(int a_bundle_id, int a_time_zone) { }

		// // RVA: 0x143D0C8 Offset: 0x143D0C8 VA: 0x143D0C8
		// public void DeleteLimitedBG() { }

		// // RVA: 0x143D874 Offset: 0x143D874 VA: 0x143D874
		public void ReserveFade(float time, Color color)
		{
			UnityEngine.Debug.LogError("TODO BG ReserveFade");
		}

		// // RVA: 0x143D89C Offset: 0x143D89C VA: 0x143D89C
		// private int GetDefaultHomeBg() { }

		// // RVA: 0x143DBCC Offset: 0x143DBCC VA: 0x143DBCC
		// private void ChangeColor(SceneGroupCategory category, TransitionList.Type transitionType) { }

		// // RVA: 0x143DCDC Offset: 0x143DCDC VA: 0x143DCDC
		// public void ChangeTilingFade(float time, float alpha) { }

		// // RVA: 0x143DD24 Offset: 0x143DD24 VA: 0x143DD24
		// public void ChangeDownLoadBg() { }

		// // RVA: 0x143DE8C Offset: 0x143DE8C VA: 0x143DE8C
		// public void ChangeNameEntryBg() { }

		// // RVA: 0x143DEDC Offset: 0x143DEDC VA: 0x143DEDC
		// public void ChangeHomeSceneView() { }

		// // RVA: 0x143DF04 Offset: 0x143DF04 VA: 0x143DF04
		// public void ChangeTeamSelect() { }

		// // RVA: 0x143DF08 Offset: 0x143DF08 VA: 0x143DF08
		// public void ChangeAttribute(GameAttribute.Type attr) { }

		// // RVA: 0x143DF4C Offset: 0x143DF4C VA: 0x143DF4C
		// public void ChangeTilingType(BgBehaviour.TilingType type) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5B48 Offset: 0x6C5B48 VA: 0x6C5B48
		// // RVA: 0x143DF80 Offset: 0x143DF80 VA: 0x143DF80
		// public IEnumerator LoadBgTexture(BgTextureType textureType, int id, bool isBlur = False) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5BC0 Offset: 0x6C5BC0 VA: 0x6C5BC0
		// // RVA: 0x143E078 Offset: 0x143E078 VA: 0x143E078
		// public IEnumerator LoadBgTexture(GameObject obj, int id) { }

		// // RVA: 0x143DD74 Offset: 0x143DD74 VA: 0x143DD74
		// private void UnloadBgTexture() { }

		// // RVA: 0x143E158 Offset: 0x143E158 VA: 0x143E158
		// private void UnloadBgTexture(BgControl.BgTexture bgTexture) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5C38 Offset: 0x6C5C38 VA: 0x6C5C38
		// // RVA: 0x143E260 Offset: 0x143E260 VA: 0x143E260
		// public IEnumerator CacheBg(BgType bgType, int id) { }

		// // RVA: 0x143CDE8 Offset: 0x143CDE8 VA: 0x143CDE8
		// public void DestroyCacheBg() { }

		// // RVA: 0x143E354 Offset: 0x143E354 VA: 0x143E354
		// public void SetPriority(BgPriority priority) { }

		// // RVA: 0x143E35C Offset: 0x143E35C VA: 0x143E35C
		// private void ApplyPriority() { }

		// // RVA: 0x143E400 Offset: 0x143E400 VA: 0x143E400
		// private bool CheckEqualBg(BgTextureType textureType, int id) { }

		// // RVA: 0x143E424 Offset: 0x143E424 VA: 0x143E424
		// private void ConvertBgType(BgType bgType, ref BgTextureType textureType, ref int id, ref int evolveId) { }

		// // RVA: 0x143E650 Offset: 0x143E650 VA: 0x143E650
		// private void ConvertBgType(BgType bgType, ref BgTextureType textureType, ref int id) { }

		// // RVA: 0x143E574 Offset: 0x143E574 VA: 0x143E574
		// public static int CompoundSceneBgId(int sceneId, int rank) { }

		// // RVA: 0x143E9F8 Offset: 0x143E9F8 VA: 0x143E9F8
		// public static bool ExtractSceneBgId(int sceneBgId, out int sceneId, out int rank) { }

		// // RVA: 0x143E584 Offset: 0x143E584 VA: 0x143E584
		// public static int GetHomeBgId(long unixTime) { }

		// // RVA: 0x143EA6C Offset: 0x143EA6C VA: 0x143EA6C
		// public void SetStoryParam(StoryBgParam param) { }

		// // RVA: 0x143EA78 Offset: 0x143EA78 VA: 0x143EA78
		public StoryBgParam OutputStoryBgParam(bool isStory)
		{
			storyBgParam.isCategoryStory = isStory;
			storyBgParam.x = m_bgBehaviour.storyBgScrollRect.content.anchoredPosition.x;
			return storyBgParam;
		}

		// // RVA: 0x143EB70 Offset: 0x143EB70 VA: 0x143EB70
		// public void StorytBgReturn() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C5CB0 Offset: 0x6C5CB0 VA: 0x6C5CB0
		// // RVA: 0x143ED60 Offset: 0x143ED60 VA: 0x143ED60
		// public IEnumerator SetStoryBgTexture(int map, Action callback) { }

		// // RVA: 0x143EE40 Offset: 0x143EE40 VA: 0x143EE40
		// public bool IsLoadingStoryBg() { }

		// // RVA: 0x143EE48 Offset: 0x143EE48 VA: 0x143EE48
		// public void StoryBgShow() { }

		// // RVA: 0x143EE70 Offset: 0x143EE70 VA: 0x143EE70
		// public void StoryBgHide() { }

		// // RVA: 0x143EC5C Offset: 0x143EC5C VA: 0x143EC5C
		// public void SetStoryBgSetPositionX(float x) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6C5D28 Offset: 0x6C5D28 VA: 0x6C5D28
		// // RVA: 0x143EF2C Offset: 0x143EF2C VA: 0x143EF2C
		// private void <StorytBgReturn>b__88_0() { }
	}
}