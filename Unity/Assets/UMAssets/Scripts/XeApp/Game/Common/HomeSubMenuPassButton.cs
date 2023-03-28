using UnityEngine;
using UnityEngine.UI;
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
		//public void Setup(int itemId, int loginCount) { }

		//// RVA: 0xEB23A4 Offset: 0xEB23A4 VA: 0xEB23A4
		//public void SetBadgeActive(HomeSubMenuPassButton.Type type) { }

		//// RVA: 0xEB2764 Offset: 0xEB2764 VA: 0xEB2764
		//public void ChangeType(HomeSubMenuPassButton.Type type) { }

		//[CompilerGeneratedAttribute] // RVA: 0x73D984 Offset: 0x73D984 VA: 0x73D984
		//// RVA: 0xEB29A0 Offset: 0xEB29A0 VA: 0xEB29A0
		//private void <Setup>b__6_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x73D994 Offset: 0x73D994 VA: 0x73D994
		//// RVA: 0xEB2AA4 Offset: 0xEB2AA4 VA: 0xEB2AA4
		//private void <SetBadgeActive>b__7_0(KeyFrameAnime sprite, int idx) { }
	}
}
