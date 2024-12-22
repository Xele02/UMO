using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;
using System;
using System.Collections.Generic;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutSNSRoomItem : LayoutSNSBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		[SerializeField]
		private Text m_roomName; // 0x18
		[SerializeField]
		private RawImageEx m_roomImage; // 0x1C
		private AbsoluteLayout m_root; // 0x20
		private AbsoluteLayout m_newIcon; // 0x24
		private Action<int> m_pressCallback; // 0x28
		private RectTransform m_rootRt; // 0x2C
		private List<IEnumerator> m_animList = new List<IEnumerator>(); // 0x30
		private bool m_newEnable; // 0x34
		private GAKAAIHLFKI m_roomData; // 0x38

		//// RVA: 0x1933380 Offset: 0x1933380 VA: 0x1933380 Slot: 14
		public override void SetStatus(GAKAAIHLFKI data, Action<int> callback)
		{
			m_pressCallback = callback;
			m_roomData = data;
			m_roomName.text = data.OPFGFINHFCE_Name;
			SetImage(data.MALFHCHNEFN_Id);
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_newEnable = data.PLKKMHBFDCJ(time);
			SwitchNewIcon(m_newEnable);
		}

		//// RVA: 0x19336C4 Offset: 0x19336C4 VA: 0x19336C4 Slot: 6
		public override void SetPosition(float pos_x, float pos_y, float height)
		{
			if(m_rootRt != null)
			{
				m_rootRt.anchoredPosition = new Vector2(pos_x, -(height * 0.5f + pos_y));
			}
		}

		//// RVA: 0x1933644 Offset: 0x1933644 VA: 0x1933644
		public void SwitchNewIcon(bool enable)
		{
			if (m_newIcon == null)
				return;
			if (!enable)
				m_newIcon.StartChildrenAnimLoop("st_non");
		}

		//// RVA: 0x19337C8 Offset: 0x19337C8 VA: 0x19337C8
		public void SetNewIconFrame(int frame)
		{
			if (m_newEnable && m_newIcon != null)
				m_newIcon.StartChildrenAnimGoStop(frame, frame);
		}

		//// RVA: 0x19334EC Offset: 0x19334EC VA: 0x19334EC
		public void SetImage(int id)
		{
			if (m_roomImage == null)
				return;
			GameManager.Instance.SnsIconCache.RoomIconLoad(id, (IiconTexture icon) =>
			{
				//0x19341C0
				icon.Set(m_roomImage);
			});
		}

		// RVA: 0x19337EC Offset: 0x19337EC VA: 0x19337EC
		public void Reset()
		{
			return;
		}

		// RVA: 0x19337F0 Offset: 0x19337F0 VA: 0x19337F0
		public void Update()
		{
			for (int i = 0; i < m_animList.Count; i++)
			{
				if (m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
					{
						m_animList[i] = null;
					}
				}
			}
		}

		//// RVA: 0x193398C Offset: 0x193398C VA: 0x193398C Slot: 8
		public override void Show()
		{
			if (m_root == null)
				return;
			gameObject.SetActive(true);
			m_root.StartChildrenAnimGoStop("st_in", "st_in");
			m_animList.Clear();
		}

		// RVA: 0x1933A74 Offset: 0x1933A74 VA: 0x1933A74 Slot: 9
		public override void Hide()
		{
			m_root.StartChildrenAnimGoStop("st_out", "st_out");
			m_animList.Clear();
			gameObject.SetActive(false);
		}

		//// RVA: 0x1933B44 Offset: 0x1933B44 VA: 0x1933B44 Slot: 10
		public override void In()
		{
			if (m_root == null)
				return;
			gameObject.SetActive(true);
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
			m_animList.Clear();
			m_animList.Add(WaitAnimIn());
		}

		//// RVA: 0x1933D00 Offset: 0x1933D00 VA: 0x1933D00 Slot: 11
		public override void Out()
		{
			if (m_root == null)
				return;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_animList.Clear();
			m_animList.Add(WaitAnimOut());
		}

		//// RVA: 0x1933E74 Offset: 0x1933E74 VA: 0x1933E74 Slot: 12
		public override bool IsPlaying()
		{
			if (m_root != null)
				return m_root.IsPlayingChildren();
			return false;
		}

		//// RVA: 0x1933E8C Offset: 0x1933E8C VA: 0x1933E8C
		//private bool IsPlayingAnim() { }

		//[IteratorStateMachineAttribute] // RVA: 0x727CCC Offset: 0x727CCC VA: 0x727CCC
		//// RVA: 0x1933C74 Offset: 0x1933C74 VA: 0x1933C74
		private IEnumerator WaitAnimIn()
		{
			//0x1934394
			while (m_root != null && m_root.IsPlayingChildren())
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727D44 Offset: 0x727D44 VA: 0x727D44
		//// RVA: 0x1933DE8 Offset: 0x1933DE8 VA: 0x1933DE8
		private IEnumerator WaitAnimOut()
		{
			//0x193449C
			while (m_root != null && m_root.IsPlayingChildren())
				yield return null;
			gameObject.SetActive(false);
		}

		// RVA: 0x1933EE4 Offset: 0x1933EE4 VA: 0x1933EE4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_rootRt = GetComponent<RectTransform>();
			m_newIcon = layout.FindViewByExId("sw_sns_pop_wind_btn_anim_swl_sns_icon_new_anim") as AbsoluteLayout;
			if(m_button != null)
			{
				m_button.AddOnClickCallback(() =>
				{
					//0x19342A0
					if (m_root != null && m_root.IsPlayingChildren())
						return;
					if (m_pressCallback != null)
						m_pressCallback(m_roomData.MALFHCHNEFN_Id);
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			m_roomImage.raycastTarget = false;
			Loaded();
			return true;
		}
	}
}
