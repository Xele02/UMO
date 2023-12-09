using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class VeiwOptionHelpCategoryData
	{
		public int uniqueId; // 0x8
		public string categoryName = ""; // 0xC
		public List<VeiwOptionHelpContentData> helps = new List<VeiwOptionHelpContentData>(); // 0x10
		public List<VeiwOptionHelpContentData> wikis = new List<VeiwOptionHelpContentData>(); // 0x14

		public bool isContainHelp { get { return helps.Count > 0; } } //0xD301B4
		public bool isContainWiki { get { return wikis.Count > 0; } } //0xD3023C

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
				for(int i = 0; i < list[found].EBEMOEPADJB.Length; i++)
				{
					if(list[found].EBEMOEPADJB[i].OCPIODNOHKL <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
					{
						if(CanShowContents((VeiwOptionHelpContentData.ConditionId)list[found].EBEMOEPADJB[i].KDBLHOFCPIO, list[found].EBEMOEPADJB[i].KLHAFHMFFNK, (VeiwOptionHelpContentData.ConditionOperation) list[found].EBEMOEPADJB[i].BENBNKNPOAA))
						{
							VeiwOptionHelpContentData data = new VeiwOptionHelpContentData();
							data.contentName = list[found].EBEMOEPADJB[i].OPFGFINHFCE;
							data.contentType = VeiwOptionHelpContentData.ContentType.Help;
							data.helpId = list[found].EBEMOEPADJB[i].EJBGHLOOLBC;
							helps.Add(data);
						}
					}
				}
				for(int i = 0; i < list[found].OJMEIBNMLNP.Length; i++)
				{
					VeiwOptionHelpContentData data = new VeiwOptionHelpContentData();
					data.wikiURL = list[found].OJMEIBNMLNP[i].HJLDBEJOMIO;
					data.contentName = list[found].OJMEIBNMLNP[i].OPFGFINHFCE;
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
					a = KDHGBOOECKC.HHCJCDFCLOB.DEAIKHLFFCL_GetTotalVOp(BOPFPIHGJMD.MLBMHDCCGHI.HJNNKCMLGFL_0/*0*/);
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
		public static List<VeiwOptionHelpCategoryData> CreateList()
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<VeiwOptionHelpCategoryData> res = new List<VeiwOptionHelpCategoryData>();
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LOJAMHAADBF_HelpBrowser.LOMHJBIJMOD.Length; i++)
			{
				DPGPEALHJOB h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LOJAMHAADBF_HelpBrowser.LOMHJBIJMOD[i];
				if (h.PLALNIIBLOF == 2)
				{
					if(t >= h.PDBPFJJCADD)
					{
						if(h.FDBNFFNFOND >= t)
						{
							VeiwOptionHelpCategoryData data = new VeiwOptionHelpCategoryData();
							data.Init(h.OBGBAOLONDD);
							if (!data.isContainHelp && !data.isContainWiki)
							{
								continue;
							}
							data.categoryName = h.OPFGFINHFCE;
							res.Add(data);
						}
					}
				}
			}
			return res;
		}
	}
}
