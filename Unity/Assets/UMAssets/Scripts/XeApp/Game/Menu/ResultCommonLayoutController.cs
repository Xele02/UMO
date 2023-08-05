using UnityEngine;

namespace XeApp.Game.Menu
{
	public class ResultCommonLayoutController : MonoBehaviour
	{
		private LayoutResultHeaderTitle layoutTitle; // 0xC
		private LayoutResultOkayButton layoutOkay; // 0x10

		public LayoutResultHeaderTitle LayoutHeaderTitle { get { return layoutTitle; } private set { return; } } //0xCFEAFC 0xCFEB04
		public LayoutResultOkayButton LayoutOkayButton { get { return layoutOkay; } private set { return; } } //0xCFEB08 0xCFEB10

		// RVA: 0xCFEB14 Offset: 0xCFEB14 VA: 0xCFEB14
		private void Awake()
		{
			layoutTitle = transform.Find("Title").GetComponent<LayoutResultHeaderTitle>();
			layoutOkay = transform.Find("Okay").GetComponent<LayoutResultOkayButton>();
		}

		// RVA: 0xCFEC38 Offset: 0xCFEC38 VA: 0xCFEC38
		private void Update()
		{
			return;
		}

		//// RVA: 0xCFEC3C Offset: 0xCFEC3C VA: 0xCFEC3C
		public bool IsReady()
		{
			return layoutTitle.IsLoaded() && layoutOkay.IsLoaded();
		}

		//// RVA: 0xCFEC98 Offset: 0xCFEC98 VA: 0xCFEC98
		public void ChangeViewForScoreResult()
		{
			layoutTitle.gameObject.SetActive(true);
			layoutTitle.ChangeTitle(LayoutResultHeaderTitle.TitleType.LIVE);
			layoutTitle.SetSkipCount(0);
			layoutOkay.gameObject.SetActive(true);
			layoutOkay.InitAnim();
		}

		//// RVA: 0xCFED98 Offset: 0xCFED98 VA: 0xCFED98
		public void ChangeViewForSkipResult(int count)
		{
			layoutTitle.gameObject.SetActive(true);
			layoutTitle.ChangeTitle(LayoutResultHeaderTitle.TitleType.SKIP);
			layoutTitle.SetSkipCount(count);
			layoutOkay.gameObject.SetActive(true);
			layoutOkay.InitAnim();
		}

		//// RVA: 0xCFEE9C Offset: 0xCFEE9C VA: 0xCFEE9C
		//public void ChangeViewForSupportResult() { }

		//// RVA: 0xCFEF9C Offset: 0xCFEF9C VA: 0xCFEF9C
		public void ChangeViewForDivaResult()
		{
			layoutTitle.gameObject.SetActive(true);
			layoutTitle.StartAlreadyAnim();
			layoutOkay.gameObject.SetActive(true);
			layoutOkay.InitAnim();
		}

		//// RVA: 0xCFF074 Offset: 0xCFF074 VA: 0xCFF074
		public void StartEndDivaResultAnim()
		{
			layoutOkay.StartEndAnim();
		}

		//// RVA: 0xCFF0A0 Offset: 0xCFF0A0 VA: 0xCFF0A0
		public void ChangeViewForDropResult()
		{
			layoutTitle.gameObject.SetActive(true);
			layoutTitle.StartAlreadyAnim();
			layoutOkay.gameObject.SetActive(true);
			layoutOkay.InitAnim();
		}

		//// RVA: 0xCFF178 Offset: 0xCFF178 VA: 0xCFF178
		//public void ChangeViewForRaidResult() { }

		//// RVA: 0xCFF1C8 Offset: 0xCFF1C8 VA: 0xCFF1C8
		public void ChangeViewForSimulationResult()
		{
			layoutTitle.gameObject.SetActive(true);
			layoutTitle.StartAlreadyAnim();
			layoutTitle.ChangeTitle(LayoutResultHeaderTitle.TitleType.S_LIVE);
			layoutTitle.SetSkipCount(0);
			layoutOkay.gameObject.SetActive(true);
			layoutOkay.StartBeginAnim(true);
		}
	}
}
