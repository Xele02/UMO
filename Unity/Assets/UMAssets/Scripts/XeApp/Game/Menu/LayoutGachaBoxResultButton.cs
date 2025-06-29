using System.Linq;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxResultButton : ActionButton
	{
		private RawImageEx m_imageItem; // 0x80
		private RawImageEx[] m_imageFrame; // 0x84
		private NumberBase m_numCount; // 0x88
		private AbsoluteLayout m_layoutPickup; // 0x8C
		private TexUVListManager m_uvMan; // 0x90
		private readonly string[] s_formatTable = new string[3]
		{
			"g_b_drop_itemfr_{0:0}_01", "g_b_drop_itemfr_{0:0}_02", "g_b_drop_itemfr_{0:0}_03"
		}; // 0x94

		// RVA: 0x19A8FF8 Offset: 0x19A8FF8 VA: 0x19A8FF8
		public void Setup(HGFPAFPGIKG.JAKMCKNADCE prize)
		{
			m_imageItem.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(prize.GLCLFMGPMAN_ItemId, (IiconTexture image) =>
			{
				//0x19AB588
				m_imageItem.enabled = true;
				image.Set(m_imageItem);
			});
			m_numCount.SetNumber(prize.LJKMKCOAICL, 0);
			for(int i = 0; i < m_imageFrame.Length; i++)
			{
				m_imageFrame[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(string.Format(s_formatTable[i], prize.LIDBKCIMCKE_Rarity)));
			}
			m_layoutPickup.StartChildrenAnimGoStop(!prize.JOPPFEHKNFO_IsPickup ? "02" : "01");
		}

		// RVA: 0x19AA210 Offset: 0x19AA210 VA: 0x19AA210
		public bool InitializeFromLayout(AbsoluteLayout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_layoutPickup = layout.FindViewById("swtbl_g_b_2_icon_medama") as AbsoluteLayout;
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_imageItem = imgs.Where((RawImageEx _) =>
			{
				//0x19AB708
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			NumberBase[] nbrs = GetComponentsInChildren<NumberBase>(true);
			m_numCount = nbrs.Where((NumberBase _) =>
			{
				//0x19AB788
				return _.name == "swnum_item_num01 (AbsoluteLayout)";
			}).First();
			m_imageFrame = new RawImageEx[3];
			for(int i = 0; i < m_imageFrame.Length; i++)
			{
				string label = string.Format("swtexf_g_b_drop_itemfr_{0:0}_{1:00}", 1, i + 1) + " (ImageView)";
				m_imageFrame[i] = imgs.Where((RawImageEx _) =>
				{
					//0x19AB808
					return _.name == label;
				}).First();
			}
			Loaded();
			return true;
		}
	}
}
