using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ViewEnergyItemData
	{
		public int id; // 0x8
		public string name; // 0xC
		public string desc; // 0x10
		public int healValue; // 0x14
		public int haveCount; // 0x18
		public int maxCount; // 0x1C
		public bool isLimit; // 0x20

		//// RVA: 0xD32EB0 Offset: 0xD32EB0 VA: 0xD32EB0
		public void Init(int id)
		{
			JKDKODAPGBJ_EnergyItem.GFGCCICHBHK dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[id - 1];
			EGOLBAPFHHD_Common.FKLHGOGJOHH saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
			this.id = id;
			haveCount = saveItem.BFINGCJHOHI_Cnt;
			maxCount = dbItem.DOOGFEGEKLG_Max;
			healValue = dbItem.JBGEEPFKIGG_HealValue;
			name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem, id);
			desc = EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem, id);
			isLimit = dbItem.HJAFPEBIBOP_IsLimit != 0;
		}

		// RVA: 0xD33174 Offset: 0xD33174 VA: 0xD33174
		public static List<ViewEnergyItemData> CreateList()
		{
			List<ViewEnergyItemData> res = new List<ViewEnergyItemData>();
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA.Count; i++)
			{
				JKDKODAPGBJ_EnergyItem.GFGCCICHBHK dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[i];
				if(dbItem.PPEGAKEIEGM_Enabled == 2)
				{
					ViewEnergyItemData data = new ViewEnergyItemData();
					data.Init(dbItem.PPFNGGCBJKC);
					res.Add(data);
				}
			}
			res.Sort(SortFunc);
			return res;
		}

		//// RVA: 0xD33540 Offset: 0xD33540 VA: 0xD33540
		private static int SortFunc(ViewEnergyItemData left, ViewEnergyItemData right)
		{
			JKDKODAPGBJ_EnergyItem.GFGCCICHBHK dbItem1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[left.id - 1];
			JKDKODAPGBJ_EnergyItem.GFGCCICHBHK dbItem2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[right.id - 1];
			return dbItem1.FPOMEEJFBIG - dbItem2.FPOMEEJFBIG;
		}
	}
}
