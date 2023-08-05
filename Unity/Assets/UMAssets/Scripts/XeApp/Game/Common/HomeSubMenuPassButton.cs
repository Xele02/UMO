using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class HomeSubMenuPassButton : HomeSubMenuButton
	{
		public enum Type
		{
			None = 0,
			Purchase = 1,
			RareUpItem = 2,
			Switch = 3,
		}

		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68AE30 Offset: 0x68AE30 VA: 0x68AE30
		private SpriteAnime badgeAnim; // 0x40
		//[HeaderAttribute] // RVA: 0x68AE94 Offset: 0x68AE94 VA: 0x68AE94
		[SerializeField]
		private Text textMessage; // 0x44
		//[HeaderAttribute] // RVA: 0x68AEE8 Offset: 0x68AEE8 VA: 0x68AEE8
		[SerializeField]
		private RawImageEx imageRareUpItem; // 0x48
		private Type m_type; // 0x4C
		private int m_loginCount; // 0x50
		
		//// RVA: 0xEB2268 Offset: 0xEB2268 VA: 0xEB2268
		public void Setup(int itemId, int loginCount)
		{
			m_loginCount = loginCount;
			imageRareUpItem.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) => {
				//0xEB29A0
				imageRareUpItem.enabled = true;
				texture.Set(imageRareUpItem);
			});
		}

		//// RVA: 0xEB23A4 Offset: 0xEB23A4 VA: 0xEB23A4
		public void SetBadgeActive(Type type)
		{
			SetBadgeActive(type != Type.None);
			ChangeType(type);
			if(type < Type.Switch)
			{
				badgeAnim.Stop(false);
				return;
			}
			if(type != Type.Switch)
				return;
			badgeAnim.Play(0, (KeyFrameAnime sprite, int idx) => {
				//0xEB2AA4
				if(idx == 1)
				{
					ChangeType(Type.RareUpItem);
					return;
				}
				if(idx != 0)
					return;
				ChangeType(Type.Purchase);
			});
		}

		//// RVA: 0xEB2764 Offset: 0xEB2764 VA: 0xEB2764
		public void ChangeType(Type type)
		{
			m_type = type;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(type == Type.RareUpItem)
			{
				textMessage.text = string.Format(bk.GetMessageByLabel("home_pass_button_rare_up_item"), m_loginCount);
				imageRareUpItem.gameObject.SetActive(true);
			}
			else if(type == Type.Purchase || type == Type.Switch)
			{
				textMessage.text = bk.GetMessageByLabel("home_pass_button_purchase");
				imageRareUpItem.gameObject.SetActive(false);
			}
		}
	}
}
