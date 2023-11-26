using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutOfferProgress : LayoutUGUIScriptBase
	{
		private const int MAX_VALKYRIE_NUM = 3;
		[SerializeField]
		private Text m_plantoonName; // 0x14
		[SerializeField]
		private Text m_progressTime; // 0x18
		[SerializeField]
		private Text[] ValkyrieName = new Text[3]; // 0x1C
		[SerializeField]
		private RawImageEx[] ValkyrieNameIcon = new RawImageEx[3]; // 0x20
		private AbsoluteLayout m_PopLayout; // 0x24
		private AbsoluteLayout m_typeLayout; // 0x28
		private HEFCLPGPMLK.AAOPGOGGMID m_OfferView; // 0x2C
		private HEFCLPGPMLK m_view; // 0x30
		private LimitTimeWatcher m_timeWatcher = new LimitTimeWatcher(); // 0x34
		private bool[] IsLodingList = new bool[3]; // 0x38

		// RVA: 0x15D4DB0 Offset: 0x15D4DB0 VA: 0x15D4DB0
		private void Start()
		{
			return;
		}

		// RVA: 0x15D4DB4 Offset: 0x15D4DB4 VA: 0x15D4DB4
		private void Update()
		{
			m_timeWatcher.Update();
		}

		// RVA: 0x15D4DE0 Offset: 0x15D4DE0 VA: 0x15D4DE0
		public void SetView(HEFCLPGPMLK.AAOPGOGGMID OfferView)
		{
			m_OfferView = OfferView;
			m_view = new HEFCLPGPMLK();
		}

		// RVA: 0x15D4E58 Offset: 0x15D4E58 VA: 0x15D4E58
		public void PopupSetting()
		{
			int offerId = m_OfferView.PPFNGGCBJKC;
            BOPFPIHGJMD.MLBMHDCCGHI offerType = m_OfferView.FGHGMHPNEMG_Category;
			OCMJNBIFJNM_Offer.JPOHOLBBFGP of = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP _) =>
			{
				//0x15D5C50
				if(_.GBJFNGCDKPM_Type == (int)offerType && _.MLDPDLPHJPM_OfferId == offerId)
				{
					return true;
				}
				return false;
			});
			if(of != null)
			{
				int cnt = 0;
				for(int i = 0; i < IsLodingList.Length; i++)
				{
					IsLodingList[i] = false;
				}
                System.Collections.Generic.List<HEFCLPGPMLK.ANKPCIEKPAH> l = m_view.PMFIOHGEPPD(of.OIOECMEEFKJ_VFp > 0 ? of.OIOECMEEFKJ_VFp : 1, true);
                VfFormSetting(of.MNCEBKHBBEF_VFform);
				l.Sort((HEFCLPGPMLK.ANKPCIEKPAH a, HEFCLPGPMLK.ANKPCIEKPAH b) =>
				{
					//0x15D5BE4
					if(a.PMKFOEIFBLB_PilotName == null)
						return 1;
					if(b.PMKFOEIFBLB_PilotName == null)
						return -1;
					return a.JMHKMDFNAIN.CompareTo(b.JMHKMDFNAIN);
				});
				for(int i = 0; i < l.Count; i++)
				{
					int _index = i;
					if(l[i].LLOBHDMHJIG_Id > 0)
					{
						cnt++;
						IsLodingList[i] = true;
						GameManager.Instance.ValkyrieIconCache.LoadPortraitIcon(l[i].LLOBHDMHJIG_Id, 0, (IiconTexture image) =>
						{
							//0x15D5CC0
							ValkyrieNameIcon[_index].enabled = true;
							IsLodingList[_index] = false;
							image.Set(ValkyrieNameIcon[_index]);
						});
						ValkyrieName[i].text = l[i].PNIEAEHKGMJ_ValkName;
					}
				}
				m_PopLayout.StartChildrenAnimGoStop(cnt.ToString("D2"));
				SetTimeWatcher(of.NCDHKKCCGOD_Edt);
				m_plantoonName.text = m_view.NPMKEEANPBE(of.OIOECMEEFKJ_VFp > 0 ? of.OIOECMEEFKJ_VFp : 1);
			}
        }

		// // RVA: 0x15D5598 Offset: 0x15D5598 VA: 0x15D5598
		private void VfFormSetting(int vfForm)
		{
			if(m_typeLayout != null)
				m_typeLayout.StartChildrenAnimGoStop(string.Format("{0:D2}", vfForm + 1));
		}

		// // RVA: 0x15D5764 Offset: 0x15D5764 VA: 0x15D5764
		private void SetTimeText(long remain)
		{
			int h, m, s;
			OfferSelectScene.GetMiddleTime((int)remain, out h, out m, out s, true);
			m_progressTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
		}

		// RVA: 0x15D588C Offset: 0x15D588C VA: 0x15D588C
		public bool IsImageLoding()
		{
			for(int i = 0; i < IsLodingList.Length; i++)
			{
				if(IsLodingList[i])
					return true;
			}
			return false;
		}

		// // RVA: 0x15D564C Offset: 0x15D564C VA: 0x15D564C
		public void SetTimeWatcher(long remainTime)
		{
			if(remainTime != 0)
			{
				m_timeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0x15D5B48
					SetTimeText(remain);
				};
				m_timeWatcher.onEndCallback = null;
				m_timeWatcher.WatchStart(remainTime, true);
			}
		}

		// RVA: 0x15D5914 Offset: 0x15D5914 VA: 0x15D5914 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_PopLayout = layout.FindViewByExId("root_sel_vfo_hsp_pop_swtbl_s_v_hsp_pop") as AbsoluteLayout;
			m_typeLayout = layout.FindViewByExId("swtbl_s_v_hsp_pop_swtbl_s_v_f_type") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
