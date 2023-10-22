using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomSelectItemBase : SwapScrollListContent
	{
		[SerializeField]
		private Vector2 m_size; // 0x20
		[SerializeField]
		private RawImageEx m_itemImage; // 0x28
		[SerializeField]
		private ButtonBase m_button; // 0x2C
		protected AbsoluteLayout m_rootLayout; // 0x30
		private AbsoluteLayout m_newIcon; // 0x34
		private AbsoluteLayout m_exchangeText; // 0x38
		private FJGOKILCBJA shopProduct; // 0x48
		private bool isShopProducts; // 0x4C
		private bool IsLayoutInitialize; // 0x4D

		public Vector2 Size { get { return m_size; } } //0x19DD17C
		public int Id { get; protected set; } // 0x3C
		public LayoutDecoCustomWindow01.SelectItemType Type { get; protected set; } // 0x40
		public bool IsLoadedTexture { get; protected set; } // 0x44
		public bool IsNew { get; protected set; } // 0x45
		public FJGOKILCBJA ShopProduct { get { return shopProduct; } } //0x19DD1C8
		public RawImageEx m_ItemImage { get { return m_itemImage; } } //0x19DCE20
		public bool IsShopProducts { get { return isShopProducts; } set { isShopProducts = value; SetExchangeText(value); } } //0x19DD1D0 0x19DD268

		// RVA: 0x19DC934 Offset: 0x19DC934 VA: 0x19DC934
		public void Update()
		{
			return;
		}

		// RVA: 0x19DC734 Offset: 0x19DC734 VA: 0x19DC734 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_newIcon = layout.FindViewById("swtbl_new_icon_01") as AbsoluteLayout;
			m_newIcon.StartChildrenAnimGoStop(1, 1);
			m_exchangeText = layout.FindViewById("swtbl_deco_num_chok_fnt") as AbsoluteLayout;
			SetExchangeText(false);
			m_itemImage.enabled = false;
			m_button.AddOnClickCallback(() =>
			{
				//0x19DD64C
				OnSelectCallback();
			});
			IsLayoutInitialize = true;
			return true;
		}

		//// RVA: 0x19DD270 Offset: 0x19DD270 VA: 0x19DD270
		private void SetNewIcon(bool isNew)
		{
			IsNew = isNew;
			m_newIcon.StartChildrenAnimGoStop(isNew ? 0 : 1, isNew ? 0 : 1);
		}

		//// RVA: 0x19DD2A0 Offset: 0x19DD2A0 VA: 0x19DD2A0
		public void SetData(int id, LayoutDecoCustomWindow01.SelectItemType type, bool isNew = false, bool isProducts = false, FJGOKILCBJA product = null)
		{
			Id = id;
			Type = type;
			SetNewIcon(isNew);
			isShopProducts = isProducts;
			SetExchangeText(isProducts);
			if (isShopProducts)
				shopProduct = product;
		}

		//// RVA: 0x19DD2E0 Offset: 0x19DD2E0 VA: 0x19DD2E0 Slot: 6
		public virtual void LoadTexture()
		{
			MenuScene.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, Id), (IiconTexture texture) =>
			{
				//0x19DD650
				SetImage(texture);
			});
		}

		//// RVA: 0x19DC93C Offset: 0x19DC93C VA: 0x19DC93C Slot: 7
		public virtual void AnimUpdateAll()
		{
			if(IsLayoutInitialize)
			{
				m_rootLayout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
				m_rootLayout.UpdateAll(new Matrix23(), Color.white);
				m_newIcon.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
				m_newIcon.UpdateAll(new Matrix23(), Color.white);
				m_exchangeText.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
				m_exchangeText.UpdateAll(new Matrix23(), Color.white);
			}
		}

		//// RVA: 0x19DD430 Offset: 0x19DD430 VA: 0x19DD430
		public void SetSerifEnable(bool _enable)
		{
			m_itemImage.gameObject.SetActive(_enable);
		}

		//// RVA: 0x19DD078 Offset: 0x19DD078 VA: 0x19DD078
		public void SetImage(IiconTexture texture)
		{
			m_itemImage.enabled = true;
			texture.Set(m_itemImage);
		}

		//// RVA: 0x19DD484 Offset: 0x19DD484 VA: 0x19DD484
		//public void Copy(LayoutDecoCustomWindow01.SelectItemData item) { }

		//// RVA: 0x19DD4C0 Offset: 0x19DD4C0 VA: 0x19DD4C0
		private void OnSelectCallback()
		{
			ClickButton.Invoke(0, this);
		}

		//// RVA: 0x19DD540 Offset: 0x19DD540 VA: 0x19DD540
		public void SelectEffectOn()
		{
			m_rootLayout.StartChildrenAnimLoop("logo_on", "loen_on");
		}

		//// RVA: 0x19DD5CC Offset: 0x19DD5CC VA: 0x19DD5CC
		public void SelectEffectOff()
		{
			m_rootLayout.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		//// RVA: 0x19DD1D8 Offset: 0x19DD1D8 VA: 0x19DD1D8
		public void SetExchangeText(bool isEnabled)
		{
			m_exchangeText.StartChildrenAnimGoStop(isEnabled ? "01" : "02", isEnabled ? "01" : "02");
		}
	}
}
