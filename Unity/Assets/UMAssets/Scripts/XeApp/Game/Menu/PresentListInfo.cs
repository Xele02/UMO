using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PresentListInfo
	{
		private IiconTexture ItemIconTexture; // 0x8
		private bool isLoad; // 0xC
		private const int TextLimit = 20;
		public int List_index; // 0x10
		public long s64bit_List_ID; // 0x18
		public int item_ID; // 0x20
		public EKLNMHFCAOI.FKGCBLHOOCL_Category item_TYPE; // 0x24
		public int item_Value; // 0x28
		public bool IsAvailable; // 0x2C
		public string name = ""; // 0x30
		public string PopName = ""; // 0x34
		public string msg = ""; // 0x38
		public string time = ""; // 0x3C
		public string limit = ""; // 0x40

		//public IiconTexture ItemTexture { get; } 0x11653FC

		// RVA: 0x1165404 Offset: 0x1165404 VA: 0x1165404
		public PresentListInfo(int titleIndex, bool isAvailable, GJDFHLBONOL data, bool ReceLis = false)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			List_index = titleIndex;
			s64bit_List_ID = data.MDPJFPHOPCH_Id;
			item_ID = data.JJBGOIMEIPF_ItemFullId;
			item_TYPE = data.NPPNDDMPFJJ_ItemCategory;
			item_Value = data.MBJIFDBEDAC_ItemCount;
			PopName = JKNGJFOBADP.JKOAGEAPJHI(data.JJBGOIMEIPF_ItemFullId, data.MBJIFDBEDAC_ItemCount);
			name = JKNGJFOBADP.JKOAGEAPJHI(data.JJBGOIMEIPF_ItemFullId, data.MBJIFDBEDAC_ItemCount, 20);
			IsAvailable = isAvailable;
			msg = data.LJGOOOMOMMA_Message;
			if(ReceLis)
			{
				DateTime date = Utility.GetLocalDateTime(data.LNDEFMALKAN_ReceivedAt);
				time = string.Format(bk.GetMessageByLabel("pbox_text_11"), new object[5]
				{
					date.Year, string.Format("{0:D2}", date.Month), string.Format("{0:D2}", date.Day), 
					string.Format("{0:D2}", date.Hour), string.Format("{0:D2}", date.Minute)
				});
			}
			else
			{
				DateTime date = Utility.GetLocalDateTime(data.BIOGKIEECGN_CreatedAt);
				time = string.Format(bk.GetMessageByLabel("pbox_text_10"), new object[5]
				{
					date.Year, string.Format("{0:D2}", date.Month), string.Format("{0:D2}", date.Day), 
					string.Format("{0:D2}", date.Hour), string.Format("{0:D2}", date.Minute)
				});
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				limit = JpStringLiterals.StringLiteral_19639;
				if (!data.JLFHLOCONEE())
				{
					long close = data.EGBOHDFBAPB_ClosedAt;
					int[] ints = new int[3] { 86400, 3600, 60 };
					int a1 = 12;
					long a2 = close / ints[0];
					if(a2 == 0)
					{
						for(int i = 1; i < ints.Length; i++)
						{
							a1++;
							a2 = close / ints[i];
							if (a2 != 0)
								break;
						}
					}
					limit = string.Format(bk.GetMessageByLabel("pbox_text_" + a1.ToString("D2")), a2);
				}
			}
			isLoad = false;
		}

		// RVA: 0x116601C Offset: 0x116601C VA: 0x116601C
		public PresentListInfo(int titleIndex, bool isAvailable)
		{
			IsAvailable = true;
		}

		//// RVA: 0x116609C Offset: 0x116609C VA: 0x116609C
		//public bool IsReady() { }

		//// RVA: 0x11660AC Offset: 0x11660AC VA: 0x11660AC
		public IiconTexture GetPresentIconTex()
		{
			if(ItemIconTexture == null && !isLoad)
			{
				GameManager.Instance.ItemTextureCache.Load(item_ID, ItemIconLoadCallback);
				isLoad = true;
			}
			return ItemIconTexture;
		}

		//// RVA: 0x11661E8 Offset: 0x11661E8 VA: 0x11661E8
		public void ItemIconLoadCallback(IiconTexture tex)
		{
			isLoad = false;
			ItemIconTexture = tex;
		}
	}
}
