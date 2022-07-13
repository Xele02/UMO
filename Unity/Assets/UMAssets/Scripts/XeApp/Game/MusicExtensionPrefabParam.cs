using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game
{
	public class MusicExtensionPrefabParam : ScriptableObject
	{
		[Serializable]
		public class AttachData
		{
			[SerializeField]
			// [TooltipAttribute] // RVA: 0x661C54 Offset: 0x661C54 VA: 0x661C54
			public string path = ""; // 0x8
			[SerializeField]
			// [TooltipAttribute] // RVA: 0x661CC0 Offset: 0x661CC0 VA: 0x661CC0
			public bool isEnableStart = true; // 0xC
		}

		[SerializeField]
		private List<MusicExtensionPrefabParam.AttachData> m_AttachDataList = new List<AttachData>(); // 0xC

		public List<MusicExtensionPrefabParam.AttachData> attachDataList { get { return m_AttachDataList; } } //0xC977B8
	}
}
