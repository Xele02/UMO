using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using XeSys;
using XeApp.Core;
using mcrs;

namespace XeApp.Game.Menu
{
	public class UnlockHomeBgScene : MonoBehaviour
	{
		private StringBuilder m_strBuilder = new StringBuilder(128); // 0xC
		private const string HomeLimitedBgBundlePath = "mn/hm/bg/";
		[SerializeField]
		private UGUIButton okButton; // 0x10
		[SerializeField]
		private RawImage[] images = new RawImage[4]; // 0x14
		[SerializeField]
		private Image fadeImg; // 0x18
		private UnlockHomeBgLogo unlockHomeBgLogo; // 0x1C
		private bool isEnd; // 0x21

		private bool IsReady { get; set; } // 0x20
		//private bool IsEnd { get; } 0x164983C

		//[IteratorStateMachineAttribute] // RVA: 0x73246C Offset: 0x73246C VA: 0x73246C
		//// RVA: 0x1649844 Offset: 0x1649844 VA: 0x1649844
		public IEnumerator Co_Initialize(int homeBgId)
		{
			string nameBundle; // 0x18
			int loadCount; // 0x1C
			AssetBundleLoadAssetOperation t_operation; // 0x20
			AssetBundleLoadLayoutOperationBase layoutOp; // 0x24
			int i; // 0x28

			//0x1649F30
			fadeImg.color = new Color(Color.black.r, Color.black.g, Color.black.b, 0);
			if (homeBgId == 0)
				homeBgId = 11;
			ALJHJDHNFFB_HomeBg.ADLLAFIDFAM dbHomeBg = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PFEKKPABPKL_HomeBg.CDENCMNHNGA[homeBgId - 1];
			m_strBuilder.SetFormat("{0}bg{1:D4}.xab", "mn/hm/bg/", dbHomeBg.OENPCNBFPDA_BgId);
			loadCount = 0;
			nameBundle = m_strBuilder.ToString();
			t_operation = null;
			for (i = 0; i < 3; i++)
			{
				m_strBuilder.SetFormat("bg_home_{0:D2}", i);
				t_operation = AssetBundleManager.LoadAssetAsync(nameBundle, m_strBuilder.ToString(), typeof(Texture));
				yield return t_operation;
				images[i].texture = t_operation.GetAsset<Texture>();
				loadCount++;
			}
			m_strBuilder.SetFormat("bg_home_{0:D2}", 0);
			t_operation = AssetBundleManager.LoadAssetAsync(nameBundle, m_strBuilder.ToString(), typeof(Texture));
			yield return t_operation;
			images[3].texture = t_operation.GetAsset<Texture>();
			loadCount++;
			for (i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(nameBundle, false);
			}
			loadCount = 0;
			nameBundle = "ly/227.xab";
			layoutOp = AssetBundleManager.LoadLayoutAsync(nameBundle, "root_ul_bg_logo_layout_root");
			yield return layoutOp;
			yield return Co.R(layoutOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject inst) =>
			{
				//0x1649D00
				unlockHomeBgLogo = inst.GetComponentInChildren<UnlockHomeBgLogo>(true);
				inst.transform.SetParent(transform, false);
			}));
			loadCount++;
			for (i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(nameBundle, false);
			}
			for (i = 0; i < images.Length; i++)
			{
				images[i].enabled = false;
			}
			okButton.gameObject.SetActive(false);
			okButton.AddOnClickCallback(OnClickOk);
			IsReady = true;
		}

		//// RVA: 0x164990C Offset: 0x164990C VA: 0x164990C
		public void StartSequence()
		{
			isEnd = false;
			this.StartCoroutineWatched(Co_StartSequence());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7324E4 Offset: 0x7324E4 VA: 0x7324E4
		//// RVA: 0x164993C Offset: 0x164993C VA: 0x164993C
		private IEnumerator Co_StartSequence()
		{
			//0x164A978
			fadeImg.raycastTarget = false;
			UnlockFadeManager.Instance.GetEffect().Leave();
			unlockHomeBgLogo.Enter();
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_003);
			for(int i = 0; i < images.Length; i++)
			{
				images[i].enabled = true;
			}
			okButton.gameObject.SetActive(true);
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1649E80
				return UnlockFadeManager.Instance.GetEffect().IsPlaying();
			});
			yield return new WaitForSeconds(1);
			this.StartCoroutineWatched(FadeBgLoop());
			yield return new WaitWhile(() =>
			{
				//0x1649DF0
				return isEnd == false;
			});
			yield return Co.R(FadeIn(0.4f));
			MenuScene.Instance.Mount((TransitionUniqueId)MenuScene.Instance.GetCurrentScene().uniqueId, MenuScene.Instance.GetCurrentScene().args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			yield return null;
			while (GameManager.Instance.fullscreenFader.isFading)
				yield return null;
			Destroy(gameObject);
		}

		//// RVA: 0x16499E8 Offset: 0x16499E8 VA: 0x16499E8
		private void OnClickOk()
		{
			fadeImg.raycastTarget = true;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			UnlockFadeManager.Release();
			isEnd = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73255C Offset: 0x73255C VA: 0x73255C
		//// RVA: 0x1649AE4 Offset: 0x1649AE4 VA: 0x1649AE4
		private IEnumerator FadeBgLoop()
		{
			float t; // 0x14
			Color color; // 0x18
			float time; // 0x28

			//0x164B0EC
			color = Color.white;
			time = 1.5f;

			if (isEnd)
				yield break;
			color.a = 1;
			for(int i = 0; i < images.Length; i++)
			{
				images[i].color = color;
			}
			t = 0;
			while(t < time)
			{
				t += Time.deltaTime;
				color.a = Mathf.Lerp(1, 0, t);
				images[0].color = color;
				yield return null;
			}
			t = 0;
			color.a = 1;
			while (t < time)
			{
				t += Time.deltaTime;
				color.a = Mathf.Lerp(1, 0, t);
				images[1].color = color;
				yield return null;
			}
			t = 0;
			color.a = 1;
			while (t < time)
			{
				t += Time.deltaTime;
				color.a = Mathf.Lerp(1, 0, t);
				images[2].color = color;
				yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7325D4 Offset: 0x7325D4 VA: 0x7325D4
		//// RVA: 0x1649B90 Offset: 0x1649B90 VA: 0x1649B90
		private IEnumerator FadeIn(float time)
		{
			float t; // 0x18
			Color color; // 0x1C

			//0x164B6C0
			t = 0;
			color = Color.black;
			color.a = 0;
			fadeImg.color = color;
			fadeImg.transform.SetAsLastSibling();
			while(t < time)
			{
				t += Time.deltaTime;
				color.a = Mathf.Lerp(0, 1, t);
				fadeImg.color = color;
				yield return null;
			}
			color.a = 1;
			fadeImg.color = color;
		}
	}
}
