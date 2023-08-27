using System;
using System.Collections;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Common
{
	public class LowModeBackgroundResource : MonoBehaviour
	{
		private bool isUnused = true; // 0xC
		private bool isLoaded; // 0xD
		public Texture introTexture; // 0x10
		public Texture cardTexture; // 0x14
		public Texture battleTexture; // 0x18
		public bool isTitleBg; // 0x1C
		public int baseRare = 1; // 0x20

		public bool isAllLoaded { get
			{
				if (isUnused)
					return true;
				return isLoaded;
			}
			private set { return; } } //0x110AE9C 0x110AEC0

		// RVA: 0x110AA5C Offset: 0x110AA5C VA: 0x110AA5C
		public void OnDestroy()
		{
			introTexture = null;
			cardTexture = null;
			battleTexture = null;
		}

		//// RVA: 0x110AA70 Offset: 0x110AA70 VA: 0x110AA70
		public void LoadResouces(int introId, int cardId, int cardRarityId, int baseRare, int battleId, Texture cardTexture)
		{
			this.StartCoroutineWatched(Co_LoadAllResouces(introId, cardId, cardRarityId, baseRare, battleId, cardTexture));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7401BC Offset: 0x7401BC VA: 0x7401BC
		//// RVA: 0x110AAAC Offset: 0x110AAAC VA: 0x110AAAC
		private IEnumerator Co_LoadAllResouces(int introId, int cardId, int cardRarityId, int baseRare, int battleId, Texture cardTexture)
		{
			//0x110AEDC
			isUnused = false;
			isLoaded = false;
			yield return this.StartCoroutineWatched(Co_LoadIntroResource(introId));
			yield return this.StartCoroutineWatched(Co_LoadCardResource(cardId, cardRarityId, baseRare, cardTexture));
			yield return this.StartCoroutineWatched(Co_LoadBattleResource(battleId));
			isLoaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x740234 Offset: 0x740234 VA: 0x740234
		//// RVA: 0x110ABF4 Offset: 0x110ABF4 VA: 0x110ABF4
		private IEnumerator Co_LoadIntroResource(int introId)
		{
			StringBuilder bundleName; // 0x18
			AssetBundleLoadAssetOperation operation; // 0x1C

			//0x110BA7C
			bundleName = new StringBuilder();
			bundleName.SetFormat("ct/gm/bg/it/{0:D4}.xab", introId);
			StringBuilder assetName = new StringBuilder();
			assetName.SetFormat("{0:D4}", introId);
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(Texture));
			yield return operation;
			introTexture = operation.GetAsset<Texture>();
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7402AC Offset: 0x7402AC VA: 0x7402AC
		//// RVA: 0x110ACBC Offset: 0x110ACBC VA: 0x110ACBC
		private IEnumerator Co_LoadCardResource(int cardId, int cardRarityId, int baseRare, Texture cardTexture)
		{
			StringBuilder bundleName; // 0x24
			AssetBundleLoadAssetOperation operation; // 0x28

			//0x110B4F8
			int bg = Database.Instance.gameSetup.ForceBG();
			if(bg < 1 && cardTexture != null)
			{
				this.cardTexture = cardTexture;
			}
			else
			{
				bundleName = new StringBuilder();
				StringBuilder assetName = new StringBuilder();
				isTitleBg = cardId < 1;
				if(bg < 1)
				{
					if(cardId < 1)
					{
						bundleName.SetFormat("ct/gm/bg/ti/cmn.xab", Array.Empty<object>());
						assetName.SetFormat("cmn", Array.Empty<object>());
					}
					else
					{
						bundleName.SetFormat("ct/sc/me/02/{0:D6}_{1:D2}.xab", cardId, cardRarityId);
						assetName.SetFormat("{0:D6}_{1:D2}", cardId, cardRarityId);
					}
				}
				else
				{
					bundleName.SetFormat("ct/gm/bg/ap/{0:D4}.xab", bg);
					assetName.SetFormat("{0:D4}", bg);
				}
				operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(Texture));
				yield return operation;
				this.cardTexture = operation.GetAsset<Texture>();
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x740324 Offset: 0x740324 VA: 0x740324
		//// RVA: 0x110ADD4 Offset: 0x110ADD4 VA: 0x110ADD4
		private IEnumerator Co_LoadBattleResource(int battleId)
		{
			StringBuilder bundleName; // 0x18
			AssetBundleLoadAssetOperation operation; // 0x1C

			//0x110B168
			bundleName = new StringBuilder();
			StringBuilder assetName = new StringBuilder();
			bundleName.SetFormat("ct/gm/bg/bt/{0:D4}.xab", battleId);
			assetName.SetFormat("{0:D4}", battleId);
			operation = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), assetName.ToString(), typeof(Texture));
			yield return operation;
			battleTexture = operation.GetAsset<Texture>();
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
		}
	}
}
