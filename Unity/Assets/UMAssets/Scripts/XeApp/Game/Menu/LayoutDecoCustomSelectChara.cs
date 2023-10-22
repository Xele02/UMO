using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomSelectChara : LayoutDecoCustomSelectItemBase
	{
		public static readonly string AssetName = "root_cstm_deco_item_00_layout_root"; // 0x0
		private int m_caraId; // 0x50
		private int m_motionId; // 0x54
		private int m_caraIdChk; // 0x58
		private int m_motionIdChk; // 0x5C

		// RVA: 0x19DC648 Offset: 0x19DC648 VA: 0x19DC648 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_rootLayout = layout.FindViewById("sw_deco_item_00") as AbsoluteLayout;
			Loaded();
			return IsLoaded();
		}

		// RVA: 0x19DC930 Offset: 0x19DC930 VA: 0x19DC930
		public void Update()
		{
			return;
		}

		// RVA: 0x19DC938 Offset: 0x19DC938 VA: 0x19DC938 Slot: 7
		public override void AnimUpdateAll()
		{
			base.AnimUpdateAll();
		}

		// RVA: 0x19DCB3C Offset: 0x19DCB3C VA: 0x19DCB3C Slot: 6
		public override void LoadTexture()
		{
			NCPPAHHCCAO charaStamp = NCPPAHHCCAO.FKDIMODKKJD().Find((NCPPAHHCCAO item) =>
			{
				//0x19DCEAC
				return item.PPFNGGCBJKC == Id;
			});
			if(charaStamp.IDELKEKDIFD_CharaId == m_caraId)
			{
				if (charaStamp.BEHMEDMNJMC_EmotionId == m_motionId)
					return;
			}
			int m_caraIdChk = charaStamp.IDELKEKDIFD_CharaId;
			int m_motionIdChk = charaStamp.BEHMEDMNJMC_EmotionId;
			m_ItemImage.enabled = false;
			MenuScene.Instance.DecorationItemTextureCache.LoadForDecoCustom(charaStamp.IDELKEKDIFD_CharaId, charaStamp.BEHMEDMNJMC_EmotionId, (IiconTexture image) =>
			{
				//0x19DCF10
				if (charaStamp.IDELKEKDIFD_CharaId != m_caraIdChk)
					return;
				if (charaStamp.BEHMEDMNJMC_EmotionId != m_motionIdChk)
					return;
				m_caraId = charaStamp.IDELKEKDIFD_CharaId;
				m_motionId = charaStamp.BEHMEDMNJMC_EmotionId;
				SetImage(image);
				m_ItemImage.enabled = true;
			});
		}
	}
}
