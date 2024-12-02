using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Menu
{
	public class KiraProductController
	{
		public enum KiraUpParameter
		{
			TOTAL = 0,
			SOUL = 1,
			VOICE = 2,
			CHARM = 3,
			LIFE = 4,
			SUPPORT = 5,
			FOLDWAVE = 6,
			LUCK = 7,
			MAX = 8,
		}
 
		public enum KiraComparisonParameter
		{
			LEFT = 0,
			RIGHT = 1,
			MAX = 2,
		}

		private LayoutGachaKiraAnimation animationLayout; // 0x8
		private bool m_islayoutLoaded; // 0xC

		public bool IsLayoutLoaded { get { return m_islayoutLoaded; } private set { return; } } //0x14BE5D4 0x14BE5D8

		// [IteratorStateMachineAttribute] // RVA: 0x6DC75C Offset: 0x6DC75C VA: 0x6DC75C
		// RVA: 0x14BE5E0 Offset: 0x14BE5E0 VA: 0x14BE5E0
		public IEnumerator StartDivaVoice()
		{
			//0x14BF930
			animationLayout.StartDivaVoice();
			yield return null;
			while(animationLayout.IsPlayingDivaVoice())
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC7D4 Offset: 0x6DC7D4 VA: 0x6DC7D4
		// RVA: 0x14BE68C Offset: 0x14BE68C VA: 0x14BE68C
		public IEnumerator StartKiraAnimation()
		{
			//0x14BFAA4
			if(MenuScene.Instance != null)
				MenuScene.Instance.RaycastDisable();
			animationLayout.StartAnimation();
			while(!animationLayout.IsKiraAnimEnd)
				yield return null;
			animationLayout.Leave();
			yield return null;
			while(animationLayout.IsPlaying())
				yield return null;
			if(MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
		}

		// RVA: 0x14BE738 Offset: 0x14BE738 VA: 0x14BE738
		public void SettingAnimLayout(int homeDivaId, SceneCardTextureCache sceneCache, SceneFrameTextureCache frameCache, int sceneId, int baseRare)
		{
			int id = GetSceneCardIdFromAttrId(sceneId);
			int rank = 1;
			if(baseRare > 3)
				rank = 2;
			animationLayout.SettingKiraPlate(sceneCache, sceneId, rank);
			animationLayout.SettingKiraPlateFrame(frameCache, id, baseRare, 2);
			animationLayout.SettingDiva(homeDivaId);
		}

		// // RVA: 0x14BE938 Offset: 0x14BE938 VA: 0x14BE938
		// private GCIJNCFDNON GetKiraSceneData(int sceneId) { }

		// // RVA: 0x14BE808 Offset: 0x14BE808 VA: 0x14BE808
		private int GetSceneCardIdFromAttrId(int cardId)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[cardId - 1].FKDCCLPGKDK_Ma;
		}

		// RVA: 0x14BEBEC Offset: 0x14BEBEC VA: 0x14BEBEC
		public bool IsEndSetting()
		{
			return animationLayout.IsEndLoadedTexture();
		}

		// RVA: 0x14BEC18 Offset: 0x14BEC18 VA: 0x14BEC18
		public void AllLayoutSetAsLastSibling()
		{
			animationLayout.transform.SetAsLastSibling();
		}

		// RVA: 0x14BEC64 Offset: 0x14BEC64 VA: 0x14BEC64
		public void AllLayoutChangeParent(Transform parent, bool worldpositionStay)
		{
			animationLayout.transform.SetParent(parent, worldpositionStay);
		}

		// RVA: 0x14BECC0 Offset: 0x14BECC0 VA: 0x14BECC0
		public void AllLayoutHide()
		{
			animationLayout.Hide();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC84C Offset: 0x6DC84C VA: 0x6DC84C
		// RVA: 0x14BECEC Offset: 0x14BECEC VA: 0x14BECEC
		public IEnumerator SettingDivaVoice(int divaId)
		{
			//0x14BF728
			bool _isLoaded = false;
			animationLayout.ChangeDivaVoice(divaId, () =>
			{
				//0x14BEF54
				_isLoaded = true;
			});
			while(!_isLoaded)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC8C4 Offset: 0x6DC8C4 VA: 0x6DC8C4
		// RVA: 0x14BEDB4 Offset: 0x14BEDB4 VA: 0x14BEDB4
		public IEnumerator ResetDivaVoice(int divaId)
		{
			//0x14BF520
			bool _isLoaded = false;
			animationLayout.ResetDivaVoice(divaId, () =>
			{
				//0x14BEF68
				_isLoaded = true;
			});
			while(!_isLoaded)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DC93C Offset: 0x6DC93C VA: 0x6DC93C
		// RVA: 0x14BEE7C Offset: 0x14BEE7C VA: 0x14BEE7C
		public IEnumerator Co_LoadLayout(Transform transform)
		{
			StringBuilder bundleName; // 0x1C
			XeSys.FontInfo systemFont; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24

			//0x14BF05C
			m_islayoutLoaded = false;
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/215.xab");
			if(animationLayout == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_gacha_kira_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
				{
					//0x14BEF7C
					instance.transform.SetParent(transform, false);
					animationLayout = instance.GetComponent<LayoutGachaKiraAnimation>();
				}));
			}
			else
			{
				animationLayout.Hide();
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			while(!animationLayout.IsLoaded())
				yield return null;
			yield return null;
			m_islayoutLoaded = true;
		}
	}
}
