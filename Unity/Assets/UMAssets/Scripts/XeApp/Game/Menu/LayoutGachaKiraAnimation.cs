using XeSys.Gfx;
using UnityEngine;
using System;
using System.Text;
using XeSys;
using XeApp.Game.Common;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutGachaKiraAnimation : LayoutUGUIScriptBase
	{
		private const int KIRA_SE_001 = 1;
		private const int KIRA_SE_002 = 2;
		private const float DelayTime = 3;
		[SerializeField]
		private RawImageEx m_scenePlate; // 0x14
		[SerializeField]
		private RawImageEx m_plateFrame; // 0x18
		[SerializeField]
		private RawImageEx m_divaPict; // 0x1C
		private AbsoluteLayout m_root; // 0x20
		private AbsoluteLayout m_maskAnim; // 0x24
		private SceneCardTextureCache m_sceneCard; // 0x28
		private SceneFrameTextureCache m_sceneFrame; // 0x2C
		private bool m_isLoadedDivaTexture; // 0x30
		private bool m_isLoadedPlateTexture; // 0x31
		private bool m_isLoadedPlateFrameTexture; // 0x32
		private int divaPictId; // 0x34
		private int kirapleatId; // 0x38
		private float AnimDelayTimer; // 0x3C
		private bool m_isKiraAnimEnd; // 0x40

		public bool IsKiraAnimEnd { get { return m_isKiraAnimEnd; } private set { return; } } //0x19B0BD8 0x19B0BDC

		// RVA: 0x19B0BE4 Offset: 0x19B0BE4 VA: 0x19B0BE4
		public void StartDivaVoice()
		{ 
			SoundManager.Instance.voDiva.Play(2);
		}

		// RVA: 0x19B0C3C Offset: 0x19B0C3C VA: 0x19B0C3C
		public bool IsPlayingDivaVoice()
		{
			return SoundManager.Instance.voDiva.isPlaying;
		}

		// RVA: 0x19B0C90 Offset: 0x19B0C90 VA: 0x19B0C90
		public void StartAnimation()
		{
			m_isKiraAnimEnd = false;
			this.StartCoroutineWatched(AnimationFrow());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DCB44 Offset: 0x6DCB44 VA: 0x6DCB44
		// // RVA: 0x19B0CC0 Offset: 0x19B0CC0 VA: 0x19B0CC0
		private IEnumerator AnimationFrow()
		{
			//0x1D4C62C
			SoundManager.Instance.voDiva.Play(1);
			m_root.StartChildrenAnimGoStop("go_in", "se_01");
			while(m_root.IsPlayingChildren())
				yield return null;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_KIRA_001);
			m_root.StartChildrenAnimGoStop("se_01", "se_02");
			while(m_root.IsPlayingChildren())
				yield return null;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SCROLL_000);
			m_root.StartChildrenAnimGoStop("se_02", "st_in");
			while(m_root.IsPlayingChildren())
				yield return null;
			m_root.StartChildrenAnimLoop("logo_act");
			m_maskAnim.StartAllAnimLoop("logo_act");
			AnimDelayTimer = 0;
			bool isWait = true;
			yield return new WaitWhile(() =>
			{
				//0x1D4C534
				AnimDelayTimer += Time.deltaTime;
				isWait = AnimDelayTimer < 3;
				return isWait;
			});
			m_isKiraAnimEnd = true;
		}

		// RVA: 0x19B0D48 Offset: 0x19B0D48 VA: 0x19B0D48
		public void Leave()
		{
			m_isKiraAnimEnd = false;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
			m_maskAnim.StartAllAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x19B0E1C Offset: 0x19B0E1C VA: 0x19B0E1C
		public void Hide()
		{
			m_isKiraAnimEnd = false;
			m_root.StartChildrenAnimGoStop("st_wait");
			m_maskAnim.StartAllAnimGoStop("st_wait");
		}

		// RVA: 0x19B0ED0 Offset: 0x19B0ED0 VA: 0x19B0ED0
		public bool IsPlaying()
		{
			return m_root.IsPlayingChildren();
		}

		// RVA: 0x19B0EFC Offset: 0x19B0EFC VA: 0x19B0EFC
		public void SettingDiva(int _divaId)
		{
			divaPictId = _divaId;
			m_isLoadedDivaTexture = false;
			GameManager.Instance.KiraDivaTextureCache.Load(_divaId, (IiconTexture texture) =>
			{
				//0x19B1698
				if(texture != null)
				{
					texture.Set(m_divaPict);
					m_isLoadedDivaTexture = true;
				}
			});
		}

		// RVA: 0x19B1018 Offset: 0x19B1018 VA: 0x19B1018
		public void SettingKiraPlate(SceneCardTextureCache sceneCard, int _pleateId, int _rank)
		{
			if(sceneCard != null)
			{
				kirapleatId = _pleateId;
				m_isLoadedPlateTexture = false;
				sceneCard.Load(_pleateId, _rank, (IiconTexture texture) =>
				{
					//0x19B1778
					if(texture != null)
					{
						texture.Set(m_scenePlate);
						m_isLoadedPlateTexture = true;
					}
				});
			}
		}

		// RVA: 0x19B10E8 Offset: 0x19B10E8 VA: 0x19B10E8
		public void ChangeDivaVoice(int _divaId, Action changeCueAction)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_gacha_diva_{0:D3}", _divaId);
			SoundManager.Instance.voDiva.RequestChangeCueSheet(str.ToString(), () =>
			{
				//0x1D4C5D8
				if(changeCueAction != null)
					changeCueAction();
			});
		}

		// RVA: 0x19B1284 Offset: 0x19B1284 VA: 0x19B1284
		public void ResetDivaVoice(int _divaId, Action changeCueAction)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("cs_diva_{0:D3}", _divaId);
			SoundManager.Instance.voDiva.RequestChangeCueSheet(str.ToString(), () =>
			{
				//0x1D4C5F4
				if(changeCueAction != null)
					changeCueAction();
			});
		}

		// RVA: 0x19B1420 Offset: 0x19B1420 VA: 0x19B1420
		public void SettingKiraPlateFrame(SceneFrameTextureCache sceneFrame, int attrId, int rank, int evolveId)
		{
			if(sceneFrame != null)
			{
				m_isLoadedPlateFrameTexture = false;
				sceneFrame.Load((GameAttribute.Type)attrId, rank, evolveId, (IiconTexture texture) =>
				{
					//0x19B1858
					if(texture != null)
					{
						texture.Set(m_plateFrame);
						m_isLoadedPlateFrameTexture = true;
					}
				});
			}
		}

		// RVA: 0x19B14F0 Offset: 0x19B14F0 VA: 0x19B14F0
		public bool IsEndLoadedTexture()
		{
			return m_isLoadedPlateTexture && m_isLoadedDivaTexture && m_isLoadedPlateFrameTexture;
		}

		// RVA: 0x19B1520 Offset: 0x19B1520 VA: 0x19B1520 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_root = layout.FindViewByExId("root_gacha_kira_sw_gacha_kira_anim") as AbsoluteLayout;
			m_maskAnim = layout.FindViewByExId("sw_gacha_kira_anim_mask") as AbsoluteLayout;
			Hide();
			Loaded();
			return true;
		}
	}
}
