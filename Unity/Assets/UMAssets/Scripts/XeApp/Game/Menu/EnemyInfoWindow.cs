using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;
using XeApp.Core;
using System.Text;

namespace XeApp.Game.Menu
{
	public class EnemyInfoWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_name; // 0x14
		[SerializeField]
		private Text[] m_sp; // 0x18
		[SerializeField]
		private Text m_info; // 0x1C
		[SerializeField]
		private RawImageEx m_enemy_image; // 0x20
		private AbsoluteLayout m_windowStyleTable; // 0x24
		private int m_enemy_id; // 0x28
		private bool m_is_tex_loaded; // 0x2C
		private bool m_is_mask_loaded; // 0x2D
		private Coroutine m_load_texture_coroutine; // 0x30
		private Action BeginTextureLoadListener; // 0x34
		private Action EndTextureLoadListner; // 0x38

		// RVA: 0x12742DC Offset: 0x12742DC VA: 0x12742DC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowStyleTable = layout.FindViewByExId("root_pop_enemy_swtbl_sw_pop_enemy") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1274410 Offset: 0x1274410 VA: 0x1274410
		private void OnDestroy()
		{
			if(m_load_texture_coroutine != null)
			{
				this.StopCoroutineWatched(m_load_texture_coroutine);
				m_load_texture_coroutine = null;
			}
		}

		//// RVA: 0x1274440 Offset: 0x1274440 VA: 0x1274440
		private void InitTex()
		{
			m_load_texture_coroutine = GameManager.Instance.StartCoroutineWatched(LoadEnemyTexture(m_enemy_id));
		}

		//// RVA: 0x12745A0 Offset: 0x12745A0 VA: 0x12745A0
		public void SetEnemy(EJKBKMBJMGL_EnemyData data)
		{
			int skillNum = 0;
			if(data.PDHCABLLJPB_CenterSkillId > 0)
			{
				m_sp[0].text = data.PFHJFIHGCKP_CenterName;
				skillNum = 1;
			}
			if(data.LMJFFFOEPLE_LiveSkillId > 0)
			{
				m_sp[1].text = data.NDPPEMCHKHA_SkillName;
				skillNum++;
			}
			m_name.text = data.OPFGFINHFCE_Name;
			m_info.text = data.KLMPFGOCBHC_Desc;
			SetWindowStyle(skillNum);
			m_enemy_id = data.EAHPLCJMPHD_Pic;
			m_is_tex_loaded = false;
			m_is_mask_loaded = false;
			m_enemy_image.enabled = false;
			InitTex();
		}

		//// RVA: 0x1274848 Offset: 0x1274848 VA: 0x1274848
		public bool IsLoadTex()
		{
			return m_is_tex_loaded && m_is_mask_loaded;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6EECE4 Offset: 0x6EECE4 VA: 0x6EECE4
		//// RVA: 0x12744F8 Offset: 0x12744F8 VA: 0x12744F8
		private IEnumerator LoadEnemyTexture(int id)
		{
			string BundleName; // 0x18
			AssetBundleLoadAssetOperation operation; // 0x1C

			//0x12748BC
			if (BeginTextureLoadListener != null)
				BeginTextureLoadListener();
			m_enemy_image.enabled = false;
			StringBuilder str = new StringBuilder(128);
			str.AppendFormat("ct/em/mh/{0:D3}.xab", id);
			BundleName = str.ToString();
			str.Clear();
			str.AppendFormat("{0:D3}", id);
			operation = AssetBundleManager.LoadAssetAsync(BundleName, str.ToString(), typeof(Texture2D));
			yield return operation;
			m_enemy_image.texture = operation.GetAsset<Texture2D>();
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			m_is_tex_loaded = true;

			operation = AssetBundleManager.LoadAssetAsync("ct/em/mh/al.xab", "al_add", typeof(Material));
			yield return operation;
			m_enemy_image.MaterialAdd = operation.GetAsset<Material>();
			AssetBundleManager.UnloadAssetBundle("ct/em/mh/al.xab", false);

			operation = AssetBundleManager.LoadAssetAsync("ct/em/mh/al.xab", "al_mul", typeof(Material));
			yield return operation;
			m_enemy_image.MaterialMul = operation.GetAsset<Material>();
			AssetBundleManager.UnloadAssetBundle("ct/em/mh/al.xab", false);

			operation = AssetBundleManager.LoadAssetAsync("ct/em/mh/al.xab", "al_base", typeof(Texture2D));
			yield return operation;
			m_enemy_image.alphaTexture = operation.GetAsset<Texture2D>();
			AssetBundleManager.UnloadAssetBundle("ct/em/mh/al.xab", false);
			m_is_mask_loaded = true;

			m_enemy_image.enabled = true;
			m_load_texture_coroutine = null;
			if (EndTextureLoadListner != null)
				EndTextureLoadListner();
		}

		//// RVA: 0x127487C Offset: 0x127487C VA: 0x127487C
		public void SetListner(Action beginListener, Action endListener)
		{
			BeginTextureLoadListener = beginListener;
			EndTextureLoadListner = endListener;
		}

		//// RVA: 0x12747A4 Offset: 0x12747A4 VA: 0x12747A4
		private void SetWindowStyle(int skillNum)
		{
			m_windowStyleTable.StartChildrenAnimGoStop((skillNum + 1).ToString("00"));
		}

		//// RVA: 0x1274888 Offset: 0x1274888 VA: 0x1274888
		//private void OnBeginTextureLoad() { }

		//// RVA: 0x127489C Offset: 0x127489C VA: 0x127489C
		//private void OnEndTextureLoad() { }
	}
}
