using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutValkyrieSelect : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_ArrowButtonL;
		[SerializeField]
		private ActionButton m_ArrowButtonR;
		[SerializeField]
		private ActionButton m_SelectButton;
		[SerializeField]
		private ActionButton m_DetachButton;
		[SerializeField]
		private Button m_TransformTouchArea;
		[SerializeField]
		private RawImageEx m_ArrowImageL;
		[SerializeField]
		private RawImageEx m_ArrowImageR;
		[SerializeField]
		private RawImageEx m_PilotImage;
		[SerializeField]
		private RawImageEx m_MainValkyrieIconImage;
		[SerializeField]
		private RawImageEx[] m_SubValkyrieImageList;
		[SerializeField]
		private RawImageEx[] m_SubValkyrieLockImageList;
		[SerializeField]
		private Text m_ValkyrieNameText;
		[SerializeField]
		private Text m_PilotNameText;
		[SerializeField]
		private Text m_AttackText;
		[SerializeField]
		private Text m_HitText;
		[SerializeField]
		private Text m_ChangeAnimNameText;
		[SerializeField]
		private Text m_ChangeAnimLevelText;
		[SerializeField]
		private Text m_ChangeAnimDescText;
		[SerializeField]
		private Text m_AbilityNameText;
		[SerializeField]
		private Text m_AbilityLevelText;
		[SerializeField]
		private Text m_AbilityDescriptionText;
		[SerializeField]
		private RawImageEx sel_fnt;
		[SerializeField]
		private RawImageEx m_atkUpArrow;
		[SerializeField]
		private RawImageEx m_hitUpArrow;
		[SerializeField]
		private Text m_NoTextLayout;
	}
}
