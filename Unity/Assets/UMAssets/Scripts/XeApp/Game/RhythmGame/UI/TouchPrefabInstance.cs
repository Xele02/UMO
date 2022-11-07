using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchPrefabInstance : MonoBehaviour
	{
		[SerializeField]
		private GameObject touchEffectPrefab; // 0xC
		[SerializeField]
		private GameObject skillEffectPrefab; // 0x10
		[SerializeField]
		private GameObject simpleResultEffectPrefab; // 0x14
		[SerializeField]
		private GameObject slideEffectPrefab; // 0x18
		[SerializeField]
		private GameObject slideTipEffectPrefab; // 0x1C
		private EffectBundleController _touchEffect; // 0x20
		private EffectBundleControllerSimple _resultEffectSimple; // 0x24
		private TouchSkillEffect _skillEffect; // 0x28
		private RandomRotate _randomRotate; // 0x2C
		private TouchSlideEffect _slideEffect; // 0x30
		private TouchSlideTipEffect _slideTipEffect; // 0x34
		private int m_fingerId = -1; // 0x38

		public EffectBundleController touchEffect { get { return _touchEffect; } } //0x1564568
		public EffectBundleControllerSimple resultEffectSimple { get { return _resultEffectSimple; } } //0x1564570
		public TouchSkillEffect SkillEffect { get { return _skillEffect; } } //0x1564578
		public RandomRotate RandomRotate { get { return _randomRotate; } } //0x1564580
		public TouchSlideEffect slideEffect { get { return _slideEffect; } } //0x1564588
		//public TouchSlideTipEffect slideTipEffect { get; } 0x1564590
		//public int FingerId { get; set; } 0x1564598 0x15645A0

		//// RVA: 0x15645A8 Offset: 0x15645A8 VA: 0x15645A8
		public void Instantiate()
		{
			GameObject go = Instantiate(touchEffectPrefab);
			_touchEffect = go.GetComponent<EffectBundleController>();
			go.transform.SetParent(transform, false);

			go = Instantiate(simpleResultEffectPrefab);
			_resultEffectSimple = go.GetComponent<EffectBundleControllerSimple>();
			go.transform.SetParent(transform, false);

			go = Instantiate(skillEffectPrefab);
			_skillEffect = go.GetComponent<TouchSkillEffect>();
			go.transform.SetParent(transform, false);

			go = Instantiate(slideEffectPrefab);
			_slideEffect = go.GetComponent<TouchSlideEffect>();
			go.transform.SetParent(transform, false);

			go = Instantiate(slideTipEffectPrefab);
			_slideTipEffect = go.GetComponent<TouchSlideTipEffect>();
			_slideTipEffect.Initialize();
			go.transform.SetParent(transform, false);
		}
	}
}
