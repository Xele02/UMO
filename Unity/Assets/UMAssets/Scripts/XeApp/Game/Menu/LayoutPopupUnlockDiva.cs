using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeSys;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupUnlockDiva : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_divaName; // 0x14
		[SerializeField]
		private RawImageEx m_diva; // 0x18
		[SerializeField]
		private Text m_comment; // 0x1C
		[SerializeField]
		private Text m_birthday; // 0x20
		[SerializeField]
		private Text m_age; // 0x24
		[SerializeField]
		private Text m_birthplace; // 0x28
		[SerializeField]
		private Text m_like; // 0x2C
		private AbsoluteLayout m_root; // 0x30
		private AbsoluteLayout m_JoinAnim; // 0x34
		private bool m_isOpen; // 0x38
		private bool m_isClosed; // 0x39
		private List<IEnumerator> m_animationList = new List<IEnumerator>(8); // 0x3C

		// RVA: 0x178E770 Offset: 0x178E770 VA: 0x178E770
		public void SetStatus(PopupUnlock.UnlockInfo info)
		{
			if(info.param.id < 0)
				return;
			FFHPBEPOMAK_DivaInfo f = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[info.param.id];
			SetDivaIcon(f.AHHJLDLAPAN_DivaId);
			SetDivaName(f.OPFGFINHFCE_Name);
			SetDivaStatus(f.AHHJLDLAPAN_DivaId);
		}

		// RVA: 0x178E934 Offset: 0x178E934 VA: 0x178E934
		public void SetDivaIcon(int divaId)
		{
			if(m_diva != null)
			{
				GameManager.Instance.DivaIconCache.LoadPortraitIcon(divaId, 1, 0, (IiconTexture texture) =>
				{
					//0x178F8B4
					texture.Set(m_diva);
				});
			}
		}

		// RVA: 0x178EA9C Offset: 0x178EA9C VA: 0x178EA9C
		public void SetDivaName(string text)
		{
			if(m_divaName != null)
				m_divaName.text = text;
		}

		// RVA: 0x178EB5C Offset: 0x178EB5C VA: 0x178EB5C
		private void SetDivaStatus(int divaId)
		{
			if(m_comment != null)
				m_comment.horizontalOverflow = HorizontalWrapMode.Wrap;
			MessageBank bk = MessageManager.Instance.GetBank("common");
			SetText(m_birthday, bk.GetMessageByLabel(string.Format("profile_diva{0:d3}_birthday", divaId)));
			SetText(m_age, bk.GetMessageByLabel(string.Format("profile_diva{0:d3}_age", divaId)));
			SetText(m_birthplace, bk.GetMessageByLabel(string.Format("profile_diva{0:d3}_birthplace", divaId)));
			SetText(m_like, bk.GetMessageByLabel(string.Format("profile_diva{0:d3}_favorite", divaId)));
			SetText(m_comment, bk.GetMessageByLabel(string.Format("profile_diva{0:d3}_description", divaId)));
		}

		// RVA: 0x178EE80 Offset: 0x178EE80 VA: 0x178EE80
		private void SetText(Text label, string text)
		{
			if(label != null)
				label.text = text;
		}

		// RVA: 0x178EF38 Offset: 0x178EF38 VA: 0x178EF38
		public void PlayJoinAnim()
		{
			m_JoinAnim.StartAllAnimGoStop("go_in", "st_in");
			m_animationList.Add(WaitJoinAnim());
		}

		// RVA: 0x178F080 Offset: 0x178F080 VA: 0x178F080
		public void PlayVoice(PopupUnlock.UnlockInfo info)
		{
			if(info.param.id < 0)
				return;
			SoundManager.Instance.voGreeting.Play(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas[info.param.id].AHHJLDLAPAN_DivaId, 0);
		}

		// RVA: 0x178F23C Offset: 0x178F23C VA: 0x178F23C
		public void Update()
		{
			if(m_animationList.Count > 0)
			{
				if(!m_animationList[0].MoveNext())
				{
					m_animationList.RemoveAt(0);
				}
			}
		}

		// RVA: 0x178F3B4 Offset: 0x178F3B4 VA: 0x178F3B4
		public void Show()
		{
			if(m_root != null)
			{
				if(m_isOpen)
					return;
				m_isOpen = true;
				m_isClosed = false;
				m_root.StartAllAnimGoStop("go_in", "st_in");
				if(m_JoinAnim != null)
					m_JoinAnim.StartAllAnimGoStop("st_wait");
			}
		}

		// RVA: 0x178F470 Offset: 0x178F470 VA: 0x178F470
		public void Hide()
		{
			if(m_root != null)
			{
				if(m_isOpen)
				{
					m_isOpen = false;
					m_isClosed = true;
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70482C Offset: 0x70482C VA: 0x70482C
		// RVA: 0x178EFF4 Offset: 0x178EFF4 VA: 0x178EFF4
		private IEnumerator WaitJoinAnim()
		{
			//0x178F998
			yield return null;
			while(m_JoinAnim.IsPlayingChildren())
				yield return null;
			m_JoinAnim.StartAllAnimLoop("logo_up", "loen_up");
		}

		// RVA: 0x178F4B0 Offset: 0x178F4B0 VA: 0x178F4B0
		public void Reset()
		{
			return;
		}

		// // RVA: 0x178F4B4 Offset: 0x178F4B4 VA: 0x178F4B4
		// private void DeleteImage(ref RawImageEx image) { }

		// RVA: 0x178F604 Offset: 0x178F604 VA: 0x178F604 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_root.StartAllAnimGoStop("st_wait");
			m_JoinAnim = layout.FindViewByExId("sw_pop_cul_set_sw_cul_anim") as AbsoluteLayout;
			m_JoinAnim.StartAllAnimGoStop("st_wait");
			if(m_diva != null)
				m_diva.raycastTarget = false;
			Loaded();
			return true;
		}
	}
}
