using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace XeApp.Game.Common
{
	public class PopPassListAbout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_buttonDetail; // 0x14
		[SerializeField]
		private ActionButton m_buttonPrivacy; // 0x18
		[SerializeField]
		private ActionButton m_buttonContract; // 0x1C
		[SerializeField]
		private Text m_text; // 0x20
		private ContentSizeFitter m_contentSizeFitter; // 0x24
		private LayoutUGUIRuntime m_runtime; // 0x28

		public Transform Parent { get; private set; } // 0x2C

		// RVA: 0xAF76EC Offset: 0xAF76EC VA: 0xAF76EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_runtime = GetComponent<LayoutUGUIRuntime>();
			Loaded();
			return true;
		}

		// RVA: 0xAF7764 Offset: 0xAF7764 VA: 0xAF7764
		public void Initialize(NHPDPKHMFEP.GGNEBJEIFCP plan, Action callback)
		{
			m_text.text = NHPDPKHMFEP.HHCJCDFCLOB.EAHHCPGNCMF(plan);
			GameManager.Instance.StartCoroutineWatched(LateInitialize(callback));
			m_buttonDetail.ClearOnClickCallback();
			m_buttonDetail.AddOnClickCallback(() =>
			{
				//0xAF7CB8
				TodoLogger.LogNotImplemented("m_buttonDetail");
			});
			m_buttonPrivacy.ClearOnClickCallback();
			m_buttonPrivacy.AddOnClickCallback(() =>
			{
				//0xAF7E78
				TodoLogger.LogNotImplemented("m_buttonPrivacy");
			});
			m_buttonContract.ClearOnClickCallback();
			m_buttonContract.AddOnClickCallback(() =>
			{
				//0xAF8090
				TodoLogger.LogNotImplemented("m_buttonContract");
			});
			GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73DA04 Offset: 0x73DA04 VA: 0x73DA04
		// RVA: 0xAF7A98 Offset: 0xAF7A98 VA: 0xAF7A98
		private IEnumerator LateInitialize(Action callback)
		{
			//0xAF8508
			while(!gameObject.activeInHierarchy)
				yield return null;
			yield return null;
			(m_buttonPrivacy.transform as RectTransform).anchoredPosition += new Vector2(0, -m_text.rectTransform.sizeDelta.y + 24);
			(m_buttonContract.transform as RectTransform).anchoredPosition += new Vector2(0, -m_text.rectTransform.sizeDelta.y + 24);
			m_buttonContract.GetComponent<RectTransform>().sizeDelta = new Vector2(m_buttonContract.GetComponent<RectTransform>().sizeDelta.x, Mathf.Abs((m_buttonContract.transform as RectTransform).anchoredPosition.y) + 100);
			if (callback != null)
				callback();
		}

		// RVA: 0xAF7B60 Offset: 0xAF7B60 VA: 0xAF7B60
		public bool IsReady()
		{
			return IsLoaded() && m_runtime.IsReady;
		}

		//// RVA: 0xAF7BB8 Offset: 0xAF7BB8 VA: 0xAF7BB8
		//private void InputDisable() { }

		//// RVA: 0xAF7C34 Offset: 0xAF7C34 VA: 0xAF7C34
		//private void InputEnable() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x73DA8C Offset: 0x73DA8C VA: 0x73DA8C
		//// RVA: 0xAF7E74 Offset: 0xAF7E74 VA: 0xAF7E74
		//private void <Initialize>b__11_3() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x73DAAC Offset: 0x73DAAC VA: 0x73DAAC
		//// RVA: 0xAF808C Offset: 0xAF808C VA: 0xAF808C
		//private void <Initialize>b__11_4() { }
		
		//[CompilerGeneratedAttribute] // RVA: 0x73DACC Offset: 0x73DACC VA: 0x73DACC
		//// RVA: 0xAF82A4 Offset: 0xAF82A4 VA: 0xAF82A4
		//private void <Initialize>b__11_6() { }
	}
}
