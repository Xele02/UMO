using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupRegistrationBirthday : UIBehaviour, IPopupContent
	{
		private class PopupRegistrationBirthdaySetting : PopupSetting
		{
			public override string PrefabPath { get { return ""; } } //0x161CB0C
			public override string BundleName { get { return BUNDLE_NAME; } } //0x161CB68
			public override string AssetName { get { return "PopupRegistrationBirthday"; } } //0x161CBF4
			public override bool IsAssetBundle { get { return true; } } //0x161CC50
			public override bool IsPreload { get { return true; } } //0x161CC58
			public override GameObject Content { get { return m_content; } } //0x161CC60

			// // RVA: 0x161CC68 Offset: 0x161CC68 VA: 0x161CC68
			// public void SetContent(GameObject obj) { }
		}

		public static readonly string BUNDLE_NAME = "ly/078.xab"; // 0x0
		private static PopupRegistrationBirthdaySetting sm_Setting = null; // 0x4
		private static PopupWindowControl sm_window = null; // 0x8
		private static DJBHIFLHJLK errorHandler = null; // 0xC
		[SerializeField] // RVA: 0x66C888 Offset: 0x66C888 VA: 0x66C888
		private GameObject m_YearObj; // 0x10
		[SerializeField] // RVA: 0x66C898 Offset: 0x66C898 VA: 0x66C898
		private GameObject m_MonthObj; // 0x14
		private LayoutPopupRegistrationBirthday m_Layout; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x161B894 Offset: 0x161B894 VA: 0x161B894 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			transform.Find("root_birth_layout_root").GetComponent<RectTransform>().sizeDelta = size;
			transform.Find("root_birth_layout_root").localPosition = Vector3.zero;
			Parent = setting.m_parent;
			m_Layout = GetComponentInChildren<LayoutPopupRegistrationBirthday>(true);
			gameObject.SetActive(true);
		}

		// RVA: 0x161BAD0 Offset: 0x161BAD0 VA: 0x161BAD0
		public void OnDestroy()
		{
			sm_Setting = null;
		}

		// // RVA: 0x161BB60 Offset: 0x161BB60 VA: 0x161BB60
		private void Setup()
		{
			m_Layout.OnClickTermsOfService = OnClickTermsOfService;
			m_Layout.Setup(m_YearObj, m_MonthObj);
		}

		// RVA: 0x161BC38 Offset: 0x161BC38 VA: 0x161BC38 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x161BC40 Offset: 0x161BC40 VA: 0x161BC40 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			Setup();
		}

		// RVA: 0x161BC84 Offset: 0x161BC84 VA: 0x161BC84 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x161BCBC Offset: 0x161BCBC VA: 0x161BCBC Slot: 21
		public bool IsReady()
		{
			return m_Layout.IsLoaded();
		}

		// RVA: 0x161BCE8 Offset: 0x161BCE8 VA: 0x161BCE8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0x161BCEC Offset: 0x161BCEC VA: 0x161BCEC
		private void OnClickTermsOfService()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			sm_window.InputDisable();
			MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.GHDACOGLNLJ_Contract, () =>
			{
				//0x161C598
				sm_window.InputEnable();
			}, () =>
			{
				//0x161C640
				if(errorHandler != null)
					errorHandler();
			});
		}

		// RVA: 0x161BFDC Offset: 0x161BFDC VA: 0x161BFDC
		public static void ShowPopup(Transform parent, PJHHCHAKGKI onRegisterBirth, JFDNPFFOACP onCancel, DJBHIFLHJLK onError, bool isCheckChangeDate)
		{
			if(sm_Setting == null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				sm_Setting = new PopupRegistrationBirthdaySetting();
				sm_Setting.WindowSize = SizeType.Large;
				sm_Setting.TitleText = bk.GetMessageByLabel("popup_denom_regist_birthday_title");
			}
			errorHandler = onError;
			sm_Setting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Register, Type = PopupButton.ButtonType.Positive }
			};
			sm_Setting.SetParent(parent);
			sm_window = PopupWindowManager.Show(sm_Setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x161C728
				int a1 = 0;
				int a2 = 0;
				if(label == PopupButton.ButtonLabel.Register)
				{
					if(isCheckChangeDate)
					{
						if(PGIGNJDPCAH.MNANNMDBHMP(() =>
						{
							//0x161C9DC
							PopupDenomination.ChangeDate(TransitionList.Type.LOGIN_BONUS);
							if(onCancel != null)
								onCancel();
						}, () =>
						{
							//0x161CA74
							PopupDenomination.ChangeDate(TransitionList.Type.TITLE);
							if(onCancel != null)
								onCancel();
						}))
						{
							//LAB_0161c958
							sm_window = null;
							errorHandler = null;
							return;
						}
					}
					if(onRegisterBirth != null)
					{
						sm_Setting.Content.GetComponentInChildren<LayoutPopupRegistrationBirthday>(true).GetBirth(out a1, out a2);
						onRegisterBirth(a1, a2);
					}
				}
				else if(label == PopupButton.ButtonLabel.Cancel && onCancel != null)
				{
					onCancel();
				}
				sm_window = null;
				errorHandler = null;
			}, null, null, null);
		}
	}
}
