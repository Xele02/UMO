using System.Text;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Common
{
	public class DivaCosVoicePlayer : VoicePlayerBase
	{
		public enum Sheet
		{
			Sole = 0,
			Duet = 1,
			Unit = 2,
		}

		public enum Category
		{
			GameStart = 0,
			TouchReaction = 1,
			ActiveSkill = 2,
			GameStartMulti = 3,
			Num = 4,
		}

		private static readonly string[] categoryPrefix = new string[4] { "rbreak_m_gstart", "rbreak_m_home", "rbreak_g_askill", "m_gstart_diva" }; // 0x0
		private bool m_enable = true; // 0x20

		//// RVA: 0xE6D7A8 Offset: 0xE6D7A8 VA: 0xE6D7A8
		public static string MakeCueSheetName(Sheet a_sheet, int a_divaId, int a_divaId2)
		{
			StringBuilder str = new StringBuilder(32);
			if(a_sheet == Sheet.Unit)
			{
				str.SetFormat("cs_diva_{0:D3}_unit_diva_{1:D3}", a_divaId, a_divaId2);
			}
			else if(a_sheet == Sheet.Duet)
			{
				str.SetFormat("cs_diva_{0:D3}_duet", a_divaId);
			}
			else
			{
				str.SetFormat("cs_diva_{0:D3}_solo", a_divaId);
			}
			return str.ToString();
		}

		//// RVA: 0xE6D92C Offset: 0xE6D92C VA: 0xE6D92C
		public static string MakeCueName(Category categoryType, int voiceId)
		{
			StringBuilder str = new StringBuilder(32);
			str.AppendFormat("{0}_{1:D3}", categoryPrefix[(int)categoryType], voiceId);
			return str.ToString();
		}

		//// RVA: 0xE6DAC0 Offset: 0xE6DAC0 VA: 0xE6DAC0
		//public static string MakeCueName_GameStart(int a_sub1, int a_sub2) { }

		//// RVA: 0xE6DC68 Offset: 0xE6DC68 VA: 0xE6DC68
		//public static string MakeCueName_GameStartMulti(int a_sub) { }

		//// RVA: 0xE6DDF4 Offset: 0xE6DDF4 VA: 0xE6DDF4
		//public void SetEnable(bool a_enable) { }

		//// RVA: 0xE6DDFC Offset: 0xE6DDFC VA: 0xE6DDFC
		public void RequestChangeCueSheetSole(int a_divaId, UnityAction onChangeCallback)
		{
			RequestChangeCueSheet(MakeCueSheetName(Sheet.Sole, a_divaId, 0), onChangeCallback);
		}

		//// RVA: 0xE6DEA0 Offset: 0xE6DEA0 VA: 0xE6DEA0
		//public void RequestChangeCueSheetDuet(int a_divaId, UnityAction onChangeCallback) { }

		//// RVA: 0xE6DF44 Offset: 0xE6DF44 VA: 0xE6DF44
		//public void RequestChangeCueSheetUnit(int a_divaId, int a_divaId2, UnityAction onChangeCallback) { }

		//// RVA: 0xE6DFEC Offset: 0xE6DFEC VA: 0xE6DFEC
		public void Play(Category categoryType, int voiceId)
		{
			if (!m_enable)
				return;
			PlayCue(MakeCueName(categoryType, voiceId));
		}

		//// RVA: 0xE6E0A0 Offset: 0xE6E0A0 VA: 0xE6E0A0
		//public void Stop() { }
	}
}
