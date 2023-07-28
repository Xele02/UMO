using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class VeiwOptionHelpCategoryData
	{
		public int uniqueId; // 0x8
		public string categoryName = ""; // 0xC
		public List<VeiwOptionHelpContentData> helps = new List<VeiwOptionHelpContentData>(); // 0x10
		public List<VeiwOptionHelpContentData> wikis = new List<VeiwOptionHelpContentData>(); // 0x14

		//public bool isContainHelp { get; } 0xD301B4
		//public bool isContainWiki { get; } 0xD3023C

		//// RVA: 0xD302C4 Offset: 0xD302C4 VA: 0xD302C4
		public void Init(int uniqueId)
		{
			this.uniqueId = uniqueId;
			CEFDJALCHBL[] list = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LOJAMHAADBF_HelpBrowser.FBJCBCOEBBB;
			int found = -1;
			for(int i = 0; i < list.Length; i++)
			{
				if (list[i].OBGBAOLONDD == uniqueId)
				{
					found = i;
					break;
				}
			}
			helps.Clear();
			wikis.Clear();
			if(found > -1)
			{
				for(int i = 0; i < list[found].EBEMOEPADJB_Helps.Length; i++)
				{
					if(list[found].EBEMOEPADJB_Helps[i].OCPIODNOHKL_PLevel <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
					{
						if(CanShowContents((VeiwOptionHelpContentData.ConditionId)list[found].EBEMOEPADJB_Helps[i].KDBLHOFCPIO_CondId, list[found].EBEMOEPADJB_Helps[i].KLHAFHMFFNK_Value, (VeiwOptionHelpContentData.ConditionOperation) list[found].EBEMOEPADJB_Helps[i].BENBNKNPOAA_CondOp))
						{
							VeiwOptionHelpContentData data = new VeiwOptionHelpContentData();
							data.contentName = list[found].EBEMOEPADJB_Helps[i].OPFGFINHFCE_Name;
							data.contentType = VeiwOptionHelpContentData.ContentType.Help;
							data.helpId = list[found].EBEMOEPADJB_Helps[i].EJBGHLOOLBC_HelpId;
							helps.Add(data);
						}
					}
				}
				for(int i = 0; i < list[found].OJMEIBNMLNP.Length; i++)
				{
					VeiwOptionHelpContentData data = new VeiwOptionHelpContentData();
					data.wikiURL = list[found].OJMEIBNMLNP[i].HJLDBEJOMIO_wikiURL;
					data.contentName = list[found].OJMEIBNMLNP[i].OPFGFINHFCE_Name;
					data.contentType = VeiwOptionHelpContentData.ContentType.Wiki;
					wikis.Add(data);
				}
			}
		}

		//// RVA: 0xD308B4 Offset: 0xD308B4 VA: 0xD308B4
		private bool CanShowContents(VeiwOptionHelpContentData.ConditionId id, int value, VeiwOptionHelpContentData.ConditionOperation op)
		{
			if(id != VeiwOptionHelpContentData.ConditionId.None)
			{
				int a = 0;
				if(id == VeiwOptionHelpContentData.ConditionId.VopClearCount)
				{
					a = KDHGBOOECKC.HHCJCDFCLOB.DEAIKHLFFCL_GetTotalVOp(BOPFPIHGJMD.MLBMHDCCGHI.HJNNKCMLGFL/*0*/);
				}
				else if(id == VeiwOptionHelpContentData.ConditionId.HighScoreRate)
				{
					a = GameManager.Instance.ViewPlayerData.BJGOPOEAAIC;
				}
				if(op != VeiwOptionHelpContentData.ConditionOperation.None)
				{
					if (op != VeiwOptionHelpContentData.ConditionOperation.GreaterEqual)
						op = VeiwOptionHelpContentData.ConditionOperation.None;
					return op == VeiwOptionHelpContentData.ConditionOperation.GreaterEqual && value <= a;
				}
				return false;
			}
			return true;
		}

		//// RVA: 0xD30A1C Offset: 0xD30A1C VA: 0xD30A1C
		//public static List<VeiwOptionHelpCategoryData> CreateList() { }
	}
}
