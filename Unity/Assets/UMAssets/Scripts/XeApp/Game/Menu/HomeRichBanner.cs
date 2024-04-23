using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.Events;
using System.Text;
using System.Collections;
using XeApp.Core;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class HomeRichBanner : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_image; // 0x14
		[SerializeField]
		private ActionButton m_okButton; // 0x18
		[SerializeField]
		private Material m_materialSource; // 0x1C
		private Layout m_layout; // 0x20
		private Material m_materialInstance; // 0x24
		private Texture m_texture; // 0x28
		private Texture m_maskTexture; // 0x2C
		private AbsoluteLayout m_abs; // 0x30
		private float m_seStartFrame; // 0x34
		//[CompilerGeneratedAttribute] // RVA: 0x6703E4 Offset: 0x6703E4 VA: 0x6703E4
		public UnityAction PushOkListener; // 0x38
		private StringBuilder m_bundleName = new StringBuilder(64); // 0x3C
		private const string TexturePath = "ct/ba/rc/{0:D6}.xab";
		private const string TextureBaseAssetFormat = "{0:D6}_base";
		private const string TextureMaskAssetFormat = "{0:D6}_mask";

		// RVA: 0x96D754 Offset: 0x96D754 VA: 0x96D754 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout;
			m_materialInstance = new Material(m_materialSource);
			m_abs = layout.FindViewByExId("sw_rich_banner_anim_sw_btn_anim") as AbsoluteLayout;
			m_seStartFrame = m_abs.FrameAnimation.SearchLabelFrame("se");
			m_okButton.AddOnClickCallback(OnOk);
			ClearLoadedCallback();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E305C Offset: 0x6E305C VA: 0x6E305C
		// RVA: 0x96D908 Offset: 0x96D908 VA: 0x96D908
		public IEnumerator Open(int pictId)
		{
			string bundleName; // 0x18
			int loadCount; // 0x1C
			bool isPlayedSe; // 0x20
			float seTime; // 0x24
			AssetBundleLoadAssetOperation op; // 0x28

			//0x96DEFC
			m_bundleName.SetFormat("ct/ba/rc/{0:D6}.xab", pictId);
			bundleName = m_bundleName.ToString();
			loadCount = 0;
			isPlayedSe = false;
			seTime = m_seStartFrame * m_abs.FrameAnimation.FrameSec;
			op = AssetBundleManager.LoadAssetAsync(bundleName, string.Format("{0:D6}_base", pictId), typeof(Texture));
			yield return op;
			m_texture = op.GetAsset<Texture>();
			loadCount++;
			op = AssetBundleManager.LoadAssetAsync(bundleName, string.Format("{0:D6}_mask", pictId), typeof(Texture));
			yield return op;
			m_maskTexture = op.GetAsset<Texture>();
			loadCount++;
			for(int i = 0; i < loadCount; i++)
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			m_materialInstance.SetTexture("_MainTex", m_texture);
			m_materialInstance.SetTexture("_MaskTex", m_maskTexture);
			m_image.MaterialMul = m_materialInstance;
			m_image.material = m_materialInstance;
			m_okButton.IsInputOff = true;
			m_layout.StartAllAnimGoStop("go_in", "st_in");
			while(m_abs.IsPlaying())
			{
				if(!isPlayedSe)
				{
					if(seTime <= m_abs.FrameAnimation.AnimCount)
					{
						SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_VFOPS_000);
						isPlayedSe = true;
					}
				}
				yield return null;
			}
			m_layout.StartAllAnimLoop("logo_act");
			m_okButton.IsInputOff = false;
			
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6E30D4 Offset: 0x6E30D4 VA: 0x6E30D4
		// RVA: 0x96D9D0 Offset: 0x96D9D0 VA: 0x96D9D0
		public IEnumerator Close()
		{
			//0x96DCFC
			m_okButton.IsInputOff = true;
			m_layout.StartAllAnimGoStop("go_out", "st_out");
			while(m_abs.IsPlaying())
				yield return null;
			Resources.UnloadAsset(m_texture);
			Resources.UnloadAsset(m_maskTexture);
			m_texture = null;
			m_maskTexture = null;
		}

		// RVA: 0x96DA7C Offset: 0x96DA7C VA: 0x96DA7C
		public void Release()
		{
			if(m_image != null)
			{
				m_image.material = null;
				m_image.MaterialMul = null;
				m_image.MaterialAdd = null;
			}
		}

		// RVA: 0x96DB84 Offset: 0x96DB84 VA: 0x96DB84
		private void OnOk()
		{
			if(PushOkListener != null)
				PushOkListener();
		}

		// RVA: 0x96DB98 Offset: 0x96DB98 VA: 0x96DB98
		public void PerformClick()
		{
			if(m_okButton != null && !m_okButton.IsInputOff)
			{
				m_okButton.PerformClick();
			}
		}
	}
}
