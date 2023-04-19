using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using XeSys;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class LayoutPopAddMusicListItem : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx jacketImage; // 0x20
		[SerializeField]
		private RawImageEx seriesLogoImage; // 0x24
		[SerializeField]
		private RawImageEx lineImage; // 0x28
		[SerializeField]
		private Text musicNameText; // 0x2C
		[SerializeField]
		private Text singerNameText; // 0x30
		private AbsoluteLayout musicAttributeFrameLayout; // 0x34
		private AbsoluteLayout unitDanceIconLayout; // 0x38
		private AbsoluteLayout musicDifficultyIconRootLayout; // 0x3C
		private StringBuilder strBuilder = new StringBuilder(64); // 0x40

		// RVA: 0x15DC12C Offset: 0x15DC12C VA: 0x15DC12C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			musicAttributeFrameLayout = layout.FindViewByExId("sw_contents_swtbl_zok") as AbsoluteLayout;
			unitDanceIconLayout = layout.FindViewByExId("sw_contents_swtbl_unit_icon") as AbsoluteLayout;
			musicDifficultyIconRootLayout = layout.FindViewByExId("sw_contents_swtbl_diff_pos") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x15DC2F4 Offset: 0x15DC2F4 VA: 0x15DC2F4
		public void SetJacket(int coverId)
		{
			GameManager.Instance.MusicJacketTextureCache.Load(coverId, (IiconTexture texture) =>
			{
				//0x15DCC50
				texture.Set(jacketImage);
			});
		}

		//// RVA: 0x15DC404 Offset: 0x15DC404 VA: 0x15DC404
		public void SetMusicAttribute(int musicAttr)
		{
			strBuilder.SetFormat("{0:D2}", musicAttr);
			musicAttributeFrameLayout.StartChildrenAnimGoStop(strBuilder.ToString());
		}

		//// RVA: 0x15DC4EC Offset: 0x15DC4EC VA: 0x15DC4EC
		public void SetLogo(int seriesId)
		{
			GameManager.Instance.MenuResidentTextureCache.LoadLogo(seriesId, (IiconTexture texture) =>
			{
				//0x15DCD30
				texture.Set(seriesLogoImage);
			});
		}

		//// RVA: 0x15DC5FC Offset: 0x15DC5FC VA: 0x15DC5FC
		public void SetMusicName(string musicName, int attr)
		{
			musicNameText.text = musicName;
			RichTextUtility.ChangeColor(musicNameText, GameAttributeTextColor.Colors[attr - 1]);
		}

		//// RVA: 0x15DC738 Offset: 0x15DC738 VA: 0x15DC738
		//public void SetSinger(string singer) { }

		//// RVA: 0x15DC774 Offset: 0x15DC774 VA: 0x15DC774
		public void SetMultiUnit(int unitNum)
		{
			strBuilder.SetFormat("{0:D2}", unitNum + 1);
			unitDanceIconLayout.StartChildrenAnimGoStop(strBuilder.ToString());
			strBuilder.SetFormat(MessageManager.Instance.GetMessage("menu", "add_unit_multi_dance_popup_01"), unitNum);
			singerNameText.text = strBuilder.ToString();
		}

		//// RVA: 0x15DC944 Offset: 0x15DC944 VA: 0x15DC944
		public void SetDifficulty(int diffcultyBit, bool is6Line)
		{
			int idx = 0;
			for(int i = 0; i < 5; i++)
			{
				if((diffcultyBit & (1 << i)) != 0)
				{
					if(musicDifficultyIconRootLayout[idx] != null)
					{
						if (musicDifficultyIconRootLayout[idx] is AbsoluteLayout)
						{
							strBuilder.SetFormat("{0:D2}", is6Line ? i + 3 : i + 1);
							(musicDifficultyIconRootLayout[idx] as AbsoluteLayout).StartChildrenAnimGoStop(strBuilder.ToString());
						}
						idx++;
					}
				}
			}
			SetAddDifficultyNum(idx);
		}

		//// RVA: 0x15DCAE8 Offset: 0x15DCAE8 VA: 0x15DCAE8
		private void SetAddDifficultyNum(int num)
		{
			strBuilder.SetFormat("{0:D2}", num);
			musicDifficultyIconRootLayout.StartChildrenAnimGoStop(strBuilder.ToString());
		}
	}
}
