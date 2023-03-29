using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class HomeEventBanner : MonoBehaviour
	{
		
		// [HeaderAttribute] // RVA: 0x689C28 Offset: 0x689C28 VA: 0x689C28
		[SerializeField]
		private float m_autoScrollWait = 0.5f; // 0xC
		// [HeaderAttribute] // RVA: 0x689C70 Offset: 0x689C70 VA: 0x689C70
		[SerializeField]
		private GridLayoutGroup m_gridLayoutGroup; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x689CE4 Offset: 0x689CE4 VA: 0x689CE4
		private BannerScrollView m_scrollView; // 0x14
		// [HeaderAttribute] // RVA: 0x689D2C Offset: 0x689D2C VA: 0x689D2C
		[SerializeField]
		private HomeEventBannerContent m_objBanner; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x689D74 Offset: 0x689D74 VA: 0x689D74
		private Transform m_rootPageIcon; // 0x1C
		[SerializeField]
		private Toggle m_basePageIcon; // 0x20
		// [HeaderAttribute] // RVA: 0x689DEC Offset: 0x689DEC VA: 0x689DEC
		[SerializeField]
		private ButtonBase m_buttonLeft; // 0x24
		// [HeaderAttribute] // RVA: 0x689E3C Offset: 0x689E3C VA: 0x689E3C
		[SerializeField]
		private ButtonBase m_buttonRight; // 0x28
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x689E8C Offset: 0x689E8C VA: 0x689E8C
		private InOutAnime m_inOutAnime; // 0x2C
		// [HeaderAttribute] // RVA: 0x689ED4 Offset: 0x689ED4 VA: 0x689ED4
		[SerializeField]
		private CanvasGroup m_canvasGroup; // 0x30
		private Font m_font; // 0x34
		private int m_inputDisableCount; // 0x38
		private List<Toggle> m_listPageIcon = new List<Toggle>(); // 0x3C

		public Action<int> onClickBannerButton { private get; set; } // 0x40

		// RVA: 0xEA9268 Offset: 0xEA9268 VA: 0xEA9268
		private void Start()
		{
			m_buttonLeft.ClearOnClickCallback();
			m_buttonLeft.AddOnClickCallback(() => {
				//0xEABAC4
				TodoLogger.LogNotImplemented("HomeEventBanner.ButtonLeft");
			});
			m_buttonRight.ClearLoadedCallback();
			m_buttonRight.AddOnClickCallback(() => {
				//0xEABB34
				TodoLogger.LogNotImplemented("HomeEventBanner.ButtonRight");
			});
			m_scrollView.OnChangeItem = (int idx) => {
				//0xEABBA4
				TodoLogger.Log(0, "OnChangeItem");
			};
			m_scrollView.OnChangeEndItem = (int idx) => {
				//0xEABBC0
				TodoLogger.Log(0, "OnChangeEndItem");
			};
			InitScrollType();
		}

		// RVA: 0xEA9710 Offset: 0xEA9710 VA: 0xEA9710
		public void SetFont(Font font)
		{
			m_font = font;
		}

		// // RVA: 0xEA9718 Offset: 0xEA9718 VA: 0xEA9718
		// public void Setup(IKDICBBFBMI cont, long currentTime) { }

		// // RVA: 0xEA97F0 Offset: 0xEA97F0 VA: 0xEA97F0
		// public void Setup(List<IKDICBBFBMI> list, long currentTime) { }

		// // RVA: 0xEAA048 Offset: 0xEAA048 VA: 0xEAA048
		// public void AddBanner(int id, long start, long end, string text = "") { }

		// // RVA: 0xEAADE4 Offset: 0xEAADE4 VA: 0xEAADE4
		// public void RemoveBanner(int id) { }

		// // RVA: 0xEA9EE0 Offset: 0xEA9EE0 VA: 0xEA9EE0
		// public void ClearBanner() { }

		// // RVA: 0xEAB328 Offset: 0xEAB328 VA: 0xEAB328
		// private void InputEnable() { }

		// // RVA: 0xEAB418 Offset: 0xEAB418 VA: 0xEAB418
		// private void InputDisable() { }

		// // RVA: 0xEAABE0 Offset: 0xEAABE0 VA: 0xEAABE0
		// private void AddPageIcon(SelectScrollViewContent content) { }

		// // RVA: 0xEAB054 Offset: 0xEAB054 VA: 0xEAB054
		// public void RemovePageIcon(SelectScrollViewContent content) { }

		// // RVA: 0xEAB510 Offset: 0xEAB510 VA: 0xEAB510
		// private void UpdatePageIcon(int index) { }

		// // RVA: 0xEA9484 Offset: 0xEA9484 VA: 0xEA9484
		private void InitScrollType()
		{
			Vector2 pos = m_scrollView.content.anchoredPosition;
			m_scrollView.content.anchoredPosition = new Vector2(pos.x, 0);
			m_scrollView.horizontal = true;
			m_scrollView.vertical = false;
			m_scrollView.horizontalNormalizedPosition = 0;
			m_scrollView.SetPosition(0, 0);
			m_scrollView.SetAutoScroll(m_autoScrollWait);
			m_gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			m_gridLayoutGroup.constraintCount = m_scrollView.scrollObjects.Count;
			m_rootPageIcon.gameObject.SetActive(true);
		}

		// // RVA: 0xEAB5FC Offset: 0xEAB5FC VA: 0xEAB5FC
		// private void ChangeBanner(int dir, float animTime) { }

		// // RVA: 0xEAB708 Offset: 0xEAB708 VA: 0xEAB708
		// public void SetActive(bool active) { }

		// // RVA: 0xEAB7E0 Offset: 0xEAB7E0 VA: 0xEAB7E0
		// public void Enter() { }

		// // RVA: 0xEAB8A8 Offset: 0xEAB8A8 VA: 0xEAB8A8
		// public void Enter(float animTime) { }

		// // RVA: 0xEAB984 Offset: 0xEAB984 VA: 0xEAB984
		// public void Leave() { }

		// // RVA: 0xEAB9B8 Offset: 0xEAB9B8 VA: 0xEAB9B8
		// public void Leave(float animTime) { }

		// // RVA: 0xEABA00 Offset: 0xEABA00 VA: 0xEABA00
		// public bool IsPlaying() { }
	}
}
