using XeSys.Gfx;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class StatusLabelSet : LayoutUGUIScriptBase
	{
		private class ListData<T>
		{
			public ListData(List<T> data)
			{
			}

			public List<T> m_data;
		}

		[Serializable]
		private class TextList : List<Text>
		{
			public TextList(List<Text> data)
			{
			}

		}

		[Serializable]
		private class RawImageList : List<RawImageEx>
		{
			public RawImageList(List<RawImageEx> data)
			{
			}

		}

		[SerializeField]
		private List<StatusLabelSet.TextList> m_valueText;
		[SerializeField]
		private List<StatusLabelSet.RawImageList> m_arrowImage;
	}
}
