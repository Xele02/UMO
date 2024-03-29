using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game;
using XeApp.Game.Menu;
using XeSys.Gfx;

namespace XeApp
{
	public class DecorationItemControllerLayout : LayoutUGUIScriptBase
	{
		public struct Setting
		{
			public Vector2 position; // 0x0
			public Vector2 size; // 0x8
			public LayoutDecorationFrameButton.ButtonType type; // 0x10
			public Action<LayoutDecorationFrameButton.ButtonType> buttonCallBack; // 0x14
		}

		private readonly Vector2 possibleMarkerSize = new Vector2(0.98f, 0.98f); // 0x14
		private LayoutDecorationFrameButton m_button; // 0x1C
		public static string BundleName = "ly/221.xab"; // 0x0
		public static string AssetName = "root_deco_frm_btn_01_layout_root"; // 0x4
		private GameObject m_possibleMarker; // 0x20
		private Image m_disiblePostMarkerImage; // 0x24
		private readonly Color DisableColor = new Color(1, 0, 0, 0.4f); // 0x2C
		private readonly Color EnableColor = new Color(0, 0, 0, 0); // 0x3C
		private Image m_frameImage; // 0x4C

		public bool IsLoadedResource { get; private set; } // 0x28

		//// RVA: 0x1AC18CC Offset: 0x1AC18CC VA: 0x1AC18CC
		public void LoadResource()
		{
			if(IsLoadedResource)
				return;
			IsLoadedResource = false;
			this.StartCoroutineWatched(Co_LoadControllerResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6AC110 Offset: 0x6AC110 VA: 0x6AC110
		//// RVA: 0x1AD5560 Offset: 0x1AD5560 VA: 0x1AD5560
		private IEnumerator Co_LoadControllerResource()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x1AD5F8C
			op = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x1AD5E08
				instance.transform.SetParent(transform, false);
				m_button = instance.GetComponent<LayoutDecorationFrameButton>();
				m_button.Hidden();
			}));
			yield return null;
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_frameImage = GetComponent<Image>();
			IsLoadedResource = true;
		}

		//// RVA: 0x1AD560C Offset: 0x1AD560C VA: 0x1AD560C
		public void Show(DecorationItemBase item, LayoutDecorationFrameButton.ButtonType type)
		{
			gameObject.SetActive(true);
			m_possibleMarker.SetActive(true);
			m_frameImage.enabled = true;
			UpdateFramePosition(item);
			m_button.Setting(transform as RectTransform, type, (LayoutDecorationFrameButton.ButtonType buttonType) =>
			{
				//0x1AD5EF8
				item.ButtonCallBack(buttonType);
				if (buttonType != LayoutDecorationFrameButton.ButtonType.Kira)
					return;
				m_button.SetKiraButtonState(item.IsKiraPoster);
			});
			if ((type & LayoutDecorationFrameButton.ButtonType.Kira) == 0)
				return;
			m_button.SetKiraButtonState(item.IsKiraPoster);
		}

		//// RVA: 0x1AD5838 Offset: 0x1AD5838 VA: 0x1AD5838
		public void UpdateFramePosition(DecorationItemBase item)
		{
			transform.localPosition = item.Position;
			transform.localScale = Vector2.one;
			(transform as RectTransform).sizeDelta = item.Size + DecorationConstants.ItemHitAddictionScale;
			m_possibleMarker.transform.localPosition = item.Position;
			m_possibleMarker.transform.localScale = possibleMarkerSize;
			(m_possibleMarker.transform as RectTransform).sizeDelta = item.Size + DecorationConstants.ItemHitAddictionScale;
		}

		//// RVA: 0x1AD5BA8 Offset: 0x1AD5BA8 VA: 0x1AD5BA8
		public void Hide()
		{
			m_button.Hidden();
			m_possibleMarker.SetActive(false);
			m_frameImage.enabled = false;
		}

		//// RVA: 0x1AD5C20 Offset: 0x1AD5C20 VA: 0x1AD5C20
		public void EnablePost(bool isEnable)
		{
			m_disiblePostMarkerImage.color = isEnable ? EnableColor : DisableColor;
		}

		//// RVA: 0x1AC184C Offset: 0x1AC184C VA: 0x1AC184C
		public void SetPossibleMaker(GameObject PossibleMarker)
		{
			m_possibleMarker = PossibleMarker;
			m_disiblePostMarkerImage = PossibleMarker.GetComponent<Image>();
		}
	}
}
