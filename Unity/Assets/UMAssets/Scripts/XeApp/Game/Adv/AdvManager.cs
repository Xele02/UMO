using CriWare;
using mcrs;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.NameEntry;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Adv
{
	public class AdvManager : MonoBehaviour
	{
		public enum Position
		{
			Center = 0,
			Left = 1,
			Right = 2,
		}

		public enum LoadResourceType
		{
			Bg = 0,
			Character = 1,
			Effect = 2,
			Num = 3,
		}

		public enum SkipTarget
		{
			Talk = 0,
			Prologue = 1,
		}

		private static readonly Vector3[] m_characterPoint = new Vector3[3]
			{
				new Vector3(0, 0, 0), new Vector3(-343, 0, 0), new Vector3(343, 0, 0)
			}; // 0x0
		private static readonly List<AdvScriptCommand.Label> CannotSkipLabel = new List<AdvScriptCommand.Label>()
		{
			AdvScriptCommand.Label.CharaLoad,
			AdvScriptCommand.Label.CharaAuraLoad,
			AdvScriptCommand.Label.BgLoad,
			AdvScriptCommand.Label.BgmLoad,
			AdvScriptCommand.Label.SeLoad,
			AdvScriptCommand.Label.VoiceLoad,
			AdvScriptCommand.Label.SendLog,
			AdvScriptCommand.Label.VoiceDownLoad,
			AdvScriptCommand.Label.AssetDownLoad,
			AdvScriptCommand.Label.LoadAnime,
			AdvScriptCommand.Label.DeleteAnime,
			AdvScriptCommand.Label.Chara,
			AdvScriptCommand.Label.CharaOff,
			AdvScriptCommand.Label.CharaAura,
			AdvScriptCommand.Label.Bg,
			AdvScriptCommand.Label.BgOff,
			AdvScriptCommand.Label.Face,
			AdvScriptCommand.Label.EndScenario,
			AdvScriptCommand.Label.EndTutorial,
			AdvScriptCommand.Label.LiveSrart,
			AdvScriptCommand.Label.DivaSelect,
			AdvScriptCommand.Label.NextAdv,
			AdvScriptCommand.Label.TutoReturnPoint,
			AdvScriptCommand.Label.LoadPrologue,
			AdvScriptCommand.Label.ReleasePrologue,
			AdvScriptCommand.Label.LoadTutorialResource,
			AdvScriptCommand.Label.ReleaseTutorialResource
		}; // 0x4
		private const string CharacterBundlePath = "ad/ch/{0:D4}_{1:D3}.xab";
		private const string CharacterBlurBundlePath = "ad/chb/{0:D4}_{1:D3}.xab";
		private const string BgBundlePath = "ad/bg/{0:D4}.xab";
		private const string AssetName = "CharaData";
		private const string CharacterBlurAssetName = "blur";
		private const string BgAssetName = "{0:D4}";
		private const string EffBunldePath = "ly/100.xab";
		[SerializeField]
		private AdvCharacter m_advCharacterPrefab; // 0xC
		[SerializeField]
		private RawImage m_bg; // 0x10
		[SerializeField]
		private Button m_skipButton; // 0x14
		[SerializeField]
		private TweenBase[] m_sendIconTween; // 0x18
		[SerializeField]
		private MessageWindowInfo[] m_windowInfo; // 0x1C
		[SerializeField]
		private RectTransform m_charaRoot; // 0x20
		[SerializeField]
		private Button m_touchArea; // 0x24
		[SerializeField]
		private RectTransform m_animeRoot; // 0x28
		[SerializeField]
		private float[] m_messageSpeed = new float[2] { 0.2f, 0.2f }; // 0x2C
		[SerializeField]
		private float FADE_TIME = 0.4f; // 0x30
		[SerializeField]
		private AdvVoicePlayer m_advVoicePlayer; // 0x34
		private int m_bgId; // 0x38
		private int m_voiceCharaId; // 0x3C
		private int m_voiceId; // 0x40
		private bool m_isRunning; // 0x44
		private bool m_isBgmFading; // 0x45
		private bool m_isSendMessage; // 0x46
		private bool m_isExecuteSkip; // 0x47
		private bool m_isRequestBgmStop; // 0x48
		private bool m_isPushSkipButton; // 0x49
		private bool m_isVoiceSync; // 0x4A
		private sbyte[] m_loadResourcesCount = new sbyte[3]; // 0x4C
		private List<AdvCharacter> m_advCharacters = new List<AdvCharacter>(); // 0x50
		private Dictionary<int, AdvCharacterData> m_charaResourceDic = new Dictionary<int, AdvCharacterData>(); // 0x54
		private Dictionary<int, Texture> m_bgResourceDic = new Dictionary<int, Texture>(); // 0x58
		private Dictionary<int, List<LayoutUGUIRuntime>> m_charaEffResourceDic = new Dictionary<int, List<LayoutUGUIRuntime>>(); // 0x5C
		private Dictionary<int, LayoutUGUIRuntime> m_directionAnime = new Dictionary<int, LayoutUGUIRuntime>(); // 0x60
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x64
		private SnsScreen m_snsScreen; // 0x68
		private List<RawImageEx> m_rawImageList = new List<RawImageEx>(); // 0x6C
		private SceneCardTextureCache m_sceneCardTextureCache = new SceneCardTextureCache(1); // 0x70
		private MessageWindowInfo m_currentMessageWindow; // 0x74
		private TweenBase m_currentSendIcon; // 0x78
		private float m_currentMessageSpeed = 0.2f; // 0x7C
		private Coroutine m_doAdvCoroutine; // 0x80
		private Coroutine m_sendIconCoroutine; // 0x84
		private AdvCharacter m_oldSpeakCharacter; // 0x88
		private AdvCharacter m_nextSpeakCharacter; // 0x8C
		private TextPopupSetting m_skipConfirmPopupSetting; // 0x90
		private Coroutine m_syncVoiceCoroutine; // 0x94
		private PrologueControl m_prologueControl; // 0x98
		//[CompilerGeneratedAttribute] // RVA: 0x68DA8C Offset: 0x68DA8C VA: 0x68DA8C
		public UnityAction NetErrorHandler; // 0x9C
		private AdvManager.SkipTarget m_skipTarget; // 0xA0
		public const int AdvTouchSeNo = 17;
		private const float AdvBgmVolume = 0.7f;
		private const int TutorialSnsId = 1;
		private const float VoiceThreshold = 0.001f;
		private CriAtomExOutputAnalyzer exPlayerOutputAnalyzer; // 0xA4
		private BgControl m_bgControl; // 0xA8

		// RVA: 0xBC50CC Offset: 0xBC50CC VA: 0xBC50CC
		private void Awake()
		{
			AdvCharacter chara = Instantiate(m_advCharacterPrefab);
			m_advCharacters.Add(chara);
			chara.transform.localPosition = m_characterPoint[0];
			chara.transform.SetParent(m_charaRoot.transform, false);
			chara.transform.SetSiblingIndex(1);
			chara.gameObject.SetActive(false);
			for(int i = 1; i < 3; i++)
			{
				AdvCharacter chara2 = Instantiate(chara);
				m_advCharacters.Add(chara2);
				chara2.transform.localPosition = m_characterPoint[i];
				chara2.transform.SetParent(m_charaRoot.transform, false);
				chara2.transform.SetSiblingIndex(1);
				chara2.gameObject.SetActive(false);
			}
			for(int i = 0; i < m_sendIconTween.Length; i++)
			{
				m_sendIconTween[i].gameObject.SetActive(false);
			}
			m_skipConfirmPopupSetting = new TextPopupSetting();
			m_skipConfirmPopupSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Skip, Type = PopupButton.ButtonType.Positive }
			};
			m_skipButton.onClick.AddListener(OnClickSkipButton);
			m_touchArea.onClick.AddListener(() =>
			{
				//0xBC8E64
				if (!m_isPushSkipButton)
					m_isSendMessage = true;
			});
			exPlayerOutputAnalyzer = new CriAtomExOutputAnalyzer(new CriAtomExOutputAnalyzer.Config() { enableLevelmeter = true });
			SoundManager.Instance.voAdv.source.AttachToAnalyzer(exPlayerOutputAnalyzer);
		}

		// RVA: 0xBC5944 Offset: 0xBC5944 VA: 0xBC5944
		private void OnDestroy()
		{
			Release();
			m_charaResourceDic = null;
			m_bgResourceDic = null;
			m_charaEffResourceDic = null;
			SoundManager.Instance.voAdv.source.DetachFromAnalyzer(exPlayerOutputAnalyzer);
		}

		//// RVA: 0xBC59E0 Offset: 0xBC59E0 VA: 0xBC59E0
		private void Release()
		{
			for(int i = 0; i < m_advCharacters.Count; i++)
			{
				m_advCharacters[i].RemoveEffect(transform);
				m_advCharacters[i].Clear();
				m_advCharacters[i].ResetState();
				m_advCharacters[i].gameObject.SetActive(false);
			}
			int cnt = m_charaEffResourceDic.Count;
			foreach (var k in m_charaEffResourceDic)
			{
				for(int i = 0; i < k.Value.Count; i++)
				{
					Destroy(k.Value[i].gameObject);
				}
				k.Value.Clear();
			}
			foreach(var k in m_directionAnime)
			{
				Destroy(k.Value.gameObject);
			}
			m_directionAnime.Clear();
			m_charaResourceDic.Clear();
			m_bgResourceDic.Clear();
			m_charaEffResourceDic.Clear();
			for(int i = 0; i < cnt; i++)
			{
				AssetBundleManager.UnloadAssetBundle("ly/100.xab", false);
			}
		}

		//// RVA: 0xBC61A0 Offset: 0xBC61A0 VA: 0xBC61A0
		private void SetDisp(bool isOn)
		{
			for(int i = 0; i < m_advCharacters.Count; i++)
			{
				m_advCharacters[i].SetDisp(isOn);
			}
			m_bg.enabled = isOn;
			m_currentMessageWindow.SetActive(isOn);
		}

		//// RVA: 0xBC62C8 Offset: 0xBC62C8 VA: 0xBC62C8
		//private void SetCharacter(int charaId, AdvManager.Position position, bool isPrism, bool isSkip, int poseId = 1, int faceId = 1, int colorId = 0) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7425F4 Offset: 0x7425F4 VA: 0x7425F4
		//// RVA: 0xBC6450 Offset: 0xBC6450 VA: 0xBC6450
		private IEnumerator HideCharacter(int charaId, bool isSkip)
		{
			AdvCharacter chara;

			//0xE52344
			chara = m_advCharacters.Find((AdvCharacter x) =>
			{
				//0xBC934C
				return x.CharaId == charaId;
			});
			yield return Co.R(chara.HideCoroutine(isSkip));
			chara.gameObject.SetActive(false);
		}

		//// RVA: 0xBC650C Offset: 0xBC650C VA: 0xBC650C
		private void DeleteCaracter(int charaId)
		{
			AdvCharacter chara = m_advCharacters.Find((AdvCharacter x) =>
			{
				//0xBC9384
				return x.CharaId == charaId;
			});
			chara.ResetState();
			chara.Clear();
			chara.gameObject.SetActive(false);
		}

		//// RVA: 0xBC6684 Offset: 0xBC6684 VA: 0xBC6684
		//private void LoadCharacter(int charaId, int poseId, bool isPrism) { }

		//[IteratorStateMachineAttribute] // RVA: 0x74266C Offset: 0x74266C VA: 0x74266C
		//// RVA: 0xBC6314 Offset: 0xBC6314 VA: 0xBC6314
		private IEnumerator SetCharacterCoroutine(int charaId, Position position, int poseId, int faceId, bool isPrism, int colorId, bool isSkip)
		{
			//0xE53A54
			int key = MakeCharacterDictKey(charaId, poseId);
			AdvCharacterData data;
			if(m_charaResourceDic.TryGetValue(key, out data))
			{
				m_advCharacters[(int)position].SetCharacterData(charaId, data, (int)position, isPrism, colorId);
				m_advCharacters[(int)position].gameObject.SetActive(true);
				m_advCharacters[(int)position].transform.SetAsLastSibling();
				m_advCharacters[(int)position].SetFace(faceId);
				yield return Co.R(m_advCharacters[(int)position].ShowCoroutine(isSkip));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7426E4 Offset: 0x7426E4 VA: 0x7426E4
		//// RVA: 0xBC66B0 Offset: 0xBC66B0 VA: 0xBC66B0
		private IEnumerator LoadCharacterCoroutine(int charaId, int poseId, bool isPrism)
		{
			int key;

			//0xE52D6C
			AdvCharacterData data = null;
			key = MakeCharacterDictKey(charaId, poseId);
			if(m_charaResourceDic.TryGetValue(key, out data))
				yield break;
			yield return this.StartCoroutineWatched(LoadCharacterResourceCoroutine(charaId, poseId, (AdvCharacterData x) =>
			{
				//0xBC93C4
				data = x;
			}));
			if(isPrism)
			{
				yield return this.StartCoroutineWatched(LoadCharacterAuraResourceCoroutine(charaId, poseId, (Texture2D x) =>
				{
					//0xBC93CC
					data.SetBlurTexture(x);
				}));
			}
			//LAB_00e52ed0
			m_charaResourceDic.Add(key, data);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x74275C Offset: 0x74275C VA: 0x74275C
		//// RVA: 0xBC6784 Offset: 0xBC6784 VA: 0xBC6784
		private IEnumerator LoadCharacterResourceCoroutine(int charaId, int poseId, UnityAction<AdvCharacterData> callBack)
		{
			string bundleName; // 0x20
			AssetBundleLoadAssetOperation op; // 0x24

			//0xE53584
			IncLoadingCount(LoadResourceType.Character);
			m_strBuilder.SetFormat("ad/ch/{0:D4}_{1:D3}.xab", charaId, poseId);
			bundleName = m_strBuilder.ToString();
			op = AssetBundleManager.LoadAssetAsync(bundleName, "CharaData", typeof(AdvCharacterData));
			yield return op;
			if (callBack != null)
				callBack(op.GetAsset<AdvCharacterData>());
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			DecLoadingCount(LoadResourceType.Character);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7427D4 Offset: 0x7427D4 VA: 0x7427D4
		//// RVA: 0xBC6858 Offset: 0xBC6858 VA: 0xBC6858
		private IEnumerator LoadCharacterAuraResourceCoroutine(int charaId, int poseId, UnityAction<Texture2D> callBack)
		{
			string bundleName; // 0x20
			AssetBundleLoadAssetOperation op; // 0x24

			//0xE529CC
			IncLoadingCount(LoadResourceType.Character);
			m_strBuilder.SetFormat("ad/chb/{0:D4}_{1:D3}.xab", charaId, poseId);
			bundleName = m_strBuilder.ToString();
			op = AssetBundleManager.LoadAssetAsync(bundleName, "blur", typeof(Texture2D));
			yield return op;
			if (callBack != null)
				callBack(op.GetAsset<Texture2D>());
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			DecLoadingCount(LoadResourceType.Character);
		}

		//// RVA: 0xBC692C Offset: 0xBC692C VA: 0xBC692C
		private int MakeCharacterDictKey(int charaId, int poseId)
		{
			return poseId | (charaId << 16);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x74284C Offset: 0x74284C VA: 0x74284C
		//// RVA: 0xBC6934 Offset: 0xBC6934 VA: 0xBC6934
		private IEnumerator LoadBgCoroutine(int bgId)
		{
			string bundleName; // 0x18
			AssetBundleLoadAssetOperation op; // 0x1C

			//0xE525C4
			if(!m_bgResourceDic.ContainsKey(bgId))
			{
				IncLoadingCount(LoadResourceType.Bg);
				m_strBuilder.SetFormat("ad/bg/{0:D4}.xab", bgId);
				bundleName = m_strBuilder.ToString();
				m_strBuilder.SetFormat("{0:D4}", bgId);
				op = AssetBundleManager.LoadAssetAsync(bundleName, m_strBuilder.ToString(), typeof(Texture));
				yield return op;
				m_bgResourceDic.Add(bgId, op.GetAsset<Texture>());
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				DecLoadingCount(LoadResourceType.Bg);
			}
		}

		//// RVA: 0xBC69D8 Offset: 0xBC69D8 VA: 0xBC69D8
		private void SetBg(int bgId)
		{
			if (m_bgId == bgId)
				return;
			m_bg.texture = null;
			m_bg.texture = m_bgResourceDic[bgId];
			m_bgId = bgId;
		}

		//// RVA: 0xBC6AB4 Offset: 0xBC6AB4 VA: 0xBC6AB4
		private void LoadBg(int bgId)
		{
			if (m_bgResourceDic.ContainsKey(bgId))
				return;
			this.StartCoroutineWatched(LoadBgCoroutine(bgId));
		}

		//// RVA: 0xBC6B58 Offset: 0xBC6B58 VA: 0xBC6B58
		//private void ShowCharacterEffect(int effId, int charaId) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7428C4 Offset: 0x7428C4 VA: 0x7428C4
		//// RVA: 0xBC6B7C Offset: 0xBC6B7C VA: 0xBC6B7C
		private IEnumerator ShowCharacterEffectCoroutine(int effId, int charaId)
		{
			//0xE53E70
			List<LayoutUGUIRuntime> lr;
			if(!m_charaEffResourceDic.TryGetValue(effId, out lr))
			{
				yield return this.StartCoroutineWatched(LoadCharacterEffectCoroutine(effId));
				m_charaEffResourceDic.TryGetValue(effId, out lr);
			}
			AdvCharacter chara = m_advCharacters.Find((AdvCharacter x) =>
			{
				//0xBC93FC
				return x.CharaId == charaId;
			});
			if(chara != null)
			{
				chara.AppendEffect(lr[0]);
				lr[0].Layout.StartAllAnim();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x74293C Offset: 0x74293C VA: 0x74293C
		//// RVA: 0xBC6C38 Offset: 0xBC6C38 VA: 0xBC6C38
		private IEnumerator LoadCharacterEffectCoroutine(int effId)
		{
			AssetBundleLoadLayoutOperationBase op;

			//0xE53174
			if (m_charaEffResourceDic.ContainsKey(effId))
				yield break;
			IncLoadingCount(LoadResourceType.Effect);
			GameObject newInstance = null;
			op = AssetBundleManager.LoadLayoutAsync("ly/100.xab", string.Format("root_adv_eff_{0:D3}_layout_root", effId));
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(null, (GameObject instance) =>
			{
				//0xBC943C
				newInstance = instance;
			}));
			List<LayoutUGUIRuntime> lr = new List<LayoutUGUIRuntime>();
			m_charaEffResourceDic.Add(effId, lr);
			lr.Add(newInstance.GetComponent<LayoutUGUIRuntime>());
			DecLoadingCount(LoadResourceType.Effect);
		}

		//// RVA: 0xBC6CDC Offset: 0xBC6CDC VA: 0xBC6CDC
		private void SetFace(int charaId, int faceId)
		{
			AdvCharacter chara = m_advCharacters.Find((AdvCharacter x) =>
			{
				//0xBC9444
				return x.CharaId == charaId;
			});
			if(chara != null)
			{
				chara.SetFace(faceId);
			}
		}

		//// RVA: 0xBC6E44 Offset: 0xBC6E44 VA: 0xBC6E44
		//private int ConvertToEffectId(AdvScriptCommand.Label label) { }

		//// RVA: 0xBC6E58 Offset: 0xBC6E58 VA: 0xBC6E58
		private void IncLoadingCount(LoadResourceType type)
		{
			m_loadResourcesCount[(int)type]++;
		}

		//// RVA: 0xBC6EA8 Offset: 0xBC6EA8 VA: 0xBC6EA8
		private void DecLoadingCount(LoadResourceType type)
		{
			m_loadResourcesCount[(int)type]--;
			if (m_loadResourcesCount[(int)type] > -1)
				return;
			m_loadResourcesCount[(int)type] = 0;
		}

		//// RVA: 0xBC6F78 Offset: 0xBC6F78 VA: 0xBC6F78
		private bool IsLoadingResource()
		{
			for(int i = 0; i < m_loadResourcesCount.Length; i++)
			{
				if (m_loadResourcesCount[i] > 0)
					return true;
			}
			return false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7429B4 Offset: 0x7429B4 VA: 0x7429B4
		//// RVA: 0xBC7004 Offset: 0xBC7004 VA: 0xBC7004
		private IEnumerator ShowSnsCoroutine(int snsId)
		{
			SnsScreen.eSceneType sceneType;

			//0xE5424C
			bool isWait = true;
			sceneType = SnsScreen.eSceneType.Adventure;
			if (snsId == 1)
				sceneType = SnsScreen.eSceneType.Tutorial;
			SoundManager.Instance.RequestEntryMenuCueSheet(() =>
			{
				//0xBC9484
				isWait = false;
			});
			while(isWait)
				yield return null;
			if(m_snsScreen == null)
			{
				m_snsScreen = SnsScreen.Create(transform.parent);
				yield return null;
			}
			isWait = true;
			if(sceneType == SnsScreen.eSceneType.Tutorial)
			{
				m_snsScreen.Initialize(0, true);
				m_snsScreen.In(sceneType, SNSController.eObjectOrderType.Last, !GameManager.Instance.IsTutorial);
			}
			else
			{
				m_snsScreen.Initialize(snsId, false);
				m_snsScreen.InRoom(sceneType, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_Talks[snsId - 1].MALFHCHNEFN_RoomId, SNSController.eObjectOrderType.Last, snsId, false, false);
			}
			m_snsScreen.OutStartCallback = () =>
			{
				//0xBC9490
				SetDisp(true);
				isWait = false;
			};
			while (m_snsScreen.layoutController == null || m_snsScreen.layoutController.layoutBoot == null)
				yield return null;
			while (m_snsScreen.layoutController.layoutBoot.IsPlaying())
				yield return null;
			while (isWait)
				yield return null;
			while(m_snsScreen.IsPlaying)
				yield return null;
			m_snsScreen.Dispose();
			m_snsScreen = null;
			isWait = true;
			SoundManager.Instance.RequestEntryAdvCueSheet(() =>
			{
				//0xBC94C8
				isWait = false;
			});
			while (isWait)
				yield return null;
		}

		//// RVA: 0xBC70A8 Offset: 0xBC70A8 VA: 0xBC70A8
		private void EffectSEPlay(AdvScriptCommand.Label label)
		{
			switch(label)
			{
				case AdvScriptCommand.Label.FlashEf:
					SoundManager.Instance.sePlayerAdv.Play((int)cs_se_adv.SE_ADV_001);
					break;
				case AdvScriptCommand.Label.ImEf:
					SoundManager.Instance.sePlayerAdv.Play((int)cs_se_adv.SE_ADV_002);
					break;
				case AdvScriptCommand.Label.QaEf:
					SoundManager.Instance.sePlayerAdv.Play((int)cs_se_adv.SE_ADV_004);
					break;
				case AdvScriptCommand.Label.HappyEf:
					SoundManager.Instance.sePlayerAdv.Play((int)cs_se_adv.SE_ADV_000);
					break;
				case AdvScriptCommand.Label.LoveEf:
					SoundManager.Instance.sePlayerAdv.Play((int)cs_se_adv.SE_ADV_003);
					break;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742A2C Offset: 0x742A2C VA: 0x742A2C
		//// RVA: 0xBC7250 Offset: 0xBC7250 VA: 0xBC7250
		private IEnumerator Dispatch(AdvScriptData scriptData, int messageIndex, int commandIndex, UnityAction onEndCommand)
		{
			int charaId;

			//0xBCD6F0
			AdvScriptCommand.Label label = scriptData.GetCommandLabel(messageIndex, commandIndex);
			if (!m_isExecuteSkip || CannotSkipLabel.FindIndex((AdvScriptCommand.Label x) =>
				 {
					 //0xBC94DC
					 return label == x;
				 }) >= 0)
			{
				switch (label)
				{
					case AdvScriptCommand.Label.CharaLoad:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							this.StartCoroutineWatched(LoadCharacterCoroutine(param0, param1, false));
						}
						break;
					case AdvScriptCommand.Label.BgLoad:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							LoadBg(param0);
						}
						break;
					case AdvScriptCommand.Label.VoiceLoad:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							bool isVoiceWait = true;
							SoundManager.Instance.voAdv.RequestChangeAdvCueSheet(param0, () =>
							{
								//0xBC9520
								isVoiceWait = false;
							});
							while (isVoiceWait)
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.SendLog:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							OAGBCBBHMPF.OGBCFNIKAFI a = OAGBCBBHMPF.OGBCFNIKAFI.FFPMNJAMFCP_13/*13*/;
							if (param0 > 0 && param0 < 6)
								a = new OAGBCBBHMPF.OGBCFNIKAFI[5] {
									OAGBCBBHMPF.OGBCFNIKAFI.FEEJKNDAHFE_19/*19*/,
									OAGBCBBHMPF.OGBCFNIKAFI.CAMJGCCMANN_28/*28*/,
									OAGBCBBHMPF.OGBCFNIKAFI.KLPNOJFFNGL_29/*29*/,
									OAGBCBBHMPF.OGBCFNIKAFI.KBMDDIHNCFI_30/*30*/,
									OAGBCBBHMPF.OGBCFNIKAFI.GFLDEDJAONB_35/*35*/
								}[param0 - 1];
							BasicTutorialManager.Log(a);
						}
						break;
					case AdvScriptCommand.Label.VoiceDownLoad:
						{
							string param0 = scriptData.GetStringCommandParam(messageIndex, commandIndex, 0);
							string[] p = param0.Split(new char[] { ',' });
							for(int i = 0; i < p.Length; i++)
							{
								m_strBuilder.SetFormat("cs_adv_{0:D6}", int.Parse(p[i]));
								if(!SoundResource.IsInstalledCueSheet(m_strBuilder.ToString()))
								{
									SoundResource.InstallCueSheet(m_strBuilder.ToString());
								}
							}
							yield return null;
							while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.AssetDownLoad:
						{
							string param0 = scriptData.GetStringCommandParam(messageIndex, commandIndex, 0);
							string[] p = param0.Split(new char[] { ',' });
							for (int i = 0; i < p.Length; i++)
								KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(p[i]);
							yield return null;
							while (KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.CharaAuraLoad:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							this.StartCoroutineWatched(LoadCharacterCoroutine(param0, param1, true));
						}
						break;
					case AdvScriptCommand.Label.Chara:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							int param2 = scriptData.GetCommandParam(messageIndex, commandIndex, 2);
							int param3 = scriptData.GetCommandParam(messageIndex, commandIndex, 3);
							this.StartCoroutineWatched(SetCharacterCoroutine(param0, (Position)param1, param2, param3, false, 0, m_isExecuteSkip));
							if (param0 == scriptData.GetSpeakerId(messageIndex))
							{
								yield return Co.R(Co_ChangeSpeakCharacter(param0, true, m_isExecuteSkip));
							}
						}
						break;
					case AdvScriptCommand.Label.CharaOff:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							yield return Co.R(HideCharacter(param0, m_isExecuteSkip));
						}
						break;
					case AdvScriptCommand.Label.CharaDelete:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							if(m_oldSpeakCharacter != null)
							{
								if (m_oldSpeakCharacter.CharaId == param0)
									m_oldSpeakCharacter = null;
							}
							DeleteCaracter(param0);
						}
						break;
					case AdvScriptCommand.Label.CharaAura:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							int param2 = scriptData.GetCommandParam(messageIndex, commandIndex, 2);
							int param3 = scriptData.GetCommandParam(messageIndex, commandIndex, 3);
							int param4 = scriptData.GetCommandParam(messageIndex, commandIndex, 4);
							this.StartCoroutineWatched(SetCharacterCoroutine(param0, (Position)param1, param2, param3, true, param4, m_isExecuteSkip));
							if(param0 == scriptData.GetSpeakerId(messageIndex))
							{
								yield return Co.R(Co_ChangeSpeakCharacter(param0, true, m_isExecuteSkip));
							}
						}
						break;
					case AdvScriptCommand.Label.Bg:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							SetBg(param0);
						}
						break;
					case AdvScriptCommand.Label.BgOff:
						{
							m_bg.texture = null;
							m_bgId = 0;
						}
						break;
					case AdvScriptCommand.Label.Window:
						{
							yield return this.StartCoroutineWatched(ShowWindowAnimeCoroutine());
						}
						break;
					case AdvScriptCommand.Label.WindowOff:
						{
							HideWindow();
						}
						break;
					case AdvScriptCommand.Label.FadeIn:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							GameManager.FadeIn(param0 / 1000.0f);
							while (GameManager.IsFading())
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.FadeOut:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							GameManager.FadeOut(param0 / 1000.0f);
							while (GameManager.IsFading())
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.ChangeCurrentWindow:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							m_currentMessageWindow = m_windowInfo[param0];
							m_currentMessageSpeed = m_messageSpeed[param0];
							m_currentSendIcon = m_sendIconTween[param0];
						}
						break;
					case AdvScriptCommand.Label.Face:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							SetFace(param0, param1);
						}
						break;
					case AdvScriptCommand.Label.Bgm:
						{
							m_isRequestBgmStop = false;
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmPlayer.MENU_BGM_ID_BASE + param0, 0.7f);
						}
						break;
					case AdvScriptCommand.Label.StopBgm:
						{
							m_isRequestBgmStop = true;
							SoundManager.Instance.bgmPlayer.Stop();
						}
						break;
					case AdvScriptCommand.Label.Se:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							SoundManager.Instance.sePlayerAdv.Play(param0);
						}
						break;
					case AdvScriptCommand.Label.StopSe:
						{
							SoundManager.Instance.sePlayerBoot.Stop();
						}
						break;
					case AdvScriptCommand.Label.Voice:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							SoundManager.Instance.voAdv.Play(param0, param1);
						}
						break;
					case AdvScriptCommand.Label.FadeOutBgm:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							m_isBgmFading = true;
							m_isRequestBgmStop = true;
							SoundManager.Instance.bgmPlayer.FadeOut(param0 / 1000.0f, () =>
							{
								//0xBC94F0
								m_isBgmFading = false;
							});
						}
						break;
					case AdvScriptCommand.Label.WaitFadeBgm:
						{
							while (m_isBgmFading)
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.SyncVoice:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							m_voiceCharaId = param0;
							m_voiceId = param1;
							m_isVoiceSync = true;
						}
						break;
					case AdvScriptCommand.Label.FlashEf:
					case AdvScriptCommand.Label.ImEf:
					case AdvScriptCommand.Label.QaEf:
					case AdvScriptCommand.Label.HappyEf:
					case AdvScriptCommand.Label.LoveEf:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							charaId = param0;
							yield return Co.R(Co_ChangeSpeakCharacter(param0, false, m_isExecuteSkip));
							EffectSEPlay(label);
							int effId = 1;
							if (label >= AdvScriptCommand.Label.ImEf && label <= AdvScriptCommand.Label.LoveEf)
								effId = (int)label - 49;
							this.StartCoroutineWatched(ShowCharacterEffectCoroutine(effId, charaId));
						}
						break;
					case AdvScriptCommand.Label.Info:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							GameManager.Instance.ShowSnsNotice(param0, () =>
							{
								//0xBC9098
								return;
							}, false);
						}
						break;
					case AdvScriptCommand.Label.Name:
						{
							bool isWait = true;
							NameEntry.NameEntry.ShowPlayerNameEntry("", (string name) =>
							{
								//0xBC9534
								CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName = name;
								isWait = false;
							}, NetErrorHandler);
							while (isWait)
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.Valkyrie:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							yield return this.StartCoroutineWatched(Co_ValkyrieGet(param0));
						}
						break;
					case AdvScriptCommand.Label.SnsShow:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							GameManager.Instance.snsNotification.Close();
							yield return this.StartCoroutineWatched(ShowSnsCoroutine(param0));
						}
						break;
					case AdvScriptCommand.Label.EndTutorial:
						{
							yield return this.StartCoroutine(Co_TutorialFinish());
						}
						break;
					case AdvScriptCommand.Label.LiveSrart:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							Database.Instance.advResult.Setup(param0);
							Database.Instance.advSetup.Setup(param1);
						}
						break;
					case AdvScriptCommand.Label.DivaSelect:
						{
							Database.Instance.advResult.Setup("DivaSelect");
						}
						break;
					case AdvScriptCommand.Label.NextAdv:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							Database.Instance.advResult.SetupNextAdv((short)param0);
						}
						break;
					case AdvScriptCommand.Label.TutoReturnPoint:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							BasicTutorialManager.Instance.UpdateRecoveryPoint((ILDKBCLAFPB.CDIPJNPICCO_RecoveryPoint)param0);
						}
						break;
					case AdvScriptCommand.Label.Wait:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							yield return new WaitForSeconds(param0 / 1000.0f);
						}
						break;
					case AdvScriptCommand.Label.Skip:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							m_skipButton.gameObject.SetActive(param0 != 0);
						}
						break;
					case AdvScriptCommand.Label.SnsNotificationTutorial:
						{
							BIFNGFAIEIL.HHCJCDFCLOB.DLKJAPDLDFG(false, 0);
						}
						break;
					case AdvScriptCommand.Label.LoadAnime:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							yield return Co.R(Co_LoadDirectionAnime(param0));
						}
						break;
					case AdvScriptCommand.Label.PlayAnime:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							string param2 = scriptData.GetStringCommandParam(messageIndex, commandIndex, 2);
							string param3 = scriptData.GetStringCommandParam(messageIndex, commandIndex, 3);
							PlayAnime(param0, param1, param2, param3);
							yield return null;
						}
						break;
					case AdvScriptCommand.Label.WaitAnime:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							charaId = param0;
							while (WaitAnime(param0))
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.DeleteAnime:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							DeleteDirectionAnime(param0);
						}
						break;
					case AdvScriptCommand.Label.DispAnime:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							int param1 = scriptData.GetCommandParam(messageIndex, commandIndex, 1);
							LayoutUGUIRuntime r = null;
							if(m_directionAnime.TryGetValue(param0, out r))
							{
								r.gameObject.SetActive(param1 != 0);
							}
						}
						break;
					case AdvScriptCommand.Label.SetPlateMaterial:
						{
							int param0 = scriptData.GetCommandParam(messageIndex, commandIndex, 0);
							string layerName = scriptData.GetStringCommandParam(messageIndex, commandIndex, 1);
							int param2 = scriptData.GetCommandParam(messageIndex, commandIndex, 2);
							int param3 = scriptData.GetCommandParam(messageIndex, commandIndex, 3);
							LayoutUGUIRuntime r;
							if(m_directionAnime.TryGetValue(param0, out r))
							{
								r.GetComponentsInChildren(true, m_rawImageList);
								m_strBuilder.SetFormat("{0} (ImageView)", layerName);
								layerName = m_strBuilder.ToString();
								RawImageEx find = m_rawImageList.Find((RawImageEx x) =>
								{
									//0xBC962C
									return x.name == layerName;
								});
								if(find != null)
								{
									bool isWait = true;
									m_sceneCardTextureCache.Load(param2, param3, (IiconTexture texture) =>
									{
										//0xBC9670
										texture.Set(find);
										find.uvRect = new Rect(0, 0, 1, 1);
										isWait = false;
									});
									while (isWait)
									{
										m_sceneCardTextureCache.Update();
										yield return null;
									}
								}
							}
						}
						break;
					case AdvScriptCommand.Label.LoadPrologue:
						{
							yield return Co.R(Co_LoadPrologueAnime());
						}
						break;
					case AdvScriptCommand.Label.StartPrologue:
						{
							yield return Co.R(Co_StartPrologueAnime());
						}
						break;
					case AdvScriptCommand.Label.WaitPrologue:
						{
							yield return Co.R(Co_WaitPrologueAnime());
						}
						break;
					case AdvScriptCommand.Label.ReleasePrologue:
						{
							yield return Co.R(Co_ReleasePrologueAnime());
						}
						break;
					case AdvScriptCommand.Label.LoadTutorialResource:
						{
							if (!BasicTutorialManager.HasInstanced)
								BasicTutorialManager.Initialize();
							bool isWait = true;
							BasicTutorialManager.Instance.PreLoadResource(() =>
							{
								//0xBC97E0
								isWait = false;
							}, true);
							while (isWait)
								yield return null;
						}
						break;
					case AdvScriptCommand.Label.ReleaseTutorialResource:
						{
							if (BasicTutorialManager.HasInstanced)
								BasicTutorialManager.Instance.Release();
						}
						break;
				}
			}
			if (onEndCommand != null)
				onEndCommand();
		}

		//// RVA: 0xBC7364 Offset: 0xBC7364 VA: 0xBC7364
		private void ChangeSpeakCharacterName(int speakerId)
		{
			if (speakerId < 1)
				return;
			m_currentMessageWindow.SetName(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.KHCACDIKJLG_Characters[speakerId - 1].OPFGFINHFCE_Name);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742AA4 Offset: 0x742AA4 VA: 0x742AA4
		//// RVA: 0xBC74BC Offset: 0xBC74BC VA: 0xBC74BC
		private IEnumerator Co_ChangeSpeakCharacter(int speakerId, bool isMomentEp, bool isSkip)
		{
			//0xBC9A20
			m_nextSpeakCharacter = m_advCharacters.Find((AdvCharacter x) =>
			{
				//0xBC97F4
				return x.CharaId == speakerId;
			});
			if(m_nextSpeakCharacter != null)
			{
				if(m_nextSpeakCharacter != m_oldSpeakCharacter)
				{
					if (!isSkip && !isMomentEp)
						this.StartCoroutineWatched(m_nextSpeakCharacter.Expansion());
					else
						m_nextSpeakCharacter.ChangeExpansion();
				}
			}
			if(m_oldSpeakCharacter != null)
			{
				if(m_oldSpeakCharacter != m_nextSpeakCharacter)
				{
					if (!isSkip)
						this.StartCoroutineWatched(m_oldSpeakCharacter.Shrink());
					else
						m_oldSpeakCharacter.ChangeShrink();
				}
			}
			if (m_oldSpeakCharacter != null)
			{
				while (m_oldSpeakCharacter.IsTweenPlaying())
					yield return null;
			}
			if (m_nextSpeakCharacter != null)
			{
				m_nextSpeakCharacter.transform.SetAsLastSibling();
				while(m_nextSpeakCharacter.IsTweenPlaying())
					yield return null;
			}
			m_oldSpeakCharacter = m_nextSpeakCharacter;
		}

		//// RVA: 0xBC75B4 Offset: 0xBC75B4 VA: 0xBC75B4
		private void OnClickSkipButton()
		{
			if (m_isSendMessage || m_isPushSkipButton)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_ShowAdvSkipPopup());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742B1C Offset: 0x742B1C VA: 0x742B1C
		//// RVA: 0xBC76CC Offset: 0xBC76CC VA: 0xBC76CC
		private IEnumerator Co_VoiceSync()
		{
			//0xBCCFD4
			bool isWait = false;
			while(SoundManager.Instance.voAdv.isPlaying)
			{
				if(m_nextSpeakCharacter != null)
				{
					if(exPlayerOutputAnalyzer.GetRms(0) >= 0.001f)
					{
						isWait = true;
						m_nextSpeakCharacter.StartMouthOneAnime(() =>
						{
							//0xBC9834
							isWait = false;
						});
						while(isWait)
						{
							if(exPlayerOutputAnalyzer.GetRms(0) < 0.001f)
							{
								isWait = false;
								m_nextSpeakCharacter.EndMouthOneAnime();
								break;
							}
							yield return null;
						}
					}
				}
				yield return null;
			}
			m_nextSpeakCharacter.EndMouthOneAnime();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742B94 Offset: 0x742B94 VA: 0x742B94
		//// RVA: 0xBC7778 Offset: 0xBC7778 VA: 0xBC7778
		private IEnumerator Co_LoadDirectionAnime(int id)
		{
			AssetBundleLoadLayoutOperationBase op;

			//0xBC9F30
			if(!m_directionAnime.ContainsKey(id))
			{
				m_strBuilder.SetFormat("ad/am/{0:D6}.xab", id);
				string bundleName = m_strBuilder.ToString();
				m_strBuilder.SetFormat("{0:D6}", id);
				op = AssetBundleManager.LoadLayoutAsync(bundleName, m_strBuilder.ToString());
				yield return op;
				yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
				{
					//0xBC9848
					LayoutUGUIRuntime r = inst.GetComponent<LayoutUGUIRuntime>();
					m_directionAnime.Add(id, r);
					r.Layout.StartAllAnimDecoLoop();
					inst.transform.SetParent(m_animeRoot.transform, false);
					inst.gameObject.SetActive(false);
				}));
			}
		}

		//// RVA: 0xBC7840 Offset: 0xBC7840 VA: 0xBC7840
		private void PlayAnime(int id, int playMode, string startLabel, string endLabel)
		{
			LayoutUGUIRuntime r;
			if(m_directionAnime.TryGetValue(id, out r))
			{
				AbsoluteLayout a = r.Layout.FindViewById("all") as AbsoluteLayout;
				if(a != null)
				{
					if (playMode == 0)
					{
						if (!string.IsNullOrEmpty(endLabel))
							a.StartChildrenAnimGoStop(startLabel, endLabel);
						else
							a.StartChildrenAnimGoStop(startLabel);
					}
					else if (!string.IsNullOrEmpty(endLabel))
						a.StartChildrenAnimLoop(startLabel, endLabel);
					else
						a.StartChildrenAnimLoop(startLabel);
				}
			}
		}

		//// RVA: 0xBC79FC Offset: 0xBC79FC VA: 0xBC79FC
		private bool WaitAnime(int id)
		{
			LayoutUGUIRuntime r;
			if (m_directionAnime.TryGetValue(id, out r))
			{
				AbsoluteLayout a = r.Layout.FindViewById("all") as AbsoluteLayout;
				if (a != null)
				{
					return a.IsPlayingChildren();
				}
			}
			return false;
		}

		//// RVA: 0xBC7B98 Offset: 0xBC7B98 VA: 0xBC7B98
		private void DeleteDirectionAnime(int id)
		{
			LayoutUGUIRuntime r;
			if (m_directionAnime.TryGetValue(id, out r))
			{
				Destroy(r.gameObject);
				m_directionAnime.Remove(id);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742C0C Offset: 0x742C0C VA: 0x742C0C
		//// RVA: 0xBC7CC0 Offset: 0xBC7CC0 VA: 0xBC7CC0
		private IEnumerator Co_LoadPrologueAnime()
		{
			int loadCount; // 0x14
			string bundlePath; // 0x18
			AssetBundleLoadLayoutOperationBase lyOpt; // 0x1C

			//0xBCA35C
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded("snd/bgm/cs_bgm_tutorial.acb");
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded("snd/bgm/cs_bgm_tutorial.awb");
			loadCount = 0;
			bundlePath = "ly/083.xab";
			lyOpt = AssetBundleManager.LoadLayoutAsync(bundlePath, "root_cmn_tuto02_layout_root");
			yield return lyOpt;
			yield return Co.R(lyOpt.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xBC8E78
				instance.transform.SetParent(transform.GetChild(0), false);
				m_prologueControl = instance.GetComponent<PrologueControl>();
			}));
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundlePath, false);
			}
			while(!m_prologueControl.IsInitialized)
				yield return null;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742C84 Offset: 0x742C84 VA: 0x742C84
		//// RVA: 0xBC7D6C Offset: 0xBC7D6C VA: 0xBC7D6C
		private IEnumerator Co_StartPrologueAnime()
		{
			//0xBCB054
			m_prologueControl.BgmChangeEventHandler += () =>
			{
				//0xBC909C
				SoundManager.Instance.bgmPlayer.ContinuousPlay(BgmConstant.Name.Prologue2, 1);
			};
			SoundManager.Instance.bgmPlayer.Play(BgmConstant.Name.Prologue1, 1);
			GameManager.Instance.fullscreenFader.Fade(1, 0);
			m_prologueControl.Play();
			m_touchArea.interactable = false;
			m_skipTarget = SkipTarget.Prologue;
			yield break;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742CFC Offset: 0x742CFC VA: 0x742CFC
		//// RVA: 0xBC7E18 Offset: 0xBC7E18 VA: 0xBC7E18
		private IEnumerator Co_WaitPrologueAnime()
		{
			//0xBCD3C0
			m_skipButton.interactable = true;
			m_isSendMessage = false;
			while(m_prologueControl.IsPlaying() && !m_isExecuteSkip)
				yield return null;
			m_skipButton.interactable = false;
			if(PopupWindowManager.IsOpenPopupWindow())
			{
				bool isWait = true;
				PopupWindowManager.Close(null, () =>
				{
					//0xBC9A10
					isWait = false;
				});
				while(isWait)
					yield return null;
			}
			m_skipTarget = SkipTarget.Talk;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742D74 Offset: 0x742D74 VA: 0x742D74
		//// RVA: 0xBC7EC4 Offset: 0xBC7EC4 VA: 0xBC7EC4
		private IEnumerator Co_ReleasePrologueAnime()
		{
			//0xBCA7D0
			SoundManager.Instance.bgmPlayer.FadeOut(1, null);
			GameManager.Instance.fullscreenFader.Fade(1, Color.black);
			yield return GameManager.Instance.WaitFadeYielder;
			m_prologueControl.gameObject.SetActive(false);
			m_touchArea.interactable = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742DEC Offset: 0x742DEC VA: 0x742DEC
		//// RVA: 0xBC7F70 Offset: 0xBC7F70 VA: 0xBC7F70
		public IEnumerator DoAdv(int advId, bool isAuto = false)
		{
			AdvScriptData adv_data; // 0x24
			int message_index; // 0x28
			bool isSpkMessage; // 0x2C
			int i; // 0x30

			//0xE50614
			CriAtom.SetBusAnalyzer(true);
			m_isExecuteSkip = false;
			m_isRunning = true;
			m_isRequestBgmStop = false;
			m_skipTarget = 0;
			m_skipButton.interactable = false;
			for(i = 0; i < m_windowInfo.Length; i++)
			{
				m_windowInfo[i].SetActive(false);
				m_windowInfo[i].SetName("");
				m_windowInfo[i].m_message.StartMessage("", 0, null);
			}
			m_currentMessageWindow = m_windowInfo[0];
			m_currentSendIcon = m_sendIconTween[0];
			m_currentMessageWindow.SetActive(true);
			m_currentMessageSpeed = m_messageSpeed[0];
			HideWindow();
			HideSendCursor();
			m_oldSpeakCharacter = null;
			m_nextSpeakCharacter = null;
			adv_data = new AdvScriptData();
			adv_data.Load(advId, null);
			bool isWait = true;
			SoundManager.Instance.RequestEntryAdvCueSheet(() =>
			{
				//0xBC9220
				isWait = false;
			});
			while (!adv_data.isReady || isWait)
				yield return null;
			adv_data.UnLoad();
			GameManager.Instance.AddPushBackButtonHandler(OnPushBackButton);
			bool isWaitCommand = false;
			for(message_index = 0; message_index < adv_data.listEntry.Length; message_index++)
			{
				m_isVoiceSync = false;
				int speakerId = adv_data.GetSpeakerId(message_index);
				for(i = 0; i < adv_data.GetCommandCount(message_index); i++)
				{
					isWaitCommand = true;
					this.StartCoroutineWatched(Dispatch(adv_data, message_index, i, () =>
					{
						//0xBC922C
						isWaitCommand = false;
					}));
					while (isWaitCommand)
						yield return null;
				}
				while (IsLoadingResource())
					yield return null;
				if(speakerId != 0)
				{
					if(!m_isExecuteSkip)
					{
						m_skipButton.interactable = true;
						ChangeSpeakCharacterName(speakerId);
						yield return Co.R(Co_ChangeSpeakCharacter(speakerId, false, m_isExecuteSkip));
						string str = DatabaseTextConverter.TranslateAdventureMessage(advId, message_index, adv_data.GetMessage(message_index));
						m_currentMessageWindow.m_message.StartMessage(str, m_currentMessageSpeed, null);
						isSpkMessage = str.Length > 0;
						if(isSpkMessage)
						{
							if(!m_isVoiceSync)
							{
								int l = m_currentMessageWindow.GetNotRichTextLength(str);
								if(m_nextSpeakCharacter != null)
								{
									m_nextSpeakCharacter.StartMouthAnime(m_currentMessageSpeed * l);
								}
							}
							else
							{
								SoundManager.Instance.voAdv.Play(m_voiceCharaId, m_voiceId);
								if(m_syncVoiceCoroutine != null)
								{
									this.StopCoroutineWatched(m_syncVoiceCoroutine);
									m_syncVoiceCoroutine = null;
								}
								m_syncVoiceCoroutine = this.StartCoroutineWatched(Co_VoiceSync());
							}
						}
						while(m_currentMessageWindow.m_message.IsPlay())
						{
							if(m_isSendMessage)
							{
								m_currentMessageWindow.m_message.Skip();
								m_isSendMessage = false;
							}
							yield return null;
						}
						ShowSendCursor();
						if(isSpkMessage && !m_isVoiceSync)
						{
							if(m_nextSpeakCharacter != null)
							{
								m_nextSpeakCharacter.EndMouthAnime();
							}
						}
						while (true)
						{
							bool stop = false;
							//LAB_00e51244
							if (m_isExecuteSkip)
							{
								//LAB_00e512f0
								stop = true;
							}
							if (isAuto && !m_isPushSkipButton)
							{
								yield return new WaitForSeconds(0.5f);
								//LAB_00e512f0
								stop = true;
							}
							if (m_isSendMessage)
							{
								if (isSpkMessage)
								{
									SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_ADV_TOUCH);
								}
								//LAB_00e512e8
								m_isSendMessage = false;
								//LAB_00e512f0
								stop = true;
							}
							else if (!isSpkMessage)
							{
								//LAB_00e512e8
								m_isSendMessage = false;
								//LAB_00e512f0
								stop = true;
							}

							if(stop)
							{
								//LAB_00e512f0
								m_skipButton.interactable = false;
								HideSendCursor();
								yield return null;
								AdvCharacter c = m_advCharacters.Find((AdvCharacter x) =>
								{
									//0xBC9240
									return x.CharaId == speakerId;
								});
								if (c != null)
								{
									c.RemoveEffect(transform);
								}
								if (m_isVoiceSync)
								{
									SoundManager.Instance.voAdv.Stop();
								}
								break;
							}
							else
							{
								yield return null;
								//LAB_00e51244
							}
						}
					}
				}
			}
			if(m_isExecuteSkip && m_isRequestBgmStop)
			{
				SoundManager.Instance.bgmPlayer.Stop();
			}
			SoundManager.Instance.voAdv.Stop();
			while (SoundManager.Instance.voAdv.isPlaying)
				yield return null;
			SoundManager.Instance.voAdv.RemoveCueSheet();
			m_sceneCardTextureCache.Terminated();
			yield return null;
			m_isRunning = false;
			GameManager.Instance.RemovePushBackButtonHandler(OnPushBackButton);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742E64 Offset: 0x742E64 VA: 0x742E64
		//// RVA: 0xBC802C Offset: 0xBC802C VA: 0xBC802C
		private IEnumerator SendIconAnimeCoroutine()
		{
			//0xE53924
			while (true)
			{
				m_currentSendIcon.UpdateCurve();
				yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742EDC Offset: 0x742EDC VA: 0x742EDC
		//// RVA: 0xBC80B4 Offset: 0xBC80B4 VA: 0xBC80B4
		private IEnumerator ShowWindowAnimeCoroutine()
		{
			//0xE54B20
			m_currentMessageWindow.SetActive(true);
			yield return this.StartCoroutineWatched(m_currentMessageWindow.Co_Show());
		}

		//// RVA: 0xBC813C Offset: 0xBC813C VA: 0xBC813C
		private void HideWindow()
		{
			m_currentMessageWindow.Hide();
			m_currentMessageWindow.SetActive(false);
		}

		//// RVA: 0xBC8190 Offset: 0xBC8190 VA: 0xBC8190
		private void ShowSendCursor()
		{
			m_currentSendIcon.gameObject.SetActive(true);
			if(m_sendIconCoroutine != null)
			{
				this.StopCoroutineWatched(m_sendIconCoroutine);
				m_sendIconCoroutine = null;
			}
			m_sendIconCoroutine = this.StartCoroutineWatched(SendIconAnimeCoroutine());
		}

		//// RVA: 0xBC8220 Offset: 0xBC8220 VA: 0xBC8220
		private void HideSendCursor()
		{
			if(m_sendIconCoroutine != null)
			{
				this.StopCoroutineWatched(m_sendIconCoroutine);
				m_sendIconCoroutine = null;
			}
			m_currentSendIcon.gameObject.SetActive(false);
		}

		//// RVA: 0xBC8294 Offset: 0xBC8294 VA: 0xBC8294
		//private OAGBCBBHMPF.OGBCFNIKAFI ConverTutorialLogStep(int value) { }

		//[IteratorStateMachineAttribute] // RVA: 0x742F54 Offset: 0x742F54 VA: 0x742F54
		//// RVA: 0xBC7640 Offset: 0xBC7640 VA: 0xBC7640
		private IEnumerator Co_ShowAdvSkipPopup()
		{
			//0xBCAA8C
			bool isOk = false;
			bool isWait = true;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_isPushSkipButton = true;
			m_skipConfirmPopupSetting.TitleText = bk.GetMessageByLabel("popup_adv_skip_title");
			m_skipConfirmPopupSetting.Text = string.Format(bk.GetMessageByLabel("popup_adv_skip_text"), bk.GetMessageByLabel(m_skipTarget == 0 ? "popup_adv_skip_target001" : "popup_adv_skip_target002"));
			PopupWindowManager.Show(m_skipConfirmPopupSetting, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0xBC9280
				if (t == PopupButton.ButtonType.Positive)
					isOk = true;
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
			m_isPushSkipButton = false;
			if(isOk)
			{
				m_skipButton.interactable = false;
				GameManager.FadeOut(0.4f);
				if(SoundManager.Instance.voAdv.isPlaying)
				{
					SoundManager.Instance.voAdv.Stop();
				}
				yield return GameManager.Instance.WaitFadeYielder;
				m_isExecuteSkip = true;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x742FCC Offset: 0x742FCC VA: 0x742FCC
		//// RVA: 0xBC82D4 Offset: 0xBC82D4 VA: 0xBC82D4
		private IEnumerator Co_TutorialFinish()
		{
			//0xBCB3B8
			FENCAJJBLBH f = GameManager.Instance.localSave.KPOCKNCJBPN_CheckSecure();
			if(f != null)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() =>
				{
					//0xBC8FF0
					NetErrorHandler();
				}, "");
				yield break;
			}
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.LOAOLBNFNNP_InitDefault();
			CIOECGOMILE.HHCJCDFCLOB.OIEBCNPOMIB_UpdateDayChange(true);
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JLJJHDGEHLK_RecvSns = 1;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd = 1;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.PPOJCDCCFNI_TutorialEnd = 1;
			BIFNGFAIEIL.HHCJCDFCLOB.DLKJAPDLDFG(true, 0);
			bool isWait = true;
			JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.GHKKPKBBEAN_Prepare(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), () =>
			{
				//0xBC92A0
				isWait = false;
			}, () =>
			{
				//0xBC8F6C
				NetErrorHandler();
			});
			while(isWait)
				yield return null;
			isWait = true;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xBC92AC
				isWait = false;
			}, () =>
			{
				//0xBC8F98
				NetErrorHandler();
			}, null);
			while(isWait)
				yield return null;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.AGEAPKNODHO();
			BasicTutorialManager.Instance.Release();
			Destroy(BasicTutorialManager.Instance);
			GameManager.Instance.IsTutorial = false;
			PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.ONHOCOBCINO_3);
			if(AssetBundleManager.isTutorialNow)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("tuto_after_title", 1) == 1)
				{
					AssetBundleManager.isTutorialNow = false;
					JHHBAFKMBDL.HHCJCDFCLOB.CIKMDHMMCIL_ShowErrorPopup(2, () =>
					{
						//0xBC8FC4
						NetErrorHandler();
					});
					yield break;
				}
			}
			AssetBundleManager.isTutorialNow = false;
			Database.Instance.advResult.Setup("DownLoad");
		}

		//// RVA: 0xBC8380 Offset: 0xBC8380 VA: 0xBC8380
		private void OnPushBackButton()
		{
			if (m_skipButton.interactable)
			{
				if (m_skipButton.gameObject.activeSelf)
				{
					OnClickSkipButton();
					return;
				}
			}
			ToastSupport.Post(MessageManager.Instance.GetMessage("menu", "android_backbutton_disable"));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x743044 Offset: 0x743044 VA: 0x743044
		//// RVA: 0xBC84D8 Offset: 0xBC84D8 VA: 0xBC84D8
		private IEnumerator Co_ValkyrieGet(int valId = 1)
		{
			string bundleName; // 0x1C
			AssetBundleLoadAssetOperation op; // 0x20
			LayoutLogoCutin effect; // 0x24
			UnityAction ok; // 0x28

			//0xBCC12C
			bool isWait = true;
			m_bgControl = new BgControl(transform.parent.gameObject);
			yield return this.StartCoroutineWatched(m_bgControl.Load(null));
			m_bgControl.SetPriority(BgPriority.Bottom);
			yield return this.StartCoroutineWatched(m_bgControl.ChangeBgCoroutine(BgType.UnlockValkyrie, -1, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			bundleName = "ly/086.xab";
			op = AssetBundleManager.LoadAssetAsync(bundleName, "UnlockValkyrieManager", typeof(GameObject));
			yield return op;
			GameObject g = Instantiate(op.GetAsset<GameObject>());
			g.transform.SetParent(transform.parent, false);
			UnlockValkyrieManager unlockValkyrieManager = g.GetComponent<UnlockValkyrieManager>();
			unlockValkyrieManager.InitializeLayout();
			yield return new WaitWhile(() =>
			{
				//0xBC92C0
				return !unlockValkyrieManager.IsInitializedLayout;
			});
			unlockValkyrieManager.InitializeValkyrie(valId, 10);
			yield return new WaitWhile(() =>
			{
				//0xBC92F0
				return !unlockValkyrieManager.IsInitializedValkyrie;
			});
			isWait = true;
			SoundManager.Instance.RequestEntryMenuCueSheet(() =>
			{
				//0xBC9320
				isWait = false;
			});
			while(isWait)
				yield return null;
			UnlockFadeManager.Create();
			this.StartCoroutineWatched(UnlockFadeManager.Instance.Co_LoadFadeEffect(unlockValkyrieManager.SeriesAttr));
			yield return new WaitWhile(() =>
			{
				//0xBC9178
				return !UnlockFadeManager.Instance.IsLoaded();
			});
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			UnlockFadeManager.Instance.GetEffect().Enter();
			effect = UnlockFadeManager.Instance.GetEffect();
			while(effect.IsPlaying())
				yield return null;
			unlockValkyrieManager.StartDirection();
			SetDisp(false);
			isWait = true;
			ok = () =>
			{
				//0xBC932C
				isWait = false;
			};
			unlockValkyrieManager.PushOkButtonHandler += ok;
			while(isWait)
				yield return null;
			unlockValkyrieManager.PushOkButtonHandler -= ok;
			GameManager.FadeOut(0.4f);
			yield return GameManager.Instance.WaitFadeYielder;
			unlockValkyrieManager.Release();
			Destroy(unlockValkyrieManager.gameObject);
			m_bgControl.Destroy();
			m_bgControl = null;
			SetDisp(true);
			GameManager.Instance.SetFPS(30);
			isWait = true;
			SoundManager.Instance.RequestEntryAdvCueSheet(() =>
			{
				//0xBC9338
				isWait = false;
			});
			while(isWait)
				yield return null;
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x7430FC Offset: 0x7430FC VA: 0x7430FC
		//// RVA: 0xBC8FC4 Offset: 0xBC8FC4 VA: 0xBC8FC4
		//private void <Co_TutorialFinish>b__109_5() { }

		//[CompilerGeneratedAttribute] // RVA: 0x74310C Offset: 0x74310C VA: 0x74310C
		//// RVA: 0xBC8FF0 Offset: 0xBC8FF0 VA: 0xBC8FF0
		//private void <Co_TutorialFinish>b__109_0() { }
	}
}
