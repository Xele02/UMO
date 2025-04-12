using System;
using System.Collections;
using System.Text;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaIconTextureCache : IconTextureCache
	{
		public enum IconType
		{
			SSize = 0,
			MSize = 1,
			LSize = 2,
			PS = 3,
			Num = 4,
		}
		public enum GoDivaIconType
		{
			Framed = 0,
			Naked = 1,
		}


		private DivaIconTexture m_loadingDivaIcon; // 0x20
		private DivaIconTexture m_loadingStatusDivaIcon; // 0x24
		private const string DivaSSizeIconPath = "ct/dv/me/01/{0:D2}_{1:D2}.xab";
		private const string DivaMSizeIconPath = "ct/dv/me/02/{0:D2}_{1:D2}.xab";
		private const string DivaLSizeIconPath = "ct/dv/me/03/{0:D2}_{1:D2}.xab";
		private const string DivaPSIconPath = "ct/dv/ps/{0:D2}_{1:D2}.xab";
		public const string DivaStoryIconPath = "ct/dv/me/05/{0:D2}_{1:D2}.xab";
		public const string DivaSmallBustupPath = "ct/dv/me/06/{0:D2}_{1:D2}.xab";
		public const string DivaStandingCostumeIconPath = "ct/dv/me/07/{0:D2}_{1:D2}.xab";
		public const string DivaEventGoDivaIconPath = "ct/dv/me/08/{0:D2}_01.xab";
		public const string DivaEventGoDivaIconTypedPath = "ct/dv/me/08/{0:D2}_{1:D2}.xab";
		private const string DivaSSizeIconInColorPath = "ct/dv/me/01/{0:D2}_{1:D2}_{2:D2}.xab";
		private const string DivaMSizeIconInColorPath = "ct/dv/me/02/{0:D2}_{1:D2}_{2:D2}.xab";
		private const string DivaLSizeIconInColorPath = "ct/dv/me/03/{0:D2}_{1:D2}_{2:D2}.xab";
		private const string DivaPSIconInColorPath = "ct/dv/ps/{0:D2}_{1:D2}_{2:D2}.xab";
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x28
		private static string[][] IconFormatTable = new string[4][] {
			new string[2] { DivaSSizeIconPath, DivaSSizeIconInColorPath },
			new string[2] { DivaMSizeIconPath, DivaMSizeIconInColorPath },
			new string[2] { DivaLSizeIconPath, DivaLSizeIconInColorPath },
			new string[2] { DivaPSIconPath, DivaPSIconInColorPath }
		}; // 0x0

		// // RVA: 0x17E3444 Offset: 0x17E3444 VA: 0x17E3444
		public static string GetIconPath(IconType type, int divaId, int modelId, int colorId)
		{
			if(colorId == 0)
			{
				return string.Format(IconFormatTable[(int)type][0], divaId, modelId);
			}
			else
			{
				return string.Format(IconFormatTable[(int)type][1], divaId, modelId, colorId);
			}
		}

		// // RVA: 0x17E3714 Offset: 0x17E3714 VA: 0x17E3714 Slot: 5
		public override void Terminated()
		{
			if (m_loadingDivaIcon != null)
				m_loadingDivaIcon.isKeep = false;
			if (m_loadingStatusDivaIcon != null)
				m_loadingStatusDivaIcon.isKeep = false;
			Clear();
			m_loadingDivaIcon = null;
			m_loadingStatusDivaIcon = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C5FB8 Offset: 0x6C5FB8 VA: 0x6C5FB8
		// // RVA: 0x17E375C Offset: 0x17E375C VA: 0x17E375C
		public IEnumerator EntryLoadingTexture()
		{
			//0x17E53EC
			if (m_loadingDivaIcon != null)
			{
				m_loadingDivaIcon.isKeep = false;
				m_loadingDivaIcon.Release();
			}
			if(m_loadingStatusDivaIcon != null)
			{
				m_loadingStatusDivaIcon.isKeep = false;
				m_loadingStatusDivaIcon.Release();
			}
			m_loadingDivaIcon = null;
			m_loadingStatusDivaIcon = null;
			Load(0, 1, 0, (IiconTexture texture) =>
			{
				//0x17E5200
				m_loadingDivaIcon = texture as DivaIconTexture;
			});
			LoadStateIcon(0, 1, 0, (IiconTexture texture) =>
			{
				//0x17E52F4
				m_loadingStatusDivaIcon = texture as DivaIconTexture;
			});
			while (m_loadingDivaIcon == null || m_loadingStatusDivaIcon == null)
				yield return null;
			m_loadingDivaIcon.isKeep = true;
			m_loadingStatusDivaIcon.isKeep = true;
		}

		// // RVA: 0x17E3808 Offset: 0x17E3808 VA: 0x17E3808
		public void SetLoadingIcon(RawImageEx image)
		{
			m_loadingDivaIcon.Set(image);
		}

		// // RVA: 0x17E3844 Offset: 0x17E3844 VA: 0x17E3844
		public void SetStatusLoadingIcon(RawImageEx image)
		{
			m_loadingStatusDivaIcon.Set(image);
		}

		// // RVA: 0x17E3880 Offset: 0x17E3880 VA: 0x17E3880 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			DivaIconTexture tex = new DivaIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x17E3908 Offset: 0x17E3908 VA: 0x17E3908
		public void Load(int id, int modelId, int colorId, Action<IiconTexture> callBack)
		{
			Load(GetIconPath(IconType.SSize, id, modelId, colorId), callBack);
		}

		// // RVA: 0x17D255C Offset: 0x17D255C VA: 0x17D255C
		public void LoadStateIcon(int id, int modelId, int colorId, Action<IiconTexture> callBack)
		{
			Load(GetIconPath(IconType.MSize, id, modelId, colorId), callBack);
		}

		// // RVA: 0x17E39C0 Offset: 0x17E39C0 VA: 0x17E39C0
		public void LoadLobbyIcon(int cosId, int colorId, Action<IiconTexture> callBack)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[cosId - 1];
			Load(GetIconPath(IconType.SSize, cos.AHHJLDLAPAN_PrismDivaId, cos.DAJGPBLEEOB_PrismCostumeModelId, colorId), callBack);
		}

		// // RVA: 0x17E061C Offset: 0x17E061C VA: 0x17E061C
		public void LoadPortraitIcon(int id, int modelId, int colorId, Action<IiconTexture> callBack)
		{
			Load(GetIconPath(IconType.LSize, id, modelId, colorId), callBack);
		}

		// // RVA: 0x17E3B88 Offset: 0x17E3B88 VA: 0x17E3B88
		public void LoadStoryIcon(int id, int modelId, Action<IiconTexture> callBack)
		{
			Load(string.Format(DivaStoryIconPath, id, modelId), callBack);
		}

		// // RVA: 0x17E3C4C Offset: 0x17E3C4C VA: 0x17E3C4C
		public void LoadStandingCostumeIcon(int id, int modelId, Action<IiconTexture> callBack)
		{
			Load(string.Format(DivaStandingCostumeIconPath, id, modelId), callBack);
		}

		// // RVA: 0x17E3D10 Offset: 0x17E3D10 VA: 0x17E3D10
		public void LoadTutorialIcon(int charId, Action<IiconTexture> callBack)
		{
			Load(MakeTutorialIconPath(charId), callBack);
		}

		// // RVA: 0x17E3E38 Offset: 0x17E3E38 VA: 0x17E3E38
		public void LoadDivaUpIco(int id, int modelId, int colorId, Action<IiconTexture> callBack)
		{
			Load(GetDivaUpIconPath(id, modelId, colorId), callBack);
		}

		// // RVA: 0x17E3EE4 Offset: 0x17E3EE4 VA: 0x17E3EE4
		public static string GetDivaUpIconPath(int id, int modelId, int colorId)
		{
			return GetIconPath(IconType.PS, id, modelId, colorId);
		}

		// // RVA: 0x17E3F80 Offset: 0x17E3F80 VA: 0x17E3F80
		public void LoadDivaSmallBustupIcon(int id, int modelId, Action<IiconTexture> callBack)
		{
			Load(string.Format(DivaSmallBustupPath, id, modelId), callBack);
		}

		// // RVA: 0x17E4044 Offset: 0x17E4044 VA: 0x17E4044
		public void LoadEventGoDivaIcon(int id, Action<IiconTexture> callBack)
		{
			Load(string.Format(DivaEventGoDivaIconPath, id), callBack);
		}

		// // RVA: 0x17E40EC Offset: 0x17E40EC VA: 0x17E40EC
		public void LoadEventGoDivaIcon(int id, GoDivaIconType type, Action<IiconTexture> callBack)
		{
			Load(string.Format(DivaEventGoDivaIconTypedPath, id, (int)type + 1), callBack);
		}

		// // RVA: 0x17E41B4 Offset: 0x17E41B4 VA: 0x17E41B4
		public static string GetDivaStandingCostumeIconPath(int id, int modelId)
		{
			return string.Format(DivaStandingCostumeIconPath, id, modelId);
		}

		// // RVA: 0x17E3DAC Offset: 0x17E3DAC VA: 0x17E3DAC
		public static string MakeTutorialIconPath(int charId)
		{
			return string.Format("ad/ic/{0:D4}.xab", charId);
		}

		// // RVA: 0x17E425C Offset: 0x17E425C VA: 0x17E425C
		public void TryInstall(DFKGGBMFFGB_PlayerInfo playerData)
		{
			for(int i = 0; i < playerData.NBIGLBMHEDC_Divas.Count; i++)
			{
				if(playerData.NBIGLBMHEDC_Divas[i].FJODMPGPDDD_DivaHave)
				{
					TryInstall(playerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId, playerData.NBIGLBMHEDC_Divas[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 0);
					TryStateDivaIconInstall(playerData.NBIGLBMHEDC_Divas[i].AHHJLDLAPAN_DivaId, playerData.NBIGLBMHEDC_Divas[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 0);
				}
			}
		}

		// // RVA: 0x17E43CC Offset: 0x17E43CC VA: 0x17E43CC
		public void TryInstall(int divaId, int modelId, int colorId)
		{
			m_strBuilder.Set(GetIconPath(IconType.SSize, divaId, modelId, colorId));
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
		}

		// // RVA: 0x17E4504 Offset: 0x17E4504 VA: 0x17E4504
		public void TryStateDivaIconInstall(int divaId, int modelId, int colorId)
		{
			m_strBuilder.Set(GetIconPath(IconType.MSize, divaId, modelId, colorId));
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
		}

		// // RVA: 0x17E463C Offset: 0x17E463C VA: 0x17E463C
		public void TryStateDivaUpIconInstall(int divaId, int modelId, int colorId)
		{
			m_strBuilder.Set(GetIconPath(IconType.PS, divaId, modelId, colorId));
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
		}

		// // RVA: 0x17E4774 Offset: 0x17E4774 VA: 0x17E4774
		// public void TryLoadStoryIconInstall(int divaId, int modelId) { }

		// // RVA: 0x17E48B0 Offset: 0x17E48B0 VA: 0x17E48B0
		// public void TryLoadStandingCostumeIconInstall(int divaId, int modelId) { }

		// // RVA: 0x17E49EC Offset: 0x17E49EC VA: 0x17E49EC
		public void TryLoadDivaSmallBustupIcon(int divaId, int modelId)
		{
			m_strBuilder.SetFormat(DivaSmallBustupPath, divaId, modelId);
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
		}

		// // RVA: 0x17E4B28 Offset: 0x17E4B28 VA: 0x17E4B28
		public void TryLoadEventGoDivaIcon(int divaId)
		{
			m_strBuilder.SetFormat(DivaEventGoDivaIconPath, divaId);
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(m_strBuilder.ToString());
		}
	}
}
